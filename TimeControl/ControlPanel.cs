using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Text.RegularExpressions;

namespace TimeControl
{
    public partial class ControlPanel : UserControl
    {
        public ControlPanel()
        {
            InitializeComponent();
        }


        private void ControlPanel_Load(object sender, EventArgs e)
        {

        }

        private void ControlPanel_Resize(object sender, EventArgs e)
        {
            this.LABEL_1.Left = 4;
            this.LABEL_1.Top = 5;

        }

        private void LABEL_1_TextChanged(object sender, EventArgs e)
        {

        }

        //private void skinButton1_Click(object sender, EventArgs e)
        //{
        //    ((SliderControl)this.Parent).ClickButton(this, e);
        //}

        //public static Array MakeArray(Form frm, string controlName, string seperator)
        //{
        //    ArrayList list = new ArrayList();
        //    Type type = null;
        //    int max = -1;
        //    ArrayList controls = GetAllControls(frm);
        //    foreach (Control control in controls)
        //    {
        //        int controlIndex = control.Name.ToLower().IndexOf(controlName.ToLower() + seperator);
        //        if (controlIndex == 0)
        //        {   
        //            string suffix = control.Name.Substring(controlName.Length);     
        //            if (IsNumeric(suffix))
        //            {          
        //                if (Strip(suffix) > max)
        //                {
        //                    max = Strip(suffix);
        //                }
        //            }
        //        }
        //    }
        //    if (max > -1)
        //    {
        //        for (int i = 0; i <= max; i++)
        //        {
        //            Control ctrl = GetControl(controls, controlName, i);     
        //            if ((ctrl != null)) type = ctrl.GetType();
        //            list.Add(ctrl);
        //        }
        //    }
        //    return list.ToArray(type);
        //}
        
    }
}
