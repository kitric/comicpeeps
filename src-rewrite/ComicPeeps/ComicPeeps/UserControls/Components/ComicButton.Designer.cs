
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblComicName = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlMain.Controls.Add(this.lblComicName);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(83, 127);
            this.pnlMain.TabIndex = 0;
            // 
            // lblComicName
            // 
            this.lblComicName.BackColor = System.Drawing.Color.Transparent;
            this.lblComicName.Font = new System.Drawing.Font("Century Gothic", 5.2F, System.Drawing.FontStyle.Bold);
            this.lblComicName.ForeColor = System.Drawing.Color.White;
            this.lblComicName.Location = new System.Drawing.Point(0, 5);
            this.lblComicName.Name = "lblComicName";
            this.lblComicName.Size = new System.Drawing.Size(83, 23);
            this.lblComicName.TabIndex = 0;
            this.lblComicName.Text = "Comic Name";
            this.lblComicName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ComicButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pnlMain);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "ComicButton";
            this.Size = new System.Drawing.Size(83, 127);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblComicName;
    }
}
