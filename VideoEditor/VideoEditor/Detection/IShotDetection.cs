using System;

namespace shotDetection.detection
{
    public interface IShotBoundaryDetection
    {
        //An interface for Strategy Design Pattern !
        //we can apply more than one strategy to detect shots 

        bool shotChangeDetector(double sTime, IntPtr Buffer, int bufferLength,
                          ref double ChangeTime);
    }
}