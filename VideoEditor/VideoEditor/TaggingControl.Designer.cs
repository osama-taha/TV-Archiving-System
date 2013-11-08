namespace ShotDetection
{
    partial class TaggingControl
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
            Telerik.WinControls.UI.GridViewDecimalColumn gridViewDecimalColumn1 = new Telerik.WinControls.UI.GridViewDecimalColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.AutoCompleteBox = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.tagsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tvArchivingDBDataSet2 = new ShotDetection.TvArchivingDBDataSet2();
            this.mediaShape1 = new Telerik.WinControls.Tests.MediaShape();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtShotDescription = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.cbCategories = new Telerik.WinControls.UI.RadMultiColumnComboBox();
            this.categoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tvArchivingDBDataSet1 = new ShotDetection.TvArchivingDBDataSet1();
            this.categoriesTableAdapter = new ShotDetection.TvArchivingDBDataSet1TableAdapters.CategoriesTableAdapter();
            this.tagsTableAdapter = new ShotDetection.TvArchivingDBDataSet2TableAdapters.TagsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCompleteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvArchivingDBDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShotDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories.EditorControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories.EditorControl.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvArchivingDBDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLabel1.Location = new System.Drawing.Point(11, 121);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(241, 18);
            this.radLabel1.TabIndex = 36;
            this.radLabel1.Text = "Tag the shot by entering keywords below: ";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSave.Location = new System.Drawing.Point(11, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 24);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnClose.Location = new System.Drawing.Point(127, 238);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 24);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // AutoCompleteBox
            // 
            this.AutoCompleteBox.AutoCompleteDataSource = this.tagsBindingSource;
            this.AutoCompleteBox.AutoCompleteDisplayMember = "Name";
            this.AutoCompleteBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AutoCompleteBox.AutoCompleteValueMember = "ID";
            this.AutoCompleteBox.Font = new System.Drawing.Font("Tahoma", 9F);
            this.AutoCompleteBox.Location = new System.Drawing.Point(11, 145);
            this.AutoCompleteBox.MaximumSize = new System.Drawing.Size(450, 0);
            this.AutoCompleteBox.MinimumSize = new System.Drawing.Size(450, 80);
            this.AutoCompleteBox.Multiline = true;
            this.AutoCompleteBox.Name = "AutoCompleteBox";
            // 
            // 
            // 
            this.AutoCompleteBox.RootElement.AutoSize = true;
            this.AutoCompleteBox.RootElement.MaxSize = new System.Drawing.Size(450, 0);
            this.AutoCompleteBox.RootElement.MinSize = new System.Drawing.Size(450, 80);
            this.AutoCompleteBox.RootElement.StretchHorizontally = false;
            this.AutoCompleteBox.RootElement.StretchVertically = false;
            this.AutoCompleteBox.Size = new System.Drawing.Size(450, 80);
            this.AutoCompleteBox.TabIndex = 33;
            // 
            // tagsBindingSource
            // 
            this.tagsBindingSource.DataMember = "Tags";
            this.tagsBindingSource.DataSource = this.tvArchivingDBDataSet2;
            // 
            // tvArchivingDBDataSet2
            // 
            this.tvArchivingDBDataSet2.DataSetName = "TvArchivingDBDataSet2";
            this.tvArchivingDBDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLabel2.Location = new System.Drawing.Point(12, 12);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(72, 18);
            this.radLabel2.TabIndex = 37;
            this.radLabel2.Text = "Description:";
            // 
            // txtShotDescription
            // 
            this.txtShotDescription.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtShotDescription.Location = new System.Drawing.Point(11, 34);
            this.txtShotDescription.Name = "txtShotDescription";
            this.txtShotDescription.Size = new System.Drawing.Size(400, 20);
            this.txtShotDescription.TabIndex = 1;
            this.txtShotDescription.TextChanged += new System.EventHandler(this.txtShotDescription_TextChanged);
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.radLabel3.Location = new System.Drawing.Point(12, 63);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(60, 18);
            this.radLabel3.TabIndex = 38;
            this.radLabel3.Text = "Category:";
            // 
            // cbCategories
            // 
            this.cbCategories.DataSource = this.categoriesBindingSource;
            this.cbCategories.DisplayMember = "Name";
            // 
            // cbCategories.NestedRadGridView
            // 
            this.cbCategories.EditorControl.BackColor = System.Drawing.SystemColors.Window;
            this.cbCategories.EditorControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategories.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCategories.EditorControl.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.cbCategories.EditorControl.MasterTemplate.AllowAddNewRow = false;
            this.cbCategories.EditorControl.MasterTemplate.AllowCellContextMenu = false;
            this.cbCategories.EditorControl.MasterTemplate.AllowColumnChooser = false;
            gridViewDecimalColumn1.DataType = typeof(int);
            gridViewDecimalColumn1.FieldName = "ID";
            gridViewDecimalColumn1.HeaderText = "ID";
            gridViewDecimalColumn1.IsAutoGenerated = true;
            gridViewDecimalColumn1.Name = "ID";
            gridViewDecimalColumn1.ReadOnly = true;
            gridViewTextBoxColumn1.FieldName = "Name";
            gridViewTextBoxColumn1.HeaderText = "Name";
            gridViewTextBoxColumn1.IsAutoGenerated = true;
            gridViewTextBoxColumn1.Name = "Name";
            this.cbCategories.EditorControl.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewDecimalColumn1,
            gridViewTextBoxColumn1});
            this.cbCategories.EditorControl.MasterTemplate.DataSource = this.categoriesBindingSource;
            this.cbCategories.EditorControl.MasterTemplate.EnableGrouping = false;
            this.cbCategories.EditorControl.MasterTemplate.ShowFilteringRow = false;
            this.cbCategories.EditorControl.Name = "NestedRadGridView";
            this.cbCategories.EditorControl.ReadOnly = true;
            this.cbCategories.EditorControl.ShowGroupPanel = false;
            this.cbCategories.EditorControl.Size = new System.Drawing.Size(240, 150);
            this.cbCategories.EditorControl.TabIndex = 0;
            this.cbCategories.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategories.Location = new System.Drawing.Point(13, 87);
            this.cbCategories.Name = "cbCategories";
            this.cbCategories.Size = new System.Drawing.Size(100, 21);
            this.cbCategories.TabIndex = 2;
            this.cbCategories.TabStop = false;
            // 
            // categoriesBindingSource
            // 
            this.categoriesBindingSource.DataMember = "Categories";
            this.categoriesBindingSource.DataSource = this.tvArchivingDBDataSet1;
            // 
            // tvArchivingDBDataSet1
            // 
            this.tvArchivingDBDataSet1.DataSetName = "TvArchivingDBDataSet1";
            this.tvArchivingDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // categoriesTableAdapter
            // 
            this.categoriesTableAdapter.ClearBeforeFill = true;
            // 
            // tagsTableAdapter
            // 
            this.tagsTableAdapter.ClearBeforeFill = true;
            // 
            // TaggingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 297);
            this.Controls.Add(this.cbCategories);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.txtShotDescription);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.AutoCompleteBox);
            this.Name = "TaggingControl";
            this.Text = "ShapedForm1";
            this.Load += new System.EventHandler(this.ShapedForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AutoCompleteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tagsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvArchivingDBDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShotDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories.EditorControl.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories.EditorControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tvArchivingDBDataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadAutoCompleteBox AutoCompleteBox;
        private Telerik.WinControls.Tests.MediaShape mediaShape1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBoxControl txtShotDescription;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadMultiColumnComboBox cbCategories;
        private TvArchivingDBDataSet1 tvArchivingDBDataSet1;
        private System.Windows.Forms.BindingSource categoriesBindingSource;
        private TvArchivingDBDataSet1TableAdapters.CategoriesTableAdapter categoriesTableAdapter;
        private TvArchivingDBDataSet2 tvArchivingDBDataSet2;
        private System.Windows.Forms.BindingSource tagsBindingSource;
        private TvArchivingDBDataSet2TableAdapters.TagsTableAdapter tagsTableAdapter;
    }
}