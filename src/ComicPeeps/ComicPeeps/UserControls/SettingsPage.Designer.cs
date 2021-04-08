
namespace ComicPeeps.UserControls
{
    partial class SettingsPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveLastPage = new System.Windows.Forms.PictureBox();
            this.btnAutoFlip = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.tbAutoFlip = new System.Windows.Forms.TextBox();
            this.tbCompressSize = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPageSize = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCsvExport = new System.Windows.Forms.Label();
            this.btnJsonExport = new System.Windows.Forms.Label();
            this.btnXmlExport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveLastPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAutoFlip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.3F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(29, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(123, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "settings.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(31, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "auto flip pages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "auto flip speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(31, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "save last page:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(31, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "compress size:";
            // 
            // btnSaveLastPage
            // 
            this.btnSaveLastPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveLastPage.Image = global::ComicPeeps.Properties.Resources.tickButton;
            this.btnSaveLastPage.Location = new System.Drawing.Point(222, 208);
            this.btnSaveLastPage.Name = "btnSaveLastPage";
            this.btnSaveLastPage.Size = new System.Drawing.Size(19, 19);
            this.btnSaveLastPage.TabIndex = 4;
            this.btnSaveLastPage.TabStop = false;
            this.btnSaveLastPage.Click += new System.EventHandler(this.btnSaveLastPage_Click);
            // 
            // btnAutoFlip
            // 
            this.btnAutoFlip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAutoFlip.Image = global::ComicPeeps.Properties.Resources.tickButton;
            this.btnAutoFlip.Location = new System.Drawing.Point(222, 102);
            this.btnAutoFlip.Name = "btnAutoFlip";
            this.btnAutoFlip.Size = new System.Drawing.Size(19, 19);
            this.btnAutoFlip.TabIndex = 4;
            this.btnAutoFlip.TabStop = false;
            this.btnAutoFlip.Click += new System.EventHandler(this.btnAutoFlip_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::ComicPeeps.Properties.Resources.saveButton;
            this.btnSave.Location = new System.Drawing.Point(40, 448);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 54);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbAutoFlip
            // 
            this.tbAutoFlip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.tbAutoFlip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAutoFlip.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.tbAutoFlip.ForeColor = System.Drawing.Color.White;
            this.tbAutoFlip.Location = new System.Drawing.Point(222, 154);
            this.tbAutoFlip.Name = "tbAutoFlip";
            this.tbAutoFlip.Size = new System.Drawing.Size(100, 24);
            this.tbAutoFlip.TabIndex = 6;
            // 
            // tbCompressSize
            // 
            this.tbCompressSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.tbCompressSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbCompressSize.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.tbCompressSize.ForeColor = System.Drawing.Color.White;
            this.tbCompressSize.Location = new System.Drawing.Point(222, 260);
            this.tbCompressSize.Name = "tbCompressSize";
            this.tbCompressSize.Size = new System.Drawing.Size(100, 24);
            this.tbCompressSize.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(31, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "page results size:";
            // 
            // tbPageSize
            // 
            this.tbPageSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(2)))), ((int)(((byte)(2)))));
            this.tbPageSize.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPageSize.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.tbPageSize.ForeColor = System.Drawing.Color.White;
            this.tbPageSize.Location = new System.Drawing.Point(222, 315);
            this.tbPageSize.Name = "tbPageSize";
            this.tbPageSize.Size = new System.Drawing.Size(100, 24);
            this.tbPageSize.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(31, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 23);
            this.label6.TabIndex = 3;
            this.label6.Text = "export data:";
            // 
            // btnCsvExport
            // 
            this.btnCsvExport.AutoSize = true;
            this.btnCsvExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCsvExport.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.btnCsvExport.ForeColor = System.Drawing.Color.White;
            this.btnCsvExport.Location = new System.Drawing.Point(218, 372);
            this.btnCsvExport.Name = "btnCsvExport";
            this.btnCsvExport.Size = new System.Drawing.Size(48, 23);
            this.btnCsvExport.TabIndex = 3;
            this.btnCsvExport.Text = "CSV";
            this.btnCsvExport.Click += new System.EventHandler(this.btnCsvExport_Click);
            // 
            // btnJsonExport
            // 
            this.btnJsonExport.AutoSize = true;
            this.btnJsonExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnJsonExport.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.btnJsonExport.ForeColor = System.Drawing.Color.White;
            this.btnJsonExport.Location = new System.Drawing.Point(308, 372);
            this.btnJsonExport.Name = "btnJsonExport";
            this.btnJsonExport.Size = new System.Drawing.Size(59, 23);
            this.btnJsonExport.TabIndex = 3;
            this.btnJsonExport.Text = "JSON";
            this.btnJsonExport.Click += new System.EventHandler(this.btnJsonExport_Click);
            // 
            // btnXmlExport
            // 
            this.btnXmlExport.AutoSize = true;
            this.btnXmlExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXmlExport.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.btnXmlExport.ForeColor = System.Drawing.Color.White;
            this.btnXmlExport.Location = new System.Drawing.Point(409, 372);
            this.btnXmlExport.Name = "btnXmlExport";
            this.btnXmlExport.Size = new System.Drawing.Size(48, 23);
            this.btnXmlExport.TabIndex = 3;
            this.btnXmlExport.Text = "XML";
            this.btnXmlExport.Click += new System.EventHandler(this.btnXmlExport_Click);
            // 
            // SettingsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tbPageSize);
            this.Controls.Add(this.tbCompressSize);
            this.Controls.Add(this.tbAutoFlip);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveLastPage);
            this.Controls.Add(this.btnAutoFlip);
            this.Controls.Add(this.btnXmlExport);
            this.Controls.Add(this.btnJsonExport);
            this.Controls.Add(this.btnCsvExport);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(757, 540);
            ((System.ComponentModel.ISupportInitialize)(this.btnSaveLastPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAutoFlip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox btnAutoFlip;
        private System.Windows.Forms.PictureBox btnSaveLastPage;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.TextBox tbAutoFlip;
        private System.Windows.Forms.TextBox tbCompressSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPageSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label btnCsvExport;
        private System.Windows.Forms.Label btnJsonExport;
        private System.Windows.Forms.Label btnXmlExport;
    }
}
