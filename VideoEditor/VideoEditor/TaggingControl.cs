using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using TvArchiving.DAL.Repositories;
using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;

namespace ShotDetection
{
    public partial class TaggingControl : Telerik.WinControls.UI.ShapedForm
    {

        private IUnitOfWork unitOfWork;
        private IDatabaseFactory databaseFactory;
        private IShotRepository shotRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IVideoFileRepository videoFileRepository;
        private Shot shot;
        private double startTime;
        private double endTime;
        private string filePath;
        private string fileName;
        private Image thumbnailImage;
        private string mode;
        private MainPage mainPage;

        public TaggingControl()
        {
            InitializeComponent();
            SetupAutoComplete(this.AutoCompleteBox);
            SetupCategoryList(this.cbCategories);
            this.databaseFactory = new DatabaseFactory();
            this.shotRepository = new ShotRepository(databaseFactory);
            this.videoFileRepository = new VideoFileRepository(databaseFactory);
            this.tagRepository = new TagRepository(databaseFactory);
            this.categoryRepository = new CategoryRepository(databaseFactory);
            this.unitOfWork = new UnitOfWork(databaseFactory);
            this.shot = shot;
        }


        public TaggingControl(MainPage mainPage, double startTime, double endTime, string filePath, string fileName, Image ThumbnailImage,int Id = -1)
            : this()
        {
            this.mainPage = mainPage;
            this.startTime = startTime;
            this.endTime = endTime;
            this.filePath = filePath;
            this.fileName = fileName;
            this.thumbnailImage = ThumbnailImage;
            this.shotListIndex = Id;
            this.mode = "Add";
        }

        public TaggingControl(MainPage mainPage,int ListItemID = -1,int shotID=-1)
            : this()
        {
            this.mainPage = mainPage;
            this.shotListIndex = ListItemID;
            this.shotID = shotID;
            this.mode = "Update";
        }

        private void SetupCategoryList(RadMultiColumnComboBox radMultiColumnComboBox)
        {
            radMultiColumnComboBox.AutoSizeDropDownToBestFit = true;
            RadMultiColumnComboBoxElement multiColumnComboElement = radMultiColumnComboBox.MultiColumnComboBoxElement;
            multiColumnComboElement.DropDownSizingMode = SizingMode.UpDownAndRightBottom;
            multiColumnComboElement.EditorControl.MasterTemplate.AutoGenerateColumns = false;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //this.cbCategories.DataSource = categoryRepository.GetAll();
            this.cbCategories.DisplayMember = "Name";
            this.cbCategories.ValueMember = "ID";
            FilterDescriptor descriptor = new FilterDescriptor(this.cbCategories.DisplayMember, FilterOperator.StartsWith, string.Empty);
            this.cbCategories.EditorControl.FilterDescriptors.Add(descriptor);
            this.cbCategories.DropDownStyle = RadDropDownStyle.DropDown;
            this.cbCategories.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cbCategories.AutoFilter = true;
            this.cbCategories.SelectedIndex = -1;

        }

        private void ShapedForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvArchivingDBDataSet2.Tags' table. You can move, or remove it, as needed.
            this.tagsTableAdapter.Fill(this.tvArchivingDBDataSet2.Tags);
            this.categoriesTableAdapter.Fill(this.tvArchivingDBDataSet1.Categories);


            if (mode == "Update")
            {
                fillFields();
            }
        }

        private void fillFields()
        {
           var model = shotRepository.GetById(shotID);
            txtShotDescription.Text = model.Description;
            cbCategories.SelectedValue = model.Category.ID;
            AutoCompleteBox.Text = model.Tags;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (mode == "Add")
                Insert();
            else if (mode == "Update")
                Change();
        }

        private void Change()
        {
            int categoryID = Convert.ToInt16(this.cbCategories.SelectedValue);

            string tags = "";
            foreach (var tag in AutoCompleteBox.Items)
            {
                Tag tg = new Tag() { Name = tag.Text };
                tagRepository.Add(tg);

            }
            tags = AutoCompleteBox.Text;


            var UpdateModel = shotRepository.GetById(shotID);
            UpdateModel.Description = txtShotDescription.Text;
            UpdateModel.Tags = tags;
            UpdateModel.Category_ID = categoryID;

            unitOfWork.Commit();
            if (shotListIndex != -1)
                mainPage.SetData(UpdateModel.Description, UpdateModel.Category.Name, UpdateModel.Tags, shotListIndex,shotID);

            this.Close();

        }

        private void Insert()
        {

            int categoryID = Convert.ToInt16(this.cbCategories.SelectedValue);

            string tags = "";
            foreach (var tag in AutoCompleteBox.Items)
            {
                Tag tg = new Tag() { Name = tag.Text };
                tagRepository.Add(tg);

            }
            tags = AutoCompleteBox.Text;

            var model = categoryRepository.GetById(categoryID);
            Shot newshot = new Shot()
            {
                From = startTime,
                m_fileName = fileName,
                m_filePath = filePath,
                Description = txtShotDescription.Text,
                Category = model,
                ToTime = endTime,
                ThumbnailImage = imageToByteArray(thumbnailImage),
                DateAdded = DateTime.Now.ToString(),
                Tags = tags
            };
            shotRepository.Add(newshot);

            unitOfWork.Commit();

            long id = shotRepository.Get(r => r.DateAdded == newshot.DateAdded).Id ;
            if (shotListIndex != -1)
                mainPage.SetData(newshot.Description,model.Name, newshot.Tags,shotListIndex,id);

            this.Close();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SetupAutoComplete(RadAutoCompleteBox radAutoCompleteBox)
        {
            radAutoCompleteBox.Items.CollectionChanged += this.OnItemsCollectionChanged;
            radAutoCompleteBox.AutoCompleteDisplayMember = "Name";
            radAutoCompleteBox.AutoCompleteValueMember = "Name";
            radAutoCompleteBox.ListElement.VisualItemFormatting += this.OnListElementVisualItemFormatting;
           // radAutoCompleteBox.AutoCompleteDataSource = new BindingSource(this.GetAutoCompleteDataSource(), string.Empty);
            radAutoCompleteBox.DropDownMaxSize = new Size(200, 0);
        }

        private void OnItemsCollectionChanged(object sender, Telerik.WinControls.Data.NotifyCollectionChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnListElementVisualItemFormatting(object sender, VisualItemFormattingEventArgs e)
        {
            RadListDataItem dataItem = e.VisualItem.Data;
            e.VisualItem.Text = string.Format("{0} <{1}>", dataItem.Text, dataItem.Value);
        }


        private DataTable GetAutoCompleteDataSource()
        {
            DataTable table = new DataTable("Tags");
            table.Columns.Add("Tag", typeof(string));
            table.Columns.Add("Tagg", typeof(string));
            table.Rows.Add("Real Madrid", "Real Madrid");
            table.Rows.Add("Raul", "Raul");
            table.Rows.Add("Race", "Race");
            table.Rows.Add("Ronaldo", "Ronaldo");
            table.Rows.Add("Cristiano Ronaldo", "Cristiano Ronaldo");
            table.Rows.Add("Benzema", "Benzema");
            table.Rows.Add("Match", "Match");
            table.Rows.Add("Match", "Match");

            return table;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public int shotListIndex { get; set; }
        public int shotID { get; set; }

        private void txtShotDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
