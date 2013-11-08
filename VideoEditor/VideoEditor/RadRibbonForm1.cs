using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ShotDetection.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;

namespace ShotDetection
{
    public partial class RadRibbonForm1 : Telerik.WinControls.UI.RadRibbonForm
    {
        #region Fields
        private DataSet dataSet;
        #endregion

        #region Enumerators
        enum Status
        {
            InProgress,
            Done,
            ReadyForTest,
            Deleted,
            NotDone
        };

        enum Priority
        {
            Low,
            High,
            Blocking
        }

        enum Type
        {
            Bug,
            Feature
        }
        #endregion

        #region Constructor

        public RadRibbonForm1()
        {
            InitializeComponent();

            //the following function fills the source.xml and XMLSchema.xsd files with sample data
            //FillData();

            CustomizeRibbon();
          //  FillDataSet();
           // SetupProjectTreeView();
            //SetupBugsGrid();
           // SetupFeaturesGrid();
           // BindControls();
            SubscribeToEvents();
            ReadOnlyControls(true);
            //ThemeResolutionService.ApplicationThemeName = "Office2010Black";


           // radDock1.DockControl(new MainPage(), DockPosition.Fill, DockType.Document);

            ((GridTableElement)this.radGridView1.GridElement).RowHeight = 80; 
            //this.radGridView1.BestFitColumns(BestFitColumnMode.AllCells);
        }



        #endregion

        #region Methods

        private void ReadOnlyControls(bool readOnly)
        {
        }


        

        private void SubscribeToEvents()
        {
           

            office2010BlackButton.Click += new EventHandler(changeThemes);
            office2010BlueButton.Click += new EventHandler(changeThemes);
            office2010SilverButton.Click += new EventHandler(changeThemes);
            controlDefaultButton.Click += new EventHandler(changeThemes);


            projectsButton.Click += new EventHandler(panelsChange_Click);
            detailsButton.Click += new EventHandler(panelsChange_Click);
            bugsButton.Click += new EventHandler(panelsChange_Click);
            featuresButton.Click += new EventHandler(panelsChange_Click);
            editMenuItem.Click += new EventHandler(editButton_Click);
            aboutMenuItem.Click += new EventHandler(aboutMenuItem_Click);
            exitMenuItem.Click += new EventHandler(exitMenuItem_Click);
        }




        private void CustomizeRibbon()
        {
            radRibbonBar1.RibbonBarElement.ApplicationMenuRightColumnWidth = 0;
            radRibbonBar1.OptionsButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            RibbonBar.ExitButton.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            Telerik.WinControls.UI.InnerItem item = RibbonBar.RibbonBarElement.QuickAccessToolBar.InnerItem;
            item.Visibility = Telerik.WinControls.ElementVisibility.Hidden;
            radRibbonBar1.StartButtonImage = Resources.up1;
        }

      

        private Status? ConvertToStatus(object value)
        {
            if (value is Status)
            {
                return (Status)value;
            }

            return null;
        }

        #endregion

        #region Events

        void radDock1_ActiveWindowChanged(object sender, DockWindowEventArgs e)
        {
            ////reset the currency manager position in order to update the controls in details tab
            //if (e.DockWindow != detailsToolWindow)
            //{
            //    RadGridView currentGrid = e.DockWindow == bugDocumentWindow ? bugsGrid : featuresGrid;
            //    CurrencyManager mgr = ((ICurrencyManagerProvider)currentGrid.MasterTemplate.ListSource).CurrencyManager;
            //    int savePos = mgr.Position;
            //    mgr.Position = mgr.Position == mgr.List.Count - 1 ? int.MinValue : int.MaxValue;
            //    mgr.Position = savePos;
            //    if (currentGrid.ChildRows.Count > 0)
            //    {
            //        currentGrid.ChildRows[0].IsSelected = true;
            //        currentGrid.ChildRows[0].IsCurrent = true;
            //    }
            //}
        }



        private void saveDatabaseButton_Click(object sender, EventArgs e)
        {
        }

        

       
        private void editButton_Click(object sender, EventArgs e)
        {
            ReadOnlyControls(false);
        }

        private void saveLayoutButton_Click(object sender, EventArgs e)
        {
        }

        private void loadLayoutButton_Click(object sender, EventArgs e)
        {

        }

        void changeThemes(object sender, EventArgs e)
        {
            RadGalleryItem element = sender as RadGalleryItem;
            ThemeResolutionService.ApplicationThemeName = element.Text;
        }

        void panelsChange_Click(object sender, EventArgs e)
        {

            //bugDocumentWindow.CloseAction = DockWindowCloseAction.Hide;
            //featureDocumentWindow.CloseAction = DockWindowCloseAction.Hide;

            //RadButtonElement button = sender as RadButtonElement;
            //if (button.Text == "Projects")
            //{
            //    projectsToolWindow.DockState = DockState.Docked;
            //}
            //if (button.Text == "Details")
            //{
            //    detailsToolWindow.DockState = DockState.Docked;
            //}
            //if (button.Text == "Bugs")
            //{
            //    bugDocumentWindow.DockState = DockState.TabbedDocument;
            //}
            //if (button.Text == "Features")
            //{
            //    featureDocumentWindow.DockState = DockState.TabbedDocument;
            //}
        }

        void rowChanged_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            ReadOnlyControls(true);
        }

        void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void aboutMenuItem_Click(object sender, EventArgs e)
        {
        }

        #endregion

        private void radRibbonBar1_Click(object sender, EventArgs e)
        {
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void radGalleryElement1_Click(object sender, EventArgs e)
        {

        }

        private void RadRibbonForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RadRibbonForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvArchivingDBDataSet3.Shots' table. You can move, or remove it, as needed.
            this.shotsTableAdapter.Fill(this.tvArchivingDBDataSet3.Shots);

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            MainPage page = new MainPage();
            page.Show();
        }

        private void radButtonElement3_Click(object sender, EventArgs e)
        {
            var form = new FORMShotsSearch();
            form.Show();
        }

     

    }
}
