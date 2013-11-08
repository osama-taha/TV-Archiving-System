namespace TimeControl
{

    partial class ControlPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LABEL_1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LABEL_1
            // 
            this.LABEL_1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LABEL_1.BackColor = System.Drawing.Color.Gray;
            this.LABEL_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LABEL_1.ForeColor = System.Drawing.Color.White;
            this.LABEL_1.Location = new System.Drawing.Point(6, 7);
            this.LABEL_1.Multiline = true;
            this.LABEL_1.Name = "LABEL_1";
            this.LABEL_1.Size = new System.Drawing.Size(72, 18);
            this.LABEL_1.TabIndex = 1;
            this.LABEL_1.TextChanged += new System.EventHandler(this.LABEL_1_TextChanged);
            // 
            // ControlPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.LABEL_1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ControlPanel";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(98, 31);
            this.Load += new System.EventHandler(this.ControlPanel_Load);
            this.Resize += new System.EventHandler(this.ControlPanel_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox LABEL_1;

    }
}
