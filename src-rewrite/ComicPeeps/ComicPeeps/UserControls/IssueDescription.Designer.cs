
namespace ComicPeeps.UserControls
{
    partial class IssueDescription
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.PictureBox();
            this.btnEdit = new System.Windows.Forms.PictureBox();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.3F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(29, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(63, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "title";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.White;
            this.lblDescription.Location = new System.Drawing.Point(336, 93);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Padding = new System.Windows.Forms.Padding(3);
            this.lblDescription.Size = new System.Drawing.Size(385, 301);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "description";
            // 
            // btnRead
            // 
            this.btnRead.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRead.Image = global::ComicPeeps.Properties.Resources.readBtn;
            this.btnRead.Location = new System.Drawing.Point(558, 423);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(162, 54);
            this.btnRead.TabIndex = 6;
            this.btnRead.TabStop = false;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = global::ComicPeeps.Properties.Resources.editBtn;
            this.btnEdit.Location = new System.Drawing.Point(336, 423);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(162, 54);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.TabStop = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Location = new System.Drawing.Point(39, 93);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(260, 399);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbThumbnail.TabIndex = 4;
            this.pbThumbnail.TabStop = false;
            // 
            // IssueDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.pbThumbnail);
            this.Controls.Add(this.lblTitle);
            this.Name = "IssueDescription";
            this.Size = new System.Drawing.Size(757, 540);
            ((System.ComponentModel.ISupportInitialize)(this.btnRead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.PictureBox btnEdit;
        private System.Windows.Forms.PictureBox btnRead;
    }
}
