
namespace ComicPeeps.UserControls
{
    partial class Home
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
            this.pbIconBig = new System.Windows.Forms.PictureBox();
            this.lblNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbIconBig)).BeginInit();
            this.SuspendLayout();
            // 
            // pbIconBig
            // 
            this.pbIconBig.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbIconBig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbIconBig.Image = global::ComicPeeps.Properties.Resources.appIconBig;
            this.pbIconBig.Location = new System.Drawing.Point(300, 191);
            this.pbIconBig.Name = "pbIconBig";
            this.pbIconBig.Size = new System.Drawing.Size(158, 158);
            this.pbIconBig.TabIndex = 0;
            this.pbIconBig.TabStop = false;
            this.pbIconBig.DoubleClick += new System.EventHandler(this.Home_DoubleClick);
            // 
            // lblNotice
            // 
            this.lblNotice.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Century Gothic", 10.6F, System.Drawing.FontStyle.Bold);
            this.lblNotice.ForeColor = System.Drawing.Color.White;
            this.lblNotice.Location = new System.Drawing.Point(240, 510);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(279, 18);
            this.lblNotice.TabIndex = 1;
            this.lblNotice.Text = "double click anywhere to open file...";
            this.lblNotice.DoubleClick += new System.EventHandler(this.Home_DoubleClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.pbIconBig);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(757, 540);
            this.DoubleClick += new System.EventHandler(this.Home_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.pbIconBig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbIconBig;
        private System.Windows.Forms.Label lblNotice;
    }
}
