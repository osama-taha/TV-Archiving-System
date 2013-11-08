using System;

namespace shotDetection.detection
{
    // Holds shot-change information.

    public class SampleEventArgs : EventArgs
    {
        public SampleEventArgs(double sTime)
        {
            this.sTime = sTime;
        }

        public double sTime { set; get; }
    }
}