using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DirectShowLib;

namespace shotDetection.detection
{

    public class ShotBoundaryDetector : ISampleGrabberCB
    {

        public ShotBoundaryDetector(int vWidth, int vHeight, int bitsPerPixel)
        {
            Strategy = new RGBDifferenceDetection(vWidth, vHeight, bitsPerPixel);
        }

        public IShotBoundaryDetection Strategy { set; get; }
        // Event fired when a new shot is detected.
        public event EventHandler<SampleEventArgs> NewShot;


        int ISampleGrabberCB.SampleCB(double sTime, IMediaSample sample)
        {
            IntPtr Buffer;
            int hr = sample.GetPointer(out Buffer);
            DsError.ThrowExceptionForHR(hr);

            Process(sTime, Buffer, sample.GetSize());

            Marshal.ReleaseComObject(sample);
            return 0;
        }

        int ISampleGrabberCB.BufferCB(double sTime, IntPtr Buffer, int bufferLen)
        {
            if (Buffer == IntPtr.Zero)
            {
                MessageBox.Show("Test");
            }
            else if (FramesCount < 10)
            {   //skip 10 frames //
                Process(sTime, Buffer, bufferLen);
                FramesCount++;
            }
            else
            {
                FramesCount = 0;
            }
            return 0;
        }

        private void Process(double sampleTime, IntPtr pBuffer, int bufferLength)
        {

            double shotChangeTime = 0;
            bool shotChanged = Strategy.shotChangeDetector(sampleTime, pBuffer, bufferLength,
                                               ref shotChangeTime);
            if (shotChanged)
            {
                BeginInvokeOnNewShotDetected(shotChangeTime);
            }
        }

        protected void BeginInvokeOnNewShotDetected(double sampleTime)
        {
            if (NewShot != null)
            { //if New shot ..
                NewShot.BeginInvoke(this, new SampleEventArgs(sampleTime),
                                     ProcessedShotChange, null);
            }
        }
        private void ProcessedShotChange(IAsyncResult result)
        {
            NewShot.EndInvoke(result);
        }

        public int FramesCount { get; set; }
    }
}