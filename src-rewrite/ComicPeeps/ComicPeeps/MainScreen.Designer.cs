
namespace ComicPeeps
{
    partial class MainScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnSettings = new System.Windows.Forms.PictureBox();
            this.btnLibrary = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pnlSeparator = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLibrary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.Black;
            this.pnlSideBar.Controls.Add(this.btnSettings);
            this.pnlSideBar.Controls.Add(this.btnLibrary);
            this.pnlSideBar.Controls.Add(this.btnHome);
            this.pnlSideBar.Controls.Add(this.pbIcon);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 0);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(200, 540);
            this.pnlSideBar.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.Image = global::ComicPeeps.Properties.Resources.settingsBtn;
            this.btnSettings.Location = new System.Drawing.Point(91, 494);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(17, 18);
            this.btnSettings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSettings.TabIndex = 3;
            this.btnSettings.TabStop = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnLibrary
            // 
            this.btnLibrary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLibrary.Image = global::ComicPeeps.Properties.Resources.libraryBtn;
            this.btnLibrary.Location = new System.Drawing.Point(19, 185);
            this.btnLibrary.Name = "btnLibrary";
            this.btnLibrary.Size = new System.Drawing.Size(162, 54);
            this.btnLibrary.TabIndex = 2;
            this.btnLibrary.TabStop = false;
            this.btnLibrary.Click += new System.EventHandler(this.btnLibrary_Click);
            // 
            // btnHome
            // 
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.Image = global::ComicPeeps.Properties.Resources.homeBtn;
            this.btnHome.Location = new System.Drawing.Point(19, 124);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(162, 54);
            this.btnHome.TabIndex = 1;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // pbIcon
            // 
            this.pbIcon.Image = global::ComicPeeps.Properties.Resources.appIcon;
            this.pbIcon.Location = new System.Drawing.Point(75, 34);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(49, 49);
            this.pbIcon.TabIndex = 0;
            this.pbIcon.TabStop = false;
            // 
            // pnlSeparator
            // 
            this.pnlSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(142)))), ((int)(((byte)(68)))));
            this.pnlSeparator.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSeparator.Location = new System.Drawing.Point(200, 0);
            this.pnlSeparator.Name = "pnlSeparator";
            this.pnlSeparator.Size = new System.Drawing.Size(3, 540);
            this.pnlSeparator.TabIndex = 1;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(203, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(757, 540);
            this.pnlContent.TabIndex = 2;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSeparator);
            this.Controls.Add(this.pnlSideBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(976, 579);
            this.Name = "MainScreen";
            this.Text = "ComicPeeps";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainScreen_FormClosing);
            this.Shown += new System.EventHandler(this.MainScreen_Shown);
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLibrary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSideBar;
        private System.Windows.Forms.Panel pnlSeparator;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.PictureBox btnLibrary;
        private System.Windows.Forms.PictureBox btnSettings;
        public System.Windows.Forms.Panel pnlContent;
    }
}

