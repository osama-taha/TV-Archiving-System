using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Diagnostics;
using DirectShowLib;

namespace shotDetection.detection
{
  
    public class DSCapture : ISampleGrabberCB, IDisposable
    {
        /// <summary> graph builder interface. </summary>
        private IFilterGraph2 graphBuilder = null;
        IMediaControl mediaCtrl = null;
        IMediaEvent MediaEvent = null;

        /// <summary> Dimensions of the image, calculated once in constructor. </summary>
        private int vWidth;
        private int vHeight;
        private int nbitsPerPixel;
        public int Count = 0;
        public int Shots = 0;
        public double ShotTime = 0;
        public bool shotChanged = false;
        public ShotBoundaryDetector m_Detector = null;
        // Allow you to "Connect to remote graph" from GraphEdit
        DsROTEntry m_rot = null;


  

        #region API

        [DllImport("Kernel32.dll", EntryPoint="RtlMoveMemory")]
        private static extern void CopyMemory(IntPtr Destination, IntPtr Source, [MarshalAs(UnmanagedType.U4)] uint Length);

        #endregion

        /// <summary> File name to scan</summary>
        public DSCapture(string FileName)
        {
            try
            {
                // Set up the capture graph
                SetupGraph(FileName);
            }
            catch
            {
                Dispose();
                throw;
            }
        }
        /// <summary> release everything. </summary>
        public void Dispose()
        {
            CloseInterfaces();
        }
        // Destructor
        ~DSCapture()
        {
            CloseInterfaces();
        }


        /// <summary> capture the next image </summary>
        public void Start()
        {
            int hr = mediaCtrl.Run();
            DsError.ThrowExceptionForHR( hr );
        }


        public void WaitUntilDone()
        {
            int hr;
            EventCode evCode;
            const int E_Abort = unchecked((int)0x80004004);

            do
            {
                System.Windows.Forms.Application.DoEvents();
                hr = this.MediaEvent.WaitForCompletion( 100, out evCode );
            } while (hr == E_Abort);
            DsError.ThrowExceptionForHR(hr);
        }


        /// <summary> build the capture graph for grabber. </summary>
        private void SetupGraph(string FileName)
        {
            int hr;

            ISampleGrabber sampGrabber = null;
            IBaseFilter	baseGrabFlt = null;
            IBaseFilter capFilter = null;
            IBaseFilter nullrenderer = null;

            // Get the graphbuilder object
            graphBuilder = new FilterGraph() as IFilterGraph2;
            mediaCtrl = graphBuilder as IMediaControl;
            MediaEvent = graphBuilder as IMediaEvent;

            IMediaFilter mediaFilt = graphBuilder as IMediaFilter;

            try
            {
#if DEBUG
                m_rot = new DsROTEntry( graphBuilder );
#endif

                // Add the video source
                hr = graphBuilder.AddSourceFilter(FileName, "Ds.NET FileFilter", out capFilter);
                DsError.ThrowExceptionForHR( hr );

                // Get the SampleGrabber interface
                sampGrabber = new SampleGrabber() as ISampleGrabber;
                baseGrabFlt = sampGrabber as IBaseFilter;

                ConfigureSampleGrabber(sampGrabber);

                // Add the frame grabber to the graph
                hr = graphBuilder.AddFilter( baseGrabFlt, "Ds.NET Grabber" );
                DsError.ThrowExceptionForHR( hr );

                // ---------------------------------
                // Connect the file filter to the sample grabber

                // Hopefully this will be the video pin, we could check by reading it's mediatype
                IPin iPinOut = DsFindPin.ByDirection(capFilter, PinDirection.Output, 0);

                // Get the input pin from the sample grabber
                IPin iPinIn = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Input, 0);

                hr = graphBuilder.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR( hr );

                // Add the null renderer to the graph
                nullrenderer = new NullRenderer() as IBaseFilter;
                hr = graphBuilder.AddFilter( nullrenderer, "Null renderer" );
                DsError.ThrowExceptionForHR( hr );

                // ---------------------------------
                // Connect the sample grabber to the null renderer

                iPinOut = DsFindPin.ByDirection(baseGrabFlt, PinDirection.Output, 0);
                iPinIn = DsFindPin.ByDirection(nullrenderer, PinDirection.Input, 0);
                
                hr = graphBuilder.Connect(iPinOut, iPinIn);
                DsError.ThrowExceptionForHR( hr );

                // Turn off the clock.  This causes the frames to be sent
                // thru the graph as fast as possible
                hr = mediaFilt.SetSyncSource(null);
                DsError.ThrowExceptionForHR( hr );

                // Read and cache the image sizes
                SaveSizeInfo(sampGrabber);


                this.m_Detector = new ShotBoundaryDetector(vWidth, vHeight, nbitsPerPixel);
                this.m_Detector.NewShot += new EventHandler<SampleEventArgs>(m_detector_NewShot);
            }
            finally
            {
                if (capFilter != null)
                {
                    Marshal.ReleaseComObject(capFilter);
                    capFilter = null;
                }
                if (sampGrabber != null)
                {
                    Marshal.ReleaseComObject(sampGrabber);
                    sampGrabber = null;
                }
                if (nullrenderer != null)
                {
                    Marshal.ReleaseComObject(nullrenderer);
                    nullrenderer = null;
                }
            }
        }

        /// <summary> Read and store the properties </summary>
        private void SaveSizeInfo(ISampleGrabber sampGrabber)
        {
            int hr;

            // Get the media type from the SampleGrabber
            AMMediaType media = new AMMediaType();
            hr = sampGrabber.GetConnectedMediaType( media );
            DsError.ThrowExceptionForHR( hr );

            if( (media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero) )
            {
                throw new NotSupportedException( "Unknown Grabber Media Format" );
            }

            // Grab the size info
             // IntPtr mInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(media.formatPtr));
            VideoInfoHeader videoInfoHeader = (VideoInfoHeader)Marshal.PtrToStructure(media.formatPtr, typeof(VideoInfoHeader));
 
            vWidth = videoInfoHeader.BmiHeader.Width;
            vHeight = videoInfoHeader.BmiHeader.Height;
            nbitsPerPixel = videoInfoHeader.BmiHeader.BitCount;
            DsUtils.FreeAMMediaType(media);
            media = null;
        }

        /// <summary> Set the options on the sample grabber </summary>
        private void ConfigureSampleGrabber(ISampleGrabber sampGrabber)
        {
            AMMediaType media;
            int hr;

            // Set the media type to Video/RBG24
            media = new AMMediaType();
            media.majorType	= MediaType.Video;
            media.subType	= MediaSubType.RGB24;
            media.formatType = FormatType.VideoInfo;
            hr = sampGrabber.SetMediaType( media );
            DsError.ThrowExceptionForHR( hr );

            DsUtils.FreeAMMediaType(media);
            media = null;

            // Choose to call BufferCB instead of SampleCB
            hr = sampGrabber.SetCallback( this, 1 );
            DsError.ThrowExceptionForHR( hr );
        }

        /// <summary> Shut down capture </summary>
        private void CloseInterfaces()
        {
            int hr;

            try
            {
                if( mediaCtrl != null )
                {
                    // Stop the graph
                    hr = mediaCtrl.Stop();
                    mediaCtrl = null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

             #if DEBUG
            if (m_rot != null)
            {
                m_rot.Dispose();
            }
             #endif

            if (graphBuilder != null)
            {
                Marshal.ReleaseComObject(graphBuilder);
                graphBuilder = null;
            }
            GC.Collect();
        }

        /// <summary> sample callback, NOT USED. </summary>
        int ISampleGrabberCB.SampleCB( double SampleTime, IMediaSample pSample )
        {
            Marshal.ReleaseComObject(pSample);
            return 0;
        }

        /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
        unsafe int ISampleGrabberCB.BufferCB( double sTime, IntPtr Buffer, int BufferLen )
        {
            ((ISampleGrabberCB) this.m_Detector).BufferCB(sTime, Buffer, BufferLen);

            Count++;

            return 0;
        }

        void m_detector_NewShot( object sender, SampleEventArgs e )
        {
            this.Shots++;
            this.ShotTime = e.sTime;
            this.shotChanged = true;
        }

        internal void Stop()
        {
            int hr = mediaCtrl.Stop();
            DsError.ThrowExceptionForHR(hr);
        }

          
        public void Rewind()
        {
            int hr;

            IMediaPosition imp = graphBuilder as IMediaPosition;
            hr = imp.put_CurrentPosition(0);
        }


 
    }
}
