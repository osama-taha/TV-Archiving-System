using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;

namespace ShotDetection
{
    public partial class FORMSEARCH1 : Telerik.WinControls.UI.ShapedForm
    {
        public FORMSEARCH1()
        {
            InitializeComponent();
        }

        private void radPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radLabel2_Click(object sender, EventArgs e)
        {

        }

        private void FORMSEARCH1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tvArchivingDataSet.Shots' table. You can move, or remove it, as needed.
            radLabel2.BorderVisible = false;

        }

        private void radPanel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void radGridView1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void radPanel2_Paint_2(object sender, PaintEventArgs e)
        {
        }

        private void radPanel2_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void radLabel5_Click(object sender, EventArgs e)
        {

        }

        private void radDropDownList3_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void radTitleBar1_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            MediaPlayer player = new MediaPlayer();

            player.Open(new Uri(@"D:\Real Madrid && Raul\Karim Benzema Skills & Goals 2011 - 2012 - YouTube.flv", UriKind.Relative));
            player.Position = TimeSpan.FromSeconds(50);
            VideoDrawing aVideoDrawing = new VideoDrawing();

            aVideoDrawing.Rect = new Rect(0, 0, 100, 100);
           
            aVideoDrawing.Player = player;

            // Play the video once.
            player.Play(); 
        }
    }
}
