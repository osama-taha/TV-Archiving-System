﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;



namespace TimeControl
{


    public partial class ZoomHScrollBar : HScrollBar
    {
        protected int valSmallChange = 1;
        protected int valLargeChange = 1;
        protected int valViewable = 1;
        protected int valMax = 1;

        public ZoomHScrollBar()
        {
            InitializeComponent();
        }

        public int ValSmallChange
        {
            get { return valSmallChange; }
            set
            {
                valSmallChange = value;
                this.SmallChange = valSmallChange;
            }
        }

        public int ValLargeChange
        {
            get { return valLargeChange; }
            set { valLargeChange = value; }
        }

        public int ViewableCount
        {
            get { return valViewable; }
            set
            {
                valViewable = value;
                Recalc();
            }
        }

        public int MaximumCount
        {
            get { return valMax; }
            set
            {
                valMax = value;
                this.LargeChange = this.Width;
                Recalc();
            }
        }




        protected void Recalc()
        {
            this.Maximum = MaximumCount;
            this.LargeChange = ViewableCount;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 8469)
            {
                switch ((uint)m.WParam)
                {
                    case 2:			// page up
                        if (this.Value - this.ValLargeChange > 0)
                        {
                            this.Value -= this.ValLargeChange;
                        }
                        else
                        {
                            this.Value = 0;
                        }
                        break;

                    case 3:			// page down
                        if (this.Value + this.LargeChange + this.ValLargeChange < this.Maximum)
                        {
                            this.Value += this.ValLargeChange;
                        }
                        else
                        {
                            this.Value = this.Maximum - this.LargeChange;
                        }
                        break;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void ZoomHScrollBar_Layout(object sender, LayoutEventArgs e)
        {
            this.LargeChange = this.Width;
            Recalc();
        }

    }

}
