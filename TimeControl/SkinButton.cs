//// Code Modified from CodeProject: Skinned Form Playing Audio and OpenGL Altogether By zapsolution

//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Text;
//using System.Windows.Forms;


//namespace Video.Controls
//{
//    public partial class SkinButton : System.Windows.Forms.Button
//    {
//        private bool _state = false;     
//        private int _subState = 0;  

//        private String _resourceON = "BTN_Push";
//        private String _resourceOFF = "BTN_Push";

//        [Category("Configuration"), Browsable(true), Description("The bitmap resource name")]
//        public String Resource
//        {
//            get { return this.Name; }
//            set { this.Name = value; }
//        }

//        [Category("Configuration"), Browsable(true), Description("The bitmap resource name")]
//        public String ResourceON
//        {
//            get { return this._resourceON; }
//            set { this._resourceON = value; }
//        }

//        [Category("Configuration"), Browsable(true), Description("The bitmap resource name")]
//        public String ResourceOFF
//        {
//            get { return this._resourceOFF; }
//            set { this._resourceOFF = value; }
//        }



//        [Category("Configuration"), Browsable(true), Description("The bitmap resource name")]
//        public bool State
//        {
//            get { return this._state; }
//            set 
//            {
//                this._state = value;

//                if (this._state)
//                    this.Resource = this.ResourceON;
//                else
//                    this.Resource = this.ResourceOFF;

//                Button btn = ((Button)this);
//                SK.USE_BTN_Image(btn, 5);

//            }
//        }

//        public SkinButton()
//        {
//            InitializeComponent();
//            CreateButtonRegion();
//        }

//        private void CreateButtonRegion()
//        {
//            SK.UseNameSpace = this.GetType().Namespace;
//            // Use default Magenta, instead of TopLeft(0,0) pixel color
//            SK.UseTransparencyColorTopLeft = true; // false;
//            // Create the button region
//            Button btn = ((Button)this);
//            SK.CreateButtonRegion(btn);

//        }

//        private void SKIN_Resize(object sender, EventArgs e)
//        {
//            CreateButtonRegion();
//        }

//        private void BTN_MouseEnter(object sender, EventArgs e)
//        {
//            Button btn = ((Button)sender);
//            SK.USE_BTN_Image(btn, 5);
//        }

//        private void BTN_MouseLeave(object sender, EventArgs e)
//        {
//            Button btn = ((Button)sender);
//            SK.USE_BTN_Image(btn, 1);
//        }

//        private void BTN_MouseUp(object sender, MouseEventArgs e)
//        {
//            Button btn = ((Button)sender);
//            SK.USE_BTN_Image(btn, 1);

//        }

//        private void BTN_MouseDown(object sender, MouseEventArgs e)
//        {
//            Button btn = ((Button)sender);
//            SK.USE_BTN_Image(btn, 2);
//        }

//        private void BTN_EnabledChanged(object sender, EventArgs e)
//        {
//            Button btn = ((Button)sender);
//            SK.InitButton(btn);
//        }

//        private void BTN_TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void BTN_Clicked(object sender, EventArgs e)
//        {
//            this.State = !this.State;
//            Button btn = ((Button)sender);
//            SK.USE_BTN_Image(btn, 1);

//        }

//    }
//}
