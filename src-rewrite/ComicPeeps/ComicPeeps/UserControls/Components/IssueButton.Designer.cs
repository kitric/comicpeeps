
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
            this.pbCompleted = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCompleted
            // 
            this.pbCompleted.BackColor = System.Drawing.Color.Transparent;
            this.pbCompleted.Image = global::ComicPeeps.Properties.Resources.completed;
            this.pbCompleted.Location = new System.Drawing.Point(57, 107);
            this.pbCompleted.Name = "pbCompleted";
            this.pbCompleted.Size = new System.Drawing.Size(22, 17);
            this.pbCompleted.TabIndex = 0;
            this.pbCompleted.TabStop = false;
            this.pbCompleted.Visible = false;
            // 
            // IssueButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.pbCompleted);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "IssueButton";
            this.Size = new System.Drawing.Size(83, 127);
            this.Load += new System.EventHandler(this.IssueButton_Load);
            this.Click += new System.EventHandler(this.IssueButton_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompleted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCompleted;
    }
}
