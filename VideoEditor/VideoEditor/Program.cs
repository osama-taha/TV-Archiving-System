using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CitiesCMS;
using ShotDetection;
using Telerik.WinControls.UI;
using shotDetection;

namespace VideoEditor
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RadRibbonForm1());
        }
    }
}
