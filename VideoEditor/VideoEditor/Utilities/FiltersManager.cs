using System;
using System.Collections.Generic;
using System.Text;

using DirectShowLib;
using DirectShowLib.DES;
using System.Runtime.InteropServices;



namespace VideoEditor
{
    public class FiltersManager
    {
        public FiltersManager()
        {
            this.Filters = new List<Filter>();
        }

        public void AddFilter(Filter filter)
        {
            this.Filters.Add(filter);
        }

        public void RemoveFilter(Filter filter)
        {
            this.Filters.Remove(filter);
        }

        public void Clear()
        {
            this.Filters.Clear();
        }

        public void Process(double sampleTime, IntPtr pBuffer, int bufferLen, MediaInfo videoInfo)
        {
            byte[] copyBytes = new byte[bufferLen];

            Marshal.Copy(pBuffer, copyBytes, 0, bufferLen);

            if (this.currentFilter != null && this.currentFilter.Active == true)
                this.currentFilter.Process(copyBytes, pBuffer, videoInfo);
        }

        public Filter currentFilter;
        public List<Filter> Filters;
    }



    public class Filter
    {
        public Filter()
        {
            this.Active = false;
            this.Complete = true;
            this.StartTime = 0;
            this.EndTime = 0;
            this.Xmin = 50;
            this.Xmax = 270;
            this.Ymin = 50;
            this.Ymax = 190;
        }

        public virtual void Process(byte[] source, IntPtr destination, MediaInfo videoInfo)
        {
            Console.Out.WriteLine("Some Filter Process.");
        }

        public bool Active;
        public bool Complete;
        public int Xmin;
        public int Xmax;
        public int Ymin;
        public int Ymax;
        public double StartTime;
        public double EndTime;
    }


}


       //public int BufferCB(double SampleTime, IntPtr pBuffer, int bufferLen)
       // {
       //     MediaInfo mediaInfo = this.mediaManager.currentMedia.mediaInfo;
       //     this.filtersManager.Process(SampleTime, pBuffer, bufferLen, mediaInfo);
       //     if (this.currentEditingState == EditingState.SelectingFilter &&
       //         this.currentState == FilterDefinitionState.FilterTypeChoosen)
       //     {
       //         byte[] copyBytes = new byte[bufferLen];
       //         Marshal.Copy(pBuffer, copyBytes, 0, bufferLen);
       //         int stride = mediaInfo.MediaStride;
       //         int stride2 = mediaInfo.MediaStride * 2;
       //         int videoWidth = mediaInfo.MediaWidth;
       //         int videoHeight = mediaInfo.MediaHeight;
       //         int windowX, windowY, windowWidth, windowHeight;
       //         this.mediaManager.currentMedia.videoWindow.GetWindowPosition(out windowX, out windowY, out windowWidth, out windowHeight);
       //         int xOffset = (this.PANEL_Video.Width - windowWidth) / 2;
       //         int yOffset = (this.PANEL_Video.Height - windowHeight) / 2;
       //         double xRatio = (double)mediaInfo.MediaWidth / windowWidth;
       //         double yRatio = (double)mediaInfo.MediaHeight / windowHeight;
       //         this.filterMinX = Math.Max(0, Math.Min(windowWidth - 1, filterDown.X - 1));
       //         this.filterMinY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterDown.Y - 1));
       //         this.filterMinX = (int)(this.filterMinX * xRatio);
       //         this.filterMinY = (int)(this.filterMinY * yRatio);
       //         this.filterMaxX = Math.Max(0, Math.Min(windowWidth - 1, filterUp.X - 1 - xOffset));
       //         this.filterMaxY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterUp.Y - 1 + yOffset));
       //         this.filterMaxX = (int)(this.filterMaxX * xRatio);
       //         this.filterMaxY = (int)(this.filterMaxY * yRatio);
       //         unsafe
       //         {
       //             byte* a = (byte*)(void*)pBuffer;
       //             byte* b = (byte*)(void*)pBuffer;
       //             byte* c = (byte*)(void*)pBuffer;
       //             byte* d = (byte*)(void*)pBuffer;
       //             int nOffset = stride - videoWidth * 3;
       //             int nWidth = videoWidth - 2;
       //             int nHeight = videoHeight - 2;
       //             int y, x;
       //             int filterWidth = Math.Abs(this.filterMaxX - this.filterMinX);
       //             int filterWidthSignal = Math.Sign(this.filterMaxX - this.filterMinX);
       //             int filterHeight = Math.Abs(this.filterMaxY - this.filterMinY);
       //             int filterHeightSignal = Math.Sign(this.filterMaxY - this.filterMinY);
       //             a += this.filterMinY * stride + this.filterMinX * 3;
       //             b += this.filterMaxY * stride + this.filterMinX * 3;
       //             for (x = 0; x < filterWidth; ++x)
       //             {
       //                 a[2] = (byte)255;
       //                 a[1] = (byte)255;
       //                 a[0] = (byte)255;
       //                 b[2] = (byte)255;
       //                 b[1] = (byte)255;
       //                 b[0] = (byte)255;
       //                 a = a + filterWidthSignal * 3;
       //                 b = b + filterWidthSignal * 3;
       //             }
       //             c += this.filterMinY * stride + this.filterMinX * 3;
       //             d += this.filterMinY * stride + this.filterMaxX * 3;

       //             for (y = 0; y < filterHeight; ++y)
       //             {
       //                 c[2] = (byte)255;
       //                 c[1] = (byte)255;
       //                 c[0] = (byte)255;
       //                 d[2] = (byte)255;
       //                 d[1] = (byte)255;
       //                 d[0] = (byte)255;
       //                 c = c + filterHeightSignal * stride;
       //                 d = d + filterHeightSignal * stride;
       //             }
       //         }
       //     }
       //     return 0;
       // }
