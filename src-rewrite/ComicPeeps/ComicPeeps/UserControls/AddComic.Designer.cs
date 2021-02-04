
namespace ComicPeeps.UserControls
{
    partial class AddComic
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlAddIndividualComic = new System.Windows.Forms.Panel();
            this.pnlAddComicDirectory = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlAddIndividualComic.SuspendLayout();
            this.pnlAddComicDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 46);
            this.label1.TabIndex = 3;
            this.label1.Text = "double click\r\nadd individual comic";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.DoubleClick += new System.EventHandler(this.AddComic_DoubleClick);
            // 
            // pnlAddIndividualComic
            // 
            this.pnlAddIndividualComic.Controls.Add(this.label1);
            this.pnlAddIndividualComic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAddIndividualComic.Location = new System.Drawing.Point(0, 0);
            this.pnlAddIndividualComic.Name = "pnlAddIndividualComic";
            this.pnlAddIndividualComic.Size = new System.Drawing.Size(350, 540);
            this.pnlAddIndividualComic.TabIndex = 4;
            this.pnlAddIndividualComic.DoubleClick += new System.EventHandler(this.AddComic_DoubleClick);
            // 
            // pnlAddComicDirectory
            // 
            this.pnlAddComicDirectory.Controls.Add(this.label2);
            this.pnlAddComicDirectory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAddComicDirectory.Location = new System.Drawing.Point(407, 0);
            this.pnlAddComicDirectory.Name = "pnlAddComicDirectory";
            this.pnlAddComicDirectory.Size = new System.Drawing.Size(350, 540);
            this.pnlAddComicDirectory.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(70, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 46);
            this.label2.TabIndex = 3;
            this.label2.Text = "double click\r\nadd comic directory";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AddComic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlAddComicDirectory);
            this.Controls.Add(this.pnlAddIndividualComic);
            this.Name = "AddComic";
            this.Size = new System.Drawing.Size(757, 540);
            this.pnlAddIndividualComic.ResumeLayout(false);
            this.pnlAddIndividualComic.PerformLayout();
            this.pnlAddComicDirectory.ResumeLayout(false);
            this.pnlAddComicDirectory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlAddIndividualComic;
        private System.Windows.Forms.Panel pnlAddComicDirectory;
        private System.Windows.Forms.Label label2;
    }
}
