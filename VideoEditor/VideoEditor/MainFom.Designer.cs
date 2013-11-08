using System.Drawing;


namespace VideoEditor
{
    partial class MainForm 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.Dispose();

            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PANEL_Video = new System.Windows.Forms.Panel();
            this.PANEL_VideoControls = new System.Windows.Forms.Panel();
            this.BTN_StepBackward = new System.Windows.Forms.Button();
            this.BTN_PlayPause = new System.Windows.Forms.Button();
            this.BTN_Stop = new System.Windows.Forms.Button();
            this.BTN_FastForward = new System.Windows.Forms.Button();
            this.BTN_FastRewind = new System.Windows.Forms.Button();
            this.BTN_Mute = new System.Windows.Forms.Button();
            this.BTN_SepFoward = new System.Windows.Forms.Button();
            this.LABEL_Volume = new System.Windows.Forms.Label();
            this.trackBarVideo = new EConTech.Windows.MACUI.MACTrackBar();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.timerVideo = new System.Windows.Forms.Timer(this.components);
            this.timerControls = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipTracks = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LABEL_Info = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sliderControl1 = new TimeControl.SliderControl();
            this.snapShots1 = new VideoEditor.SnapShots();
            this.PANEL_VideoControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // PANEL_Video
            // 
            this.PANEL_Video.BackColor = System.Drawing.Color.Black;
            this.PANEL_Video.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PANEL_Video.Location = new System.Drawing.Point(7, 5);
            this.PANEL_Video.Name = "PANEL_Video";
            this.PANEL_Video.Size = new System.Drawing.Size(399, 232);
            this.PANEL_Video.TabIndex = 2;
            this.PANEL_Video.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PANEL_Video_MouseMove);
            this.PANEL_Video.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PANEL_Video_MouseDown);
            this.PANEL_Video.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PANEL_Video_MouseUp);
            // 
            // PANEL_VideoControls
            // 
            this.PANEL_VideoControls.BackColor = System.Drawing.Color.DimGray;
            this.PANEL_VideoControls.Controls.Add(this.BTN_StepBackward);
            this.PANEL_VideoControls.Controls.Add(this.BTN_PlayPause);
            this.PANEL_VideoControls.Controls.Add(this.BTN_Stop);
            this.PANEL_VideoControls.Controls.Add(this.BTN_FastForward);
            this.PANEL_VideoControls.Controls.Add(this.BTN_FastRewind);
            this.PANEL_VideoControls.Controls.Add(this.BTN_Mute);
            this.PANEL_VideoControls.Controls.Add(this.BTN_SepFoward);
            this.PANEL_VideoControls.Controls.Add(this.LABEL_Volume);
            this.PANEL_VideoControls.Controls.Add(this.trackBarVideo);
            this.PANEL_VideoControls.Controls.Add(this.trackBarVolume);
            this.PANEL_VideoControls.Location = new System.Drawing.Point(7, 236);
            this.PANEL_VideoControls.Margin = new System.Windows.Forms.Padding(0);
            this.PANEL_VideoControls.Name = "PANEL_VideoControls";
            this.PANEL_VideoControls.Size = new System.Drawing.Size(399, 73);
            this.PANEL_VideoControls.TabIndex = 3;
            // 
            // BTN_StepBackward
            // 
            this.BTN_StepBackward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_StepBackward.BackColor = System.Drawing.Color.Transparent;
            this.BTN_StepBackward.BackgroundImage = global::VideoEditor.Properties.Resources.vstepbackward;
            this.BTN_StepBackward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_StepBackward.FlatAppearance.BorderSize = 0;
            this.BTN_StepBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_StepBackward.Location = new System.Drawing.Point(13, 30);
            this.BTN_StepBackward.Name = "BTN_StepBackward";
            this.BTN_StepBackward.Size = new System.Drawing.Size(40, 40);
            this.BTN_StepBackward.TabIndex = 9;
            this.toolTipMain.SetToolTip(this.BTN_StepBackward, "Step Backward");
            this.BTN_StepBackward.UseVisualStyleBackColor = false;
            this.BTN_StepBackward.Click += new System.EventHandler(this.BTN_StepBackward_Click);
            this.BTN_StepBackward.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_PlayPause
            // 
            this.BTN_PlayPause.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_PlayPause.BackColor = System.Drawing.Color.Transparent;
            this.BTN_PlayPause.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_PlayPause.BackgroundImage")));
            this.BTN_PlayPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_PlayPause.FlatAppearance.BorderSize = 0;
            this.BTN_PlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_PlayPause.Location = new System.Drawing.Point(93, 30);
            this.BTN_PlayPause.Name = "BTN_PlayPause";
            this.BTN_PlayPause.Size = new System.Drawing.Size(40, 40);
            this.BTN_PlayPause.TabIndex = 1;
            this.toolTipMain.SetToolTip(this.BTN_PlayPause, "Play / Pause");
            this.BTN_PlayPause.UseVisualStyleBackColor = false;
            this.BTN_PlayPause.Click += new System.EventHandler(this.BTN_PlayPause_Click);
            this.BTN_PlayPause.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_Stop
            // 
            this.BTN_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_Stop.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Stop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Stop.BackgroundImage")));
            this.BTN_Stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Stop.FlatAppearance.BorderSize = 0;
            this.BTN_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Stop.Location = new System.Drawing.Point(132, 30);
            this.BTN_Stop.Name = "BTN_Stop";
            this.BTN_Stop.Size = new System.Drawing.Size(40, 40);
            this.BTN_Stop.TabIndex = 2;
            this.toolTipMain.SetToolTip(this.BTN_Stop, "Stop Playing");
            this.BTN_Stop.UseVisualStyleBackColor = false;
            this.BTN_Stop.Click += new System.EventHandler(this.BTN_Stop_Click);
            this.BTN_Stop.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_FastForward
            // 
            this.BTN_FastForward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_FastForward.BackColor = System.Drawing.Color.Transparent;
            this.BTN_FastForward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_FastForward.BackgroundImage")));
            this.BTN_FastForward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_FastForward.FlatAppearance.BorderSize = 0;
            this.BTN_FastForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_FastForward.Location = new System.Drawing.Point(172, 30);
            this.BTN_FastForward.Name = "BTN_FastForward";
            this.BTN_FastForward.Size = new System.Drawing.Size(40, 40);
            this.BTN_FastForward.TabIndex = 3;
            this.toolTipMain.SetToolTip(this.BTN_FastForward, "Fast Forward");
            this.BTN_FastForward.UseVisualStyleBackColor = false;
            this.BTN_FastForward.Click += new System.EventHandler(this.BTN_FastForward_Click);
            this.BTN_FastForward.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_FastRewind
            // 
            this.BTN_FastRewind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_FastRewind.BackColor = System.Drawing.Color.Transparent;
            this.BTN_FastRewind.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_FastRewind.BackgroundImage")));
            this.BTN_FastRewind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_FastRewind.FlatAppearance.BorderSize = 0;
            this.BTN_FastRewind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_FastRewind.Location = new System.Drawing.Point(53, 30);
            this.BTN_FastRewind.Name = "BTN_FastRewind";
            this.BTN_FastRewind.Size = new System.Drawing.Size(40, 40);
            this.BTN_FastRewind.TabIndex = 7;
            this.toolTipMain.SetToolTip(this.BTN_FastRewind, "Fast Rewind");
            this.BTN_FastRewind.UseVisualStyleBackColor = false;
            this.BTN_FastRewind.Click += new System.EventHandler(this.BTN_FastRewind_Click);
            this.BTN_FastRewind.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_Mute
            // 
            this.BTN_Mute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Mute.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Mute.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_Mute.BackgroundImage")));
            this.BTN_Mute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_Mute.FlatAppearance.BorderSize = 0;
            this.BTN_Mute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Mute.Location = new System.Drawing.Point(346, 30);
            this.BTN_Mute.Name = "BTN_Mute";
            this.BTN_Mute.Size = new System.Drawing.Size(40, 40);
            this.BTN_Mute.TabIndex = 13;
            this.toolTipMain.SetToolTip(this.BTN_Mute, "Mute / Un-Mute");
            this.BTN_Mute.UseVisualStyleBackColor = false;
            this.BTN_Mute.Click += new System.EventHandler(this.BTN_Mute_Click);
            this.BTN_Mute.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // BTN_SepFoward
            // 
            this.BTN_SepFoward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_SepFoward.BackColor = System.Drawing.Color.Transparent;
            this.BTN_SepFoward.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BTN_SepFoward.BackgroundImage")));
            this.BTN_SepFoward.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTN_SepFoward.FlatAppearance.BorderSize = 0;
            this.BTN_SepFoward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SepFoward.Location = new System.Drawing.Point(213, 30);
            this.BTN_SepFoward.Name = "BTN_SepFoward";
            this.BTN_SepFoward.Size = new System.Drawing.Size(42, 40);
            this.BTN_SepFoward.TabIndex = 10;
            this.toolTipMain.SetToolTip(this.BTN_SepFoward, "Step Forward");
            this.BTN_SepFoward.UseVisualStyleBackColor = false;
            this.BTN_SepFoward.Click += new System.EventHandler(this.BTN_StepForward_Click);
            this.BTN_SepFoward.MouseEnter += new System.EventHandler(this.ResetButtonRegion);
            // 
            // LABEL_Volume
            // 
            this.LABEL_Volume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LABEL_Volume.AutoSize = true;
            this.LABEL_Volume.ForeColor = System.Drawing.Color.White;
            this.LABEL_Volume.Location = new System.Drawing.Point(278, 54);
            this.LABEL_Volume.Name = "LABEL_Volume";
            this.LABEL_Volume.Size = new System.Drawing.Size(42, 13);
            this.LABEL_Volume.TabIndex = 17;
            this.LABEL_Volume.Text = "Volume";
            // 
            // trackBarVideo
            // 
            this.trackBarVideo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVideo.BackColor = System.Drawing.Color.Transparent;
            this.trackBarVideo.BorderColor = System.Drawing.Color.DimGray;
            this.trackBarVideo.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackBarVideo.ForeColor = System.Drawing.Color.Black;
            this.trackBarVideo.IndentHeight = 6;
            this.trackBarVideo.Location = new System.Drawing.Point(13, 1);
            this.trackBarVideo.Maximum = 10;
            this.trackBarVideo.Minimum = 0;
            this.trackBarVideo.Name = "trackBarVideo";
            this.trackBarVideo.Size = new System.Drawing.Size(373, 28);
            this.trackBarVideo.TabIndex = 16;
            this.trackBarVideo.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVideo.TickColor = System.Drawing.Color.Transparent;
            this.trackBarVideo.TickHeight = 1;
            this.trackBarVideo.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarVideo.TrackerColor = System.Drawing.Color.Red;
            this.trackBarVideo.TrackerSize = new System.Drawing.Size(16, 16);
            this.trackBarVideo.TrackLineColor = System.Drawing.Color.Transparent;
            this.trackBarVideo.TrackLineHeight = 1;
            this.trackBarVideo.Value = 0;
            this.trackBarVideo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trackBarVideo_MouseClick);
            this.trackBarVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trackBarVideo_MouseMove);
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarVolume.BackColor = System.Drawing.Color.DimGray;
            this.trackBarVolume.Location = new System.Drawing.Point(255, 27);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.trackBarVolume.Size = new System.Drawing.Size(85, 45);
            this.trackBarVolume.TabIndex = 16;
            this.trackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.toolTipMain.SetToolTip(this.trackBarVolume, "Changes volume of current media");
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.ValueChanged += new System.EventHandler(this.trackBarVolume_Changed);
            // 
            // timerVideo
            // 
            this.timerVideo.Tick += new System.EventHandler(this.mediaTimerTick);
            // 
            // timerControls
            // 
            this.timerControls.Tick += new System.EventHandler(this.timerControls_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(51, 17);
            this.statusLabel.Text = "Stopped";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(86, 40);
            this.toolStripLabel1.Text = "toolStripLabel1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton2.Text = "toolStripButton1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton3.Text = "toolStripButton1";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton4.Text = "toolStripButton1";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton5.Text = "toolStripButton1";
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton6.Text = "toolStripButton1";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(40, 40);
            this.toolStripButton7.Text = "toolStripButton1";
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Location = new System.Drawing.Point(0, 702);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1187, 22);
            this.statusStrip.TabIndex = 17;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(51, 17);
            this.toolStripStatusLabel1.Text = "Stopped";
            // 
            // LABEL_Info
            // 
            this.LABEL_Info.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LABEL_Info.AutoSize = true;
            this.LABEL_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LABEL_Info.ForeColor = System.Drawing.Color.White;
            this.LABEL_Info.Location = new System.Drawing.Point(563, 48);
            this.LABEL_Info.Name = "LABEL_Info";
            this.LABEL_Info.Size = new System.Drawing.Size(0, 20);
            this.LABEL_Info.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(433, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Double click image to go to that frame";
            // 
            // sliderControl1
            // 
            this.sliderControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderControl1.displayDate = "1/9/2009";
            this.sliderControl1.Location = new System.Drawing.Point(8, 404);
            this.sliderControl1.Name = "sliderControl1";
            this.sliderControl1.Size = new System.Drawing.Size(1167, 295);
            this.sliderControl1.TabIndex = 18;
            this.sliderControl1.YAxisDisplay = TimeControl.SliderControl.YAxisDisplayType.SKINBUTTON;
            this.sliderControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.videoSlider1_MouseClick);
            this.sliderControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.videoSlider1_MouseDown);
            this.sliderControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoSlider1_MouseUp);
            // 
            // snapShots1
            // 
            this.snapShots1.AutoScroll = true;
            this.snapShots1.HorizontalMode = true;
            this.snapShots1.Location = new System.Drawing.Point(8, 317);
            this.snapShots1.Name = "snapShots1";
            this.snapShots1.Size = new System.Drawing.Size(1167, 81);
            this.snapShots1.TabIndex = 22;
            this.snapShots1.Text = "snapShots1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1187, 724);
            this.Controls.Add(this.snapShots1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LABEL_Info);
            this.Controls.Add(this.sliderControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.PANEL_Video);
            this.Controls.Add(this.PANEL_VideoControls);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(565, 425);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimeLine Control for DirectShow & VLC";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Resize += new System.EventHandler(this.MediaForm_Resize);
            this.PANEL_VideoControls.ResumeLayout(false);
            this.PANEL_VideoControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel PANEL_Video;
        private System.Windows.Forms.Panel PANEL_VideoControls;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BTN_FastForward;
        private System.Windows.Forms.Button BTN_Stop;
        private System.Windows.Forms.Button BTN_FastRewind;
        private System.Windows.Forms.Timer timerVideo;
        private System.Windows.Forms.Timer timerControls;
        private System.Windows.Forms.Button BTN_SepFoward;
        private System.Windows.Forms.Button BTN_StepBackward;
        private System.Windows.Forms.Button BTN_Mute;
        private System.Windows.Forms.Button BTN_PlayPause;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolTip toolTipMain;
        public System.Windows.Forms.ToolTip toolTipTracks;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private EConTech.Windows.MACUI.MACTrackBar trackBarVideo;
        private System.Windows.Forms.Label LABEL_Volume;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private TimeControl.SliderControl sliderControl1;
        private System.Windows.Forms.Label LABEL_Info;
        private System.Windows.Forms.Label label1;
        private SnapShots snapShots1;
    }
}

