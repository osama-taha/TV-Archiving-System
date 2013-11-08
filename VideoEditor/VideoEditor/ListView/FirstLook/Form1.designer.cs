using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Telerik.Examples.WinControls.ListView.FirstLook
{
    partial class Form1 : RadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Telerik.WinControls.UI.RadListDataItem radListDataItem46 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem47 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem48 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem49 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem50 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem51 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem52 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem53 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem54 = new Telerik.WinControls.UI.RadListDataItem();
            this.settingsPanel = new Telerik.WinControls.UI.RadPanel();
            this.btnSpy = new Telerik.WinControls.UI.RadButton();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.commandBarLabel1 = new Telerik.WinControls.UI.CommandBarLabel();
            this.commandBarDropDownSort = new Telerik.WinControls.UI.CommandBarDropDownList();
            this.commandBarSeparator1 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarLabel2 = new Telerik.WinControls.UI.CommandBarLabel();
            this.commandBarDropDownGroup = new Telerik.WinControls.UI.CommandBarDropDownList();
            this.commandBarSeparator2 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarToggleList = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.commandBarToggleTiles = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.commandBarToggleDetails = new Telerik.WinControls.UI.CommandBarToggleButton();
            this.commandBarSeparator3 = new Telerik.WinControls.UI.CommandBarSeparator();
            this.commandBarTextBoxFilter = new Telerik.WinControls.UI.CommandBarTextBox();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            ((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSpy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.Location = new System.Drawing.Point(0, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(0, 0);
            this.settingsPanel.TabIndex = 0;
            // 
            // btnSpy
            // 
            this.btnSpy.Image = ((System.Drawing.Image)(resources.GetObject("btnSpy.Image")));
            this.btnSpy.Location = new System.Drawing.Point(0, 0);
            this.btnSpy.Name = "btnSpy";
            this.btnSpy.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            // 
            // 
            // 
            this.btnSpy.RootElement.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnSpy.Size = new System.Drawing.Size(120, 24);
            this.btnSpy.TabIndex = 0;
            this.btnSpy.Text = "RadControl Spy ";
            // 
            // radListView1
            // 
            this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListView1.EnableColumnSort = true;
            this.radListView1.EnableSorting = true;
            this.radListView1.FullRowSelect = false;
            this.radListView1.GroupIndent = 0;
            this.radListView1.ItemSize = new System.Drawing.Size(64, 64);
            this.radListView1.Location = new System.Drawing.Point(0, 55);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(919, 437);
            this.radListView1.TabIndex = 0;
            this.radListView1.Text = "radListView1";
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.IconsView;
            this.radListView1.BindingCompleted += new System.EventHandler(this.radListView1_BindingCompleted);
            this.radListView1.SelectedItemChanged += new System.EventHandler(this.radListView1_SelectedItemChanged);
            this.radListView1.VisualItemCreating += new Telerik.WinControls.UI.ListViewVisualItemCreatingEventHandler(this.radListView1_VisualItemCreating);
            this.radListView1.ItemDataBound += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemDataBound);
            this.radListView1.ColumnCreating += new Telerik.WinControls.UI.ListViewColumnCreatingEventHandler(this.radListView1_ColumnCreating);
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 0);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(919, 55);
            this.radCommandBar1.TabIndex = 4;
            this.radCommandBar1.TextChanged += new System.EventHandler(this.commandBarTextBoxFilter_TextChanged);
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.DisplayName = null;
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.EnableDragging = false;
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.commandBarLabel1,
            this.commandBarDropDownSort,
            this.commandBarSeparator1,
            this.commandBarLabel2,
            this.commandBarDropDownGroup,
            this.commandBarSeparator2,
            this.commandBarToggleList,
            this.commandBarToggleTiles,
            this.commandBarToggleDetails,
            this.commandBarSeparator3,
            this.commandBarTextBoxFilter});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            this.commandBarStripElement1.StretchHorizontally = true;
            this.commandBarStripElement1.Text = "";
            // 
            // commandBarLabel1
            // 
            this.commandBarLabel1.AccessibleDescription = "Sort By:";
            this.commandBarLabel1.AccessibleName = "Sort By:";
            this.commandBarLabel1.DisplayName = "commandBarLabel1";
            this.commandBarLabel1.Name = "commandBarLabel1";
            this.commandBarLabel1.Text = "Sort By:";
            this.commandBarLabel1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarDropDownSort
            // 
            this.commandBarDropDownSort.AccessibleDescription = "None";
            this.commandBarDropDownSort.AccessibleName = "None";
            this.commandBarDropDownSort.DisplayName = "commandBarDropDownList1";
            this.commandBarDropDownSort.DropDownAnimationEnabled = true;
            this.commandBarDropDownSort.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem46.Text = "None";
            radListDataItem46.TextWrap = true;
            radListDataItem47.Text = "Make";
            radListDataItem47.TextWrap = true;
            radListDataItem48.Text = "Model";
            radListDataItem48.TextWrap = true;
            radListDataItem49.Text = "Category";
            radListDataItem49.TextWrap = true;
            radListDataItem50.Text = "Year";
            radListDataItem50.TextWrap = true;
            this.commandBarDropDownSort.Items.Add(radListDataItem46);
            this.commandBarDropDownSort.Items.Add(radListDataItem47);
            this.commandBarDropDownSort.Items.Add(radListDataItem48);
            this.commandBarDropDownSort.Items.Add(radListDataItem49);
            this.commandBarDropDownSort.Items.Add(radListDataItem50);
            this.commandBarDropDownSort.MaxDropDownItems = 0;
            this.commandBarDropDownSort.Name = "commandBarDropDownSort";
            this.commandBarDropDownSort.Text = "None";
            this.commandBarDropDownSort.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarDropDownSort.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.commandBarDropDownSort_SelectedIndexChanged);
            // 
            // commandBarSeparator1
            // 
            this.commandBarSeparator1.AccessibleDescription = "commandBarSeparator1";
            this.commandBarSeparator1.AccessibleName = "commandBarSeparator1";
            this.commandBarSeparator1.DisplayName = "commandBarSeparator1";
            this.commandBarSeparator1.Name = "commandBarSeparator1";
            this.commandBarSeparator1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator1.VisibleInOverflowMenu = false;
            // 
            // commandBarLabel2
            // 
            this.commandBarLabel2.AccessibleDescription = "Group By:";
            this.commandBarLabel2.AccessibleName = "Group By:";
            this.commandBarLabel2.DisplayName = "commandBarLabel2";
            this.commandBarLabel2.Name = "commandBarLabel2";
            this.commandBarLabel2.Text = "Group By:";
            this.commandBarLabel2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // commandBarDropDownGroup
            // 
            this.commandBarDropDownGroup.DisplayName = "commandBarDropDownList2";
            this.commandBarDropDownGroup.DropDownAnimationEnabled = true;
            this.commandBarDropDownGroup.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            radListDataItem51.Text = "None";
            radListDataItem51.TextWrap = true;
            radListDataItem52.Text = "Make";
            radListDataItem52.TextWrap = true;
            radListDataItem53.Text = "Category";
            radListDataItem53.TextWrap = true;
            radListDataItem54.Text = "Year";
            radListDataItem54.TextWrap = true;
            this.commandBarDropDownGroup.Items.Add(radListDataItem51);
            this.commandBarDropDownGroup.Items.Add(radListDataItem52);
            this.commandBarDropDownGroup.Items.Add(radListDataItem53);
            this.commandBarDropDownGroup.Items.Add(radListDataItem54);
            this.commandBarDropDownGroup.MaxDropDownItems = 0;
            this.commandBarDropDownGroup.Name = "commandBarDropDownGroup";
            this.commandBarDropDownGroup.Text = "";
            this.commandBarDropDownGroup.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarDropDownGroup.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.commandBarDropDownGroup_SelectedIndexChanged);
            // 
            // commandBarSeparator2
            // 
            this.commandBarSeparator2.AccessibleDescription = "commandBarSeparator2";
            this.commandBarSeparator2.AccessibleName = "commandBarSeparator2";
            this.commandBarSeparator2.DisplayName = "commandBarSeparator2";
            this.commandBarSeparator2.Name = "commandBarSeparator2";
            this.commandBarSeparator2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator2.VisibleInOverflowMenu = false;
            // 
            // commandBarToggleList
            // 
            this.commandBarToggleList.AccessibleDescription = "commandBarToggleButton1";
            this.commandBarToggleList.AccessibleName = "commandBarToggleButton1";
            this.commandBarToggleList.DisplayName = "commandBarToggleButton1";
            this.commandBarToggleList.Image = ((System.Drawing.Image)(resources.GetObject("commandBarToggleList.Image")));
            this.commandBarToggleList.Name = "commandBarToggleList";
            this.commandBarToggleList.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarToggleList.Text = "commandBarToggleButton1";
            this.commandBarToggleList.ToolTipText = "ListView";
            this.commandBarToggleList.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarToggleList.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.ViewToggleButton_ToggleStateChanging);
            this.commandBarToggleList.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ViewToggleButton_ToggleStateChanged);
            // 
            // commandBarToggleTiles
            // 
            this.commandBarToggleTiles.AccessibleDescription = "commandBarToggleButton2";
            this.commandBarToggleTiles.AccessibleName = "commandBarToggleButton2";
            this.commandBarToggleTiles.DisplayName = "commandBarToggleButton2";
            this.commandBarToggleTiles.Image = ((System.Drawing.Image)(resources.GetObject("commandBarToggleTiles.Image")));
            this.commandBarToggleTiles.Name = "commandBarToggleTiles";
            this.commandBarToggleTiles.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarToggleTiles.Text = "commandBarToggleButton2";
            this.commandBarToggleTiles.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.commandBarToggleTiles.ToolTipText = "IconsView";
            this.commandBarToggleTiles.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarToggleTiles.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.ViewToggleButton_ToggleStateChanging);
            this.commandBarToggleTiles.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ViewToggleButton_ToggleStateChanged);
            // 
            // commandBarToggleDetails
            // 
            this.commandBarToggleDetails.AccessibleDescription = "commandBarToggleButton3";
            this.commandBarToggleDetails.AccessibleName = "commandBarToggleButton3";
            this.commandBarToggleDetails.DisplayName = "commandBarToggleButton3";
            this.commandBarToggleDetails.Image = ((System.Drawing.Image)(resources.GetObject("commandBarToggleDetails.Image")));
            this.commandBarToggleDetails.Name = "commandBarToggleDetails";
            this.commandBarToggleDetails.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.commandBarToggleDetails.Text = "commandBarToggleButton3";
            this.commandBarToggleDetails.ToolTipText = "DetailsView";
            this.commandBarToggleDetails.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarToggleDetails.ToggleStateChanging += new Telerik.WinControls.UI.StateChangingEventHandler(this.ViewToggleButton_ToggleStateChanging);
            this.commandBarToggleDetails.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.ViewToggleButton_ToggleStateChanged);
            // 
            // commandBarSeparator3
            // 
            this.commandBarSeparator3.AccessibleDescription = "commandBarSeparator3";
            this.commandBarSeparator3.AccessibleName = "commandBarSeparator3";
            this.commandBarSeparator3.DisplayName = "commandBarSeparator3";
            this.commandBarSeparator3.Name = "commandBarSeparator3";
            this.commandBarSeparator3.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarSeparator3.VisibleInOverflowMenu = false;
            // 
            // commandBarTextBoxFilter
            // 
            this.commandBarTextBoxFilter.DisplayName = "commandBarTextBox1";
            this.commandBarTextBoxFilter.MinSize = new System.Drawing.Size(200, 0);
            this.commandBarTextBoxFilter.Name = "commandBarTextBoxFilter";
            this.commandBarTextBoxFilter.StretchHorizontally = true;
            this.commandBarTextBoxFilter.Text = "";
            this.commandBarTextBoxFilter.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.commandBarTextBoxFilter.TextChanged += new System.EventHandler(this.commandBarTextBoxFilter_TextChanged);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.radListView1);
            this.radPanel1.Controls.Add(this.radCommandBar1);
            this.radPanel1.Location = new System.Drawing.Point(3, 5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(919, 492);
            this.radPanel1.TabIndex = 5;
            this.radPanel1.Text = "radPanel1";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1029, 509);
            this.Controls.Add(this.radPanel1);
            this.Name = "Form1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.settingsPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSpy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.radPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel1;
        private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownSort;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator1;
        private Telerik.WinControls.UI.CommandBarLabel commandBarLabel2;
        private Telerik.WinControls.UI.CommandBarDropDownList commandBarDropDownGroup;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator2;
        private Telerik.WinControls.UI.CommandBarTextBox commandBarTextBoxFilter;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.CommandBarToggleButton commandBarToggleList;
        private Telerik.WinControls.UI.CommandBarToggleButton commandBarToggleTiles;
        private Telerik.WinControls.UI.CommandBarToggleButton commandBarToggleDetails;
        private Telerik.WinControls.UI.CommandBarSeparator commandBarSeparator3;
        private Telerik.WinControls.UI.RadButton btnSpy;
        private RadPanel settingsPanel;
    }
}