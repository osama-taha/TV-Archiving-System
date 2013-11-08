using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Permissions;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Xml;
using System.Runtime.InteropServices;

using Video.Controls;

using System.Text.RegularExpressions;

namespace TimeControl
{
    public partial class SliderControl : UserControl
    {
        private static int _sliderHPos = 0;
        private static int _barCount = 0;

        public static int barIndex = -1;
        public static int fileIndex = -1;
        private static bool _time24 = true;

        public delegate void GoToClickHandler(object sender, GoToClickEventArgs e);
        [Category("Configuration"), Browsable(false), Description("")]
        public event GoToClickHandler GoToClick;
        
        public delegate void ValidClickHandler(object sender, FireEventArgs e);
        [Category("Configuration"), Browsable(false), Description("")]
        public event ValidClickHandler ValidClick;

        public delegate void AddRemoveClickHandler(object sender, AddRemoveClickEventArgs e);
        [Category("Configuration"), Browsable(false), Description("")]
        public event AddRemoveClickHandler AddRemoveClick;
        
        // number of wanted Button
        private static int thumbSeconds = 0;
        private static int zoomFactor = 1;
        private static int sBarH = 17;
        private static int sBarW = 17;

        ///////////////////////////////////////////////
        private static int iButtonBar = 320;
        private static int iBarHeight = 24;
        private static uint uBarHeight = 24;
        private static int iMediaAxisTop = 22;
        private static int iHSliderHeight = 22;
        ///////////////////////////////////////////////


        private static string appSkinPath = string.Empty;


        public SliderControl()
        {
            this.SetStyle(ControlStyles.ContainerControl, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();

            this.videoSlider1.barHeight = iBarHeight;

            this.videoSlider1.XChanged +=new EventHandler(videoSlider1_XChanged);

            this.videoSlider1.ValueChanged += new System.EventHandler(this.SlidersValueChanged);
            this.videoSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);

            String appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        }

        [Flags]
        public enum YAxisDisplayType : int
        {
            SKINBUTTON = 0, 
            VISTABUTTON = 1,
            COOLPANEL = 2,
        }

        private YAxisDisplayType _yAxisDisplay = 0;
        [Description("Selected search date.")]
        [Category("VideoSlider")]
        [DefaultValue("01/01/2008")]
        public YAxisDisplayType YAxisDisplay
        {
            get { return _yAxisDisplay; }
            set
            {
                _yAxisDisplay = value;
                this.Invalidate();
            }
        }

        private String _displayDate = DateTime.Now.ToShortDateString();
        [Description("Selected search date.")]
        [Category("VideoSlider")]
        [DefaultValue("01/01/2008")]
        public String displayDate
        {
            get { return _displayDate; }
            set
            {
                _displayDate = value;
                //this.LABEL_Date.Text = _displayDate;

                double d1 = (double)this.PANEL_Display.Width / 2;
                double d2 = (double)this.PANEL_ThumbTime.Width / 2;
                PANEL_ThumbTime.Left = Convert.ToInt32(d1 - d2);

                UpDateTimeDisplay();
                this.Invalidate();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Action")]
        [Description("Gets the file index of the selected camera.")]
        public int FileIndex
        {
            get { return fileIndex; }
        }

        static bool isVLCPlaying = false;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Status")]
        [Description("Playing status.")]
        public bool IsVLCPlaying
        {
            get { return isVLCPlaying; }
            set { isVLCPlaying = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Category("Button")]
        [Description("Gets the camera button.")]
        public int BarIndex
        {
            get { return barIndex;  Invalidate(); }
        }

 
        private void SliderControl_Load(object sender, EventArgs e)
        {
            if (videoSlider1 != null)
            {
                this.videoSlider1.Top = iHSliderHeight;
                this.videoSlider1.Left = iButtonBar;
                this.videoSlider1.Width = this.Width - (iButtonBar + 1) - iHSliderHeight;
                this.videoSlider1.Height = this.Height - iHSliderHeight - 25;

                this.sliderH.Top = 0;
                this.sliderH.Left = iButtonBar;
                this.sliderH.Width = this.videoSlider1.Width;

                this.sliderV.Top = iHSliderHeight;
                this.sliderV.Left = this.Width - this.sliderV.Width;
                this.sliderV.Height = this.videoSlider1.Height - 18;

                this.mediaAxis1.Top = iMediaAxisTop;
                this.mediaAxis1.Left = 0;
                this.mediaAxis1.Width = iButtonBar;
                this.mediaAxis1.Height = this.videoSlider1.Height - 18;
                //this.mediaAxis1.Height = this.Height - 28;

                //this.mediaAxis1.Top = 16;
                //this.mediaAxis1.Left = 0;
                //this.mediaAxis1.Width = 100;
                //this.mediaAxis1.Height = this.videoSlider1.Height - 18;

                this.PANEL_Display.Height = 25;
                this.PANEL_Display.Top = this.Height - this.PANEL_Display.Height;
                this.PANEL_Display.Left = iButtonBar;
                this.PANEL_Display.Width = this.sliderH.Width;

                double d1 = (double)this.PANEL_Display.Width / 2;
                double d2 = (double)this.PANEL_ThumbTime.Width / 2;
                PANEL_ThumbTime.Left = Convert.ToInt32(d1 - d2);

                UpDateTimeDisplay();

                timePicker.Top = 3;
                timePicker.Left = this.PANEL_Display.Width - timePicker.Width;
                BTN_Goto.Top = 2;
                BTN_Goto.Left = this.PANEL_Display.Width - (BTN_Goto.Width + timePicker.Width + 1);

                if ((sliderV != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    this.sliderV.Minimum = 0;
                    this.sliderV.Maximum = (_barCount * iBarHeight);
                    if ((iBarHeight * _barCount) > this.videoSlider1.Height - 25)
                    {
                        this.sliderV.Enabled = true;
                        this.sliderV.Maximum = (iBarHeight * (_barCount + 1)) - this.videoSlider1.Height - 25;
                    }
                    else
                    {
                        this.videoSlider1.ScreenOffsetY = 0;
                        this.sliderV.Value = 0;
                        this.sliderV.Enabled = false;
                    }
                    sliderZoom.Value = 0;
                }
                if ((sliderH != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    //SetSliderH();
                }
                BTN_MoveLeft.Size = new Size(19, 19);
                BTN_MoveRight.Size = new Size(19, 19);
                BTN_MoveUp.Size = new Size(19, 19);
                BTN_MoveDown.Size = new Size(19, 19);
                BTN_MoveLeft.Image = global::TimeControl.Properties.Resources.BTN_MoveLeft;
                BTN_MoveRight.Image = global::TimeControl.Properties.Resources.BTN_MoveRight;
                BTN_MoveUp.Image = global::TimeControl.Properties.Resources.BTN_MoveUp;
                BTN_MoveDown.Image = global::TimeControl.Properties.Resources.BTN_MoveDown;

                BTN_MoveLeft.Left = this.sliderH.Left;
                BTN_MoveRight.Left = this.sliderH.Right - BTN_MoveRight.Width;
                BTN_MoveUp.Left = this.videoSlider1.Right;
                BTN_MoveUp.Top = this.sliderV.Top;
                BTN_MoveDown.Left = this.videoSlider1.Right;
                BTN_MoveDown.Top = this.sliderV.Bottom - BTN_MoveDown.Height;

                PANEL_Buttons.Top = 15;
                PANEL_Buttons.Left = 0;
                PANEL_Buttons.Height = this.Height - 15 - 25 - 15;
                PANEL_Buttons.Width = iButtonBar;

                dgvHeaders.Width = iButtonBar;

                //sliderInfo.Left = 2;
                //sliderInfo.Top = BTN_Add.Top - sliderInfo.Height - 2;
                sliderInfo.Width = mediaAxis1.Width-10;

                //CreateCoverButtons();
                //this.PANEL_Cover.Visible = true;
                this.sliderH.Value = 0;

            }

            timePicker.Format = DateTimePickerFormat.Custom;
            timePicker.CustomFormat = "HH:mm:ss";



        }

        private void UpDateTimeDisplay()
        {
            //LABEL_Date.Top = 0;
            LABEL_ThumbTime.Top =0;
            LABEL_AMPM.Top = 0;
            //LABEL_Date.Left = 0;
            //LABEL_ThumbTime.Left = this.LABEL_Date.Right + 8;
            LABEL_AMPM.Left = LABEL_ThumbTime.Right - 4;
        }

        private void SliderControl_Resize(object sender, EventArgs e)
        {
            if (videoSlider1 != null)
            {
                this.videoSlider1.Top = iHSliderHeight;
                this.videoSlider1.Left = iButtonBar;
                this.videoSlider1.Width = this.Width - 101 - iHSliderHeight;
                this.videoSlider1.Height = this.Height - iHSliderHeight - 25;

                this.sliderH.Top = 0;
                this.sliderH.Left = iButtonBar;
                this.sliderH.Width = this.videoSlider1.Width;
                this.sliderV.Top = iHSliderHeight;
                this.sliderV.Left = this.Width - this.sliderV.Width;
                this.sliderV.Height = this.videoSlider1.Height - 18;

                this.mediaAxis1.Top = iMediaAxisTop;
                this.mediaAxis1.Left = 0;
                this.mediaAxis1.Width = iButtonBar;
                this.mediaAxis1.Height = this.videoSlider1.Height - 18;
                //this.mediaAxis1.Height = this.Height - 28;

                this.PANEL_Display.Height = 25;
                this.PANEL_Display.Top = this.Height - this.PANEL_Display.Height;
                this.PANEL_Display.Left = iButtonBar;
                this.PANEL_Display.Width = this.sliderH.Width;

                double d1 = (double)this.PANEL_Display.Width / 2;
                double d2 = (double)this.PANEL_ThumbTime.Width / 2;
                PANEL_ThumbTime.Left = Convert.ToInt32(d1 - d2);

                UpDateTimeDisplay();

                timePicker.Top = 3;
                timePicker.Left = this.PANEL_Display.Width - timePicker.Width;
                BTN_Goto.Top = 2;
                BTN_Goto.Left = this.PANEL_Display.Width - (BTN_Goto.Width + timePicker.Width + 1);

                if ((sliderV != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    this.sliderV.Minimum = 0;
                    this.sliderV.Maximum = (_barCount * iBarHeight);
                    if ((iBarHeight * _barCount) > this.videoSlider1.Height - 25)
                    {
                        this.sliderV.Enabled = true;
                        this.sliderV.Maximum = (iBarHeight * (_barCount + 1)) - this.videoSlider1.Height - 25;
                    }
                    else
                    {
                        this.videoSlider1.ScreenOffsetY = 0;
                        this.sliderV.Value = 0;
                        this.sliderV.Enabled = false;
                    }

                    //SetSliderH();
                    PANEL_Buttons.Top = 15;
                    PANEL_Buttons.Left = 0;
                    PANEL_Buttons.Height = this.Height - 15 - 25 - 15;
                    PANEL_Buttons.Width = iButtonBar;

                    sliderInfo.Left = 2;
                    sliderInfo.Top = BTN_Add.Top - sliderInfo.Height - 2;
                    sliderInfo.Width = mediaAxis1.Width - 10;

                    PANEL_Buttons.Top = Convert.ToInt32(this.videoSlider1.ScreenOffsetY);
                }
                else
                {
                    this.videoSlider1.ScreenOffsetY = 0;
                    this.sliderV.Value = 0;
                    this.sliderV.Enabled = false;
                }

                if ((sliderH != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    //SetSliderH();
                }

                BTN_MoveLeft.Left = this.sliderH.Left;
                BTN_MoveRight.Left = this.sliderH.Right - BTN_MoveRight.Width;
                BTN_MoveUp.Left = this.videoSlider1.Right;
                BTN_MoveUp.Top = this.sliderV.Top;
                BTN_MoveDown.Left = this.videoSlider1.Right;
                BTN_MoveDown.Top = this.sliderV.Bottom - BTN_MoveDown.Height;



            }
            Test();

        }


        private void BTN_Time_Click(object sender, EventArgs e)
        {
            _time24 = !_time24;
            this.videoSlider1.Time24 = _time24;
            if (_time24)
            {
                //BTN_Time.Text = "AM / PM";
                this.LABEL_AMPM.Visible = false;
                timePicker.CustomFormat = "HH:mm:ss"; 
            }
            else
            {
                //BTN_Time.Text = "24 HRS";
                this.LABEL_AMPM.Visible = true;
                timePicker.CustomFormat = "hh:mm:ss:tt";
            }
            int zz = this.videoSlider1.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, zz, 0);
            this.LABEL_AMPM.Text = "AM";
            if (zz > 43200)
                this.LABEL_AMPM.Text = "PM";

            if (!_time24)
                if (zz > 46800)
                {
                    ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
                }

            if ((!_time24) && (zz < 3600))
                LABEL_ThumbTime.Text = string.Format("12:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            else
                LABEL_ThumbTime.Text = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));


            this.Validate();
            timePicker.Refresh();
        }


        public void LoadBarsFromDataSet(object[] data)
        {
            //WARNING: DO NOT RESET _barCount UNTIL ALL BUTTONS ARE CLEARED !!!!!
            ClearBars();
            this.videoSlider1.LoadBarsFromDataSet(data);

            LoadDataGrid(data);

            if (data != null)
            {
                DefaultClickButton();

                sliderV.SmallChange = uBarHeight;
                sliderV.LargeChange = uBarHeight;
                this.sliderV.Minimum = 0;
                this.sliderV.Maximum = (_barCount * iBarHeight);
                if ((iBarHeight * _barCount) > this.videoSlider1.Height - 25)
                {
                    this.sliderV.Enabled = true;
                    this.sliderV.Maximum = (iBarHeight * (_barCount + 1)) - this.videoSlider1.Height - 25;
                }
                else
                {
                    this.videoSlider1.ScreenOffsetY = 0;
                    this.sliderV.Value = 0;
                    this.sliderV.Enabled = false;
                }
                //this.PANEL_Cover.Visible = false;
            }
            this.sliderV.Value = 0;
            PANEL_Buttons.Top = 0; 
            ScrollEventArgs sea = new ScrollEventArgs(ScrollEventType.First, 0);
            this.sliderV_Scroll(this, sea);
            this.videoSlider1.Invalidate();
            this.videoSlider1.Refresh();
        }

        public void ClearBars()
        {
            DataSet ds = null;
            this.PANEL_Buttons.DataSource = ds;
            this.dgvHeaders.DataSource = ds;
            this.sliderH.Value = 0;
            ////////////////////////////////////////////////////////////////
            //DO NOT RESET DEFAULTS UNTIL AFTER ALL BUTTONS ARE REMOVED !!!!
            sliderZoom.Value = 0;
            barIndex = -1;
            _barCount = 0;
            this.videoSlider1.SelectBar(barIndex);
            this.sliderH.Value = 0;
            ////////////////////////////////////////////////////////////////
        }


        private void BTN_Goto_Click(object sender, EventArgs e)
        {
            int seconds = (60 * 60 * this.timePicker.Value.Hour) + (60 * this.timePicker.Value.Minute) + this.timePicker.Value.Second;
            if ((GoToClick != null) && (seconds >= 0) && (seconds <= 86400))
            {
                GoToClickEventArgs ee = new GoToClickEventArgs(seconds);
                GoToClick(this, ee);
            }
        }

        public void SetZoom(int zoom)
        {
            sliderZoom.Value = zoom;
            if(videoSlider1 != null) 
            {
                int z = sliderZoom.Value;

                float ff = 86400f;
                switch (z)
                {
                    case 0:
                        {
                            ff = 86400f;
                            LABEL_Zoom.Text = "24 HRS";
                        }
                        break;
                    case 1:
                        {
                            ff = 43200f;
                            LABEL_Zoom.Text = "12 HRS";
                        }
                        break;
                    case 2:
                        {
                            ff = (float)6 * 3600;
                            LABEL_Zoom.Text = "6 HRS";
                        }
                        break;
                    case 3:
                        {
                            ff = 3600f;
                            LABEL_Zoom.Text = "1 HR";
                        }
                        break;
                    case 4:
                        {
                            ff = 900f;
                            LABEL_Zoom.Text = "15 MIN";
                        }
                        break;
                    case 5:
                        {
                            ff = 60f;
                            LABEL_Zoom.Text = "1 MIN";
                        }
                        break;


                }

                this.videoSlider1.Zoom2(ff);
                this.videoSlider1.Invalidate();
                SetSliderH();
            }
        }

        private void sliderZoom_Scroll(object sender, ScrollEventArgs e)
        {

            if ((videoSlider1 != null) && (e.Type == ScrollEventType.EndScroll))
            {
                int z = sliderZoom.Value;

                float ff = 86400f;
                switch (z)
                {
                    case 0:
                        {
                            ff = 86400f;
                            LABEL_Zoom.Text = "24 HRS";
                        }
                        break;
                    case 1:
                        {
                            ff = 43200f;
                            LABEL_Zoom.Text = "12 HRS";
                        }
                        break;
                    case 2:
                        {
                            ff = (float)6 * 3600;
                            LABEL_Zoom.Text = "6 HRS";
                        }
                        break;
                    case 3:
                        {
                            ff = 3600f;
                            LABEL_Zoom.Text = "1 HR";
                        }
                        break;
                    case 4:
                        {
                            ff = 900f;
                            LABEL_Zoom.Text = "15 MIN";
                        }
                        break;
                    case 5:
                        {
                            ff = 60f;
                            LABEL_Zoom.Text = "1 MIN";
                        }
                        break;


                }

                this.videoSlider1.Zoom2(ff);
                this.videoSlider1.Invalidate();

                // Don't allow user to scroll beyond display bounds
                //BTN_MoveLeft.Enabled = !this.videoSlider1.AtMinX();
                //BTN_MoveRight.Enabled = !this.videoSlider1.AtMaxX();
                //BTN_MoveUp.Enabled = !this.videoSlider1.AtMinY();
                //BTN_MoveDown.Enabled = !this.videoSlider1.AtMaxY();

                SetSliderH();

            }
        }

        private void sliderH_Scroll(object sender, ScrollEventArgs e)
        {
            //if (e.Type == ScrollEventType.EndScroll)
            //{
            this.videoSlider1.MoveSliderH((float)e.NewValue);
            //Invalidate();
            Application.DoEvents();
            //}
        }

        public void SetSliderHPosition()
        {
            if (this.videoSlider1.DataRect.Width < 86400)
                this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.Left);
            else
                this.sliderH.Value = 0;

        }

        private void SetSliderH()
        {
            this.sliderH.Minimum = 0;
            this.sliderH.SmallChange = (uint)1;
            this.sliderH.LargeChange = (uint)1;
            this.sliderH.Value = 0;
            
            if((_barCount > 0) && (this.videoSlider1.DataRect.Width < 86400))
            {
                this.sliderH.Enabled = true; 
                this.sliderH.Maximum = 86400 - Convert.ToInt32(this.videoSlider1.DataRect.Width);
                this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.Left);
            }
            else
            {
                this.sliderH.Value = 0;
                this.sliderH.Enabled = false;
            }

            this.Invalidate();
            this.Refresh();
        }

        private void sliderH_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Type == ScrollEventType.EndScroll)
            //{
            //if ((Convert.ToInt32(this.videoSlider1.DataRect.Left) > 0)
            //    && (Convert.ToInt32(this.videoSlider1.DataRect.Left) < 86400))
            //{
            //    this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.Left);
            //}
            //Invalidate();
            //}

        }

        private void SlidersScroll(object sender, ScrollEventArgs e)
        {
                if (e.NewValue < 0)
                    return;

                if (e.NewValue > this.videoSlider1.DataRect.X + this.videoSlider1.DataRect.Width)
                {
                    this.videoSlider1.ZoomRight();
                }
                if (e.NewValue < this.videoSlider1.DataRect.X)
                {
                    this.videoSlider1.ZoomLeft();
                }

                int zz = e.NewValue;
                TimeSpan ts = new TimeSpan(0, 0, 0, zz, 0);
                LABEL_AMPM.Text = "AM";
                if (zz > 43200)
                    LABEL_AMPM.Text = "PM";

                if (!_time24)
                    if (zz > 46800)
                    {
                        ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
                    }

                if ((!_time24) && (zz < 3600))
                    LABEL_ThumbTime.Text = string.Format("12:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
                else
                    LABEL_ThumbTime.Text = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));

                if (e.Type == ScrollEventType.EndScroll)
                {
                    this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.X);
                    
                }
        }

        private void videoSlider1_XChanged(object sender, EventArgs e)
        {
            SetSliderH();
        }

        public void ClearGraph()
        {
            //this.PANEL_Cover.Visible = true;
            this.sliderH.Value = 0;           
            this.LoadBarsFromDataSet(null);
        }




        private void SlidersValueChanged(object sender, EventArgs e)
        {
            if ((sender as TimeControl.VideoSlider).Value < 0)
                return;

            if ((sender as TimeControl.VideoSlider).Value > this.videoSlider1.DataRect.X + this.videoSlider1.DataRect.Width)
            {
                this.videoSlider1.ZoomRight();
            }
            if ((sender as TimeControl.VideoSlider).Value < this.videoSlider1.DataRect.X)
            {
                this.videoSlider1.ZoomLeft();
            }

            int zz = (sender as TimeControl.VideoSlider).Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, zz, 0);
            LABEL_AMPM.Text = "AM";
            if (zz > 43200)
                LABEL_AMPM.Text = "PM";

            if (!_time24)
                if (zz > 46800)
                {
                    ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
                }

            if (!_time24)
                if (zz > 46800)
                {
                    ts = new TimeSpan(0, 0, 0, zz - 43200, 0);
                }

            if ((!_time24) && (zz < 3600))
                LABEL_ThumbTime.Text = string.Format("12:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            else
                LABEL_ThumbTime.Text = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));

           this.sliderH.Value = Convert.ToInt32(this.videoSlider1.DataRect.X);
           Invalidate();

        }
        

        private void sliderV_Scroll(object sender, ScrollEventArgs e)
        {
            PANEL_Buttons.Top = -sliderV.Value;
            //PANEL_Buttons.FirstDisplayedScrollingRowIndex = sliderV.Value;

            //int lineStart, lineEnd;
            //lineStart = pPos.LineStart + (sliderV.Value / 30);
            //int bytesRemaining = slice.Length - (30 - (sliderV.Value % 30));
            //if (bytesRemaining < 0)
            //    bytesRemaining = 0;
            //lineEnd = lineStart + (bytesRemaining / 30);
            //double d1 = (double)(sliderV.Value - (sliderV.Value % iBarHeight)) / iBarHeight;


            //PANEL_Buttons.FirstDisplayedScrollingRowIndex = Convert.ToInt32(d1);

            //int jumpToRow = (Convert.ToInt32(d1) % 30);
            //if (PANEL_Buttons.Rows.Count >= jumpToRow && jumpToRow >= 1)
            //{
            //    PANEL_Buttons.FirstDisplayedScrollingRowIndex = jumpToRow;
            //    //PANEL_Buttons.Rows[jumpToRow].Selected = true;
            //}

            this.videoSlider1.ScreenOffsetY = -(float)sliderV.Value;
            Application.DoEvents();
        }

        private void BTN_MoveLeft_Click(object sender, EventArgs e)
        {
            this.videoSlider1.MoveLeft();
        }

        private void BTN_MoveRight_Click(object sender, EventArgs e)
        {
            this.videoSlider1.MoveRight();
        }

        private void BTN_MoveUp_Click(object sender, EventArgs e)
        {
            if (PANEL_Buttons.Top == 0)
                return;

            PANEL_Buttons.Top += iBarHeight;
            this.videoSlider1.MoveUp();
            Invalidate();
        }

        private void BTN_MoveDown_Click(object sender, EventArgs e)
        {
            if (PANEL_Buttons.Bottom <= this.videoSlider1.Height - iBarHeight)
                return;

            PANEL_Buttons.Top -= iBarHeight;
            this.videoSlider1.MoveDown();
            Invalidate();
        }
        
        public void ResizePanels()
        {
            Invalidate();
        }

        private void sliderZoom_ValueChanged(object sender, EventArgs e)
        {
            SetSliderH();
        }


        // Result of event click Button
        //public void ClickButton(Object sender, System.EventArgs e)
        //{
        //    int oldBarIndex = this.BarIndex;
        //    //barIndex = Convert.ToInt32(((SkinButton)sender).Tag.ToString());
        //    barIndex = this.PANEL_Buttons.SelectedRows[0].Index;

        //    if (barIndex < 0)
        //        return;

        //    this.videoSlider1.SelectBar(barIndex);

        //    if (ValidClick != null)
        //    {
        //        FireEventArgs ee = new FireEventArgs(barIndex, oldBarIndex);
        //        ValidClick(this, ee);
        //    }
        //    //PANEL_Buttons.Invalidate();
        //    Invalidate();
        //}

        public void DefaultClickButton()
        {
            if(this.videoSlider1.Bars.Length > 0)
            {
              //  this.videoSlider1.SelectBar(0);
            }

        }



        private void BTN_Add_Click(object sender, EventArgs e)
        {
            if (AddRemoveClick != null)
            {
                int addremove = 1;
                AddRemoveClickEventArgs ee = new AddRemoveClickEventArgs(addremove);
                AddRemoveClick(this, ee);
            }
        }

        private void BTN_Remove_Click(object sender, EventArgs e)
        {
            if (AddRemoveClick != null)
            {
                AddRemoveClickEventArgs ee = new AddRemoveClickEventArgs(0);
                AddRemoveClick(this, ee);
            }
        }

        public void LoadDataGrid(object[] data)
        {
            if (data == null)
                return;

            sliderZoom.Value = 0;
            barIndex = -1;
            _barCount = 0;
            this.videoSlider1.SelectBar(barIndex);
            sliderZoom.Value = 0;
            _barCount = 0;

            DataSet ds = new DataSet();
            object[] state = (object[])data;
            ds = (DataSet)state[0];
            _barCount = ds.Tables[0].Rows.Count;


            this.PANEL_Buttons.RowTemplate.Height = iBarHeight;

            if ((this.videoSlider1.Bars != null) && (this.videoSlider1.Bars.Length > 0))
            {
                _barCount = this.videoSlider1.Bars.GetLength(0);
                this.PANEL_Buttons.Top = 0;
                this.PANEL_Buttons.Height = iBarHeight * _barCount;
                //this.PANEL_Buttons.Height = this.Height;

                this.PANEL_Buttons.ColumnHeadersHeight = 22;
            }
            else
                return;

            int xPos = 0;
            int yPos = 0;

            this.PANEL_Buttons.DataSource = ds.Tables[0].DefaultView;
            //this.PANEL_Buttons.Columns[0].Visible = false;
            //this.PANEL_Buttons.Columns[1].Visible = false;

            this.dgvHeaders.DataSource = ds.Tables[0].DefaultView;
            for (int jj = 0; jj < this.dgvHeaders.Columns.Count; jj++ )
                this.dgvHeaders.Columns[jj].SortMode = DataGridViewColumnSortMode.NotSortable;
            
            //this.dgvHeaders.Columns[0].Visible = false;

            DataGridViewColumnSelector cs = new DataGridViewColumnSelector(this.dgvHeaders, this.PANEL_Buttons);
            cs.MaxHeight = 100;
            cs.Width = 110;

            this.sliderH.Value = 0;

            this.sliderInfo.Maximum = this.PANEL_Buttons.ColumnCount;
        }


        //private void PANEL_Buttons_SelectionChanged(object sender, EventArgs e)
        //{
        //    int iSelected = -1;
        //    int i = 0;
        //    for (i = 0; i < PANEL_Buttons.SelectedRows.Count; i++)
        //    {
        //        if (PANEL_Buttons.SelectedRows[i].Selected)
        //            break;
        //    }
        //    iSelected = PANEL_Buttons.SelectedRows[i].Index;
        //    int oldBarIndex = this.BarIndex;

        //    if (iSelected > -1)
        //    {
        //        this.videoSlider1.SelectBar(iSelected);
        //        if (ValidClick != null)
        //        {
        //            FireEventArgs ee = new FireEventArgs(barIndex, oldBarIndex);
        //            ValidClick(this, ee);
        //        }
        //    }
        //}

        private void PANEL_Buttons_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int oldBarIndex = this.BarIndex;
            if (PANEL_Buttons.DataSource == null) // CRITICAL CHECK !!!
                return;

            if (e.RowIndex < 0)
                return;

            barIndex = e.RowIndex;
            PANEL_Buttons.Rows[barIndex].Selected = true;
            this.videoSlider1.SelectBar(barIndex); // Changes bar color to orange!
            if (ValidClick != null)
            {
                FireEventArgs ee = new FireEventArgs(barIndex, oldBarIndex);
                ValidClick(this, ee);
            }
        }

        private void PANEL_Buttons_Scroll(object sender, ScrollEventArgs e)
        {
            //BTN_Goto.Text = e.NewValue.ToString();


        }

        private void sliderInfo_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.NewValue < PANEL_Buttons.ColumnCount)
            {
                if (this.PANEL_Buttons.Columns[e.NewValue].Visible)
                {
                    PANEL_Buttons.FirstDisplayedScrollingColumnIndex = e.NewValue;
                    dgvHeaders.FirstDisplayedScrollingColumnIndex = e.NewValue;
                }
            }
        }

        private void Test()
        {
            if (videoSlider1 != null)
            {
                this.videoSlider1.Top = iHSliderHeight;
                this.videoSlider1.Left = iButtonBar;
                this.videoSlider1.Width = this.Width - (iButtonBar + 1) - iHSliderHeight;
                this.videoSlider1.Height = this.Height - iHSliderHeight - 25;

                this.sliderH.Top = 0;
                this.sliderH.Left = iButtonBar;
                this.sliderH.Width = this.videoSlider1.Width;

                this.sliderV.Top = iHSliderHeight;
                this.sliderV.Left = this.Width - this.sliderV.Width;
                this.sliderV.Height = this.videoSlider1.Height - 18;

                this.mediaAxis1.Top = iMediaAxisTop;
                this.mediaAxis1.Left = 0;
                this.mediaAxis1.Width = iButtonBar;
                this.mediaAxis1.Height = this.videoSlider1.Height - 18;
                //this.mediaAxis1.Height = this.Height - 28;

                //this.mediaAxis1.Top = 16;
                //this.mediaAxis1.Left = 0;
                //this.mediaAxis1.Width = 100;
                //this.mediaAxis1.Height = this.videoSlider1.Height - 18;

                this.PANEL_Display.Height = 25;
                this.PANEL_Display.Top = this.Height - this.PANEL_Display.Height;
                this.PANEL_Display.Left = iButtonBar;
                this.PANEL_Display.Width = this.sliderH.Width;

                double d1 = (double)this.PANEL_Display.Width / 2;
                double d2 = (double)this.PANEL_ThumbTime.Width / 2;
                PANEL_ThumbTime.Left = Convert.ToInt32(d1 - d2);

                UpDateTimeDisplay();

                timePicker.Top = 3;
                timePicker.Left = this.PANEL_Display.Width - timePicker.Width;
                BTN_Goto.Top = 2;
                BTN_Goto.Left = this.PANEL_Display.Width - (BTN_Goto.Width + timePicker.Width + 1);

                if ((sliderV != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    this.sliderV.Minimum = 0;
                    this.sliderV.Maximum = (_barCount * iBarHeight);
                    if ((iBarHeight * _barCount) > this.videoSlider1.Height - 25)
                    {
                        this.sliderV.Enabled = true;
                        this.sliderV.Maximum = (iBarHeight * (_barCount + 1)) - this.videoSlider1.Height - 25;
                    }
                    else
                    {
                        this.videoSlider1.ScreenOffsetY = 0;
                        this.sliderV.Value = 0;
                        this.sliderV.Enabled = false;
                    }
                    sliderZoom.Value = 0;
                }
                if ((sliderH != null) && (mediaAxis1 != null) && (_barCount > 0))
                {
                    //SetSliderH();
                }
                BTN_MoveLeft.Size = new Size(19, 19);
                BTN_MoveRight.Size = new Size(19, 19);
                BTN_MoveUp.Size = new Size(19, 19);
                BTN_MoveDown.Size = new Size(19, 19);
                BTN_MoveLeft.Image = global::TimeControl.Properties.Resources.BTN_MoveLeft;
                BTN_MoveRight.Image = global::TimeControl.Properties.Resources.BTN_MoveRight;
                BTN_MoveUp.Image = global::TimeControl.Properties.Resources.BTN_MoveUp;
                BTN_MoveDown.Image = global::TimeControl.Properties.Resources.BTN_MoveDown;

                BTN_MoveLeft.Left = this.sliderH.Left;
                BTN_MoveRight.Left = this.sliderH.Right - BTN_MoveRight.Width;
                BTN_MoveUp.Left = this.videoSlider1.Right;
                BTN_MoveUp.Top = this.sliderV.Top;
                BTN_MoveDown.Left = this.videoSlider1.Right;
                BTN_MoveDown.Top = this.sliderV.Bottom - BTN_MoveDown.Height;

                PANEL_Buttons.Top = 15;
                PANEL_Buttons.Left = 0;
                PANEL_Buttons.Height = this.Height - 15 - 25 - 15;
                PANEL_Buttons.Width = iButtonBar;

                dgvHeaders.Width = iButtonBar;

                //sliderInfo.Left = 2;
                sliderInfo.Top = mediaAxis1.Bottom + 2;
                sliderInfo.Width = mediaAxis1.Width - 10;

                //CreateCoverButtons();
                //this.PANEL_Cover.Visible = true;
                this.sliderH.Value = 0;

            }

        }

        private void PANEL_Buttons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void videoSlider1_Scroll(object sender, ScrollEventArgs e)
        {

        }
        
    }//END OF CLASS


    public class GoToClickEventArgs : EventArgs
    {
        public GoToClickEventArgs(int gotoPos)
        {
            this.gotoPos = gotoPos;
        }
        public int gotoPos;

    }    //end of class GoToClickEventArgs


    public class FireEventArgs : EventArgs
    {
        public FireEventArgs(int btnID, int btnPrevID)
        {
            this.btnID = btnID;
            this.btnPrevID = btnPrevID;
        }
        public int btnID;
        public int btnPrevID;
    } //end of class FireEventArgs


    public class AddRemoveClickEventArgs : EventArgs
    {
        public AddRemoveClickEventArgs(int addremove)
        {
            this.addremove = addremove;
        }
        public int addremove;

    }  //end of class AddRemoveClickEventArgs



}














