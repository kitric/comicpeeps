
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
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.cmMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
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
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(83, 127);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 1;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.ComicButton_Click);
            // 
            // ComicButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmMain;
            this.Controls.Add(this.pbImage);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ComicButton";
            this.Size = new System.Drawing.Size(83, 127);
            this.Load += new System.EventHandler(this.ComicButton_Load);
            this.Click += new System.EventHandler(this.ComicButton_Click);
            this.cmMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateIssues;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
        private System.Windows.Forms.PictureBox pbImage;
    }
}
