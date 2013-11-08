using ShotDetection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace CitiesCMS
{
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();

        }
  
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
           
        }

      

       

        private void mnuFrontDesk_Click(object sender, EventArgs e)
        {
           
            
        }

       
        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ret;
            ret = MessageBox.Show("Are you want to Exit!", "Exit".ToUpper(), MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (ret == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }



       
        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void userAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSettings settings = new frmSettings();
            //settings.ShowDialog();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //frmAllCustomer customer = new frmAllCustomer();
            //customer.MdiParent = MainForm.ActiveForm;
            //customer.AddCustomer();
        }

        private void mnuCustomerFile_Click(object sender, EventArgs e)
        {
            //frmAllCustomer allcustomer = new frmAllCustomer();
            //allcustomer.MdiParent = this;
            //allcustomer.Show();
        }

        private void mnuCurrentUser_Click(object sender, EventArgs e)
        {
            //frmLogin login = new frmLogin();
            //login.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesOrderDelivery deliver = new frmSalesOrderDelivery();
            //deliver.WindowState = FormWindowState.Maximized;
            //deliver.MdiParent = this;
            //deliver.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmOption settings = new frmOption();
            //settings.Show();
        }

        private void newReservationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesOrder order = new frmSalesOrder();
            //order.WindowState = FormWindowState.Maximized;
            //order.MdiParent = this;
            //order.Show();
        }

        private void orderCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reservationScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmSalesOrderReturn returned = new frmSalesOrderReturn();
            //returned.WindowState = FormWindowState.Maximized;
            //returned.MdiParent = this;
            //returned.Show();
        }

        private void rentalPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRentalPlan cat = new frmRentalPlan();
            //cat.ShowDialog();
        }

        private void rentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmRental rent = new frmRental();
            //rent.Show();
        }

        private void salesPOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCashSales POS = new frmCashSales();
            //POS.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmReports reports = new frmReports();
            //reports.WindowState = FormWindowState.Maximized;
            //reports.MdiParent = this;
            //reports.Show();
        }

        private void cmdRent_Click(object sender, EventArgs e)
        {
            //frmRental rent = new frmRental();
            //rent.Show();
        }

        private void cmdSales_Click(object sender, EventArgs e)
        {
            //frmCashSales POS = new frmCashSales();
            //POS.Show();
        }

        private void cmdSell_Click(object sender, EventArgs e)
        {
            //frmAllCustomer customer = new frmAllCustomer();
            //customer.WindowState = FormWindowState.Maximized;
            //customer.MdiParent = MainForm.ActiveForm;
            //customer.Show();
        }

        private void cmdReservation_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Process Proc = new System.Diagnostics.Process();
            //Proc.StartInfo.FileName = "CalendarSample.exe";
            //Proc.Start();
         //  clsFunction.Native.LoadProcessInControl("CalendarSample.exe", this);
        }

        private void cmdMovieSearch_Click(object sender, EventArgs e)
        {
            MainPage form = new MainPage();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAbout about = new frmAbout();
            //about.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            //frmEmailLogin emaillogin = new frmEmailLogin();
            //emaillogin.mFormState = "Custom Email";
            //emaillogin.ShowDialog();
        }

        private void lvNav_DoubleClick(object sender, EventArgs e)
        {
            switch (lvNav.FocusedItem.Text)
            {
                case "Shot Detection":
                      MainPage form = new MainPage();
                        form.MdiParent = this;
                        form.WindowState = FormWindowState.Maximized;
                        form.Show();                   
                        break;
                case "Searching Area":
                      FORMShotsSearch formShotsSearch = new FORMShotsSearch();
                        formShotsSearch.MdiParent = this;
                        formShotsSearch.WindowState = FormWindowState.Maximized;
                        formShotsSearch.Show();
                        break;
                

            }
        }

        private void lvNav_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
        }

   }
}
