
namespace ComicPeeps.UserControls
{
    partial class ComicViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComicViewer));
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pbRight = new System.Windows.Forms.PictureBox();
            this.pnlPages = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pbLeft = new System.Windows.Forms.PictureBox();
            this.lblPageCount = new System.Windows.Forms.Label();
            this.pbPageImage = new System.Windows.Forms.PictureBox();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).BeginInit();
            this.pnlPages.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPageImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlRight
            // 
            this.pnlRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRight.Controls.Add(this.pbRight);
            this.pnlRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlRight.Location = new System.Drawing.Point(814, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(145, 540);
            this.pnlRight.TabIndex = 6;
            this.pnlRight.Click += new System.EventHandler(this.pnlRight_Click);
            // 
            // pbRight
            // 
            this.pbRight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pbRight.Image = global::ComicPeeps.Properties.Resources.rightButton;
            this.pbRight.Location = new System.Drawing.Point(68, 249);
            this.pbRight.Name = "pbRight";
            this.pbRight.Size = new System.Drawing.Size(26, 41);
            this.pbRight.TabIndex = 3;
            this.pbRight.TabStop = false;
            this.pbRight.Click += new System.EventHandler(this.pnlRight_Click);
            // 
            // pnlPages
            // 
            this.pnlPages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.pnlPages.Controls.Add(this.pbPageImage);
            this.pnlPages.Location = new System.Drawing.Point(211, 0);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(540, 540);
            this.pnlPages.TabIndex = 4;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlLeft.Controls.Add(this.pbLeft);
            this.pnlLeft.Controls.Add(this.lblPageCount);
            this.pnlLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlLeft.Location = new System.Drawing.Point(1, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(145, 540);
            this.pnlLeft.TabIndex = 5;
            this.pnlLeft.Click += new System.EventHandler(this.pnlLeft_Click);
            // 
            // pbLeft
            // 
            this.pbLeft.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pbLeft.Image = global::ComicPeeps.Properties.Resources.leftButton;
            this.pbLeft.Location = new System.Drawing.Point(50, 249);
            this.pbLeft.Name = "pbLeft";
            this.pbLeft.Size = new System.Drawing.Size(26, 41);
            this.pbLeft.TabIndex = 2;
            this.pbLeft.TabStop = false;
            this.pbLeft.Click += new System.EventHandler(this.pnlLeft_Click);
            // 
            // lblPageCount
            // 
            this.lblPageCount.AutoSize = true;
            this.lblPageCount.Font = new System.Drawing.Font("Century Gothic", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPageCount.ForeColor = System.Drawing.Color.White;
            this.lblPageCount.Location = new System.Drawing.Point(10, 10);
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(34, 16);
            this.lblPageCount.TabIndex = 1;
            this.lblPageCount.Text = "0 / 0";
            // 
            // pbPageImage
            // 
            this.pbPageImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPageImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.pbPageImage.Location = new System.Drawing.Point(0, 0);
            this.pbPageImage.Name = "pbPageImage";
            this.pbPageImage.Size = new System.Drawing.Size(540, 540);
            this.pbPageImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPageImage.TabIndex = 0;
            this.pbPageImage.TabStop = false;
            // 
            // ComicViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComicViewer";
            this.Text = "ComicViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComicViewer_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComicViewer_KeyDown);
            this.pnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRight)).EndInit();
            this.pnlPages.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPageImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.PictureBox pbRight;
        private System.Windows.Forms.Panel pnlPages;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox pbLeft;
        private System.Windows.Forms.Label lblPageCount;
        private System.Windows.Forms.PictureBox pbPageImage;
    }
}