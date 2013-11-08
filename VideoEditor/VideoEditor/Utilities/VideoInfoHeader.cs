using System;
using System.Collections.Generic;
using System.Text;
using DirectShowLib;

namespace VideoEditor.Utilities
{
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public class VideoInfoHeader
    {
        public long AvgTimePerFrame;
        public int BitErrorRate;
        public int BitRate;
        public DirectShowLib.BitmapInfoHeader BmiHeader;
        public DsRect SrcRect;
        public DsRect TargetRect;

        public VideoInfoHeader()
        {
        }
    }
}
