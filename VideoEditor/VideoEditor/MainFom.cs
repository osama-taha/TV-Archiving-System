using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Drawing.Imaging;
using System.Xml;
using Microsoft.Win32;

using DirectShowLib;


namespace VideoEditor
{
    public partial class MainForm : Form, ISampleGrabberCB
    {
        private object syncRoot = new Object();
        /////////////////////////////////////////////////
        static private bool bVlcFileIsPlaying = false;
        private static string _startData = string.Empty;
        private static int iRecordingType = 0;
        private static int fileIndex = 0;
        private static float _fileLength = 0.0f;
        private static float _startSeconds = 0.0f;
        private static float _offsetSeconds = 0.0f;
        private static float _endSeconds = 0.0f;
        private static string _videoFilename = string.Empty;
        private static int _advance = 0;
        private static bool _goodData = true;
        public static int thumbSeconds = 0;
        static private int goThumbPosition = 0;
        /////////////////////////////////////////////////

        private static VideoFilesList<VideoFiles> videoFilesList = new VideoFilesList<VideoFiles>();

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public enum FilterDefinitionState
        {
            FilterAreaChoosen,
            FilterTypeChoosen,
            AreaOverVideoChoosen,
            None
        }

        public enum FilterArea
        {
            Partial,
            Complete,
            None
        }

        public enum FilterType
        {
            Negative,
            Blur,
            Sharpen,
            EdgesDetection,
            Diferences,
            None
        }

        public FilterDefinitionState currentState = FilterDefinitionState.None;
        public FilterArea currentFilterArea = FilterArea.None;
        public FilterType currentFilterType = FilterType.None;

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public List<Frames> images;

        public MediaManager mediaManager = new MediaManager();
        public FiltersManager filtersManager = new FiltersManager();

        public Point filterDown = new Point(50, 50);
        public Point filterUp = new Point(100, 100);

        public int filterMinX;
        public int filterMinY;
        public int filterMaxX;
        public int filterMaxY;

        public enum VideoState
        {
            FastBackwards,
            Playing,
            Paused,
            Stopped,
            FastForwarding
        }

        public enum AudioState
        {
            Enabled,
            Disabled
        }

        public enum EditingState
        {
            SelectingFilter,
            None
        }

        public VideoState currentVideoState = VideoState.Stopped;
        public AudioState currentAudioState = AudioState.Enabled;
        public EditingState currentEditingState = EditingState.None;
        public int currentVolume = -100;

        [Browsable(true)]
        [Category("Mouse")]
        [Description("Occurs when a child control notifies the form that the mouse has been pressed")]
        public event MouseEventHandler ChildMouseDown;

        private const int WM_PARENTNOTIFY = 0x0210;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_RBUTTONDOWN = 0x0204;
        private const int WM_MBUTTONDOWN = 0x0207;
        private const int WM_XBUTTONDOWN = 0x020B;

        private const ushort XBUTTON1 = 0x0001;
        private const ushort XBUTTON2 = 0x0002;

        private ushort LOWORD(int l) { return (ushort)(l); }
        private ushort HIWORD(int l) { return (ushort)(((int)(l) >> 16) & 0xFFFF); }

        //different constant needed by the app
        const int WM_GRAPHNOTIFY = 0x00008001;
        const int WS_CHILD = 0x40000000;
        const int WS_CLIPCHILDREN = 0x02000000;
        const int WS_CLIPSIBLINGS = 0x04000000;
        const int WM_MOVE = 0x00000003;
        const int EC_COMPLETE = 0x00000001;

        private const int WM_MOUSEMOVE = 0x0200;
        //private const int WM_LBUTTONDOWN = 0x201;
        //private const int WM_RBUTTONDOWN = 0x204;
        //private const int WM_MBUTTONDOWN = 0x207;
        private const int WM_MOUSEWHEEL = 0x20A;
        private const int WM_KEYDOWN = 0x100;

        public MainForm()
        {
            InitializeComponent();

            #region "SET DRAG PROPERTIES"

            RegistryKey OurKey = Registry.CurrentUser;
            RegistryKey subOurKey = OurKey.OpenSubKey("Control Panel\\Desktop", true);
            subOurKey.SetValue("DragFullWindows", 1);
            RegistryKey subOurKey2 = OurKey.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\VisualEffects\\DragFullWindows", true);
            subOurKey2.SetValue("DefaultApplied", 0x00000001);
            //SystemParametersInfo((int)Win32.SPIActions.SPI_SETDRAGFULLWINDOWS, 1, null, (int)Win32.SPIWinINIFlags.SPIF_SENDWININICHANGE);

            #endregion "SET DRAG PROPERTIES"

            //this.ChildMouseDown += new MouseEventHandler(MainForm_ChildMouseDown);

            //this.KeyDown += new KeyEventHandler(MainForm_KeyDown);
        }


        enum MsgCodes
        {
            KeyDown = 0x100, KeyUp = 0x101, AltKeyDown = 0x104, AltKeyUp = 0x105
        }     
        MsgCodes[] ExaminedKeyActions = (MsgCodes[])Enum.GetValues(typeof(MsgCodes));      
        protected override bool ProcessKeyPreview(ref Message m)   
        {
            //for debugging only
            MsgCodes MsgCode = (MsgCodes)m.Msg;     
            Keys Key=(Keys)((int)(m.WParam)) | Control.ModifierKeys;     
            if (Array.IndexOf(ExaminedKeyActions, MsgCode) >= 0)      
            {
                Debug.WriteLine(string.Concat(MsgCode, " ", Key));       
            }     
            
            if ((m.Msg == 0x100) || (m.Msg == 0x104))        
            {         
                KeyEventArgs e = new KeyEventArgs(((Keys)((int)(m.WParam))) | Control.ModifierKeys);       
                TrappedKeyDown(e);          
                if (e.Handled)          
                {               
                    Debug.WriteLine("Trapped");             
                    return true;         
                }       
            }        
            return base.ProcessKeyPreview(ref m);  
        }     
        private void TrappedKeyDown(KeyEventArgs e)   
        {
            if (this.mediaManager.currentMedia == null)
            {
                e.Handled = true;
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Space:
                    { BTN_PlayPause_Click(null, null); break; }
                case Keys.P:
                    { BTN_PlayPause_Click(null, null); break; }
                case Keys.S:
                    { BTN_Stop_Click(null, null); break; }
                case Keys.M:
                    { BTN_Mute_Click(null, null); break; }
                case Keys.D1:
                    { StepFrames(1); break; }
                case Keys.D2:
                    { StepFrames(2); break; }
                case Keys.D3:
                    { StepFrames(3); break; }
                case Keys.D4:
                    { StepFrames(4); break; }
                case Keys.D5:
                    { StepFrames(5); break; }
                case Keys.D6:
                    { StepFrames(6); break; }
                case Keys.D7:
                    { StepFrames(7); break; }
                case Keys.D8:
                    { StepFrames(8); break; }
                case Keys.D9:
                    { StepFrames(9); break; }

                //case Keys.H:
                //    { menuControlHalf_Click(null, null); break; }
                //case Keys.T:
                //    { menuControlThreeQ_Click(null, null); break; }
                //case Keys.N:
                //    { menuControlNormal_Click(null, null); break; }
                //case Keys.D:
                //    { menuControlDouble_Click(null, null); break; }

                //case Keys.F:
                //    { ToggleFullScreen(); break; }
                //case Keys.Enter:
                //    { ToggleFullScreen(); break; }
                //case Keys.Escape:
                //    {
                //        if (fullScreen)
                //            ToggleFullScreen();
                //        break;
                //    }

                //case Keys.Left:
                //    { menuRateDecr_Click(null, null); break; }
                //case Keys.Right:
                //    { menuRateIncr_Click(null, null); break; }
                //case Keys.Up:
                //    { menuRateDouble_Click(null, null); break; }
                //case Keys.Down:
                //    { menuRateHalf_Click(null, null); break; }
                //case Keys.Back:
                //    { menuRateNormal_Click(null, null); break; }
            }
            e.Handled = true;
        }   

                                                                                                                                                                                       /// 

        private void MainForm_ChildMouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //    MessageBox.Show("XButton1");

            //else if (e.Button == MouseButtons.XButton2)
            //    MessageBox.Show("XButton1");
        }

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_KEYDOWN)
        //    {
        //        MessageBox.Show("hhh");
        //    }
        //    else if (m.Msg == WM_PARENTNOTIFY)
        //    {
        //        MouseButtons button = MouseButtons.None;

        //        switch (LOWORD(m.WParam.ToInt32()))
        //        {
        //            case WM_LBUTTONDOWN:
        //                button = MouseButtons.Left;
        //                break;
        //            case WM_RBUTTONDOWN:
        //                button = MouseButtons.Right;
        //                break;
        //            case WM_MBUTTONDOWN:
        //                button = MouseButtons.Middle;
        //                break;
        //            case WM_XBUTTONDOWN:
        //                if (HIWORD(m.WParam.ToInt32()) == XBUTTON1)
        //                    button = MouseButtons.XButton1;
        //                else if (HIWORD(m.WParam.ToInt32()) == XBUTTON2)
        //                    button = MouseButtons.XButton2;
        //                break;
        //        }

        //        //if (button != MouseButtons.None)
        //        //    OnChildMouseDown(button, LOWORD(m.LParam.ToInt32()), HIWORD(m.LParam.ToInt32()));
        //    }
        //    if (m.Msg == WM_GRAPHNOTIFY)
        //    {
        //        //if (mediaEvt != null)
        //        //    OnGraphNotify();
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

        //protected void OnChildMouseDown(MouseButtons button, int x, int y)
        //{
        //    if (ChildMouseDown != null)
        //        ChildMouseDown(this, new MouseEventArgs(button, 0, x, y, 0));
        //}

        public void CloseVideo()
        {
            this.timerControls.Stop();
            this.mediaManager.CloseCurrentVideo();
            this.currentVideoState = VideoState.Stopped;
        }

        public void OpenVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.mediaManager.currentMedia.StopPlay += new HotMediaEvent(videoCompleted);
            this.mediaManager.currentMedia.setVolume(this.currentVolume);
            double fps = this.mediaManager.currentMedia.getFramePerSecond();
            double duration = this.mediaManager.currentMedia.getDuration();
            this.timerControls.Stop();
            this.timerControls.Interval = (int)(1000 / (Math.Max(fps, 30)));
            this.timerControls.Start();
            this.trackBarVideo.Maximum = (int)(fps * duration);

        }

        /// <summary> step n-numbers of frames in stream. </summary>
        private void StepFrames(int frames)
        {
            if ((this.mediaManager.currentMedia.frameStep == null) || (this.mediaManager.currentMedia.control == null))
                return;

            this.mediaManager.currentMedia.frameStep.CanStep(frames, null);
            if (this.currentVideoState != VideoState.Paused)
                this.mediaManager.currentMedia.Pause();

            this.currentVideoState = VideoState.Paused;
            this.mediaManager.currentMedia.frameStep.Step((int)frames, null);
        }

        public void PlayVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            if (this.currentAudioState == AudioState.Enabled)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);

            if (this.currentVideoState == VideoState.Stopped)
            {
                this.BTN_PlayPause.BackgroundImage = global::VideoEditor.Properties.Resources.vpause;

                //WS
                if (thumbSeconds < this.mediaManager.currentMedia.getDuration())
                {
                    this.mediaManager.currentMedia.setPosition((double)thumbSeconds);
                }

                this.mediaManager.currentMedia.Start();
                this.currentVideoState = VideoState.Playing;
            }
            else if (this.currentVideoState == VideoState.Playing)
            {
                this.BTN_PlayPause.BackgroundImage = global::VideoEditor.Properties.Resources.vplay;
                this.mediaManager.currentMedia.Pause();
                this.currentVideoState = VideoState.Paused;
            }
            else
            {
                this.BTN_PlayPause.BackgroundImage = global::VideoEditor.Properties.Resources.vpause;
                this.mediaManager.currentMedia.Start();
                this.currentVideoState = VideoState.Playing;
            }
        }

        public void StopVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            this.BTN_PlayPause.BackgroundImage = global::VideoEditor.Properties.Resources.vplay;
            this.mediaManager.currentMedia.Stop();
            this.mediaManager.currentMedia.Rewind();
            this.currentVideoState = VideoState.Stopped;
        }


        private void BTN_PlayPause_Click(object sender, EventArgs e)
        {
            this.PlayVideo();
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            this.StopVideo();
        }

        private void Rewind()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.mediaManager.currentMedia.Rewind();
        }

        private void BTN_FastRewind_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Interval = 1000 / ((int)this.mediaManager.currentMedia.getFramePerSecond() * 2);
            this.timerVideo.Start();
            this.currentVideoState = VideoState.FastBackwards;
        }

        private void BTN_FastForward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Interval = 1000 / ((int)this.mediaManager.currentMedia.getFramePerSecond() * 2);
            this.timerVideo.Start();
            this.currentVideoState = VideoState.FastForwarding;
        }

        private void mediaTimerTick(object sender, EventArgs e)
        {
            if (currentVideoState == VideoState.FastBackwards)
                this.mediaManager.currentMedia.FastBackwards();
            if (currentVideoState == VideoState.FastForwarding)
                this.mediaManager.currentMedia.FastForward();
        }

        private void timerControls_Tick(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia != null)
            {
                double fps = this.mediaManager.currentMedia.getFramePerSecond();
                double position = this.mediaManager.currentMedia.getPosition();
                this.trackBarVideo.Value = (int)(position * fps);
                this.statusLabel.Text = Sec2String(this.mediaManager.currentMedia.getPosition()) + " / " +
                                        Sec2String(this.mediaManager.currentMedia.getDuration());

                if ((this.currentVideoState == VideoState.Playing) && (this.currentVideoState != VideoState.Paused))
                {
                    double thumbPosInFile = position;
                    int pos = 0;
                    pos = Convert.ToInt32(thumbPosInFile);
                    if (pos < 0)
                        pos = 0;
                    this.sliderControl1.videoSlider1.Value = pos;
                }
            }

        }

        public void MuteAudio() 
        {
            this.currentAudioState = AudioState.Disabled;
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(-10000);
        }

        public void UnMuteAudio()
        {
            this.currentAudioState = AudioState.Enabled;
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);
        }

        private void BTN_Mute_Click(object sender, EventArgs e)
        {
            int newVolume = this.currentVolume;
            if (this.currentAudioState == AudioState.Enabled)
            {
                newVolume = -10000;
                this.BTN_Mute.BackgroundImage = global::VideoEditor.Properties.Resources.vmute;
                this.currentAudioState = AudioState.Disabled;
            }
            else if (this.currentAudioState == AudioState.Disabled)
            {
                newVolume = this.currentVolume;
                this.BTN_Mute.BackgroundImage = global::VideoEditor.Properties.Resources.vunmute;
                this.currentAudioState = AudioState.Enabled;
            }
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(newVolume);
        }

        private void trackBarVolume_Changed(object sender, EventArgs e)
        {
            this.currentVolume = (int)(-Math.Pow(10, 4 * ((double)this.trackBarVolume.Value / (double)this.trackBarVolume.Maximum)));
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);
        }


        private void BTN_StepBackward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;
            double newPosition = this.mediaManager.currentMedia.getPosition() - 5;
            this.mediaManager.currentMedia.setPosition(newPosition);
        }

        private void BTN_StepForward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;
            double newPosition = this.mediaManager.currentMedia.getPosition() + 5;
            this.mediaManager.currentMedia.setPosition(newPosition);
        }

        public void videoCompleted(object sender)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            this.mediaManager.currentMedia.Stop();
            this.mediaManager.currentMedia.Rewind();
            this.currentVideoState = VideoState.Stopped;
        }

        //Prevents rectangle from showing on buttons
        //You can also use this to set dropshows on buttons
        private void ResetButtonRegion(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(0, 0, ((Button)sender).Width - 4, ((Button)sender).Height - 4);
            ((Button)sender).Region = new Region(myGraphicsPath);
        }


        private void MediaForm_Resize(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.SizeWindow();

            this.sliderControl1.Width = this.Width - 10;
            this.snapShots1.Width = this.sliderControl1.Width;
            this.sliderControl1.Top = this.snapShots1.Bottom + 4;
            this.sliderControl1.Height = this.statusStrip.Top - this.sliderControl1.Top;


            

            //this.sliderControl1.ClearBars();
            DataTable dt = (DataTable)videoFilesList;
            //DataView dv = new DataView(dt);
            //dv.Sort = "FileDate";
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            object[] param = new object[] { ds };
            this.sliderControl1.LoadBarsFromDataSet(param);
            this.sliderControl1.videoSlider1.Invalidate();

            this.sliderControl1.SetZoom(3);
            thumbSeconds = 0;
            this.sliderControl1.SetSliderHPosition();

            // Bill SerGio: Dispose of DataSet
            ds.Dispose();

        }

        private void trackBarVideo_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int position = (int)((this.trackBarVideo.Maximum * e.X) / this.trackBarVideo.Width);
                if (this.currentVideoState == VideoState.Playing)
                {
                    this.mediaManager.currentMedia.Pause();
                    this.mediaManager.currentMedia.setPosition(position);
                    this.mediaManager.currentMedia.Start();
                }
                if (this.currentVideoState == VideoState.Paused)
                    this.mediaManager.currentMedia.setPosition(position);
            }
        }

        private void trackBarVideo_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int position = (int)((this.trackBarVideo.Maximum * e.X) / this.trackBarVideo.Width);

                if (this.currentVideoState == VideoState.Playing)
                {
                    this.mediaManager.currentMedia.Pause();
                    this.mediaManager.currentMedia.setPosition(position);
                    this.mediaManager.currentMedia.Start();
                }
                if (this.currentVideoState == VideoState.Paused)
                    this.mediaManager.currentMedia.setPosition(position);
            }
        }

        /*
        // Create the filter graph manager.
        CComPtr< IGraphBuilder >  pGraph;
        pGraph.CoCreateInstance( CLSID_FilterGraph );
        // Create the source filter.
        CComPtr< IBaseFilter >    pSource;
        // Get default video device. (See below for more on connecting to a
        //                            capture device.)
        GetDefaultCapDevice(&pSource);
        // Create the Sample Grabber filter. (See below for further
        //                                    clarification on the workings
        //                                    of the Sample Grabber.)
        CComPtr< ISampleGrabber > pGrabber;
        pGrabber.CoCreateInstance( CLSID_SampleGrabber );
        CComQIPtr< IBaseFilter, &IID_IBaseFilter > pGrabberBase( pGrabber );
        // Add the filters to the filter graph.
        pGraph->AddFilter( pSource, L"Source" );
        pGraph->AddFilter( pGrabberBase, L"Grabber" );
        // Connect the filters (See below for more on connecting filters)
        pGraph->Connect( pSourcePin, pGrabPin );
        CComPtr >IPin> pGrabOutPin = GetOutPin( pGrabberBase, 0 );
        pGraph->Render( pGrabOutPin );  // This call connects the renderer
                               // filter to complete the graph
        // Set up graph to grab just one sample.
        pGrabber->SetOneShot( TRUE );
        // Wait to be notified that a sample has been obtained.
        CComQIPtr< IMediaEvent, &IID_IMediaEvent > pEvent( pGraph );
        long EvCode = 0;
        pEvent->WaitForCompletion( INFINITE, &EvCode );
        */

        //unsafe int ISampleGrabberCB.SampleCB(double SampleTime, IMediaSample pSample)
        //{
        //    IntPtr ptr;
        //    pSample.GetPointer(out ptr);
        //    byte* b = (byte*)ptr;
        //    for (int x = 1; x <= videoHeight; x++)
        //    {
        //        for (int y = 0; y < videoStride; y++)
        //        {
        //            *b ^= 0xff;
        //            b++;
        //        }

        //        b = (byte*)(ptr);
        //        b += (x * videoStride);
        //    }
        //    Marshal.ReleaseComObject(pSample);
        //    return 0;
        //} 

        public int BufferCB(double SampleTime, IntPtr pBuffer, int bufferLen)
        {
            MediaInfo mediaInfo = this.mediaManager.currentMedia.mediaInfo;
            this.filtersManager.Process(SampleTime, pBuffer, bufferLen, mediaInfo);
            if (this.currentEditingState == EditingState.SelectingFilter &&
                this.currentState == FilterDefinitionState.FilterTypeChoosen)
            {
                byte[] copyBytes = new byte[bufferLen];
                Marshal.Copy(pBuffer, copyBytes, 0, bufferLen);
                int stride = mediaInfo.MediaStride;
                int stride2 = mediaInfo.MediaStride * 2;
                int videoWidth = mediaInfo.MediaWidth;
                int videoHeight = mediaInfo.MediaHeight;
                int windowX, windowY, windowWidth, windowHeight;
                this.mediaManager.currentMedia.videoWindow.GetWindowPosition(out windowX, out windowY, out windowWidth, out windowHeight);
                int xOffset = (this.PANEL_Video.Width - windowWidth) / 2;
                int yOffset = (this.PANEL_Video.Height - windowHeight) / 2;
                double xRatio = (double)mediaInfo.MediaWidth / windowWidth;
                double yRatio = (double)mediaInfo.MediaHeight / windowHeight;
                this.filterMinX = Math.Max(0, Math.Min(windowWidth - 1, filterDown.X - 1));
                this.filterMinY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterDown.Y - 1));
                this.filterMinX = (int)(this.filterMinX * xRatio);
                this.filterMinY = (int)(this.filterMinY * yRatio);
                this.filterMaxX = Math.Max(0, Math.Min(windowWidth - 1, filterUp.X - 1 - xOffset));
                this.filterMaxY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterUp.Y - 1 + yOffset));
                this.filterMaxX = (int)(this.filterMaxX * xRatio);
                this.filterMaxY = (int)(this.filterMaxY * yRatio);
                unsafe
                {
                    byte* a = (byte*)(void*)pBuffer;
                    byte* b = (byte*)(void*)pBuffer;
                    byte* c = (byte*)(void*)pBuffer;
                    byte* d = (byte*)(void*)pBuffer;
                    int nOffset = stride - videoWidth * 3;
                    int nWidth = videoWidth - 2;
                    int nHeight = videoHeight - 2;
                    int y, x;
                    int filterWidth = Math.Abs(this.filterMaxX - this.filterMinX);
                    int filterWidthSignal = Math.Sign(this.filterMaxX - this.filterMinX);
                    int filterHeight = Math.Abs(this.filterMaxY - this.filterMinY);
                    int filterHeightSignal = Math.Sign(this.filterMaxY - this.filterMinY);
                    a += this.filterMinY * stride + this.filterMinX * 3;
                    b += this.filterMaxY * stride + this.filterMinX * 3;
                    for (x = 0; x < filterWidth; ++x)
                    {
                        a[2] = (byte)255;
                        a[1] = (byte)255;
                        a[0] = (byte)255;
                        b[2] = (byte)255;
                        b[1] = (byte)255;
                        b[0] = (byte)255;
                        a = a + filterWidthSignal * 3;
                        b = b + filterWidthSignal * 3;
                    }
                    c += this.filterMinY * stride + this.filterMinX * 3;
                    d += this.filterMinY * stride + this.filterMaxX * 3;

                    for (y = 0; y < filterHeight; ++y)
                    {
                        c[2] = (byte)255;
                        c[1] = (byte)255;
                        c[0] = (byte)255;
                        d[2] = (byte)255;
                        d[1] = (byte)255;
                        d[0] = (byte)255;
                        c = c + filterHeightSignal * stride;
                        d = d + filterHeightSignal * stride;
                    }
                }
            }
            return 0;
        }

        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            return 0;
        }

        private void PANEL_Video_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.currentFilterArea == FilterArea.Partial)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.filterDown.X = e.X;
                    this.filterDown.Y = e.Y;
                    this.currentEditingState = EditingState.SelectingFilter;
                }
            }
        }


        private void PANEL_Video_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.filterUp.X = e.X;
                this.filterUp.Y = e.Y;
            }
        }

        private void PANEL_Video_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.currentFilterArea == FilterArea.Partial)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.filterUp.X = e.X;
                    this.filterUp.Y = e.Y;
                    this.currentEditingState = EditingState.None;
                }

                this.currentState = FilterDefinitionState.AreaOverVideoChoosen;
                this.EnableFiltering();
            }
        }




        ///////////////////////////////////////////////////////////
        #region "------------- SNAPSHOTS -------------------------"
        //private void PANEL_Buttons_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{


        //}
        private void MainForm_Load(object sender, EventArgs e)
        {
            #region "CREATE SLIDER CONTROL"

            this.sliderControl1.videoSlider1.ValueChanged += new System.EventHandler(this.SlidersValueChanged);
            this.sliderControl1.videoSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);
            this.sliderControl1.videoSlider1.MouseClick += new MouseEventHandler(videoSlider1_MouseClick);
            this.sliderControl1.videoSlider1.MouseDown += new MouseEventHandler(videoSlider1_MouseDown);
            this.sliderControl1.videoSlider1.MouseUp += new MouseEventHandler(videoSlider1_MouseUp);
            //this.sliderControl1.GoToClick += new TimeControl.SliderControl.GoToClickHandler(sliderControl1_GoToClick);
            this.sliderControl1.ValidClick += new TimeControl.SliderControl.ValidClickHandler(sliderControl1_ValidClick);
            this.sliderControl1.AddRemoveClick += new TimeControl.SliderControl.AddRemoveClickHandler(sliderControl1_AddRemoveClick);

           // this.sliderControl1.PANEL_Buttons.RowEnter +=new DataGridViewCellEventHandler(PANEL_Buttons_RowEnter);


            #endregion "CREATE SLIDER CONTROL"

            //foreach(Control c in this.Controls )
            //{

            //        c.MouseMove += new MouseEventHandler(c_MouseMove);
            //        c.MouseUp += new MouseEventHandler(c_MouseUp);  
            //        c.MouseDown += new MouseEventHandler(c_MouseDown); 

            //}
        }


        private void videoSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (this.currentVideoState == VideoState.Playing)
            {
                this.mediaManager.currentMedia.Pause();
            }
        }

        private void videoSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (this.mediaManager.currentMedia == null)
            //    return;

            //goThumbPosition = this.sliderControl1.videoSlider1.Value;
            //if (this.currentVideoState == VideoState.Playing)
            //{
            //    this.mediaManager.currentMedia.Pause();
            //    this.mediaManager.currentMedia.setPosition(goThumbPosition);
            //    this.mediaManager.currentMedia.Start();
            //}
            //if (this.currentVideoState == VideoState.Paused)
            //    this.mediaManager.currentMedia.setPosition(goThumbPosition);
        }
        
        private void videoSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, this.sliderControl1.videoSlider1.MouseDownValue, 0);
            string ss = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            goThumbPosition = this.sliderControl1.videoSlider1.MouseDownValue;
            StopVideo();
            //PlayVideoFiles(goThumbPosition);
            thumbSeconds = goThumbPosition;
        }

        public void SlidersScroll(object sender, ScrollEventArgs e)
        {
            lock (this)
            {
                if (e.NewValue < 0)
                    return;
            }
        }

        public void SlidersValueChanged(object sender, EventArgs e)
        {
            lock (this.syncRoot)
            {
                if ((sender as TimeControl.VideoSlider).Value < 0)
                    return;

                thumbSeconds = (sender as TimeControl.VideoSlider).Value;
                Time tt = new Time((sender as TimeControl.VideoSlider).Value);
            }
        }



        private void sliderControl1_AddRemoveClick(object sender, TimeControl.AddRemoveClickEventArgs e)
        {
            if (e.addremove > 0)
                AddMedia();
            else
            {
                RemoveMedia();
                this.snapShots1.Clear();
            }
        }

        bool CheckExtension(FileInfo f)
        {
            if (f.Extension.StartsWith(".mp"))
                return true;
            if (f.Extension.StartsWith(".wm"))
                return true;
            if (f.Extension.StartsWith(".avi"))
                return true;
            if (f.Extension.StartsWith(".asf"))
                return true;
            if (f.Extension.StartsWith(".mov"))
                return true;
            if (f.Extension.StartsWith(".rm"))
                return true;
            if (f.Extension.StartsWith(".ram"))
                return true;
            if (f.Extension.StartsWith(".m4v"))
                return true;
            return false;
        }

        private void AddMedia()
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            System.IO.FileInfo fi = new System.IO.FileInfo(this.openFileDialog.FileName);
            if((!fi.Exists) || ( !CheckExtension(fi) ))
                return;
            bool bFound = false;
            string sFilePath = string.Empty;
            for (int i = 0; i < videoFilesList.Count; i++)
            {
                sFilePath = videoFilesList[i].FilePath;
                if (fi.FullName == sFilePath)
                {
                    bFound = true;
                    break;
                }
            }
            if (bFound)
                return;

            try
            {
                MediaPlayer newVideo = new MediaPlayer(this.openFileDialog.FileName);

                if (!this.mediaManager.videos.Contains(this.openFileDialog.FileName))
                {
                    double fps = 0;
                    double duration = 0;
                    fps = newVideo.getFramePerSecond();
                    duration = newVideo.getDuration();
                    int i = videoFilesList.Count;
                    //videoFilesList.Add(new VideoFiles(i, fi.Name, fi.FullName, 0, fps, duration));
                    videoFilesList.Add(new VideoFiles(fi.Name, fi.FullName, 0, fps, duration));
                                        
                    DataTable dt = (DataTable)videoFilesList;
                    //DataView dv = new DataView(dt);
                    //dv.Sort = "FileDate";
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    object[] param = new object[] { ds };
                    this.sliderControl1.LoadBarsFromDataSet(param);
                    this.sliderControl1.videoSlider1.Invalidate();

                    this.sliderControl1.SetZoom(3);
                    thumbSeconds = 0;
                    this.sliderControl1.SetSliderHPosition();

                    this.mediaManager.AddVideo(newVideo, this.openFileDialog.FileName);
                    newVideo.LoadSnapShots(); 

                    // Bill SerGio: Dispose of DataSet
                    ds.Dispose();
                }
            }
            catch (COMException comex)
            {
                MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RemoveMedia()
        {
            int iSelected = this.sliderControl1.videoSlider1.BarIndex;

            if(iSelected > -1) 
            {
                string sFilePath = this.sliderControl1.videoSlider1.Bars[iSelected].FilePath;
                MediaPlayer video = this.mediaManager.GetVideo(sFilePath);
                if (video == this.mediaManager.currentMedia)
                {
                    this.StopVideo();
                    this.mediaManager.CloseCurrentVideo();
                }
                this.ReloadInfo();
                this.mediaManager.RemoveVideo(sFilePath);
                
                string sTemp = string.Empty;
                for (int i = 0; i < videoFilesList.Count; i++)
                {
                    sTemp = videoFilesList[i].FilePath;
                    if (sTemp == sFilePath)
                    {
                        videoFilesList.RemoveAt(i);
                        break;
                    }
                }

                try
                {
                    if (videoFilesList.Count > 0)
                    {
                        DataTable dt = (DataTable)videoFilesList;
                        //DataView dv = new DataView(dt);
                        //dv.Sort = "FileDate";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        object[] param = new object[] { ds };
                        this.sliderControl1.LoadBarsFromDataSet(param);
                        this.sliderControl1.videoSlider1.Invalidate();
                        // Bill SerGio: Dispose of DataSet
                        ds.Dispose();
                        this.sliderControl1.SetZoom(3);
                    }
                    else
                    {
                        this.sliderControl1.ClearGraph();
                        this.sliderControl1.SetZoom(1);
                    }

                }
                catch (COMException comex)
                {
                    MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            LoadVideo(0);
        }

        private void LoadVideo(int iBtnID)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            string sFilePath = string.Empty;
            //this.sliderControl1.videoSlider1.SelectBar(newIndex);

            int iSelectedBar = this.sliderControl1.videoSlider1.BarIndex;
            if (iSelectedBar < 0)
                return;

            sFilePath = this.sliderControl1.videoSlider1.Bars[iSelectedBar].FilePath;

            this.StopVideo();
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.ClearVideoWindow();
            if (this.filtersManager.currentFilter != null)
                this.filtersManager.currentFilter = null;
            this.mediaManager.SetCurrentVideo(sFilePath);
            this.OpenVideo();
            this.ReloadInfo();

            this.mediaManager.currentMedia.SetupVideoWindow(this.PANEL_Video);

            StringBuilder sb = new StringBuilder();
            sb.Append("FilePath: ");
            sb.Append(this.mediaManager.currentMedia.mediaInfo.sFilePath);
            sb.Append("\r\n");

            sb.Append("Duration: ");
            sb.Append(this.mediaManager.currentMedia.mediaInfo.duration.ToString());
            sb.Append("\r\n");

            sb.Append("FPS: ");
            sb.Append(this.mediaManager.currentMedia.mediaInfo.fps.ToString());
            sb.Append("\r\n");

            sb.Append("Height: ");
            sb.Append(this.mediaManager.currentMedia.mediaInfo.MediaHeight.ToString());
            sb.Append("\r\n");

            sb.Append("Width: ");
            sb.Append(this.mediaManager.currentMedia.mediaInfo.MediaWidth.ToString());
            sb.Append("\r\n");

            LABEL_Info.Text = sb.ToString();

        }

        #endregion "------------- SNAPSHOTS -------------------------"

        public void ReloadInfo()
        {
            this.snapShots1.Clear();
            int i = 0;
            PictureBox box;
            if (this.mediaManager.currentMedia != null)
            {
                List<Frames> list = this.mediaManager.currentMedia.segmentationImages;
                this.images = list;
                if (this.mediaManager.currentMedia.fileType == MediaPlayer.FileType.Video)
                {
                    this.snapShots1.LoadFrames(list);
                }
            }
        }

        public void pictureClick(object sender, EventArgs e)
        {
            int index = Int16.Parse(((PictureBox)sender).Name);
            this.mediaManager.currentMedia.setPosition((this.images[index]).time);
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        private void LoadFilter(string sFilterName, FilterArea filterArea)
        {
            if (sFilterName == "SomeFilter")
            {
                this.currentState = FilterDefinitionState.FilterTypeChoosen;
                this.currentFilterType = FilterType.Negative;

                //SomeFilter sf = new SomeFilter();
                //this.filtersManager.currentFilter = sf;

                if (filterArea == FilterArea.Partial)
                {
                    //sf.Complete = false;
                }
                else
                {
                    //sf.Complete = true;
                    //sf.Active = true;
                }
            }
        }


        private void completeFilterArea(object sender, EventArgs e)
        {
            this.currentState = FilterDefinitionState.FilterAreaChoosen;
            this.currentFilterArea = FilterArea.Complete;
        }

        private void partialFilter()
        {
            this.currentState = FilterDefinitionState.FilterAreaChoosen;
            this.currentFilterArea = FilterArea.Partial;
        }

        private void clearFilters()
        {
            this.currentState = FilterDefinitionState.None;
            this.currentFilterArea = FilterArea.None;
            this.currentFilterType = FilterType.None;
            this.filtersManager.currentFilter = null;
        }

        public void EnableFiltering()
        {
            if (this.filtersManager.currentFilter != null)
            {
                Filter currentFilter = this.filtersManager.currentFilter;
                currentFilter.Xmin = this.filterMinX;
                currentFilter.Ymin = this.filterMinY;
                currentFilter.Xmax = this.filterMaxX;
                currentFilter.Ymax = this.filterMaxY;
                currentFilter.Active = true;
            }
        }

        public void ResetFiltersForm()
        {
            this.currentState = FilterDefinitionState.None;
        }


        public static string Sec2String(double seconds)
        {
            double mySeconds = seconds;

            int myHours = (int)(mySeconds / 3600); //3600 Seconds in 1 hour 
            mySeconds %= 3600;

            int myMinutes = (int)(mySeconds / 60); //60 Seconds in a minute 
            mySeconds %= 60;

            string mySec = ((int)mySeconds).ToString();
            string myMin = myMinutes.ToString();
            string myHou = myHours.ToString();

            if (myHours < 10) { myHou = myHou.Insert(0, "0"); }
            if (myMinutes < 10) { myMin = myMin.Insert(0, "0"); }
            if (mySeconds < 10) { mySec = mySec.Insert(0, "0"); }

            return myHou + ":" + myMin + ":" + mySec;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.mediaManager.currentMedia != null)
            {
                this.mediaManager.currentMedia.Stop();
                this.mediaManager.currentMedia.Dispose();
                this.mediaManager.currentMedia = null;
                this.currentVideoState = VideoState.Stopped;
            }

            CloseVideo();
            this.timerVideo.Stop();
            this.timerControls.Stop();
            this.snapShots1.Clear();

            System.Threading.Thread t = new System.Threading.Thread(delegate()
            { 
                Environment.Exit(1);
            });
            t.Start();
            t.Join();

            System.Windows.Forms.Application.Exit();
            System.Environment.Exit(0); 

        }


        #region --- PLAY RECORDINGS METHODS ----------------------------------------

        private string SecondsToString(int seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, seconds, 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(float length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(double length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }

        #endregion --- PLAY RECORDINGS METHODS -------------------------------------

        private void sliderControl1_ValidClick(object sender, TimeControl.FireEventArgs e)
        {
            //int i = this.sliderControl1.videoSlider1.BarIndex;
            //MessageBox.Show(i.ToString());
            int newIndex = Convert.ToInt32(e.btnID);
 
            //if (newIndex > -1)
            //{
            //    //if (e.btnID != e.btnPrevID)
            //    LoadVideo(newIndex);
            //}

            if (this.sliderControl1.videoSlider1.Bars.Length < 1)
                return;

            //int i = this.sliderControl1.videoSlider1.BarIndex;

            if ((newIndex > -1) && (newIndex < this.sliderControl1.videoSlider1.Bars.Length))
            {
                //Stops previous video
                this.StopVideo();

                //Clears the assossiation between that video and current control
                if (this.mediaManager.currentMedia != null)
                    this.mediaManager.currentMedia.ClearVideoWindow();

                //Clears filters
                if (this.filtersManager.currentFilter != null)
                    this.filtersManager.currentFilter = null;

                this.sliderControl1.videoSlider1.SelectBar(newIndex);
                //Sets Selected Item as new Video
                //i = this.sliderControl1.videoSlider1.BarIndex;
                string sFile = this.sliderControl1.videoSlider1.Bars[newIndex].FilePath;
                this.mediaManager.SetCurrentVideo(sFile);

                //Opens video
                this.OpenVideo();

                //Reloads TracksForm info
                this.ReloadInfo();

                if (this.mediaManager.currentMedia != null)
                    this.mediaManager.currentMedia.SetupVideoWindow(PANEL_Video);

                LoadVideo(newIndex);

            }
         
        }

    }



    #region "MESSAGE CLASS"

    public class MessageReceivedEventArgs : EventArgs
    {
        private readonly Message _message;
        public MessageReceivedEventArgs(Message message) { _message = message; }
        public Message Message { get { return _message; } }
    }

    public static class MessageEvents
    {
        private static object _lock = new object();
        private static MessageWindow _window;
        private static IntPtr _windowHandle;
        private static SynchronizationContext _context;

        public static event EventHandler<MessageReceivedEventArgs> MessageReceived;

        public static void WatchMessage(int message)
        {
            EnsureInitialized();
            _window.RegisterEventForMessage(message);
        }

        public static IntPtr WindowHandle
        {
            get
            {
                EnsureInitialized();
                return _windowHandle;
            }
        }

        private static void EnsureInitialized()
        {
            lock (_lock)
            {
                if (_window == null)
                {
                    _context = AsyncOperationManager.SynchronizationContext;
                    using (ManualResetEvent mre = new ManualResetEvent(false))
                    {
                        Thread t = new Thread((ThreadStart)delegate
                        {
                            _window = new MessageWindow();
                            _windowHandle = _window.Handle;
                            mre.Set();
                            Application.Run();
                        });
                        t.Name = "MessageEvents message loop";
                        t.IsBackground = true;
                        t.Start();

                        mre.WaitOne();
                    }
                }
            }
        }

        private class MessageWindow : Form
        {
            private ReaderWriterLock _lock = new ReaderWriterLock();
            private Dictionary<int, bool> _messageSet = new Dictionary<int, bool>();

            public void RegisterEventForMessage(int messageID)
            {
                _lock.AcquireWriterLock(Timeout.Infinite);
                _messageSet[messageID] = true;
                _lock.ReleaseWriterLock();
            }

            protected override void WndProc(ref Message m)
            {
                _lock.AcquireReaderLock(Timeout.Infinite);
                bool handleMessage = _messageSet.ContainsKey(m.Msg);
                _lock.ReleaseReaderLock();

                if (handleMessage)
                {
                    MessageEvents._context.Post(delegate(object state)
                    {
                        EventHandler<MessageReceivedEventArgs> handler = MessageEvents.MessageReceived;
                        if (handler != null) handler(null, new MessageReceivedEventArgs((Message)state));
                    }, m);
                }

                base.WndProc(ref m);
            }
        }
    }

    #endregion "MESSAGE CLASS"


}