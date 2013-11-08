using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DirectShowLib;
using ShotDetection.FolderExprorer;
using Telerik.WinControls;
using Telerik.WinControls.Enumerations;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.UI;
using TvArchiving.DAL.Repositories;
using TvArchiving.Domain.Entities;
using TvArchiving.Domain.Infrastructure;
using TvArchiving.Domain.Interfaces;
using VideoEditor;
using shotDetection.detection;
using Filter = Telerik.WinControls.Filter;
using Telerik.WinControls.Data;
using Telerik.WinControls.Primitives;
using ShotDetection.Properties;
using Padding = System.Windows.Forms.Padding;

namespace ShotDetection
{
    public partial class MainPage : Telerik.WinControls.UI.RadForm
    {
        private string setMode;
        DSCapture cam = null;
        State m_State = State.Uninit;
        private object syncRoot = new Object();
        /////////////////////////////////////////////////
        public static int thumbSeconds = 0;
        static private int goThumbPosition = 0;
        /////////////////////////////////////////////////

        private static VideoFilesList<VideoFiles> videoFilesList = new VideoFilesList<VideoFiles>();

        private static List<VideoFile> videoFiles = new List<VideoFile>();


        private IUnitOfWork unitOfWork;
        private IDatabaseFactory databaseFactory;
        private IShotRepository shotRepository;
        private ICategoryRepository categoryRepository;
        private IVideoFileRepository videoFileRepository;
        private ITagRepository tagRepository;

        //Check Video Withen video 
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        public enum FilterDefinitionState
        {
            FilterAreaChoosen,
            FilterTypeChoosen,
            AreaOverVideoChoosen,
            None
        }

        public enum FilterArea
        {
            Partial,
            Complete,
            None
        }

        public enum FilterType
        {
            Negative,
            Blur,
            Sharpen,
            EdgesDetection,
            Diferences,
            None
        }

        public FilterDefinitionState currentState = FilterDefinitionState.None;
        public FilterArea currentFilterArea = FilterArea.None;
        public FilterType currentFilterType = FilterType.None;

        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////

        public List<Frames> images;

        public MediaManager mediaManager = new MediaManager();
        public FiltersManager filtersManager = new FiltersManager();

        public Point filterDown = new Point(50, 50);
        public Point filterUp = new Point(100, 100);

        public int filterMinX;
        public int filterMinY;
        public int filterMaxX;
        public int filterMaxY;

        public enum VideoState
        {
            FastBackwards,
            Playing,
            Paused,
            Stopped,
            FastForwarding
        }

        public enum AudioState
        {
            Enabled,
            Disabled
        }

        public enum EditingState
        {
            SelectingFilter,
            None
        }

        public VideoState currentVideoState = VideoState.Stopped;
        public AudioState currentAudioState = AudioState.Enabled;
        public EditingState currentEditingState = EditingState.None;
        public int currentVolume = -100;



        public MainPage()
        {
            InitializeComponent();


            this.databaseFactory = new DatabaseFactory();
            this.shotRepository = new ShotRepository(databaseFactory);
            this.tagRepository = new TagRepository(databaseFactory);
            this.videoFileRepository = new VideoFileRepository(databaseFactory);
            this.categoryRepository = new CategoryRepository(databaseFactory);
            this.unitOfWork = new UnitOfWork(databaseFactory);


            commandBarToggleTiles.Image = Resources.tiles_icon;
            commandBarToggleDetails.Image = Resources.details_icon;

            ImagePrimitive searchIcon = new ImagePrimitive();
            searchIcon.Image = ShotDetection.Properties.Resources.TV_search;
            searchIcon.Alignment = ContentAlignment.MiddleRight;
            this.commandBarTextBoxFilter.TextBoxElement.StretchHorizontally = true;
            this.commandBarTextBoxFilter.TextBoxElement.Alignment = ContentAlignment.MiddleRight;
            this.commandBarTextBoxFilter.TextBoxElement.Children.Add(searchIcon);
            this.commandBarTextBoxFilter.TextBoxElement.TextBoxItem.Alignment = ContentAlignment.MiddleLeft;
            this.commandBarTextBoxFilter.TextBoxElement.TextBoxItem.PropertyChanged += new PropertyChangedEventHandler(TextBoxItem_PropertyChanged);

            this.radListView1.VisualItemFormatting += new Telerik.WinControls.UI.ListViewVisualItemEventHandler(radListView1_VisualItemFormatting);
            this.radListView1.ViewTypeChanged += new EventHandler(radListView1_ViewTypeChanged);
            this.radListView1.CellFormatting += new Telerik.WinControls.UI.ListViewCellFormattingEventHandler(radListView1_CellFormatting);
            this.radListView1.SortDescriptors.CollectionChanged += new NotifyCollectionChangedEventHandler(SortDescriptors_CollectionChanged);

            this.radListView1.AllowEdit = false;
            this.radListView1.AllowRemove = false;

            //this.radListView1_ViewTypeChanged(this, EventArgs.Empty);

            this.radListView1.Columns.Add(new ListViewDetailColumn("Image", "Picture"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("FilePath", "File Path"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("FileName", "File Name"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("From", "From"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("To", "To"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("Duration", "Duration"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("KeyFrame", "Key Frame"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("Category", "Category"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("Tags", "Tags"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("Description", "Description"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("DateAdded", "Date Added"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("Taged", "Taged"));
            this.radListView1.Columns.Add(new ListViewDetailColumn("ID", "ID"));



            this.radListView1.Columns["FilePath"].Visible = false;
            this.radListView1.Columns["KeyFrame"].Visible = false;
            this.radListView1.Columns["FileName"].Visible = false;
            this.radListView1.Columns["ID"].Visible = false;


            this.contextMenuStrip1.Enabled = false;
            this.contextMenuStrip1.Visible = false;
            this.contextMenuStrip1.ItemClicked += contextMenuStrip1_ItemClicked;

            ///

            ThemeResolutionService.ApplicationThemeName = "Office2010Black";

            SetupListView();

            radPanel1.PanelElement.PanelBorder.Visibility = ElementVisibility.Collapsed;
            splitPanel1.BorderStyle = BorderStyle.None;
            splitPanel2.BorderStyle = BorderStyle.None;


            radTreeView1.LazyMode = false;
            AddNodes();
            radTreeView1.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(radTreeView1_SelectedNodeChanged);
            radTreeView1.NodesNeeded += new NodesNeededEventHandler(radTreeView1_NodesNeeded);
            radTreeView1.KeyDown += new KeyEventHandler(radTreeView1_KeyDown);
            radTreeView1.NodeFormatting += new TreeNodeFormattingEventHandler(radTreeView1_NodeFormatting);

            radTreeView1.SelectedNode = radTreeView1.Nodes["My Computer"];

            radBreadCrumb1.DefaultTreeView = radTreeView1;

            AddButtonToTextBox();
            // radTextBox1.TextChanged += new EventHandler(radTextBox1_TextChanged);
            //radTextBox1.AutoCompleteCustomSource = autoCompleteDataSource1;

            AddButtonsToStatusStrip();

            historyButton.ShowArrow = false;


        }

        private void AddButtonsToStatusStrip()
        {

        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddButtonToTextBox()
        {
            searchButton = new CustomButton();
            searchButton.Image = Resources.TV_search;
            searchButton.ImageAlignment = ContentAlignment.MiddleCenter;
            searchButton.ShouldHandleMouseInput = false;
            searchButton.MaxSize = new System.Drawing.Size(16, 16);
            searchButton.MinSize = new System.Drawing.Size(16, 16);
            searchButton.ButtonFillElement.BackColor = Color.Transparent;
            searchButton.ButtonFillElement.BackColor2 = Color.Transparent;
            searchButton.ButtonFillElement.BackColor3 = Color.Transparent;
            searchButton.ButtonFillElement.BackColor4 = Color.Transparent;
            searchButton.BorderElement.Visibility = ElementVisibility.Collapsed;
            searchButton.Click += new EventHandler(searchButton_Click);

            //  RadTextBoxItem textBoxItem = this.radTextBox1.TextBoxElement.TextBoxItem;
            // textBoxItem.Alignment = ContentAlignment.MiddleLeft;

            //this.radTextBox1.TextBoxElement.Children.Remove(textBoxItem);

            // DockLayoutPanel.SetDock(textBoxItem, Telerik.WinControls.Layouts.Dock.Left);
            // DockLayoutPanel.SetDock(searchButton, Telerik.WinControls.Layouts.Dock.Right);

            DockLayoutPanel dockLayoutPanel = new DockLayoutPanel();

            dockLayoutPanel.Children.Add(searchButton);
            //  dockLayoutPanel.Children.Add(textBoxItem);

            //  this.radTextBox1.TextBoxElement.Children.Add(dockLayoutPanel);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            // radTextBox1.Text = "";
        }

        private void AddNodes()
        {
            RadTreeNode favorites = new RadTreeNode();
            favorites.Text = "Favorites";
            favorites.Image = Resources.favorites1;
            radTreeView1.Nodes.Add(favorites);

            RadTreeNode desktop = new RadTreeNode();
            desktop.Tag = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            desktop.Text = "Desktop";
            favorites.Nodes.Add(desktop);

            RadTreeNode libraries = new RadTreeNode();
            libraries.Text = "Libraries";
            libraries.Image = Resources.documents1;
            radTreeView1.Nodes.Add(libraries);

            RadTreeNode documents = new RadTreeNode("Documents");
            documents.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            libraries.Nodes.Add(documents);

            RadTreeNode music = new RadTreeNode("Music");
            music.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            libraries.Nodes.Add(music);

            RadTreeNode pictures = new RadTreeNode("Pictures");
            pictures.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            libraries.Nodes.Add(pictures);

            RadTreeNode myComputerNode = new RadTreeNode("My Computer");
            myComputerNode.Image = Resources.TV_search;

            string[] drives = Directory.GetLogicalDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                RadTreeNode node = new RadTreeNode(drives[i]);
                node.Tag = drives[i];
                myComputerNode.Nodes.Add(node);
            }
            radTreeView1.Nodes.Add(myComputerNode);
        }

        private void radTreeView1_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                IntPtr hImgLarge = SHGetFileInfo(e.Node.Tag.ToString(), 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                e.NodeElement.ImageElement.Image = System.Drawing.Icon.FromHandle(shinfo.hIcon).ToBitmap();
            }
        }

        private void radTreeView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Back)
            {
                NavigateBack();
            }
        }

        private void radTreeView1_NodesNeeded(object sender, NodesNeededEventArgs e)
        {
            if (e.Parent.Tag != null)
            {
                string directoryPath = e.Parent.Tag.ToString();
                if (Directory.Exists(directoryPath))
                {
                    try
                    {
                        string[] directories = Directory.GetDirectories(directoryPath);

                        for (int i = 0; i < directories.Length; i++)
                        {
                            //string r = Path.GetFileName(directories[i]);

                            //if(r.EndsWith(".mov") || r.EndsWith(".wm")
                            //  || r.EndsWith(".mp") || r.EndsWith(".w4v") ||
                            //  r.EndsWith(".avi"))
                            //{
                            RadTreeNode node = new RadTreeNode(Path.GetFileName(directories[i]));
                            node.Tag = directories[i];
                            e.Nodes.Add(node);
                            //}
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                    catch (IOException) { }
                }
            }
        }

        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node == null)
            {
                return;
            }
            try
            {
                //this checks for access exceptions
                if (e.Node.Tag != null)
                {
                    string[] directories = Directory.GetDirectories(e.Node.Tag.ToString());
                }

                //add the node to history
                if (!(navigateOperationInProgress))
                {
                    backCollection.Push(e.Node);
                }

                //update view
                UpdateView(e.Node);

                //updates status strip labels


                if (e.Node.Nodes.Count > 0 && e.Node.Expanded == false)
                {
                    e.Node.Expanded = true;
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                RadMessageBox.Show(ex.Message.ToString());
            }
            catch (IOException ex2)
            {
                RadMessageBox.Show(ex2.Message.ToString());
            }
        }

        private void UpdateView(RadTreeNode node)
        {

            try
            {
                radListView2.Items.Clear();

                if (node.Tag == null && (node.Text == "Favorites" || node.Text == "Libraries" || node.Text == "My Computer"))
                {
                    foreach (RadTreeNode childNode in node.Nodes)
                    {
                        ListViewDataItem item = new ListViewDataItem();
                        radListView2.Items.Add(item);
                        item.Text = childNode.Text;
                        item["Name"] = childNode.Text;
                        item.Tag = childNode.Tag;

                        IntPtr hImgLarge = SHGetFileInfo(childNode.Tag.ToString(), 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                        item.Image = System.Drawing.Icon.FromHandle(shinfo.hIcon).ToBitmap();
                    }
                    return;
                }

                if (node.Tag != null)
                {
                    string[] directories = Directory.GetDirectories(node.Tag.ToString());
                    string[] files = ((from r in Directory.GetFiles(node.Tag.ToString())
                                       where r.EndsWith(".mov") || r.EndsWith(".wm")
                                       || r.EndsWith(".mp") || r.EndsWith(".w4v") ||
                                       r.EndsWith(".avi")
                                       select r).ToArray());

                    foreach (string directory in directories)
                    {
                        ListViewDataItem item = new ListViewDataItem();
                        radListView2.Items.Add(item);
                        item.Text = Path.GetFileName(directory);
                        item.Tag = directory;
                        item["Name"] = Path.GetFileName(directory);
                        item["Date Modified"] = Directory.GetLastWriteTime(directory);
                        item["Type"] = "File folder";
                        item["Size"] = "";

                        IntPtr hImgLarge = SHGetFileInfo(directory, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                        item.Image = System.Drawing.Icon.FromHandle(shinfo.hIcon).ToBitmap();
                    }

                    foreach (string file in files)
                    {
                        ListViewDataItem item = new ListViewDataItem();
                        radListView2.Items.Add(item);
                        item.Tag = file;
                        item.Text = Path.GetFileName(file);
                        item["Name"] = Path.GetFileName(file);
                        item["Date Modified"] = System.IO.File.GetLastWriteTime(file);
                        item["Type"] = "File folder";
                        FileInfo fi = new FileInfo(file);
                        item["Size"] = GetFileSize(fi.Length);

                        IntPtr hImgLarge = SHGetFileInfo(file, 0, ref shinfo, Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
                        item.Image = System.Drawing.Icon.FromHandle(shinfo.hIcon).ToBitmap();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        SHFILEINFO shinfo = new SHFILEINFO();

        // Constants that we need in the function call
        private const int SHGFI_ICON = 0x100;
        private const int SHGFI_SMALLICON = 0x1;
        private const int SHGFI_LARGEICON = 0x0;

        // This structure will contain information about the file
        public struct SHFILEINFO
        {
            // Handle to the icon representing the file
            public IntPtr hIcon;
            // Index of the icon within the image list
            public int iIcon;
            // Various attributes of the file
            public uint dwAttributes;
            // Path to the file
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szDisplayName;
            // File type
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };


        [DllImport("Shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, int cbFileInfo, uint uFlags);


        private string GetFileSize(double byteCount)
        {
            string size = "0 Bytes";
            if (byteCount >= 1073741824.0)
                size = String.Format("{0:##.##}", byteCount / 1073741824.0) + " GB";
            else if (byteCount >= 1048576.0)
                size = String.Format("{0:##.##}", byteCount / 1048576.0) + " MB";
            else if (byteCount >= 1024.0)
                size = String.Format("{0:##.##}", byteCount / 1024.0) + " KB";
            else if (byteCount > 0 && byteCount < 1024.0)
                size = byteCount.ToString() + " Bytes";

            return size;
        }


        private void SetupListView()
        {
            radListView2.ItemMouseDoubleClick += new ListViewItemEventHandler(radListView2_ItemMouseDoubleClick);
            radListView2.KeyDown += new KeyEventHandler(radListView2_KeyDown);
            radListView2.ViewTypeChanged += new EventHandler(radListView2_ViewTypeChanged);
            radListView2.VisualItemFormatting += new ListViewVisualItemEventHandler(radListView2_VisualItemFormatting);
            radListView2.CellFormatting += new ListViewCellFormattingEventHandler(radListView2_CellFormatting);
            radListView2.SelectedItemsChanged += new EventHandler(radListView2_SelectedItemsChanged);
            radListView2.ItemValidating += new ListViewItemValidatingEventHandler(radListView2_ItemValidating);
            radListView2.ItemEdited += new ListViewItemEditedEventHandler(radListView2_ItemEdited);
            radListView2.ItemEditing += new ListViewItemEditingEventHandler(radListView2_ItemEditing);
            radListView2.DragLeave += radListView2_DragLeave;
            radListView2.AllowDrop = true;
            radListView2.AllowDragDrop = true;
            sliderControl1.AllowDrop = true;

            radListView2.EnableFiltering = true;
            radListView2.EnableSorting = true;
            radListView2.MultiSelect = true;
            radListView2.FullRowSelect = false;
            radListView2.AllowRemove = false;

            radListView2.Columns.Add(new ListViewDetailColumn("Name"));
            radListView2.Columns.Add(new ListViewDetailColumn("Date Modified"));
            radListView2.Columns.Add(new ListViewDetailColumn("Type"));
            radListView2.Columns.Add(new ListViewDetailColumn("Size"));
        }



        private string filePath = "";
        private void radListView2_DragLeave(object sender, EventArgs e)
        {
            filePath = radListView2.SelectedItem.Tag.ToString() + "\\" + radListView2.Items[9].SubItems[0].ToString();
        }

        private void radListView2_ItemEditing(object sender, ListViewItemEditingEventArgs e)
        {

            DirectoryInfo di = new DirectoryInfo(e.Item.Tag.ToString());
            if (di.Parent == null)
            {
                RadMessageBox.Show("Cannot change drive name");
                e.Cancel = true;
            }
        }

        private void radListView2_ItemEdited(object sender, ListViewItemEditedEventArgs e)
        {

            try
            {

                string sourcePath = e.VisualItem.Data.Tag.ToString();
                string destinationPath = Path.GetDirectoryName(sourcePath) + "\\" + e.VisualItem.Text;

                if (!(string.Equals(sourcePath, destinationPath)))
                {
                    if (System.IO.File.Exists(sourcePath))
                    {
                        System.IO.File.Move(sourcePath, destinationPath);
                    }
                    else if (System.IO.Directory.Exists(sourcePath))
                    {
                        System.IO.Directory.Move(sourcePath, destinationPath);
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        private void radListView2_ItemValidating(object sender, ListViewItemValidatingEventArgs e)
        {
            if (string.IsNullOrEmpty(Convert.ToString(e.NewValue)))
            {
                e.Cancel = true;
            }
        }

        private void radListView2_SelectedItemsChanged(object sender, EventArgs e)
        {
        }

        private void radListView2_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {
            e.CellElement.TextAlignment = ContentAlignment.MiddleLeft;
            e.CellElement.TextImageRelation = TextImageRelation.ImageBeforeText;
            e.CellElement.ImageAlignment = ContentAlignment.MiddleLeft;
        }

        private void radListView2_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
        {

        }

        private void radListView2_ViewTypeChanged(object sender, EventArgs e)
        {
            switch (radListView2.ViewType)
            {
                case ListViewType.DetailsView:
                    radListView2.AllowArbitraryItemWidth = false;
                    radListView2.AllowArbitraryItemHeight = true;
                    radListView2.ItemSize = new Size(64, 64);
                    break;
                case ListViewType.IconsView:
                    radListView2.AllowArbitraryItemWidth = false;
                    radListView2.AllowArbitraryItemHeight = true;
                    radListView2.ItemSize = new Size(64, 64);
                    break;
                case ListViewType.ListView:
                    radListView2.FullRowSelect = false;

                    break;
                default:
                    break;
            }
        }

        private void radListView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Back)
            {
                NavigateBack();
            }
            if (e.KeyData == Keys.Enter && radListView2.SelectedItem != null)
            {
                foreach (RadTreeNode node in radTreeView1.SelectedNode.Nodes)
                {
                    if (radListView2.SelectedItem.Text == node.Text)
                    {
                        radTreeView1.SelectedNode = node;
                        return;
                    }
                }
                Process.Start(radListView2.SelectedItem.Tag.ToString());
            }
        }


        Stack<RadTreeNode> backCollection = new Stack<RadTreeNode>();
        Stack<RadTreeNode> forwardCollection = new Stack<RadTreeNode>();
        bool navigateOperationInProgress = false;
        CustomButton searchButton;
        AutoCompleteStringCollection autoCompleteDataSource1 = new AutoCompleteStringCollection();
        CustomToggleButton detailsToggleButton;
        CustomToggleButton iconsToggleButton;
        List<ListViewDataItem> copySource = null;
        enum IconSize { Small, Medium, Large, ExtraLarge }
        IconSize iconSize = IconSize.Medium;


        private void NavigateBack()
        {
            if (backCollection.Count > 0)
            {
                if (backCollection.Peek() == radTreeView1.SelectedNode)
                {
                    forwardCollection.Push(backCollection.Pop());
                }
                navigateOperationInProgress = true;
                radTreeView1.SelectedNode = backCollection.Peek();
                forwardCollection.Push(backCollection.Pop());
                navigateOperationInProgress = false;
            }
        }

        private void radListView2_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            foreach (RadTreeNode node in radTreeView1.SelectedNode.Nodes)
            {
                if (e.Item.Text == node.Text)
                {
                    radTreeView1.SelectedNode = node;
                    return;
                }
            }
            Process.Start(e.Item.Tag.ToString());
        }


        void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            Shot shot = null;
            if (e.ClickedItem.Text == "Tag")
            {
                if (radListView1.SelectedItem != null)
                {
                    int index = radListView1.SelectedIndex;
                    try
                    {

                        if (radListView1.SelectedItem["Taged"] == "NO")
                        {
                            double endTime = -1;
                            double startTime = Convert.ToDouble(radListView1.Items[index]["From"].ToString());
                            string filePath = radListView1.Items[index]["FilePath"].ToString();
                            string fileName = radListView1.Items[index]["FileName"].ToString();
                            if (radListView1.Items[index + 1] != null &&
                                radListView1.Items[index]["FilePath"].ToString() ==
                                radListView1.Items[index + 1]["FilePath"].ToString())
                            {
                                endTime = Convert.ToDouble(radListView1.Items[index + 1]["From"].ToString());
                                radListView1.Items[index]["Duration"] = (endTime - startTime).ToString() +
                                                                        " sec";
                            }

                            Image img = radListView1.SelectedItem.Image;
                            TaggingControl control = new TaggingControl(this, startTime, endTime, filePath, fileName, img, index);
                            control.Show();
                        }

                        else if (radListView1.SelectedItem["Taged"] == "YES")
                        {
                            int shotID = Convert.ToInt16(radListView1.Items[index]["ID"].ToString());

                            TaggingControl control = new TaggingControl(this, index, shotID);
                            control.Show();
                        }

                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        public void CloseVideo()
        {
            try
            {


            this.timerControls.Stop();
            this.mediaManager.CloseCurrentVideo();
            this.currentVideoState = VideoState.Stopped;
            }
            catch (Exception)
            {
            }
        }

        public void OpenVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.mediaManager.currentMedia.StopPlay += new HotMediaEvent(videoCompleted);
            this.mediaManager.currentMedia.setVolume(this.currentVolume);
            double fps = this.mediaManager.currentMedia.getFramePerSecond();
            double duration = this.mediaManager.currentMedia.getDuration();
            this.timerControls.Stop();
            this.timerControls.Interval = (int)(1000 / (Math.Max(fps, 30)));
            this.timerControls.Start();
            this.trackBarVideo.Maximum = (int)(fps * duration);

        }

        /// <summary> step n-numbers of frames in stream. </summary>
        private void StepFrames(int frames)
        {
            if ((this.mediaManager.currentMedia.frameStep == null) || (this.mediaManager.currentMedia.control == null))
                return;

            this.mediaManager.currentMedia.frameStep.CanStep(frames, null);
            if (this.currentVideoState != VideoState.Paused)
                this.mediaManager.currentMedia.Pause();

            this.currentVideoState = VideoState.Paused;
            this.mediaManager.currentMedia.frameStep.Step((int)frames, null);
        }

        public void PlayVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            if (this.currentAudioState == AudioState.Enabled)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);

            if (this.currentVideoState == VideoState.Stopped)
            {
                this.BTN_PlayPause.BackgroundImage = global::ShotDetection.Properties.Resources.vpause;

                //WS
                if (thumbSeconds < this.mediaManager.currentMedia.getDuration())
                {
                    this.mediaManager.currentMedia.setPosition((double)thumbSeconds);
                }

                this.mediaManager.currentMedia.Start();
                this.currentVideoState = VideoState.Playing;
            }
            else if (this.currentVideoState == VideoState.Playing)
            {
                this.BTN_PlayPause.BackgroundImage = global::ShotDetection.Properties.Resources.vplay;
                this.mediaManager.currentMedia.Pause();
                this.currentVideoState = VideoState.Paused;
            }
            else
            {
                this.BTN_PlayPause.BackgroundImage = global::ShotDetection.Properties.Resources.vpause;
                this.mediaManager.currentMedia.Start();
                this.currentVideoState = VideoState.Playing;
            }
        }

        public void StopVideo()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            this.BTN_PlayPause.BackgroundImage = global::ShotDetection.Properties.Resources.vplay;
            this.mediaManager.currentMedia.Stop();
            this.mediaManager.currentMedia.Rewind();
            this.currentVideoState = VideoState.Stopped;
        }


        private void BTN_PlayPause_Click(object sender, EventArgs e)
        {
            this.PlayVideo();
        }

        private void BTN_Stop_Click(object sender, EventArgs e)
        {
            this.StopVideo();
        }

        private void Rewind()
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.mediaManager.currentMedia.Rewind();
        }

        private void BTN_FastRewind_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Interval = 1000 / ((int)this.mediaManager.currentMedia.getFramePerSecond() * 2);
            this.timerVideo.Start();
            this.currentVideoState = VideoState.FastBackwards;
        }

        private void BTN_FastForward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Interval = 1000 / ((int)this.mediaManager.currentMedia.getFramePerSecond() * 2);
            this.timerVideo.Start();
            this.currentVideoState = VideoState.FastForwarding;
        }

        private void mediaTimerTick(object sender, EventArgs e)
        {
            if (currentVideoState == VideoState.FastBackwards)
                this.mediaManager.currentMedia.FastBackwards();
            if (currentVideoState == VideoState.FastForwarding)
                this.mediaManager.currentMedia.FastForward();
        }

        private void timerControls_Tick(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia != null)
            {
                double fps = this.mediaManager.currentMedia.getFramePerSecond();
                double position = this.mediaManager.currentMedia.getPosition();
                this.trackBarVideo.Value = (int)(position * fps);
                this.statusLabel.Text = Sec2String(this.mediaManager.currentMedia.getPosition()) + " / " +
                                        Sec2String(this.mediaManager.currentMedia.getDuration());

                if ((this.currentVideoState == VideoState.Playing) && (this.currentVideoState != VideoState.Paused))
                {
                    double thumbPosInFile = position;
                    int pos = 0;
                    pos = Convert.ToInt32(thumbPosInFile);
                    if (pos < 0)
                        pos = 0;
                    this.sliderControl1.videoSlider1.Value = pos;
                }
            }

        }

        public void MuteAudio()
        {
            this.currentAudioState = AudioState.Disabled;
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(-10000);
        }

        public void UnMuteAudio()
        {
            this.currentAudioState = AudioState.Enabled;
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);
        }

        private void BTN_Mute_Click(object sender, EventArgs e)
        {
            int newVolume = this.currentVolume;
            if (this.currentAudioState == AudioState.Enabled)
            {
                newVolume = -10000;
                this.BTN_Mute.BackgroundImage = global::ShotDetection.Properties.Resources.vmute;
                this.currentAudioState = AudioState.Disabled;
            }
            else if (this.currentAudioState == AudioState.Disabled)
            {
                newVolume = this.currentVolume;
                this.BTN_Mute.BackgroundImage = global::ShotDetection.Properties.Resources.vunmute;
                this.currentAudioState = AudioState.Enabled;
            }
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(newVolume);
        }

        private void trackBarVolume_Changed(object sender, EventArgs e)
        {
            this.currentVolume = (int)(-Math.Pow(10, 4 * ((double)this.trackBarVolume.Value / (double)this.trackBarVolume.Maximum)));
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.setVolume(this.currentVolume);
        }


        private void BTN_StepBackward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;
            double newPosition = this.mediaManager.currentMedia.getPosition() - 5;
            this.mediaManager.currentMedia.setPosition(newPosition);
        }

        private void BTN_StepForward_Click(object sender, EventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;
            double newPosition = this.mediaManager.currentMedia.getPosition() + 5;
            this.mediaManager.currentMedia.setPosition(newPosition);
        }

        public void videoCompleted(object sender)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            this.timerVideo.Stop();
            this.mediaManager.currentMedia.Stop();
            this.mediaManager.currentMedia.Rewind();
            this.currentVideoState = VideoState.Stopped;
        }

        //Prevents rectangle from showing on buttons
        //You can also use this to set dropshows on buttons
        private void ResetButtonRegion(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath myGraphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
            myGraphicsPath.AddEllipse(0, 0, ((Button)sender).Width - 4, ((Button)sender).Height - 4);
            ((Button)sender).Region = new Region(myGraphicsPath);
        }


        private void MediaForm_Resize(object sender, EventArgs e)
        {

            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.SizeWindow();

            //this.sliderControl1.Dock = DockStyle.Bottom;
            // this.snapShots1.Width = this.sliderControl1.Width;
            //this.sliderControl1.Top = this.radSplitContainer1.Bottom + 60;
            //this.sliderControl1.Height = this.sliderControl1.Top - this.statusStrip.Top;




            //this.sliderControl1.ClearBars();
            //DataTable dt = (DataTable)videoFilesList;
            ////DataView dv = new DataView(dt);
            ////dv.Sort = "FileDate";
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            //object[] param = new object[] { ds };
            //this.sliderControl1.LoadBarsFromDataSet(param);
            //this.sliderControl1.videoSlider1.Invalidate();

            //this.sliderControl1.SetZoom(3);
            //thumbSeconds = 0;
            //this.sliderControl1.SetSliderHPosition();

            //// Bill SerGio: Dispose of DataSet
            //ds.Dispose();
        }

        private void trackBarVideo_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int position = (int)((this.trackBarVideo.Maximum * e.X) / this.trackBarVideo.Width);
                if (this.currentVideoState == VideoState.Playing)
                {
                    this.mediaManager.currentMedia.Pause();
                    this.mediaManager.currentMedia.setPosition(position);
                    this.mediaManager.currentMedia.Start();
                }
                if (this.currentVideoState == VideoState.Paused)
                    this.mediaManager.currentMedia.setPosition(position);
            }
        }

        private void trackBarVideo_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (e.Button == MouseButtons.Left)
            {
                int position = (int)((this.trackBarVideo.Maximum * e.X) / this.trackBarVideo.Width);

                if (this.currentVideoState == VideoState.Playing)
                {
                    this.mediaManager.currentMedia.Pause();
                    this.mediaManager.currentMedia.setPosition(position);
                    this.mediaManager.currentMedia.Start();
                }
                if (this.currentVideoState == VideoState.Paused)
                    this.mediaManager.currentMedia.setPosition(position);
            }
        }


        public int BufferCB(double SampleTime, IntPtr pBuffer, int bufferLen)
        {
            MediaInfo mediaInfo = this.mediaManager.currentMedia.mediaInfo;
            this.filtersManager.Process(SampleTime, pBuffer, bufferLen, mediaInfo);
            if (this.currentEditingState == EditingState.SelectingFilter &&
                this.currentState == FilterDefinitionState.FilterTypeChoosen)
            {
                byte[] copyBytes = new byte[bufferLen];
                Marshal.Copy(pBuffer, copyBytes, 0, bufferLen);
                int stride = mediaInfo.MediaStride;
                int stride2 = mediaInfo.MediaStride * 2;
                int videoWidth = mediaInfo.MediaWidth;
                int videoHeight = mediaInfo.MediaHeight;
                int windowX, windowY, windowWidth, windowHeight;
                this.mediaManager.currentMedia.videoWindow.GetWindowPosition(out windowX, out windowY, out windowWidth, out windowHeight);
                int xOffset = (this.PANEL_Video.Width - windowWidth) / 2;
                int yOffset = (this.PANEL_Video.Height - windowHeight) / 2;
                double xRatio = (double)mediaInfo.MediaWidth / windowWidth;
                double yRatio = (double)mediaInfo.MediaHeight / windowHeight;
                this.filterMinX = Math.Max(0, Math.Min(windowWidth - 1, filterDown.X - 1));
                this.filterMinY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterDown.Y - 1));
                this.filterMinX = (int)(this.filterMinX * xRatio);
                this.filterMinY = (int)(this.filterMinY * yRatio);
                this.filterMaxX = Math.Max(0, Math.Min(windowWidth - 1, filterUp.X - 1 - xOffset));
                this.filterMaxY = Math.Max(0, Math.Min(windowHeight - 1, windowHeight - filterUp.Y - 1 + yOffset));
                this.filterMaxX = (int)(this.filterMaxX * xRatio);
                this.filterMaxY = (int)(this.filterMaxY * yRatio);
                unsafe
                {
                    byte* a = (byte*)(void*)pBuffer;
                    byte* b = (byte*)(void*)pBuffer;
                    byte* c = (byte*)(void*)pBuffer;
                    byte* d = (byte*)(void*)pBuffer;
                    int nOffset = stride - videoWidth * 3;
                    int nWidth = videoWidth - 2;
                    int nHeight = videoHeight - 2;
                    int y, x;
                    int filterWidth = Math.Abs(this.filterMaxX - this.filterMinX);
                    int filterWidthSignal = Math.Sign(this.filterMaxX - this.filterMinX);
                    int filterHeight = Math.Abs(this.filterMaxY - this.filterMinY);
                    int filterHeightSignal = Math.Sign(this.filterMaxY - this.filterMinY);
                    a += this.filterMinY * stride + this.filterMinX * 3;
                    b += this.filterMaxY * stride + this.filterMinX * 3;
                    for (x = 0; x < filterWidth; ++x)
                    {
                        a[2] = (byte)255;
                        a[1] = (byte)255;
                        a[0] = (byte)255;
                        b[2] = (byte)255;
                        b[1] = (byte)255;
                        b[0] = (byte)255;
                        a = a + filterWidthSignal * 3;
                        b = b + filterWidthSignal * 3;
                    }
                    c += this.filterMinY * stride + this.filterMinX * 3;
                    d += this.filterMinY * stride + this.filterMaxX * 3;

                    for (y = 0; y < filterHeight; ++y)
                    {
                        c[2] = (byte)255;
                        c[1] = (byte)255;
                        c[0] = (byte)255;
                        d[2] = (byte)255;
                        d[1] = (byte)255;
                        d[0] = (byte)255;
                        c = c + filterHeightSignal * stride;
                        d = d + filterHeightSignal * stride;
                    }
                }
            }
            return 0;
        }

        public int SampleCB(double SampleTime, IMediaSample pSample)
        {
            return 0;
        }

        private void PANEL_Video_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.currentFilterArea == FilterArea.Partial)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.filterDown.X = e.X;
                    this.filterDown.Y = e.Y;
                    this.currentEditingState = EditingState.SelectingFilter;
                }
            }
        }


        private void PANEL_Video_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.filterUp.X = e.X;
                this.filterUp.Y = e.Y;
            }
        }

        private void PANEL_Video_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.currentFilterArea == FilterArea.Partial)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.filterUp.X = e.X;
                    this.filterUp.Y = e.Y;
                    this.currentEditingState = EditingState.None;
                }

                this.currentState = FilterDefinitionState.AreaOverVideoChoosen;
                this.EnableFiltering();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.sliderControl1.videoSlider1.ValueChanged += new System.EventHandler(this.SlidersValueChanged);
            this.sliderControl1.videoSlider1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.SlidersScroll);
            this.sliderControl1.videoSlider1.MouseClick += new MouseEventHandler(videoSlider1_MouseClick);
            this.sliderControl1.videoSlider1.MouseDown += new MouseEventHandler(videoSlider1_MouseDown);
            this.sliderControl1.videoSlider1.MouseUp += new MouseEventHandler(videoSlider1_MouseUp);
            this.sliderControl1.ValidClick += new TimeControl.SliderControl.ValidClickHandler(sliderControl1_ValidClick);
            this.sliderControl1.AddRemoveClick += new TimeControl.SliderControl.AddRemoveClickHandler(sliderControl1_AddRemoveClick);
            radPageView1.SelectedPage = radPageViewPage1;
        }


        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                TreeNode parentnode = e.Node;
                DirectoryInfo dr = new DirectoryInfo(parentnode.FullPath);
                parentnode.Nodes.Clear();
                foreach (DirectoryInfo dir in dr.GetDirectories())
                {
                    TreeNode node = new TreeNode();
                    node.Text = dir.Name;
                    node.Nodes.Add("");
                    parentnode.Nodes.Add(node);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!");
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode current = e.Node;
                string path = current.FullPath;
                string[] Files = ((from r in Directory.GetFiles(path)
                                   where r.EndsWith(".mov") || r.EndsWith(".wm")
                                   || r.EndsWith(".mp") || r.EndsWith(".w4v") ||
                                   r.EndsWith(".avi")
                                   select r).ToArray());

                string[] Directories = Directory.GetDirectories(path);
                string[] subinfo = new string[3];
                //listView1.Clear();
                //listView1.Columns.Add("Name", 255);
                //listView1.Columns.Add("Size", 100);
                //listView1.Columns.Add("Type", 80);
                foreach (string Dname in Directories)
                {
                    subinfo[0] = GetFileName(Dname);
                    subinfo[1] = "";
                    subinfo[2] = "FOLDER";
                    ListViewItem DItems = new ListViewItem(subinfo);
                    // listView1.Items.Add(DItems);
                }
                foreach (string Fname in Files)
                {
                    subinfo[0] = GetFileName(Fname);
                    subinfo[1] = GetSizeinfo(Fname);
                    subinfo[2] = GetTypeinfo(Fname);
                    ListViewItem FItems = new ListViewItem(subinfo);
                    // listView1.Items.Add(FItems);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!");
            }
        }
        public string GetFileName(string path)
        {
            int Nameindex = path.LastIndexOf('\\');
            return path.Substring(Nameindex + 1);
        }
        public string GetTypeinfo(string path)
        {
            int Typeindex = path.LastIndexOf('.');
            string FType;
            if (Typeindex != -1)
            {
                FType = path.Substring(Typeindex + 1);
                FType = FType.ToUpper();
                if (FType == "AVI" || FType == "3GP" || FType == "WMV")
                {
                    FType = "Video Clip";
                }
                else if (FType == "MP3")
                {
                    FType = "MP3 Format Sound";
                }
                return FType;
            }
            else
            {
                FType = "FILE";
                return FType;
            }
        }
        public string GetSizeinfo(string path)
        {
            FileInfo fi = new FileInfo(path);
            long size = fi.Length;
            string txtsize = "";
            if (size < 1024)
            {
                txtsize = "byte";
            }
            else if (size > 1024)
            {
                size = size / 1024;
                txtsize = "Kb";
            }
            if (size > 1024)
            {
                size = size / 1024;
                txtsize = "Mb";
            }
            if (size > 1024)
            {
                size = size / 1024;
                txtsize = "Gb";
            }
            return size + " " + txtsize;
        }


        private void videoSlider1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            if (this.currentVideoState == VideoState.Playing)
            {
                this.mediaManager.currentMedia.Pause();
            }
        }

        private void videoSlider1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            goThumbPosition = this.sliderControl1.videoSlider1.Value;
            if (this.currentVideoState == VideoState.Playing)
            {
                this.mediaManager.currentMedia.Pause();
                this.mediaManager.currentMedia.setPosition(goThumbPosition);
                this.mediaManager.currentMedia.Start();
            }
            if (this.currentVideoState == VideoState.Paused)
                this.mediaManager.currentMedia.setPosition(goThumbPosition);
        }

        private void videoSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, this.sliderControl1.videoSlider1.MouseDownValue, 0);
            string ss = string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
            goThumbPosition = this.sliderControl1.videoSlider1.MouseDownValue;
            StopVideo();
            //PlayVideoFiles(goThumbPosition);
            thumbSeconds = goThumbPosition;
        }

        public void SlidersScroll(object sender, ScrollEventArgs e)
        {
            lock (this)
            {
                if (e.NewValue < 0)
                    return;
            }
        }

        public void SlidersValueChanged(object sender, EventArgs e)
        {
            lock (this.syncRoot)
            {
                if ((sender as TimeControl.VideoSlider).Value < 0)
                    return;

                thumbSeconds = (sender as TimeControl.VideoSlider).Value;
                Time tt = new Time((sender as TimeControl.VideoSlider).Value);
            }
        }



        private void sliderControl1_AddRemoveClick(object sender, TimeControl.AddRemoveClickEventArgs e)
        {
            if (e.addremove > 0)
                AddMedia();
            else
            {
                RemoveMedia();
                //  this.snapShots1.Clear();
            }
        }

        bool CheckExtension(FileInfo f)
        {
            if (f.Extension.StartsWith(".mp"))
                return true;
            if (f.Extension.StartsWith(".wm"))
                return true;
            if (f.Extension.StartsWith(".avi"))
                return true;
            if (f.Extension.StartsWith(".asf"))
                return true;
            if (f.Extension.StartsWith(".mov"))
                return true;
            if (f.Extension.StartsWith(".rm"))
                return true;
            if (f.Extension.StartsWith(".ram"))
                return true;
            if (f.Extension.StartsWith(".m4v"))
                return true;
            return false;
        }

        private void AddMedia()
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            System.IO.FileInfo fi = new System.IO.FileInfo(this.openFileDialog.FileName);
            if ((!fi.Exists) || (!CheckExtension(fi)))
                return;
            bool bFound = false;
            string sFilePath = string.Empty;
            for (int i = 0; i < videoFilesList.Count; i++)
            {
                sFilePath = videoFilesList[i].FilePath;
                if (fi.FullName == sFilePath)
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
                return;

            try
            {
                MediaPlayer newVideo = new MediaPlayer(this.openFileDialog.FileName);
                if (!this.mediaManager.videos.Contains(this.openFileDialog.FileName))
                {

                    double fps = 0;
                    double duration = 0;
                    fps = newVideo.getFramePerSecond();
                    duration = newVideo.getDuration();

                    VideoFile model = null;
                    model = videoFileRepository.Get(v => v.m_fileName == fi.Name &&
                   v.m_fps == fps && v.m_filePath == fi.FullName && v.m_duration == duration);

                    //if (model != null)
                    //{

                    //    foreach (var shot in model.Shots)
                    //    {

                    //    }
                    //}

                    VideoFiles video = new VideoFiles(fi.Name, fi.FullName, 0, fps, duration);
                    //  if (model != null) video.shots = model.Shots;
                    videoFilesList.Add(video);

                    DataTable dt = (DataTable)videoFilesList;
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    object[] param = new object[] { ds };
                    this.sliderControl1.LoadBarsFromDataSet(param);
                    this.sliderControl1.videoSlider1.Invalidate();

                    this.sliderControl1.SetZoom(3);
                    thumbSeconds = 0;
                    this.sliderControl1.SetSliderHPosition();

                    this.mediaManager.AddVideo(newVideo, this.openFileDialog.FileName);

                    ds.Dispose();
                }
            }
            catch (COMException comex)
            {
                MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RemoveMedia()
        {
            int iSelected = this.sliderControl1.videoSlider1.BarIndex;

            if (iSelected > -1)
            {
                string sFilePath = this.sliderControl1.videoSlider1.Bars[iSelected].FilePath;
                MediaPlayer video = this.mediaManager.GetVideo(sFilePath);
                if (video == this.mediaManager.currentMedia)
                {
                    this.StopVideo();
                    this.mediaManager.CloseCurrentVideo();
                }
                this.ReloadInfo();
                this.mediaManager.RemoveVideo(sFilePath);

                string sTemp = string.Empty;
                for (int i = 0; i < videoFilesList.Count; i++)
                {
                    sTemp = videoFilesList[i].FilePath;
                    if (sTemp == sFilePath)
                    {
                        videoFilesList.RemoveAt(i);
                        break;
                    }
                }

                try
                {
                    if (videoFilesList.Count > 0)
                    {
                        DataTable dt = (DataTable)videoFilesList;
                        //DataView dv = new DataView(dt);
                        //dv.Sort = "FileDate";
                        DataSet ds = new DataSet();
                        ds.Tables.Add(dt);
                        object[] param = new object[] { ds };
                        this.sliderControl1.LoadBarsFromDataSet(param);
                        this.sliderControl1.videoSlider1.Invalidate();
                        // Bill SerGio: Dispose of DataSet
                        ds.Dispose();
                        this.sliderControl1.SetZoom(3);
                    }
                    else
                    {
                        this.sliderControl1.ClearGraph();
                        this.sliderControl1.SetZoom(1);
                    }

                }
                catch (COMException comex)
                {
                    MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            LoadVideo(0);
        }

        private void LoadVideo(int iBtnID)
        {
            if (this.mediaManager.currentMedia == null)
                return;

            string sFilePath = string.Empty;
            //this.sliderControl1.videoSlider1.SelectBar(newIndex);

            int iSelectedBar = this.sliderControl1.videoSlider1.BarIndex;
            if (iSelectedBar < 0)
                return;

            sFilePath = this.sliderControl1.videoSlider1.Bars[iSelectedBar].FilePath;

            this.StopVideo();
            if (this.mediaManager.currentMedia != null)
                this.mediaManager.currentMedia.ClearVideoWindow();
            if (this.filtersManager.currentFilter != null)
                this.filtersManager.currentFilter = null;
            this.mediaManager.SetCurrentVideo(sFilePath);
            this.OpenVideo();
            this.ReloadInfo();

            this.mediaManager.currentMedia.SetupVideoWindow(this.PANEL_Video);
            this.PlayVideo();
            this.LoadShots();
        }

        private void LoadShots()
        {
            if (videoFilesList[this.sliderControl1.videoSlider1.BarIndex] != null)
            {
                VideoFiles video = videoFilesList[this.sliderControl1.videoSlider1.BarIndex];
                if (video.shots != null)
                    foreach (var shot in video.shots)
                    {

                        Image returnImage = null;
                        using (MemoryStream ms = new MemoryStream(shot.ThumbnailImage, 0, shot.ThumbnailImage.Length))
                        {
                            ms.Seek(0, SeekOrigin.Begin);
                            returnImage = Image.FromStream(ms);
                        }
                        string f = shot.From.ToString();
                        returnImage.Save(f);

                        //imageListView1.Items.Add(item);
                    }
            }
        }


        public void ReloadInfo()
        {

        }

        private Frames currentshot;
        public void AddShot(double shotTime)
        {

            PictureBox box;
            if (this.mediaManager.currentMedia != null)
            {

                if (shots == null)
                    shots = new List<Frames>();

                if (this.mediaManager.currentMedia.fileType == VideoEditor.enums.FileType.Video)
                {
                    currentshot = new Frames(shotTime - 1.0, this.mediaManager.currentMedia.SnapShot(shotTime));

                    int index = this.sliderControl1.videoSlider1.BarIndex;
                    radListView1.Items.Add("", videoFilesList[index].FilePath,
                                           videoFilesList[index].FileName,
                                           shotTime.ToString(), "", "", "", "", "", "", DateTime.Now.ToShortDateString(), "NO"
                                           );
                }

            }

        }


        public void pictureClick(object sender, EventArgs e)
        {
            int index = Int16.Parse(((PictureBox)sender).Name);
            this.mediaManager.currentMedia.setPosition((this.images[index]).time);
        }



        ///////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////

        private void LoadFilter(string sFilterName, FilterArea filterArea)
        {
            if (sFilterName == "SomeFilter")
            {
                this.currentState = FilterDefinitionState.FilterTypeChoosen;
                this.currentFilterType = FilterType.Negative;

                //SomeFilter sf = new SomeFilter();
                //this.filtersManager.currentFilter = sf;

                if (filterArea == FilterArea.Partial)
                {
                    //sf.Complete = false;
                }
                else
                {
                    //sf.Complete = true;
                    //sf.Active = true;
                }
            }
        }


        private void completeFilterArea(object sender, EventArgs e)
        {
            this.currentState = FilterDefinitionState.FilterAreaChoosen;
            this.currentFilterArea = FilterArea.Complete;
        }

        private void partialFilter()
        {
            this.currentState = FilterDefinitionState.FilterAreaChoosen;
            this.currentFilterArea = FilterArea.Partial;
        }

        private void clearFilters()
        {
            this.currentState = FilterDefinitionState.None;
            this.currentFilterArea = FilterArea.None;
            this.currentFilterType = FilterType.None;
            this.filtersManager.currentFilter = null;
        }

        public void EnableFiltering()
        {
            if (this.filtersManager.currentFilter != null)
            {
                VideoEditor.Filter currentFilter = this.filtersManager.currentFilter;
                currentFilter.Xmin = this.filterMinX;
                currentFilter.Ymin = this.filterMinY;
                currentFilter.Xmax = this.filterMaxX;
                currentFilter.Ymax = this.filterMaxY;
                currentFilter.Active = true;
            }
        }

        public void ResetFiltersForm()
        {
            this.currentState = FilterDefinitionState.None;
        }


        public static string Sec2String(double seconds)
        {
            double mySeconds = seconds;

            int myHours = (int)(mySeconds / 3600); //3600 Seconds in 1 hour 
            mySeconds %= 3600;

            int myMinutes = (int)(mySeconds / 60); //60 Seconds in a minute 
            mySeconds %= 60;

            string mySec = ((int)mySeconds).ToString();
            string myMin = myMinutes.ToString();
            string myHou = myHours.ToString();

            if (myHours < 10) { myHou = myHou.Insert(0, "0"); }
            if (myMinutes < 10) { myMin = myMin.Insert(0, "0"); }
            if (mySeconds < 10) { mySec = mySec.Insert(0, "0"); }

            return myHou + ":" + myMin + ":" + mySec;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.mediaManager.currentMedia != null)
            {
                this.mediaManager.currentMedia.Stop();
                this.mediaManager.currentMedia.Dispose();
                this.mediaManager.currentMedia = null;
                this.currentVideoState = VideoState.Stopped;
            }


            try
            {


            CloseVideo();
            this.timerVideo.Stop();
            this.timerControls.Stop();
            // this.snapShots1.Clear();

            //System.Threading.Thread t = new System.Threading.Thread(delegate()
            //{
            //    Environment.Exit(1);
            //});
            //t.Start();
            //t.Join();

            //System.Windows.Forms.Application.Exit();
            //System.Environment.Exit(0);

            }
            catch (Exception)
            {
            }

        }


        #region --- PLAY RECORDINGS METHODS ----------------------------------------

        private string SecondsToString(int seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, seconds, 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(float length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }
        string SecondsToString(double length)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, Convert.ToInt32(length), 0);
            return string.Format("{0}:{1}:{2}", ts.Hours.ToString("00"), ts.Minutes.ToString("00"), ts.Seconds.ToString("00"));
        }

        #endregion --- PLAY RECORDINGS METHODS -------------------------------------

        private void sliderControl1_ValidClick(object sender, TimeControl.FireEventArgs e)
        {
            //int i = this.sliderControl1.videoSlider1.BarIndex;
            //MessageBox.Show(i.ToString());
            int newIndex = Convert.ToInt32(e.btnID);

            //if (newIndex > -1)
            //{
            //    //if (e.btnID != e.btnPrevID)
            //    LoadVideo(newIndex);
            //}

            if (this.sliderControl1.videoSlider1.Bars.Length < 1)
                return;

            //int i = this.sliderControl1.videoSlider1.BarIndex;

            if ((newIndex > -1) && (newIndex < this.sliderControl1.videoSlider1.Bars.Length))
            {
                //Stops previous video
                this.StopVideo();

                //Clears the assossiation between that video and current control
                if (this.mediaManager.currentMedia != null)
                    this.mediaManager.currentMedia.ClearVideoWindow();

                //Clears filters
                if (this.filtersManager.currentFilter != null)
                    this.filtersManager.currentFilter = null;

                this.sliderControl1.videoSlider1.SelectBar(newIndex);
                //Sets Selected Item as new Video
                //i = this.sliderControl1.videoSlider1.BarIndex;
                string sFile = this.sliderControl1.videoSlider1.Bars[newIndex].FilePath;
                this.mediaManager.SetCurrentVideo(sFile);

                //Opens video
                this.OpenVideo();

                //Reloads TracksForm info
                this.ReloadInfo();

                if (this.mediaManager.currentMedia != null)
                    this.mediaManager.currentMedia.SetupVideoWindow(PANEL_Video);

                LoadVideo(newIndex);

            }

        }

        private void detectShotBtn_Click(object sender, EventArgs e)
        {
            //Cursor.Current = Cursors.WaitCursor;
            //if (dataGridView1 != null)
            //{
            //    dataGridView1.Rows.Clear();
            //    dataGridView1.Visible = true;
            //}
            cam = new DSCapture(this.mediaManager.currentMedia.mediaInfo.sFilePath);
            shots = new List<Frames>();

            // Start displaying statistics
            timer2.Enabled = true;
            cam.Start(); //capture the next image
            cam.WaitUntilDone();
            timer2.Enabled = false;

            // Final update
            // dataGridView1.Rows.Add(cam.m_Scenes, cam.m_ShotTime.ToString());

            lock (this)
            {
                cam.Dispose();
                cam = null;
            }

            Cursor.Current = Cursors.Default;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (cam != null && cam.shotChanged == true)
            {
                AddShot(cam.ShotTime);
                cam.shotChanged = false;
            }
        }


        public List<Frames> shots { get; set; }


        //private void imageListView1_ItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.mediaManager.currentMedia.setPosition(Convert.ToDouble(e.Item.Text));
        //    setMode = "Play";
        //    currentShot = e.Item.Index;

        //    shotTimer.Start();
        //    mediaManager.currentMedia.Start();
        //}



        public int currentShot { get; set; }

        private void shotTimer_Tick(object sender, EventArgs e)
        {
            //try
            //{
            //    if (setMode == "Play" && this.mediaManager.currentMedia != null && imageListView1.Items[currentShot + 1] != null)
            //    {

            //        double d = mediaManager.currentMedia.getPosition();
            //        if (d >= Convert.ToDouble(imageListView1.Items[currentShot + 1].Text.ToString()))
            //        {
            //            mediaManager.currentMedia.Stop();
            //            shotTimer.Stop();
            //        }

            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        private void radPageViewPage1_Paint(object sender, PaintEventArgs e)
        {

        }


        void SortDescriptors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this.radListView1.SortDescriptors.Count == 0)
            {
                this.commandBarDropDownSort.SelectedIndex = 0;
                return;
            }

            string columnName = this.radListView1.Columns[this.radListView1.SortDescriptors[0].PropertyName].HeaderText;
            if (columnName == "Manufactured")
            {
                columnName = "Year";
            }
            RadListDataItem item = this.commandBarDropDownSort.ListElement.FindItemExact(columnName, false);
            if (item != null)
            {
                this.commandBarDropDownSort.SelectedItem = item;
            }
        }

        void radListView1_BindingCompleted(object sender, System.EventArgs e)
        {

            this.radListView1.Columns["Image"].Width = 180;
            this.radListView1.Columns["Image"].MinWidth = 180;
            this.radListView1.Columns["DateAdded"].Width = 90;
            this.radListView1.Columns["DateAdded"].MinWidth = 90;
            this.radListView1.Columns["From"].Width = 40;
            this.radListView1.Columns["From"].MinWidth = 40;
            this.radListView1.Columns["To"].Width = 40;
            this.radListView1.Columns["To"].MinWidth = 40;
            this.radListView1.Columns["KeyFrame"].Width = 70;
            this.radListView1.Columns["Description"].MinWidth = 200;
            this.radListView1.Columns["Tags"].MinWidth = 200;
            this.radListView1.Columns["Taged"].Width = 30;

            this.radListView1.Columns["FilePath"].Visible = false;

            int pictureColumnIndex = this.radListView1.Columns.IndexOf("Image");
            this.radListView1.Columns.Move(pictureColumnIndex, 0);
        }

        void radListView1_ColumnCreating(object sender, ListViewColumnCreatingEventArgs e)
        {

            if (e.Column.FieldName == "Image")
                e.Column.HeaderText = "Picture";

            if (e.Column.FieldName == "DateAdded")
                e.Column.HeaderText = "Date Added";

            if (e.Column.Name == "FilePath")
                e.Column.Visible = false;


            if (e.Column.FieldName == "Category")
            {
                e.Column.HeaderText = "Category";
                e.Column.Width = 90;
                e.Column.MinWidth = 90;
            }

            if (e.Column.FieldName == "Description")
            {
                e.Column.HeaderText = "Description";
                e.Column.Width = 200;
                e.Column.MinWidth = 200;
            }

        }

        void radListView1_CellFormatting(object sender, ListViewCellFormattingEventArgs e)
        {

            if (e.CellElement is DetailListViewHeaderCellElement)
            {
                return;
            }

            if (e.CellElement.Data.HeaderText == "Picture")
            {
                ((DetailListViewDataCellElement)e.CellElement).Image = ((DetailListViewDataCellElement)e.CellElement).Row.Image;
                e.CellElement.Text = "";
                e.CellElement.ImageAlignment = ContentAlignment.MiddleCenter;
                e.CellElement.TextImageRelation = TextImageRelation.Overlay;
            }
            else
            {
                e.CellElement.Image = null;
            }

            if (e.CellElement.Data.HeaderText == "Date Added" || e.CellElement.Data.HeaderText == "Rating")
            {
                e.CellElement.Text = "<html><span style=\"color:#161112;font-size:11.5pt;\">" + e.CellElement.Text + "</span>";
            }
            else if (this.features.Contains(e.CellElement.Data.FieldName))
            {
                bool containsFeature = this.ContainsFeature(((DetailListViewDataCellElement)e.CellElement).Row, e.CellElement.Data.FieldName);
                string color = (containsFeature) ? "#050F70" : "#B52822";
                e.CellElement.ForeColor = (Color)(new ColorConverter().ConvertFromString(color));
                e.CellElement.Font = new Font(e.CellElement.Font.FontFamily, 10, GraphicsUnit.Point);
                //e.CellElement.Text = (containsFeature) ? "YES" : "NO";
            }
            else if (e.CellElement.Data.HeaderText != "Picture")
            {
                e.CellElement.ForeColor = (Color)(new ColorConverter().ConvertFromString("#050F70"));
                e.CellElement.Font = new Font(e.CellElement.Font.FontFamily, 10, GraphicsUnit.Point);
                e.CellElement.Text = e.CellElement.Text;
            }
        }

        void radListView1_ViewTypeChanged(object sender, EventArgs e)
        {
            switch (radListView1.ViewType)
            {
                case ListViewType.ListView:
                    SetupIconsView();
                    break;
                case ListViewType.IconsView:
                    SetupIconsView();
                    break;
                case ListViewType.DetailsView:
                    SetupDetailsView();
                    break;
            }
        }

        private void SetupDetailsView()
        {
            this.radListView1.ItemSize = new Size(0, 110);
        }

        private void SetupIconsView()
        {
            this.radListView1.ItemSize = new Size(295, 120);
            this.radListView1.ItemSpacing = 5;
            this.radListView1.GroupIndent = 0;
        }

        private void SetupSimpleListView()
        {
            this.radListView1.AllowArbitraryItemHeight = true;

        }

        List<string> features = new List<string>() { "From", "ToTime", "Rating" };

        private bool ContainsFeature(ListViewDataItem item, string feature)
        {
            return item[feature] != null && Convert.ToInt32(item[feature]) != 0;
        }

        private string GetFeatures(ListViewDataItem item)
        {
            StringBuilder featuresString = new StringBuilder();

            foreach (string feature in this.features)
            {
                if (ContainsFeature(item, feature))
                {
                    featuresString.Append(feature + ", ");
                }
            }

            if (featuresString.Length > 1)
            {
                featuresString.Remove(featuresString.Length - 2, 2);
            }

            return featuresString.ToString();
        }


        void radListView1_VisualItemCreating(object sender, Telerik.WinControls.UI.ListViewVisualItemCreatingEventArgs e)
        {
        //    if (this.radListView1.ViewType == ListViewType.ListView && !(e.VisualItem is BaseListViewGroupVisualItem))
        //    {
        //        e.VisualItem = new CarsListVisualItem();
        //    }
        }

        void radListView1_VisualItemFormatting(object sender, Telerik.WinControls.UI.ListViewVisualItemEventArgs e)
        {
            if (e.VisualItem is BaseListViewGroupVisualItem)
            {
                return;
            }



            if (this.radListView1.ViewType == ListViewType.IconsView)
            {

                if (e.VisualItem.Data["Taged"] == "YES")
                    e.VisualItem.Text = "<html>" +
                        "<span style=\"color:#040203;font-size:8pt;\">" + "From : " + e.VisualItem.Data["From"] + " sec" +
                                        "<br><span style=\"color:#040203;font-size:8pt;\">" + "Duration:" + e.VisualItem.Data["Duration"] + "</span>"
                                        + "<br><span style=\"color:#0f9f13;font-size:10pt;\">" + e.VisualItem.Data["Category"] + "</span>"
                                        + "<br><span style=\"color:#0f54d3;font-size:7.5pt;\">" + "Taged" + "</span>";

                else if (e.VisualItem.Data["Taged"] == "NO")
                    e.VisualItem.Text = "<html>" +
                                        "<span style=\"color:#040203;font-size:8pt;\">" + "From : " + e.VisualItem.Data["From"] + " sec " + "</span>"
                                        + "<br><span style=\"color:#040203;font-size:8pt;\">" + "Duration:" + e.VisualItem.Data["Duration"] + "</span>"
                                        + "<br><span style=\"color:#0f9f13;font-size:7.5pt;\">" + "Double Click To Tag" + "</span>";

                e.VisualItem.ImageLayout = ImageLayout.Center;
                e.VisualItem.ImageAlignment = ContentAlignment.MiddleCenter;
            }

            if (this.radListView1.ViewType == ListViewType.ListView)
            {
                e.VisualItem.Padding = new Padding(5, 5, 0, 5);
                e.VisualItem.Layout.LeftPart.Margin = new Padding(0, 0, 5, 0);
            }
        }

        void radListView1_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            //e.Item.Image = Image.FromFile(@"D:\Projects\ME\Backup\VideoEditor\VideoEditor\bin\file21.6.bmp");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.commandBarDropDownGroup.SelectedIndex = 1;
        }

        private bool updatingToggleState = false;

        private void ViewToggleButton_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (updatingToggleState)
            {
                return;
            }

            this.updatingToggleState = true;

            if (this.commandBarToggleDetails != sender)
            {
                this.commandBarToggleDetails.ToggleState = ToggleState.Off;
            }

            if (this.commandBarToggleTiles != sender)
            {
                this.commandBarToggleTiles.ToggleState = ToggleState.Off;
            }

            this.updatingToggleState = false;

            if (this.commandBarToggleDetails.ToggleState == ToggleState.On)
            {
                this.radListView1.ViewType = ListViewType.DetailsView;
            }

            if (this.commandBarToggleTiles.ToggleState == ToggleState.On)
            {
                this.radListView1.ViewType = ListViewType.IconsView;
            }

        }

        private void ViewToggleButton_ToggleStateChanging(object sender, StateChangingEventArgs args)
        {
            if (!updatingToggleState && args.OldValue == ToggleState.On)
            {
                args.Cancel = true;
            }
        }

        private void commandBarDropDownSort_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radListView1.SortDescriptors.CollectionChanged -= SortDescriptors_CollectionChanged;

            this.radListView1.SortDescriptors.Clear();
            switch (this.commandBarDropDownSort.Text)
            {
                case "From":
                    this.radListView1.SortDescriptors.Add(new SortDescriptor("From", ListSortDirection.Ascending));
                    this.radListView1.EnableSorting = true;
                    break;
            }

            this.radListView1.SortDescriptors.CollectionChanged += SortDescriptors_CollectionChanged;
        }

        private void commandBarDropDownGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            this.radListView1.GroupDescriptors.Clear();
            switch (this.commandBarDropDownGroup.Text)
            {
                case "None":
                    this.radListView1.EnableGrouping = false;
                    this.radListView1.ShowGroups = false;
                    break;
                case "File Name":
                    this.radListView1.GroupDescriptors.Add(new GroupDescriptor(
                        new SortDescriptor[] { new SortDescriptor("FileName", ListSortDirection.Ascending) }));
                    this.radListView1.EnableGrouping = true;
                    this.radListView1.ShowGroups = true;
                    break;
            }
        }

        private void commandBarTextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            this.radListView1.FilterDescriptors.Clear();

            if (String.IsNullOrEmpty(this.commandBarTextBoxFilter.Text))
            {
                this.radListView1.EnableFiltering = false;
            }
            else
            {
                this.radListView1.FilterDescriptors.LogicalOperator = FilterLogicalOperator.Or;
                this.radListView1.FilterDescriptors.Add("DateAdded", FilterOperator.Contains, this.commandBarTextBoxFilter.Text);
                this.radListView1.FilterDescriptors.Add("Name", FilterOperator.Contains, this.commandBarTextBoxFilter.Text);
                this.radListView1.EnableFiltering = true;
            }
        }

        private void TextBoxItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Bounds")
            {
                commandBarTextBoxFilter.TextBoxElement.TextBoxItem.HostedControl.MaximumSize = new Size((int)commandBarTextBoxFilter.DesiredSize.Width - 28, 0);
            }
        }


        private void radListView1_ItemCreating(object sender, ListViewItemCreatingEventArgs e)
        {
            try
            {
                if (currentshot != null)
                    e.Item.Image = currentshot.image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            }
            catch (Exception)
            {
            }
        }

        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            //contextMenuStrip1.Enabled = true;
            // contextMenuStrip1.Visible = true;
            //radListView1.SelectedItem = e.Item;
        }

        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (radListView1.SelectedItem != null)
            {
                int index = radListView1.SelectedIndex;
                try
                {
                    double endTime = -1;
                    double startTime = Convert.ToDouble(radListView1.Items[index]["From"].ToString());
                    string filePath = radListView1.Items[index]["FilePath"].ToString();
                    string fileName = radListView1.Items[index]["FileName"].ToString();
                    if (radListView1.Items[index + 1] != null &&
                        radListView1.Items[index]["FilePath"].ToString() == radListView1.Items[index + 1]["FilePath"].ToString())
                    {
                        endTime = Convert.ToDouble(radListView1.Items[index + 1]["From"].ToString());
                        radListView1.Items[index]["Duration"] = ((int)(endTime - startTime)).ToString() + " sec";
                    }

                }
                catch (Exception)
                {
                }
            }
        }

        private void radListView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                BaseListViewVisualItem item = this.radListView1.ElementTree.GetElementAtPoint(e.Location) as BaseListViewVisualItem;
                if (item != null)
                {
                    this.radListView1.SelectedItem = item.Data;
                    contextMenuStrip1.Enabled = true;
                    contextMenuStrip1.Visible = true;
                    contextMenuStrip1.Show(e.Location.X, e.Location.Y);
                }
                else
                {
                    contextMenuStrip1.Enabled = false;
                    contextMenuStrip1.Visible = false;
                }


            }
        }



        public void SetData(string p1, string p2, string p3, int shotid,long dbId)
        {


            radListView1.Items[shotid]["Description"] = p1;
            radListView1.Items[shotid]["Category"] = p2;
            radListView1.Items[shotid]["Tags"] = p3;
            radListView1.Items[shotid]["Taged"] = "YES";
            radListView1.Items[shotid]["ID"] = dbId.ToString();

        }

        public AutoCompleteStringCollection autoCompleteDataSource { get; set; }

        private void backButton_Click_1(object sender, EventArgs e)
        {
            NavigateBack();
        }

        private void forwardButton_Click_1(object sender, EventArgs e)
        {
            NavigateForward();

        }

        private void NavigateForward()
        {
            if (forwardCollection.Count > 0)
            {
                if (forwardCollection.Peek() == radTreeView1.SelectedNode)
                {
                    backCollection.Push(forwardCollection.Pop());
                }

                navigateOperationInProgress = true;
                radTreeView1.SelectedNode = forwardCollection.Peek();
                backCollection.Push(forwardCollection.Pop());
                navigateOperationInProgress = false;
            }
        }

        private void historyButton_Click_1(object sender, EventArgs e)
        {
            historyButton.Items.Clear();
            foreach (RadTreeNode node in backCollection)
            {
                if (node != radTreeView1.SelectedNode)
                {
                    RadMenuItem historyDropDownItem = new RadMenuItem();
                    historyDropDownItem.Text = node.Text;
                    historyDropDownItem.Tag = node;
                    historyDropDownItem.Click += new EventHandler(historyDropDownItem_Click);
                    historyButton.Items.Add(historyDropDownItem);
                }
            }
            if (historyButton.Items.Count > 0)
            {
                historyButton.ShowDropDown();
            }
        }

        private void historyDropDownItem_Click(object sender, EventArgs e)
        {
            RadMenuItem item = sender as RadMenuItem;
            radTreeView1.SelectedNode = item.Tag as RadTreeNode;
        }

        private void upButton_Click_1(object sender, EventArgs e)
        {

            if (radTreeView1.SelectedNode != null && radTreeView1.SelectedNode.Parent != null)
            {
                radTreeView1.SelectedNode = radTreeView1.SelectedNode.Parent;
            }
        }

        private void refreshButton_Click_1(object sender, EventArgs e)
        {
            if (radTreeView1.SelectedNode != null)
            {
                RadTreeNode savedNode = radTreeView1.SelectedNode;
                radTreeView1.SelectedNode = new RadTreeNode();
                radTreeView1.SelectedNode = savedNode;
            }
        }

        private void sliderControl1_DragDrop(object sender, DragEventArgs e)
        {

            string file = e.Data.ToString();
            System.IO.FileInfo fi = new System.IO.FileInfo(file);
            if ((!fi.Exists) || (!CheckExtension(fi)))
                return;
            bool bFound = false;
            string sFilePath = string.Empty;
            for (int i = 0; i < videoFilesList.Count; i++)
            {
                sFilePath = videoFilesList[i].FilePath;
                if (fi.FullName == sFilePath)
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
                return;

            try
            {
                MediaPlayer newVideo = new MediaPlayer(file);
                if (!this.mediaManager.videos.Contains(file))
                {

                    double fps = 0;
                    double duration = 0;
                    fps = newVideo.getFramePerSecond();
                    duration = newVideo.getDuration();

                    VideoFile model = null;
                    model = videoFileRepository.Get(v => v.m_fileName == fi.Name &&
                   v.m_fps == fps && v.m_filePath == fi.FullName && v.m_duration == duration);

                    VideoFiles video = new VideoFiles(fi.Name, fi.FullName, 0, fps, duration);
                    //  if (model != null) video.shots = model.Shots;
                    videoFilesList.Add(video);

                    DataTable dt = (DataTable)videoFilesList;
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt);
                    object[] param = new object[] { ds };
                    this.sliderControl1.LoadBarsFromDataSet(param);
                    this.sliderControl1.videoSlider1.Invalidate();

                    this.sliderControl1.SetZoom(3);
                    thumbSeconds = 0;
                    this.sliderControl1.SetSliderHPosition();

                    this.mediaManager.AddVideo(newVideo, file);

                    ds.Dispose();
                }
            }
            catch (COMException comex)
            {
                MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void filesListContextMenu_Opening(object sender, CancelEventArgs e)
        {



        }

        private void filesListContextMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (e.ClickedItem != null && e.ClickedItem.Text == "Add to TimeLine")
                {

                    filePath = radListView2.SelectedItem.Tag.ToString();


                    string file = filePath;
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    if ((!fi.Exists) || (!CheckExtension(fi)))
                        return;
                    bool bFound = false;
                    string sFilePath = string.Empty;
                    for (int i = 0; i < videoFilesList.Count; i++)
                    {
                        sFilePath = videoFilesList[i].FilePath;
                        if (fi.FullName == sFilePath)
                        {
                            bFound = true;
                            break;
                        }
                    }

                    if (bFound)
                        return;

                    try
                    {
                        MediaPlayer newVideo = new MediaPlayer(file);
                        if (!this.mediaManager.videos.Contains(file))
                        {

                            double fps = 0;
                            double duration = 0;
                            fps = newVideo.getFramePerSecond();
                            duration = newVideo.getDuration();

                            VideoFile model = null;
                            model = videoFileRepository.Get(v => v.m_fileName == fi.Name &&
                           v.m_fps == fps && v.m_filePath == fi.FullName && v.m_duration == duration);

                            VideoFiles video = new VideoFiles(fi.Name, fi.FullName, 0, fps, duration);
                            //  if (model != null) video.shots = model.Shots;
                            videoFilesList.Add(video);

                            DataTable dt = (DataTable)videoFilesList;
                            DataSet ds = new DataSet();
                            ds.Tables.Add(dt);
                            object[] param = new object[] { ds };
                            this.sliderControl1.LoadBarsFromDataSet(param);
                            this.sliderControl1.videoSlider1.Invalidate();

                            this.sliderControl1.SetZoom(3);
                            thumbSeconds = 0;
                            this.sliderControl1.SetSliderHPosition();

                            this.mediaManager.AddVideo(newVideo, file);

                            ds.Dispose();
                        }
                    }
                    catch (COMException comex)
                    {
                        MessageBox.Show("Failed to load video: " + comex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }

            }
            catch (Exception)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PANEL_Video_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {

            try
            {
                cam = new DSCapture(this.mediaManager.currentMedia.mediaInfo.sFilePath);
                shots = new List<Frames>();

                // Start displaying statistics
                timer2.Enabled = true;
                cam.Start(); //capture the next image
                cam.WaitUntilDone();
                timer2.Enabled = false;

                // Final update
                // dataGridView1.Rows.Add(cam.m_Scenes, cam.m_ShotTime.ToString());

                lock (this)
                {
                    cam.Dispose();
                    cam = null;
                }

            }
            catch (Exception)
            {
            }
        }

        private void MainPage_ResizeEnd(object sender, EventArgs e)
        {
        }

        private void radPageView1_SelectedPageChanged(object sender, EventArgs e)
        {

        }

        private void statusStrip_StatusBarClick(object sender, RadStatusBarClickEventArgs args)
        {

        }


        private void radListView1_ItemMouseDoubleClick(object sender, ListViewItemEventArgs e)
        {
            Shot shot = null;

                if (radListView1.SelectedItem != null)
                {
                    int index = radListView1.SelectedIndex;
                    try
                    {

                        if (radListView1.SelectedItem["Taged"] == "NO")
                        {
                            double endTime = -1;
                            double startTime = Convert.ToDouble(radListView1.Items[index]["From"].ToString());
                            string filePath = radListView1.Items[index]["FilePath"].ToString();
                            string fileName = radListView1.Items[index]["FileName"].ToString();
                            if (radListView1.Items[index + 1] != null &&
                                radListView1.Items[index]["FilePath"].ToString() ==
                                radListView1.Items[index + 1]["FilePath"].ToString())
                            {
                                endTime = Convert.ToDouble(radListView1.Items[index + 1]["From"].ToString());
                                radListView1.Items[index]["Duration"] = (endTime - startTime).ToString() +
                                                                        " sec";
                            }

                            Image img = radListView1.SelectedItem.Image;
                            TaggingControl control = new TaggingControl(this, startTime, endTime, filePath, fileName, img, index);
                            control.Show();
                        }

                        else if (radListView1.SelectedItem["Taged"] == "YES")
                        {
                            int shotID = Convert.ToInt16(radListView1.Items[index]["ID"].ToString());

                            TaggingControl control = new TaggingControl(this, index, shotID);
                            control.Show();
                        }

                    }
                    catch (Exception)
                    {
                    }
                }   
        }


    }


}
