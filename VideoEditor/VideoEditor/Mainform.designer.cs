namespace CitiesCMS
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Shot Detection", 3);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Searching Area", 2);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.startMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCurrentUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.emailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCurrentUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolBar = new System.Windows.Forms.ToolStrip();
            this.cmdMovieSearch = new System.Windows.Forms.ToolStripButton();
            this.cmdOpenDrawer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.navigationPane1 = new DevComponents.DotNetBar.NavigationPane();
            this.navigationPanePanel1 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.lvNav = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel5 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.buttonItem5 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel4 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonItem4 = new DevComponents.DotNetBar.ButtonItem();
            this.navigationPanePanel3 = new DevComponents.DotNetBar.NavigationPanePanel();
            this.lvCustomer = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonItem3 = new DevComponents.DotNetBar.ButtonItem();
            this.tabStrip1 = new DevComponents.DotNetBar.TabStrip();
            this.i16x16 = new System.Windows.Forms.ImageList(this.components);
            this.i32x32 = new System.Windows.Forms.ImageList(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolBar.SuspendLayout();
            this.navigationPane1.SuspendLayout();
            this.navigationPanePanel1.SuspendLayout();
            this.navigationPanePanel4.SuspendLayout();
            this.navigationPanePanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMenu,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // startMenu
            // 
            this.startMenu.BackColor = System.Drawing.Color.Transparent;
            this.startMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCurrentUser,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.startMenu.ForeColor = System.Drawing.Color.Black;
            this.startMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startMenu.ImageTransparentColor = System.Drawing.Color.Black;
            this.startMenu.Name = "startMenu";
            this.startMenu.Size = new System.Drawing.Size(54, 20);
            this.startMenu.Text = "Action";
            // 
            // mnuCurrentUser
            // 
            this.mnuCurrentUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mnuCurrentUser.Name = "mnuCurrentUser";
            this.mnuCurrentUser.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuCurrentUser.Size = new System.Drawing.Size(123, 22);
            this.mnuCurrentUser.Text = "Login";
            this.mnuCurrentUser.Click += new System.EventHandler(this.mnuCurrentUser_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(120, 6);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(120, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchUserToolStripMenuItem,
            this.logOffToolStripMenuItem,
            this.lockToolStripMenuItem});
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // switchUserToolStripMenuItem
            // 
            this.switchUserToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("switchUserToolStripMenuItem.Image")));
            this.switchUserToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.switchUserToolStripMenuItem.Name = "switchUserToolStripMenuItem";
            this.switchUserToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.switchUserToolStripMenuItem.Text = "Switch User";
            // 
            // logOffToolStripMenuItem
            // 
            this.logOffToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logOffToolStripMenuItem.Image")));
            this.logOffToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logOffToolStripMenuItem.Name = "logOffToolStripMenuItem";
            this.logOffToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.logOffToolStripMenuItem.Text = "Log off";
            this.logOffToolStripMenuItem.Click += new System.EventHandler(this.logOffToolStripMenuItem_Click);
            // 
            // lockToolStripMenuItem
            // 
            this.lockToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lockToolStripMenuItem.Image")));
            this.lockToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.lockToolStripMenuItem.Name = "lockToolStripMenuItem";
            this.lockToolStripMenuItem.Size = new System.Drawing.Size(151, 38);
            this.lockToolStripMenuItem.Text = "Lock";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.emailToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(161, 6);
            // 
            // emailToolStripMenuItem
            // 
            this.emailToolStripMenuItem.Name = "emailToolStripMenuItem";
            this.emailToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.emailToolStripMenuItem.Text = "Backup Database";
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.restoreToolStripMenuItem.Text = "&Restore Database";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingsToolStripMenuItem.Image")));
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripMenuItem7,
            this.toolStripMenuItem10});
            this.toolStripMenuItem2.ForeColor = System.Drawing.Color.Black;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItem2.Text = "&Windows";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem3.Text = "&New Window";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem4.Text = "&Cascade";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem5.Text = "Tile &Vertical";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem6.Text = "Tile &Horizontal";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem7.Text = "C&lose All";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(151, 22);
            this.toolStripMenuItem10.Text = "&Arrange Icons";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtCurrentUser});
            this.statusStrip1.Location = new System.Drawing.Point(0, 554);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1028, 24);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 19);
            this.toolStripStatusLabel1.Text = "Current User:";
            // 
            // txtCurrentUser
            // 
            this.txtCurrentUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.txtCurrentUser.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.txtCurrentUser.Name = "txtCurrentUser";
            this.txtCurrentUser.Size = new System.Drawing.Size(39, 19);
            this.txtCurrentUser.Text = "<....>";
            // 
            // toolBar
            // 
            this.toolBar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdMovieSearch,
            this.cmdOpenDrawer,
            this.toolStripSeparator10});
            this.toolBar.Location = new System.Drawing.Point(0, 24);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(1028, 39);
            this.toolBar.TabIndex = 4;
            this.toolBar.Text = "toolStrip1";
            // 
            // cmdMovieSearch
            // 
            this.cmdMovieSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdMovieSearch.Image = ((System.Drawing.Image)(resources.GetObject("cmdMovieSearch.Image")));
            this.cmdMovieSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdMovieSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdMovieSearch.Name = "cmdMovieSearch";
            this.cmdMovieSearch.Size = new System.Drawing.Size(36, 36);
            this.cmdMovieSearch.Text = "Movie Search";
            this.cmdMovieSearch.Click += new System.EventHandler(this.cmdMovieSearch_Click);
            // 
            // cmdOpenDrawer
            // 
            this.cmdOpenDrawer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdOpenDrawer.Image = ((System.Drawing.Image)(resources.GetObject("cmdOpenDrawer.Image")));
            this.cmdOpenDrawer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cmdOpenDrawer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdOpenDrawer.Name = "cmdOpenDrawer";
            this.cmdOpenDrawer.Size = new System.Drawing.Size(36, 36);
            this.cmdOpenDrawer.Text = "Email";
            this.cmdOpenDrawer.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 39);
            // 
            // panelEx1
            // 
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(164, 746);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 62;
            this.panelEx1.Text = "Click to collapse";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panelEx1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter1.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(164, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(8, 746);
            this.expandableSplitter1.TabIndex = 63;
            this.expandableSplitter1.TabStop = false;
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.ForeColor = System.Drawing.Color.Black;
            this.expandableSplitter2.GripDarkColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(142)))), ((int)(((byte)(75)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(207)))), ((int)(((byte)(139)))));
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.SystemColors.ControlText;
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(150)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(164, 0);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(8, 746);
            this.expandableSplitter2.TabIndex = 63;
            this.expandableSplitter2.TabStop = false;
            // 
            // ribbonControl1
            // 
            // 
            // 
            // 
            this.ribbonControl1.BackgroundStyle.Class = "";
            this.ribbonControl1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControl1.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControl1.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControl1.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControl1.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControl1.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControl1.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControl1.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControl1.SystemText.QatDialogOkButton = "OK";
            this.ribbonControl1.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControl1.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControl1.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControl1.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            // 
            // navigationPane1
            // 
            this.navigationPane1.CanCollapse = true;
            this.navigationPane1.Controls.Add(this.navigationPanePanel1);
            this.navigationPane1.Controls.Add(this.navigationPane1.TitlePanel);
            this.navigationPane1.Controls.Add(this.navigationPanePanel5);
            this.navigationPane1.Controls.Add(this.navigationPanePanel4);
            this.navigationPane1.Controls.Add(this.navigationPanePanel3);
            this.navigationPane1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navigationPane1.ItemPaddingBottom = 2;
            this.navigationPane1.ItemPaddingTop = 2;
            this.navigationPane1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem1,
            this.buttonItem3,
            this.buttonItem4,
            this.buttonItem5});
            this.navigationPane1.Location = new System.Drawing.Point(0, 63);
            this.navigationPane1.Name = "navigationPane1";
            this.navigationPane1.NavigationBarHeight = 172;
            this.navigationPane1.Padding = new System.Windows.Forms.Padding(1);
            this.navigationPane1.Size = new System.Drawing.Size(184, 491);
            this.navigationPane1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPane1.TabIndex = 8;
            // 
            // navigationPanePanel1
            // 
            this.navigationPanePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel1.Controls.Add(this.lvNav);
            this.navigationPanePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel1.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel1.Name = "navigationPanePanel1";
            this.navigationPanePanel1.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.navigationPanePanel1.ParentItem = this.buttonItem1;
            this.navigationPanePanel1.Size = new System.Drawing.Size(182, 317);
            this.navigationPanePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel1.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel1.Style.GradientAngle = 90;
            this.navigationPanePanel1.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel1.TabIndex = 2;
            // 
            // lvNav
            // 
            this.lvNav.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNav.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            listViewItem1.ToolTipText = "Shot Detection";
            listViewItem2.ToolTipText = "Searching Area";
            this.lvNav.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2});
            this.lvNav.Location = new System.Drawing.Point(1, 1);
            this.lvNav.Name = "lvNav";
            this.lvNav.Size = new System.Drawing.Size(180, 316);
            this.lvNav.SmallImageList = this.imageList1;
            this.lvNav.TabIndex = 0;
            this.lvNav.UseCompatibleStateImageBehavior = false;
            this.lvNav.View = System.Windows.Forms.View.SmallIcon;
            this.lvNav.SelectedIndexChanged += new System.EventHandler(this.lvNav_SelectedIndexChanged);
            this.lvNav.DoubleClick += new System.EventHandler(this.lvNav_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "CheckMark.png");
            this.imageList1.Images.SetKeyName(1, "User3.png");
            this.imageList1.Images.SetKeyName(2, "email.gif");
            this.imageList1.Images.SetKeyName(3, "1438.ico");
            this.imageList1.Images.SetKeyName(4, "box.ico");
            this.imageList1.Images.SetKeyName(5, "money.gif");
            this.imageList1.Images.SetKeyName(6, "Gold Coin - Stacks.png");
            this.imageList1.Images.SetKeyName(7, "box.ico");
            this.imageList1.Images.SetKeyName(8, "brief_case.ico");
            this.imageList1.Images.SetKeyName(9, "credit-cards.png");
            this.imageList1.Images.SetKeyName(10, "empty-shopping-cart.png");
            this.imageList1.Images.SetKeyName(11, "NewInvoice.png");
            this.imageList1.Images.SetKeyName(12, "package.gif");
            this.imageList1.Images.SetKeyName(13, "prodotti.gif");
            this.imageList1.Images.SetKeyName(14, "Shopping Cart.png");
            this.imageList1.Images.SetKeyName(15, "shopping-bag.png");
            this.imageList1.Images.SetKeyName(16, "Wholesale.png");
            // 
            // buttonItem1
            // 
            this.buttonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem1.Checked = true;
            this.buttonItem1.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem1.Image")));
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.OptionGroup = "navBar";
            this.buttonItem1.SubItemsExpandWidth = 11;
            this.buttonItem1.Text = "خيارات سريعة";
            this.buttonItem1.Tooltip = "Click to manage Quick Launch";
            // 
            // navigationPanePanel5
            // 
            this.navigationPanePanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel5.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel5.Name = "navigationPanePanel5";
            this.navigationPanePanel5.ParentItem = this.buttonItem5;
            this.navigationPanePanel5.Size = new System.Drawing.Size(182, 317);
            this.navigationPanePanel5.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel5.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel5.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel5.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel5.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel5.Style.GradientAngle = 90;
            this.navigationPanePanel5.Style.WordWrap = true;
            this.navigationPanePanel5.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel5.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel5.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel5.TabIndex = 6;
            this.navigationPanePanel5.Text = "Drop your controls here and erase Text property";
            // 
            // buttonItem5
            // 
            this.buttonItem5.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem5.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem5.Image")));
            this.buttonItem5.Name = "buttonItem5";
            this.buttonItem5.OptionGroup = "navBar";
            this.buttonItem5.SubItemsExpandWidth = 11;
            this.buttonItem5.Text = "Notes";
            // 
            // navigationPanePanel4
            // 
            this.navigationPanePanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel4.Controls.Add(this.listView1);
            this.navigationPanePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel4.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel4.Name = "navigationPanePanel4";
            this.navigationPanePanel4.ParentItem = this.buttonItem4;
            this.navigationPanePanel4.Size = new System.Drawing.Size(182, 317);
            this.navigationPanePanel4.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel4.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel4.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel4.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel4.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel4.Style.GradientAngle = 90;
            this.navigationPanePanel4.Style.WordWrap = true;
            this.navigationPanePanel4.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel4.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel4.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel4.TabIndex = 5;
            this.navigationPanePanel4.Text = "Drop your controls here and erase Text property";
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(182, 317);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.SmallIcon;
            // 
            // buttonItem4
            // 
            this.buttonItem4.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem4.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem4.Image")));
            this.buttonItem4.Name = "buttonItem4";
            this.buttonItem4.OptionGroup = "navBar";
            this.buttonItem4.SubItemsExpandWidth = 11;
            this.buttonItem4.Text = "خيارات أخرى";
            // 
            // navigationPanePanel3
            // 
            this.navigationPanePanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.navigationPanePanel3.Controls.Add(this.lvCustomer);
            this.navigationPanePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationPanePanel3.Location = new System.Drawing.Point(1, 1);
            this.navigationPanePanel3.Name = "navigationPanePanel3";
            this.navigationPanePanel3.ParentItem = this.buttonItem3;
            this.navigationPanePanel3.Size = new System.Drawing.Size(182, 317);
            this.navigationPanePanel3.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.navigationPanePanel3.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.navigationPanePanel3.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.Tile;
            this.navigationPanePanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.navigationPanePanel3.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.navigationPanePanel3.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.navigationPanePanel3.Style.GradientAngle = 90;
            this.navigationPanePanel3.Style.WordWrap = true;
            this.navigationPanePanel3.StyleMouseDown.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.StyleMouseDown.WordWrap = true;
            this.navigationPanePanel3.StyleMouseOver.Alignment = System.Drawing.StringAlignment.Center;
            this.navigationPanePanel3.StyleMouseOver.WordWrap = true;
            this.navigationPanePanel3.TabIndex = 4;
            this.navigationPanePanel3.Text = "Drop your controls here and erase Text property";
            // 
            // lvCustomer
            // 
            this.lvCustomer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCustomer.FullRowSelect = true;
            this.lvCustomer.Location = new System.Drawing.Point(0, 0);
            this.lvCustomer.Name = "lvCustomer";
            this.lvCustomer.RightToLeftLayout = true;
            this.lvCustomer.Size = new System.Drawing.Size(182, 317);
            this.lvCustomer.SmallImageList = this.imageList1;
            this.lvCustomer.TabIndex = 1;
            this.lvCustomer.UseCompatibleStateImageBehavior = false;
            this.lvCustomer.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "القرى السياحية";
            this.columnHeader1.Width = 178;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 0;
            // 
            // buttonItem3
            // 
            this.buttonItem3.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
            this.buttonItem3.Image = ((System.Drawing.Image)(resources.GetObject("buttonItem3.Image")));
            this.buttonItem3.Name = "buttonItem3";
            this.buttonItem3.OptionGroup = "navBar";
            this.buttonItem3.SubItemsExpandWidth = 11;
            this.buttonItem3.Text = "القرى السياحية";
            this.buttonItem3.Tooltip = "اضغط هنا لعرض القائمة";
            this.buttonItem3.Click += new System.EventHandler(this.buttonItem3_Click);
            // 
            // tabStrip1
            // 
            this.tabStrip1.AutoSelectAttachedControl = true;
            this.tabStrip1.CanReorderTabs = true;
            this.tabStrip1.CloseButtonOnTabsVisible = true;
            this.tabStrip1.CloseButtonVisible = false;
            this.tabStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabStrip1.Location = new System.Drawing.Point(184, 63);
            this.tabStrip1.MdiForm = this;
            this.tabStrip1.MdiTabbedDocuments = true;
            this.tabStrip1.Name = "tabStrip1";
            this.tabStrip1.SelectedTab = null;
            this.tabStrip1.SelectedTabFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabStrip1.Size = new System.Drawing.Size(844, 26);
            this.tabStrip1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabStrip1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top;
            this.tabStrip1.TabIndex = 9;
            this.tabStrip1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabStrip1.Text = "tabStrip1";
            // 
            // i16x16
            // 
            this.i16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("i16x16.ImageStream")));
            this.i16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.i16x16.Images.SetKeyName(0, "");
            this.i16x16.Images.SetKeyName(1, "");
            this.i16x16.Images.SetKeyName(2, "");
            this.i16x16.Images.SetKeyName(3, "");
            this.i16x16.Images.SetKeyName(4, "");
            this.i16x16.Images.SetKeyName(5, "");
            this.i16x16.Images.SetKeyName(6, "");
            this.i16x16.Images.SetKeyName(7, "");
            this.i16x16.Images.SetKeyName(8, "");
            this.i16x16.Images.SetKeyName(9, "");
            this.i16x16.Images.SetKeyName(10, "");
            this.i16x16.Images.SetKeyName(11, "");
            this.i16x16.Images.SetKeyName(12, "");
            this.i16x16.Images.SetKeyName(13, "");
            this.i16x16.Images.SetKeyName(14, "");
            this.i16x16.Images.SetKeyName(15, "");
            this.i16x16.Images.SetKeyName(16, "");
            this.i16x16.Images.SetKeyName(17, "");
            this.i16x16.Images.SetKeyName(18, "");
            this.i16x16.Images.SetKeyName(19, "");
            this.i16x16.Images.SetKeyName(20, "");
            this.i16x16.Images.SetKeyName(21, "");
            this.i16x16.Images.SetKeyName(22, "");
            this.i16x16.Images.SetKeyName(23, "");
            // 
            // i32x32
            // 
            this.i32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("i32x32.ImageStream")));
            this.i32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.i32x32.Images.SetKeyName(0, "");
            this.i32x32.Images.SetKeyName(1, "");
            this.i32x32.Images.SetKeyName(2, "");
            this.i32x32.Images.SetKeyName(3, "");
            this.i32x32.Images.SetKeyName(4, "");
            this.i32x32.Images.SetKeyName(5, "");
            this.i32x32.Images.SetKeyName(6, "");
            this.i32x32.Images.SetKeyName(7, "");
            this.i32x32.Images.SetKeyName(8, "");
            this.i32x32.Images.SetKeyName(9, "");
            this.i32x32.Images.SetKeyName(10, "");
            this.i32x32.Images.SetKeyName(11, "");
            this.i32x32.Images.SetKeyName(12, "");
            this.i32x32.Images.SetKeyName(13, "");
            this.i32x32.Images.SetKeyName(14, "");
            this.i32x32.Images.SetKeyName(15, "");
            this.i32x32.Images.SetKeyName(16, "");
            this.i32x32.Images.SetKeyName(17, "");
            this.i32x32.Images.SetKeyName(18, "");
            this.i32x32.Images.SetKeyName(19, "");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1028, 578);
            this.Controls.Add(this.tabStrip1);
            this.Controls.Add(this.navigationPane1);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "TV Archiving System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolBar.ResumeLayout(false);
            this.toolBar.PerformLayout();
            this.navigationPane1.ResumeLayout(false);
            this.navigationPanePanel1.ResumeLayout(false);
            this.navigationPanePanel4.ResumeLayout(false);
            this.navigationPanePanel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem startMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem switchUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuCurrentUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        public System.Windows.Forms.ToolStripStatusLabel txtCurrentUser;
        private System.Windows.Forms.ToolStrip toolBar;
        private System.Windows.Forms.ToolStripButton cmdMovieSearch;
        private System.Windows.Forms.ToolStripButton cmdOpenDrawer;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private DevComponents.DotNetBar.NavigationPane navigationPane1;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel3;
        private DevComponents.DotNetBar.ButtonItem buttonItem3;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel5;
        private DevComponents.DotNetBar.ButtonItem buttonItem5;
        private DevComponents.DotNetBar.NavigationPanePanel navigationPanePanel4;
        private DevComponents.DotNetBar.ButtonItem buttonItem4;
        private DevComponents.DotNetBar.TabStrip tabStrip1;
        private System.Windows.Forms.ListView lvNav;
        private System.Windows.Forms.ListView lvCustomer;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView listView1;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ImageList i16x16;
        public System.Windows.Forms.ImageList i32x32;
        public System.Windows.Forms.ToolTip toolTip1;
    }
}



