using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using TvArchiving.DAL.Repositories;
using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;

namespace ShotDetection
{
    public partial class FORMShotsSearch : Telerik.WinControls.UI.RadForm
    {

        private IUnitOfWork unitOfWork;
        private IDatabaseFactory databaseFactory;
        private IShotRepository shotRepository;
        private ICategoryRepository categoryRepository;
        private ITagRepository tagRepository;
        private IVideoFileRepository videoFileRepository;
        public long shotId { get; set; }
        public int rowIndex { get; set; }


        public FORMShotsSearch()
        {

            InitializeComponent();

            this.databaseFactory = new DatabaseFactory();
            this.shotRepository = new ShotRepository(databaseFactory);
            this.videoFileRepository = new VideoFileRepository(databaseFactory);
            this.tagRepository = new TagRepository(databaseFactory);
            this.categoryRepository = new CategoryRepository(databaseFactory);
            this.unitOfWork = new UnitOfWork(databaseFactory);
        }

        private void FORMShotsSearch_Load(object sender, EventArgs e)
        {
            this.tagsTableAdapter.Fill(this.tags._Tags);
            this.radPageViewPage2.Enabled = false;
            this.SearchingPage.SelectedPage = radPageViewPage1;
            ((GridTableElement)this.radGridView1.GridElement).RowHeight = 80;
            radGridView1.Columns["Id"].IsVisible = false;

            this.shotsTableAdapter.Fill(this.tvArchivingDBDataSet.Shots);


        }

        private void TextBoxItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Bounds")
            {
                commandBarTextBoxFilter.TextBoxElement.TextBoxItem.HostedControl.MaximumSize = new Size((int)commandBarTextBoxFilter.DesiredSize.Width - 28, 0);
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            FilterDescriptor filter1 = new FilterDescriptor();
            filter1.Operator = FilterOperator.Contains;
            if (radAutoCompleteBox1.Text.Length > 0)
                filter1.Value = radAutoCompleteBox1.Text.Substring(0, radAutoCompleteBox1.Text.Length - 1);
            else
                filter1.Value = "";

            filter1.IsFilterEditor = true;
            this.radGridView1.Columns["Tags"].FilterDescriptor = filter1;

        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                this.radPageViewPage2.Enabled = true;
                this.SearchingPage.SelectedPage = radPageViewPage2;
                this.rowIndex = e.RowIndex;
                this.shotId = long.Parse(radGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                this.pbThumnail.Image = byteArrayToImage(e.Row.Cells["ThumbnailImage"].Value as byte[]);
                this.txtDescription.Text = radGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                this.txtKeywords.Text = radGridView1.Rows[e.RowIndex].Cells["Tags"].Value.ToString();
                this.lbBy.Text = "Added By: Admin";
                this.lbDate.Text = radGridView1.Rows[e.RowIndex].Cells["DateAdded"].Value.ToString();
            }
        }


        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void RadButton_Click(object sender, EventArgs e)
        {

            string tags = "";
            foreach (var tag in txtKeywords.Items)
            {
                Tag tg = new Tag() { Name = tag.Text };
                tagRepository.Add(tg);

            }
            tags = txtKeywords.Text;


            var UpdateModel = shotRepository.GetById(shotId);
            UpdateModel.Description = txtDescription.Text;
            UpdateModel.Tags = tags;

            unitOfWork.Commit();

            radGridView1.Rows[rowIndex].Cells["Description"].Value = txtDescription.Text;
            radGridView1.Rows[rowIndex].Cells["Tags"].Value = txtKeywords.Text;

        }
    }

}
