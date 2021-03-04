
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
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCompleted
            // 
            this.pbCompleted.BackColor = System.Drawing.Color.Transparent;
            this.pbCompleted.Image = global::ComicPeeps.Properties.Resources.completed;
            this.pbCompleted.Location = new System.Drawing.Point(100, 171);
            this.pbCompleted.Name = "pbCompleted";
            this.pbCompleted.Size = new System.Drawing.Size(22, 17);
            this.pbCompleted.TabIndex = 0;
            this.pbCompleted.TabStop = false;
            this.pbCompleted.Visible = false;
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
            // IssueButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmsMain;
            this.Controls.Add(this.pbCompleted);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "IssueButton";
            this.Size = new System.Drawing.Size(125, 191);
            this.Load += new System.EventHandler(this.IssueButton_Load);
            this.Click += new System.EventHandler(this.IssueButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCompleted;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmMarkAsRead;
    }
}
