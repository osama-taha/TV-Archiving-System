using System;
using System.Diagnostics;

namespace shotDetection.detection
{

   // By Comparing the average difference between 
   // RGB bytes values in each frame. 

   public class RGBDifferenceDetection : IShotBoundaryDetection
   {

       // RGB difference threshold which indicates a shot change
      private const double RGBDifferenceTh = 21;
      private const double RGBLevel = 90;
     
       // min and max RGB Difference thresholds
      private const double Min = 5;
      private const double Max = 45;

      private const double ChangeInRGBLevelRatio = .395;
      public const int nSamples = 3000;
      private int[] Locations;

       //will have the previous measurments  
      private byte[] pSamples;
      private int pAvgDifferences;
      private int pAvgDifferencesChange;
      private double pSampleTime;
      private int pAvgRGB;

       // video Width , Height,and number of bits per pixel.
      public RGBDifferenceDetection(int vWidth, int vHeight, int nbits)
      {
         Random random = new Random();
        
          int vframeSize = vWidth * vHeight * (nbits / 8);
   
          // if dat size > 3000 , samples = 3000 else = vframeSize;
         int samples = Math.Min(nSamples, vframeSize);

         Locations = new int[samples];
         pSamples = new byte[samples];

         for (int j = 0; j < Locations.Length; j++)
         {
            Locations[j] = random.Next(vframeSize);
         }
      }

      public unsafe bool shotChangeDetector(double sTime, IntPtr Buffer, int bufferLength, ref double ChangeTime)
  
      {
         bool shotChanged = false;

         Byte* buff = (Byte*) Buffer;
         int lastLocation = 0, sumDifferences = 0,sumRGB = 0;

         for (int i = 0; i < Locations.Length; i++)
         {
            buff += Locations[i] - lastLocation;
            sumDifferences = sumDifferences + (*buff ^ pSamples[i]);
            sumRGB += *buff;

            lastLocation = Locations[i];
            pSamples[i] = *buff;
         }

         int avgRGB = sumRGB / Locations.Length;
         int avgDifferences = sumDifferences / Locations.Length;
         int avgDiffChange = avgDifferences - pAvgDifferences;

         if (isNewShot(avgDiffChange))
         {
             if (sTime > 60)
             {
                 int min = (int)(sTime)/60;
                 double second = (sTime)%60;
                 Debug.WriteLine("New shot Time: \t" + min + ":" + second );    
             }

             else
             Debug.WriteLine("New shot Time: \t" + sTime);  
            

            shotChanged = true;
            ChangeTime = pSampleTime;
         }
          //set the current measurments to be previous.
             pAvgRGB = avgRGB;
             pAvgDifferencesChange = avgDiffChange;
             pAvgDifferences = avgDifferences;
             pSampleTime = sTime;

         return shotChanged;
      }

      private bool isNewShot(int avgDiffChange)
      {

          //find the variance of the previous Rgb Level
         double Variance = pAvgRGB - RGBLevel;
         double pDiffThr = (Variance * ChangeInRGBLevelRatio) +
                                    RGBDifferenceTh;
 
         pDiffThr = (int)Math.Max(Min, Math.Min(Max, pDiffThr));

         if (pAvgDifferencesChange > pDiffThr && avgDiffChange < (-pAvgDifferencesChange * .5))
         {
            return true;
         }

         return false;
      }

   
   }
}