
namespace ComicPeeps.UserControls.Components
{
    partial class IssueButton
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
            this.pbCompleted = new System.Windows.Forms.PictureBox();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMarkAsRead = new System.Windows.Forms.ToolStripMenuItem();
            this.lblIssueName = new System.Windows.Forms.Label();
            this.pbCover = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).BeginInit();
            this.cmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCompleted
            // 
            this.pbCompleted.BackColor = System.Drawing.Color.Transparent;
            this.pbCompleted.Image = global::ComicPeeps.Properties.Resources.completed;
            this.pbCompleted.Location = new System.Drawing.Point(606, 12);
            this.pbCompleted.Name = "pbCompleted";
            this.pbCompleted.Size = new System.Drawing.Size(22, 17);
            this.pbCompleted.TabIndex = 0;
            this.pbCompleted.TabStop = false;
            this.pbCompleted.Visible = false;
            this.pbCompleted.Click += new System.EventHandler(this.IssueButton_Click);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMarkAsRead});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(142, 26);
            // 
            // tsmMarkAsRead
            // 
            this.tsmMarkAsRead.Name = "tsmMarkAsRead";
            this.tsmMarkAsRead.Size = new System.Drawing.Size(141, 22);
            this.tsmMarkAsRead.Text = "Mark as read";
            this.tsmMarkAsRead.Click += new System.EventHandler(this.tsmMarkAsRead_Click);
            // 
            // lblIssueName
            // 
            this.lblIssueName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIssueName.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueName.Location = new System.Drawing.Point(40, 12);
            this.lblIssueName.Name = "lblIssueName";
            this.lblIssueName.Size = new System.Drawing.Size(560, 23);
            this.lblIssueName.TabIndex = 3;
            this.lblIssueName.Text = "comic name";
            this.lblIssueName.Click += new System.EventHandler(this.IssueButton_Click);
            // 
            // pbCover
            // 
            this.pbCover.Location = new System.Drawing.Point(0, 0);
            this.pbCover.Name = "pbCover";
            this.pbCover.Size = new System.Drawing.Size(26, 40);
            this.pbCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCover.TabIndex = 4;
            this.pbCover.TabStop = false;
            this.pbCover.Click += new System.EventHandler(this.IssueButton_Click);
            // 
            // IssueButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmsMain;
            this.Controls.Add(this.pbCover);
            this.Controls.Add(this.lblIssueName);
            this.Controls.Add(this.pbCompleted);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "IssueButton";
            this.Size = new System.Drawing.Size(641, 40);
            this.Load += new System.EventHandler(this.IssueButton_Load);
            this.Click += new System.EventHandler(this.IssueButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).EndInit();
            this.cmsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCover)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCompleted;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmMarkAsRead;
        private System.Windows.Forms.Label lblIssueName;
        private System.Windows.Forms.PictureBox pbCover;
    }
}
