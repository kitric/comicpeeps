namespace ComicsReader
{
    partial class ComicReader
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutComicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comicPeepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.madPeepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PageCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.next2 = new System.Windows.Forms.PictureBox();
            this.ZoomOut = new System.Windows.Forms.PictureBox();
            this.ZoomIn = new System.Windows.Forms.PictureBox();
            this.prev = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prev)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1332, 25);
            this.panel1.TabIndex = 10;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1332, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeFileToolStripMenuItem,
            this.aboutComicToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeFileToolStripMenuItem
            // 
            this.closeFileToolStripMenuItem.Name = "closeFileToolStripMenuItem";
            this.closeFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeFileToolStripMenuItem.Text = "Close File";
            this.closeFileToolStripMenuItem.Click += new System.EventHandler(this.closeFileToolStripMenuItem_Click);
            // 
            // aboutComicToolStripMenuItem
            // 
            this.aboutComicToolStripMenuItem.Name = "aboutComicToolStripMenuItem";
            this.aboutComicToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.aboutComicToolStripMenuItem.Text = "About Comic";
            this.aboutComicToolStripMenuItem.Click += new System.EventHandler(this.aboutComicToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardShortcutsToolStripMenuItem,
            this.clearCacheToolStripMenuItem,
            this.clearHistoryToolStripMenuItem,
            this.fAQToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts";
            this.keyboardShortcutsToolStripMenuItem.Click += new System.EventHandler(this.keyboardShortcutsToolStripMenuItem_Click);
            // 
            // clearCacheToolStripMenuItem
            // 
            this.clearCacheToolStripMenuItem.Name = "clearCacheToolStripMenuItem";
            this.clearCacheToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearCacheToolStripMenuItem.Text = "Clear Cache";
            this.clearCacheToolStripMenuItem.Click += new System.EventHandler(this.generalToolStripMenuItem_Click);
            // 
            // clearHistoryToolStripMenuItem
            // 
            this.clearHistoryToolStripMenuItem.Name = "clearHistoryToolStripMenuItem";
            this.clearHistoryToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearHistoryToolStripMenuItem.Text = "Clear History";
            this.clearHistoryToolStripMenuItem.Click += new System.EventHandler(this.clearHistoryToolStripMenuItem_Click);
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.fAQToolStripMenuItem.Text = "FAQ";
            this.fAQToolStripMenuItem.Click += new System.EventHandler(this.fAQToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comicPeepsToolStripMenuItem,
            this.madPeepsToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // comicPeepsToolStripMenuItem
            // 
            this.comicPeepsToolStripMenuItem.Name = "comicPeepsToolStripMenuItem";
            this.comicPeepsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.comicPeepsToolStripMenuItem.Text = "ComicPeeps";
            this.comicPeepsToolStripMenuItem.Click += new System.EventHandler(this.comicPeepsToolStripMenuItem_Click);
            // 
            // madPeepsToolStripMenuItem
            // 
            this.madPeepsToolStripMenuItem.Name = "madPeepsToolStripMenuItem";
            this.madPeepsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.madPeepsToolStripMenuItem.Text = "MadPeeps";
            this.madPeepsToolStripMenuItem.Click += new System.EventHandler(this.madPeepsToolStripMenuItem_Click);
            // 
            // PageCount
            // 
            this.PageCount.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PageCount.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.PageCount.ForeColor = System.Drawing.Color.White;
            this.PageCount.Location = new System.Drawing.Point(621, 708);
            this.PageCount.Name = "PageCount";
            this.PageCount.Size = new System.Drawing.Size(90, 33);
            this.PageCount.TabIndex = 11;
            this.PageCount.Text = "1";
            this.PageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(13, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1307, 628);
            this.panel2.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1307, 628);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // next2
            // 
            this.next2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.next2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next2.Enabled = false;
            this.next2.Image = global::ComicsReader.Properties.Resources.next;
            this.next2.Location = new System.Drawing.Point(756, 714);
            this.next2.Name = "next2";
            this.next2.Size = new System.Drawing.Size(44, 20);
            this.next2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.next2.TabIndex = 17;
            this.next2.TabStop = false;
            this.next2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ZoomOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZoomOut.Image = global::ComicsReader.Properties.Resources.zoomout2;
            this.ZoomOut.Location = new System.Drawing.Point(717, 708);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(33, 33);
            this.ZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ZoomOut.TabIndex = 15;
            this.ZoomOut.TabStop = false;
            this.ZoomOut.Click += new System.EventHandler(this.ZoomOut_Click);
            // 
            // ZoomIn
            // 
            this.ZoomIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ZoomIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ZoomIn.Image = global::ComicsReader.Properties.Resources.zoomin1;
            this.ZoomIn.Location = new System.Drawing.Point(582, 708);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(33, 33);
            this.ZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ZoomIn.TabIndex = 14;
            this.ZoomIn.TabStop = false;
            this.ZoomIn.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // prev
            // 
            this.prev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prev.Enabled = false;
            this.prev.Image = global::ComicsReader.Properties.Resources.previous;
            this.prev.Location = new System.Drawing.Point(526, 714);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(44, 20);
            this.prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.prev.TabIndex = 9;
            this.prev.TabStop = false;
            this.prev.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // ComicReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.next2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ZoomOut);
            this.Controls.Add(this.ZoomIn);
            this.Controls.Add(this.PageCount);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.prev);
            this.Name = "ComicReader";
            this.Size = new System.Drawing.Size(1332, 760);
            this.Load += new System.EventHandler(this.ComicReader_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComicReader_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prev)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox prev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeFileToolStripMenuItem;
        private System.Windows.Forms.Label PageCount;
        private System.Windows.Forms.PictureBox ZoomIn;
        private System.Windows.Forms.PictureBox ZoomOut;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutComicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comicPeepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem madPeepsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearHistoryToolStripMenuItem;
        private System.Windows.Forms.PictureBox next2;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
    }
}
