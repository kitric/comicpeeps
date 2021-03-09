
namespace ComicPeeps.UserControls.Components
{
    partial class ComicButton
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
            this.components = new System.ComponentModel.Container();
            this.cmMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmUpdateIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.pbCover = new System.Windows.Forms.PictureBox();
            this.lblComicName = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.PictureBox();
            this.btnUpdate = new System.Windows.Forms.PictureBox();
            this.lblIssueCount = new System.Windows.Forms.Label();
            this.cmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // cmMain
            // 
            this.cmMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmUpdateIssues,
            this.tsmRemove});
            this.cmMain.Name = "cmMain";
            this.cmMain.Size = new System.Drawing.Size(147, 48);
            // 
            // tsmUpdateIssues
            // 
            this.tsmUpdateIssues.Name = "tsmUpdateIssues";
            this.tsmUpdateIssues.Size = new System.Drawing.Size(146, 22);
            this.tsmUpdateIssues.Text = "Update Issues";
            this.tsmUpdateIssues.Click += new System.EventHandler(this.tsmUpdateIssues_Click);
            // 
            // tsmRemove
            // 
            this.tsmRemove.Name = "tsmRemove";
            this.tsmRemove.Size = new System.Drawing.Size(146, 22);
            this.tsmRemove.Text = "Remove";
            this.tsmRemove.Click += new System.EventHandler(this.tsmRemove_Click);
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(0, 0);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(26, 40);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 1;
            this.pbCover.TabStop = false;
            this.pbCover.Click += new System.EventHandler(this.ComicButton_Click);
            // 
            // lblComicName
            // 
            this.lblComicName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComicName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComicName.Location = new System.Drawing.Point(40, 12);
            this.lblComicName.Name = "lblComicName";
            this.lblComicName.Size = new System.Drawing.Size(374, 23);
            this.lblComicName.TabIndex = 2;
            this.lblComicName.Text = "comic name";
            this.lblComicName.Click += new System.EventHandler(this.ComicButton_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = global::ComicPeeps.Properties.Resources.delete;
            this.btnDelete.Location = new System.Drawing.Point(609, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(15, 15);
            this.btnDelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDelete.TabIndex = 3;
            this.btnDelete.TabStop = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Image = global::ComicPeeps.Properties.Resources.update;
            this.btnUpdate.Location = new System.Drawing.Point(575, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(15, 15);
            this.btnUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.TabStop = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lblIssueCount
            // 
            this.lblIssueCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssueCount.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueCount.Location = new System.Drawing.Point(420, 12);
            this.lblIssueCount.Name = "lblIssueCount";
            this.lblIssueCount.Size = new System.Drawing.Size(136, 23);
            this.lblIssueCount.TabIndex = 2;
            this.lblIssueCount.Text = "issues";
            this.lblIssueCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblIssueCount.Click += new System.EventHandler(this.ComicButton_Click);
            // 
            // ComicButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmMain;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblIssueCount);
            this.Controls.Add(this.lblComicName);
            this.Controls.Add(this.pbCover);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ComicButton";
            this.Size = new System.Drawing.Size(641, 40);
            this.Load += new System.EventHandler(this.ComicButton_Load);
            this.Click += new System.EventHandler(this.ComicButton_Click);
            this.cmMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateIssues;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.PictureBox pbCover;
        private System.Windows.Forms.Label lblComicName;
        private System.Windows.Forms.PictureBox btnDelete;
        private System.Windows.Forms.PictureBox btnUpdate;
        private System.Windows.Forms.Label lblIssueCount;
    }
}
