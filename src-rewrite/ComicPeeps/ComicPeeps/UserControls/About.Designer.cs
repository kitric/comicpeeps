﻿
namespace ComicPeeps.UserControls
{
    partial class About
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
            this.btnWeb = new System.Windows.Forms.Label();
            this.lblSummary = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.mattbull = new System.Windows.Forms.PictureBox();
            this.nordic = new System.Windows.Forms.PictureBox();
            this.crxssed = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mattbull)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nordic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crxssed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWeb
            // 
            this.btnWeb.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnWeb.AutoSize = true;
            this.btnWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWeb.Font = new System.Drawing.Font("Century Gothic", 15.4F);
            this.btnWeb.ForeColor = System.Drawing.Color.White;
            this.btnWeb.Location = new System.Drawing.Point(293, 265);
            this.btnWeb.Name = "btnWeb";
            this.btnWeb.Size = new System.Drawing.Size(172, 24);
            this.btnWeb.TabIndex = 2;
            this.btnWeb.Text = "visit our website!";
            this.btnWeb.Click += new System.EventHandler(this.btnWeb_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Century Gothic", 10.4F);
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Location = new System.Drawing.Point(248, 386);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(262, 114);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "ComicPeeps is a minimalistic\r\ndigital comic reader.\r\nThe project is open-source, " +
    "available\r\non the Kitric Github page\r\n\r\nv";
            this.lblSummary.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.Image = global::ComicPeeps.Properties.Resources.cp_text;
            this.pictureBox5.Location = new System.Drawing.Point(257, 331);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(244, 38);
            this.pictureBox5.TabIndex = 3;
            this.pictureBox5.TabStop = false;
            // 
            // mattbull
            // 
            this.mattbull.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.mattbull.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mattbull.Image = global::ComicPeeps.Properties.Resources.mattbull;
            this.mattbull.Location = new System.Drawing.Point(435, 108);
            this.mattbull.Name = "mattbull";
            this.mattbull.Size = new System.Drawing.Size(114, 126);
            this.mattbull.TabIndex = 1;
            this.mattbull.TabStop = false;
            this.mattbull.Click += new System.EventHandler(this.mattbull_Click);
            // 
            // nordic
            // 
            this.nordic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nordic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nordic.Image = global::ComicPeeps.Properties.Resources.nordic;
            this.nordic.Location = new System.Drawing.Point(322, 108);
            this.nordic.Name = "nordic";
            this.nordic.Size = new System.Drawing.Size(114, 126);
            this.nordic.TabIndex = 1;
            this.nordic.TabStop = false;
            this.nordic.Click += new System.EventHandler(this.nordic_Click);
            // 
            // crxssed
            // 
            this.crxssed.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crxssed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.crxssed.Image = global::ComicPeeps.Properties.Resources.crxssed;
            this.crxssed.Location = new System.Drawing.Point(208, 108);
            this.crxssed.Name = "crxssed";
            this.crxssed.Size = new System.Drawing.Size(114, 126);
            this.crxssed.TabIndex = 1;
            this.crxssed.TabStop = false;
            this.crxssed.Click += new System.EventHandler(this.crxssed_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::ComicPeeps.Properties.Resources.kitric;
            this.pictureBox1.Location = new System.Drawing.Point(314, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnWeb);
            this.Controls.Add(this.mattbull);
            this.Controls.Add(this.nordic);
            this.Controls.Add(this.crxssed);
            this.Controls.Add(this.pictureBox1);
            this.Name = "About";
            this.Size = new System.Drawing.Size(757, 540);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mattbull)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nordic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crxssed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox crxssed;
        private System.Windows.Forms.PictureBox nordic;
        private System.Windows.Forms.PictureBox mattbull;
        private System.Windows.Forms.Label btnWeb;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label lblSummary;
    }
}
