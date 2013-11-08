namespace TimeControl
{
    partial class SliderControl
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SliderControl));
            this.PANEL_Display = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LABEL_Zoom = new System.Windows.Forms.Label();
            this.BTN_Goto = new System.Windows.Forms.Button();
            this.PANEL_ThumbTime = new System.Windows.Forms.Panel();
            this.LABEL_AMPM = new System.Windows.Forms.Label();
            this.LABEL_ThumbTime = new System.Windows.Forms.Label();
            this.mediaAxis1 = new System.Windows.Forms.Panel();
            this.PANEL_Buttons = new System.Windows.Forms.DataGridView();
            this.BTN_MoveLeft = new System.Windows.Forms.Button();
            this.BTN_MoveRight = new System.Windows.Forms.Button();
            this.BTN_MoveUp = new System.Windows.Forms.Button();
            this.BTN_MoveDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_Remove = new System.Windows.Forms.Button();
            this.BTN_Add = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.dgvHeaders = new System.Windows.Forms.DataGridView();
            this.sliderInfo = new Video.Controls.ColorSlider();
            this.sliderZoom = new Video.Controls.ColorSlider();
            this.timePicker = new VideoPlayer.FlatDateTimePicker();
            this.sliderV = new Video.Controls.ColorSlider();
            this.videoSlider1 = new TimeControl.VideoSlider();
            this.sliderH = new Video.Controls.ColorSlider();
            this.PANEL_Display.SuspendLayout();
            this.PANEL_ThumbTime.SuspendLayout();
            this.mediaAxis1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Buttons)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).BeginInit();
            this.SuspendLayout();
            // 
            // PANEL_Display
            // 
            this.PANEL_Display.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PANEL_Display.Controls.Add(this.label1);
            this.PANEL_Display.Controls.Add(this.LABEL_Zoom);
            this.PANEL_Display.Controls.Add(this.sliderZoom);
            this.PANEL_Display.Controls.Add(this.BTN_Goto);
            this.PANEL_Display.Controls.Add(this.timePicker);
            this.PANEL_Display.Controls.Add(this.PANEL_ThumbTime);
            this.PANEL_Display.Location = new System.Drawing.Point(101, 372);
            this.PANEL_Display.Name = "PANEL_Display";
            this.PANEL_Display.Size = new System.Drawing.Size(647, 25);
            this.PANEL_Display.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Zoom";
            // 
            // LABEL_Zoom
            // 
            this.LABEL_Zoom.AutoSize = true;
            this.LABEL_Zoom.ForeColor = System.Drawing.Color.White;
            this.LABEL_Zoom.Location = new System.Drawing.Point(142, 7);
            this.LABEL_Zoom.Name = "LABEL_Zoom";
            this.LABEL_Zoom.Size = new System.Drawing.Size(45, 13);
            this.LABEL_Zoom.TabIndex = 201;
            this.LABEL_Zoom.Text = "24 HRS";
            // 
            // BTN_Goto
            // 
            this.BTN_Goto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Goto.Enabled = false;
            this.BTN_Goto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Goto.Location = new System.Drawing.Point(487, 2);
            this.BTN_Goto.Name = "BTN_Goto";
            this.BTN_Goto.Size = new System.Drawing.Size(71, 22);
            this.BTN_Goto.TabIndex = 198;
            this.BTN_Goto.Text = "GO TO";
            this.BTN_Goto.UseVisualStyleBackColor = true;
            this.BTN_Goto.Visible = false;
            this.BTN_Goto.Click += new System.EventHandler(this.BTN_Goto_Click);
            // 
            // PANEL_ThumbTime
            // 
            this.PANEL_ThumbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.PANEL_ThumbTime.Controls.Add(this.LABEL_AMPM);
            this.PANEL_ThumbTime.Controls.Add(this.LABEL_ThumbTime);
            this.PANEL_ThumbTime.Location = new System.Drawing.Point(281, 2);
            this.PANEL_ThumbTime.Name = "PANEL_ThumbTime";
            this.PANEL_ThumbTime.Size = new System.Drawing.Size(106, 21);
            this.PANEL_ThumbTime.TabIndex = 2;
            // 
            // LABEL_AMPM
            // 
            this.LABEL_AMPM.AutoSize = true;
            this.LABEL_AMPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.LABEL_AMPM.Location = new System.Drawing.Point(202, 1);
            this.LABEL_AMPM.Margin = new System.Windows.Forms.Padding(0);
            this.LABEL_AMPM.Name = "LABEL_AMPM";
            this.LABEL_AMPM.Size = new System.Drawing.Size(0, 22);
            this.LABEL_AMPM.TabIndex = 10;
            this.LABEL_AMPM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LABEL_AMPM.Visible = false;
            // 
            // LABEL_ThumbTime
            // 
            this.LABEL_ThumbTime.AutoSize = true;
            this.LABEL_ThumbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.LABEL_ThumbTime.ForeColor = System.Drawing.Color.White;
            this.LABEL_ThumbTime.Location = new System.Drawing.Point(18, -1);
            this.LABEL_ThumbTime.Margin = new System.Windows.Forms.Padding(0);
            this.LABEL_ThumbTime.Name = "LABEL_ThumbTime";
            this.LABEL_ThumbTime.Size = new System.Drawing.Size(80, 22);
            this.LABEL_ThumbTime.TabIndex = 4;
            this.LABEL_ThumbTime.Text = "00:00:00";
            this.LABEL_ThumbTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mediaAxis1
            // 
            this.mediaAxis1.Controls.Add(this.PANEL_Buttons);
            this.mediaAxis1.Location = new System.Drawing.Point(0, 23);
            this.mediaAxis1.Margin = new System.Windows.Forms.Padding(0);
            this.mediaAxis1.Name = "mediaAxis1";
            this.mediaAxis1.Size = new System.Drawing.Size(101, 327);
            this.mediaAxis1.TabIndex = 5;
            // 
            // PANEL_Buttons
            // 
            this.PANEL_Buttons.AllowUserToAddRows = false;
            this.PANEL_Buttons.AllowUserToDeleteRows = false;
            this.PANEL_Buttons.AllowUserToResizeColumns = false;
            this.PANEL_Buttons.AllowUserToResizeRows = false;
            this.PANEL_Buttons.BackgroundColor = System.Drawing.Color.Gray;
            this.PANEL_Buttons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PANEL_Buttons.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PANEL_Buttons.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.PANEL_Buttons.ColumnHeadersHeight = 16;
            this.PANEL_Buttons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PANEL_Buttons.ColumnHeadersVisible = false;
            this.PANEL_Buttons.Location = new System.Drawing.Point(0, 0);
            this.PANEL_Buttons.MultiSelect = false;
            this.PANEL_Buttons.Name = "PANEL_Buttons";
            this.PANEL_Buttons.ReadOnly = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.PANEL_Buttons.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.PANEL_Buttons.RowTemplate.Height = 30;
            this.PANEL_Buttons.RowTemplate.ReadOnly = true;
            this.PANEL_Buttons.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PANEL_Buttons.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.PANEL_Buttons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PANEL_Buttons.Size = new System.Drawing.Size(101, 345);
            this.PANEL_Buttons.TabIndex = 1;
            this.PANEL_Buttons.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PANEL_Buttons_CellContentClick);
            this.PANEL_Buttons.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PANEL_Buttons_RowEnter);
            this.PANEL_Buttons.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PANEL_Buttons_Scroll);
            // 
            // BTN_MoveLeft
            // 
            this.BTN_MoveLeft.FlatAppearance.BorderSize = 0;
            this.BTN_MoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MoveLeft.Location = new System.Drawing.Point(100, -3);
            this.BTN_MoveLeft.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_MoveLeft.Name = "BTN_MoveLeft";
            this.BTN_MoveLeft.Size = new System.Drawing.Size(20, 20);
            this.BTN_MoveLeft.TabIndex = 6;
            this.BTN_MoveLeft.UseVisualStyleBackColor = true;
            this.BTN_MoveLeft.Visible = false;
            this.BTN_MoveLeft.Click += new System.EventHandler(this.BTN_MoveLeft_Click);
            // 
            // BTN_MoveRight
            // 
            this.BTN_MoveRight.FlatAppearance.BorderSize = 0;
            this.BTN_MoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MoveRight.Location = new System.Drawing.Point(728, -3);
            this.BTN_MoveRight.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_MoveRight.Name = "BTN_MoveRight";
            this.BTN_MoveRight.Size = new System.Drawing.Size(20, 20);
            this.BTN_MoveRight.TabIndex = 7;
            this.BTN_MoveRight.UseVisualStyleBackColor = true;
            this.BTN_MoveRight.Visible = false;
            this.BTN_MoveRight.Click += new System.EventHandler(this.BTN_MoveRight_Click);
            // 
            // BTN_MoveUp
            // 
            this.BTN_MoveUp.FlatAppearance.BorderSize = 0;
            this.BTN_MoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MoveUp.Location = new System.Drawing.Point(748, 21);
            this.BTN_MoveUp.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_MoveUp.Name = "BTN_MoveUp";
            this.BTN_MoveUp.Size = new System.Drawing.Size(20, 20);
            this.BTN_MoveUp.TabIndex = 8;
            this.BTN_MoveUp.UseVisualStyleBackColor = true;
            this.BTN_MoveUp.Visible = false;
            this.BTN_MoveUp.Click += new System.EventHandler(this.BTN_MoveUp_Click);
            // 
            // BTN_MoveDown
            // 
            this.BTN_MoveDown.FlatAppearance.BorderSize = 0;
            this.BTN_MoveDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_MoveDown.Location = new System.Drawing.Point(748, 352);
            this.BTN_MoveDown.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_MoveDown.Name = "BTN_MoveDown";
            this.BTN_MoveDown.Size = new System.Drawing.Size(20, 20);
            this.BTN_MoveDown.TabIndex = 9;
            this.BTN_MoveDown.UseVisualStyleBackColor = true;
            this.BTN_MoveDown.Visible = false;
            this.BTN_MoveDown.Click += new System.EventHandler(this.BTN_MoveDown_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.BTN_Remove);
            this.panel1.Controls.Add(this.BTN_Add);
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(95, 23);
            this.panel1.TabIndex = 10;
            // 
            // BTN_Remove
            // 
            this.BTN_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Remove.Location = new System.Drawing.Point(40, 0);
            this.BTN_Remove.Name = "BTN_Remove";
            this.BTN_Remove.Size = new System.Drawing.Size(56, 22);
            this.BTN_Remove.TabIndex = 200;
            this.BTN_Remove.Text = "Remove";
            this.BTN_Remove.UseVisualStyleBackColor = true;
            this.BTN_Remove.Click += new System.EventHandler(this.BTN_Remove_Click);
            // 
            // BTN_Add
            // 
            this.BTN_Add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Add.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Add.Location = new System.Drawing.Point(2, 0);
            this.BTN_Add.Name = "BTN_Add";
            this.BTN_Add.Size = new System.Drawing.Size(37, 22);
            this.BTN_Add.TabIndex = 199;
            this.BTN_Add.Text = "Add";
            this.BTN_Add.UseVisualStyleBackColor = true;
            this.BTN_Add.Click += new System.EventHandler(this.BTN_Add_Click);
            // 
            // dgvHeaders
            // 
            this.dgvHeaders.AllowUserToAddRows = false;
            this.dgvHeaders.AllowUserToDeleteRows = false;
            this.dgvHeaders.AllowUserToResizeColumns = false;
            this.dgvHeaders.AllowUserToResizeRows = false;
            this.dgvHeaders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHeaders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvHeaders.ColumnHeadersHeight = 25;
            this.dgvHeaders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHeaders.Location = new System.Drawing.Point(0, 0);
            this.dgvHeaders.MultiSelect = false;
            this.dgvHeaders.Name = "dgvHeaders";
            this.dgvHeaders.ReadOnly = true;
            this.dgvHeaders.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvHeaders.RowTemplate.ReadOnly = true;
            this.dgvHeaders.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvHeaders.ShowCellErrors = false;
            this.dgvHeaders.ShowCellToolTips = false;
            this.dgvHeaders.ShowEditingIcon = false;
            this.dgvHeaders.ShowRowErrors = false;
            this.dgvHeaders.Size = new System.Drawing.Size(97, 22);
            this.dgvHeaders.TabIndex = 202;
            // 
            // sliderInfo
            // 
            this.sliderInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sliderInfo.BackColor = System.Drawing.Color.Transparent;
            this.sliderInfo.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderInfo.LargeChange = ((uint)(1u));
            this.sliderInfo.Location = new System.Drawing.Point(2, 354);
            this.sliderInfo.Margin = new System.Windows.Forms.Padding(0);
            this.sliderInfo.Maximum = 1;
            this.sliderInfo.MouseWheelBarPartitions = 1;
            this.sliderInfo.Name = "sliderInfo";
            this.sliderInfo.Size = new System.Drawing.Size(94, 15);
            this.sliderInfo.SmallChange = ((uint)(1u));
            this.sliderInfo.TabIndex = 201;
            this.sliderInfo.Text = "colorSlider1";
            this.sliderInfo.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderInfo.Value = 0;
            this.sliderInfo.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderInfo_Scroll);
            // 
            // sliderZoom
            // 
            this.sliderZoom.BackColor = System.Drawing.Color.Transparent;
            this.sliderZoom.BarInnerColor = System.Drawing.Color.Blue;
            this.sliderZoom.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderZoom.LargeChange = ((uint)(1u));
            this.sliderZoom.Location = new System.Drawing.Point(40, 6);
            this.sliderZoom.Margin = new System.Windows.Forms.Padding(0);
            this.sliderZoom.Maximum = 5;
            this.sliderZoom.MouseWheelBarPartitions = 1;
            this.sliderZoom.Name = "sliderZoom";
            this.sliderZoom.Size = new System.Drawing.Size(99, 15);
            this.sliderZoom.SmallChange = ((uint)(1u));
            this.sliderZoom.TabIndex = 200;
            this.sliderZoom.Text = "colorSlider1";
            this.sliderZoom.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderZoom.Value = 0;
            this.sliderZoom.ValueChanged += new System.EventHandler(this.sliderZoom_ValueChanged);
            this.sliderZoom.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderZoom_Scroll);
            // 
            // timePicker
            // 
            this.timePicker.CalendarForeColor = System.Drawing.Color.DimGray;
            this.timePicker.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.timePicker.CalendarTitleBackColor = System.Drawing.Color.WhiteSmoke;
            this.timePicker.CalendarTitleForeColor = System.Drawing.SystemColors.Desktop;
            this.timePicker.CustomFormat = "";
            this.timePicker.Enabled = false;
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timePicker.Location = new System.Drawing.Point(559, 2);
            this.timePicker.Margin = new System.Windows.Forms.Padding(0);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(88, 20);
            this.timePicker.TabIndex = 199;
            this.timePicker.Value = new System.DateTime(2008, 5, 1, 12, 0, 0, 0);
            this.timePicker.Visible = false;
            // 
            // sliderV
            // 
            this.sliderV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderV.BackColor = System.Drawing.Color.Transparent;
            this.sliderV.BarInnerColor = System.Drawing.Color.DarkBlue;
            this.sliderV.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderV.LargeChange = ((uint)(60u));
            this.sliderV.Location = new System.Drawing.Point(748, 21);
            this.sliderV.Name = "sliderV";
            this.sliderV.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.sliderV.Size = new System.Drawing.Size(15, 351);
            this.sliderV.SmallChange = ((uint)(60u));
            this.sliderV.TabIndex = 2;
            this.sliderV.Text = "colorSlider2";
            this.sliderV.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderV.Value = 0;
            this.sliderV.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderV_Scroll);
            // 
            // videoSlider1
            // 
            this.videoSlider1.BackColor = System.Drawing.Color.Gray;
            this.videoSlider1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BarInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BarOffsetY = 0F;
            this.videoSlider1.BarOuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.videoSlider1.BarSelectedPenColor = System.Drawing.Color.Orange;
            this.videoSlider1.BorderRoundRectSize = new System.Drawing.Size(2, 2);
            this.videoSlider1.ChartColor = System.Drawing.Color.Lime;
            this.videoSlider1.DataRect = ((System.Drawing.RectangleF)(resources.GetObject("videoSlider1.DataRect")));
            this.videoSlider1.displayDate = "05/5/2008";
            this.videoSlider1.LargeChange = ((uint)(5u));
            this.videoSlider1.Location = new System.Drawing.Point(104, 23);
            this.videoSlider1.Margin = new System.Windows.Forms.Padding(0);
            this.videoSlider1.Name = "videoSlider1";
            this.videoSlider1.ScreenOffsetY = 0F;
            this.videoSlider1.Size = new System.Drawing.Size(644, 356);
            this.videoSlider1.SmallChange = ((uint)(1u));
            this.videoSlider1.TabIndex = 0;
            this.videoSlider1.ThumbRoundRectSize = new System.Drawing.Size(2, 2);
            this.videoSlider1.Time24 = true;
            this.videoSlider1.XLabel = "";
            this.videoSlider1.YLabel = "camera 01";
            this.videoSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.videoSlider1_Scroll);
            // 
            // sliderH
            // 
            this.sliderH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderH.BackColor = System.Drawing.Color.Transparent;
            this.sliderH.BarInnerColor = System.Drawing.Color.DarkBlue;
            this.sliderH.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderH.Enabled = false;
            this.sliderH.LargeChange = ((uint)(1u));
            this.sliderH.Location = new System.Drawing.Point(101, 0);
            this.sliderH.Margin = new System.Windows.Forms.Padding(0);
            this.sliderH.Maximum = 2;
            this.sliderH.Name = "sliderH";
            this.sliderH.Size = new System.Drawing.Size(647, 15);
            this.sliderH.SmallChange = ((uint)(1u));
            this.sliderH.TabIndex = 1;
            this.sliderH.Text = "colorSlider1";
            this.sliderH.ThumbRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderH.Value = 0;
            this.sliderH.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderH_Scroll);
            this.sliderH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sliderH_MouseDown);
            // 
            // SliderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvHeaders);
            this.Controls.Add(this.sliderInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BTN_MoveRight);
            this.Controls.Add(this.BTN_MoveDown);
            this.Controls.Add(this.BTN_MoveUp);
            this.Controls.Add(this.BTN_MoveLeft);
            this.Controls.Add(this.mediaAxis1);
            this.Controls.Add(this.PANEL_Display);
            this.Controls.Add(this.sliderV);
            this.Controls.Add(this.videoSlider1);
            this.Controls.Add(this.sliderH);
            this.Name = "SliderControl";
            this.Size = new System.Drawing.Size(766, 397);
            this.Load += new System.EventHandler(this.SliderControl_Load);
            this.Resize += new System.EventHandler(this.SliderControl_Resize);
            this.PANEL_Display.ResumeLayout(false);
            this.PANEL_Display.PerformLayout();
            this.PANEL_ThumbTime.ResumeLayout(false);
            this.PANEL_ThumbTime.PerformLayout();
            this.mediaAxis1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PANEL_Buttons)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHeaders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public VideoSlider videoSlider1;
        private Video.Controls.ColorSlider sliderH;
        private System.Windows.Forms.Panel PANEL_Display;
        private System.Windows.Forms.Panel PANEL_ThumbTime;
        public System.Windows.Forms.Label LABEL_AMPM;
        public System.Windows.Forms.Label LABEL_ThumbTime;
        public System.Windows.Forms.Panel mediaAxis1;
        public System.Windows.Forms.Button BTN_Goto;
        public VideoPlayer.FlatDateTimePicker timePicker;
        private System.Windows.Forms.Label LABEL_Zoom;
        private Video.Controls.ColorSlider sliderZoom;
        private System.Windows.Forms.Button BTN_MoveLeft;
        private System.Windows.Forms.Button BTN_MoveRight;
        private System.Windows.Forms.Button BTN_MoveUp;
        private System.Windows.Forms.Button BTN_MoveDown;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button BTN_Remove;
        public System.Windows.Forms.Button BTN_Add;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        public System.Windows.Forms.DataGridView PANEL_Buttons;
        private Video.Controls.ColorSlider sliderInfo;
        private System.Windows.Forms.DataGridView dgvHeaders;
        private Video.Controls.ColorSlider sliderV;




    }
}
