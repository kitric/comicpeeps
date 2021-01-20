
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
            this.lblNotice = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNotice
            // 
            this.lblNotice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNotice.AutoSize = true;
            this.lblNotice.Font = new System.Drawing.Font("Century Gothic", 10.6F, System.Drawing.FontStyle.Bold);
            this.lblNotice.ForeColor = System.Drawing.Color.White;
            this.lblNotice.Location = new System.Drawing.Point(256, 276);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(244, 18);
            this.lblNotice.TabIndex = 2;
            this.lblNotice.Text = "double click anywhere to add...";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(273, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "specify folder path...";
            // 
            // AddComic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNotice);
            this.Name = "AddComic";
            this.Size = new System.Drawing.Size(757, 540);
            this.DoubleClick += new System.EventHandler(this.AddComic_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.Label label1;
    }
}
