
namespace ComicPeeps.UserControls
{
    partial class Editor
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
            this.lblSeries = new System.Windows.Forms.Label();
            this.tbSeries = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 20.3F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(29, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(63, 34);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "title";
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.lblSeries.ForeColor = System.Drawing.Color.White;
            this.lblSeries.Location = new System.Drawing.Point(29, 89);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(66, 23);
            this.lblSeries.TabIndex = 3;
            this.lblSeries.Text = "series:";
            // 
            // tbSeries
            // 
            this.tbSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSeries.BackColor = System.Drawing.Color.Black;
            this.tbSeries.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSeries.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.tbSeries.ForeColor = System.Drawing.Color.White;
            this.tbSeries.Location = new System.Drawing.Point(101, 90);
            this.tbSeries.Name = "tbSeries";
            this.tbSeries.Size = new System.Drawing.Size(445, 24);
            this.tbSeries.TabIndex = 4;
            // 
            // lblNumber
            // 
            this.lblNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.lblNumber.ForeColor = System.Drawing.Color.White;
            this.lblNumber.Location = new System.Drawing.Point(552, 89);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(86, 23);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "number:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.Black;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(644, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 24);
            this.textBox1.TabIndex = 4;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Century Gothic", 14.2F, System.Drawing.FontStyle.Bold);
            this.lblSummary.ForeColor = System.Drawing.Color.White;
            this.lblSummary.Location = new System.Drawing.Point(29, 140);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(100, 23);
            this.lblSummary.TabIndex = 3;
            this.lblSummary.Text = "summary:";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Century Gothic", 14.2F);
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(139, 141);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(576, 263);
            this.textBox2.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = global::ComicPeeps.Properties.Resources.saveButton;
            this.btnSave.Location = new System.Drawing.Point(139, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 54);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = global::ComicPeeps.Properties.Resources.cancelButton;
            this.btnCancel.Location = new System.Drawing.Point(553, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 54);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.TabStop = false;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.tbSeries);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.lblSeries);
            this.Controls.Add(this.lblTitle);
            this.Name = "Editor";
            this.Size = new System.Drawing.Size(757, 540);
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.TextBox tbSeries;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.PictureBox btnCancel;
    }
}
