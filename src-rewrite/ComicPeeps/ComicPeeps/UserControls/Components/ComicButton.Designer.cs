
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
            this.cmMain.SuspendLayout();
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
            // ComicButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ContextMenuStrip = this.cmMain;
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ComicButton";
            this.Size = new System.Drawing.Size(125, 191);
            this.Load += new System.EventHandler(this.ComicButton_Load);
            this.Click += new System.EventHandler(this.ComicButton_Click);
            this.cmMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmMain;
        private System.Windows.Forms.ToolStripMenuItem tsmUpdateIssues;
        private System.Windows.Forms.ToolStripMenuItem tsmRemove;
    }
}
