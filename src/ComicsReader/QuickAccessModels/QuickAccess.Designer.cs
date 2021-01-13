namespace ComicsReader.QuickAccessModels
{
    partial class QuickAccess
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
            this.addFolder = new System.Windows.Forms.Label();
            this.QAPANEL = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // addFolder
            // 
            this.addFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addFolder.AutoSize = true;
            this.addFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addFolder.Font = new System.Drawing.Font("Century Gothic", 17F, System.Drawing.FontStyle.Bold);
            this.addFolder.ForeColor = System.Drawing.Color.White;
            this.addFolder.Location = new System.Drawing.Point(3, 719);
            this.addFolder.Name = "addFolder";
            this.addFolder.Size = new System.Drawing.Size(244, 27);
            this.addFolder.TabIndex = 0;
            this.addFolder.Text = "Add comic directory";
            this.addFolder.Click += new System.EventHandler(this.addFolder_Click);
            // 
            // QAPANEL
            // 
            this.QAPANEL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QAPANEL.BackColor = System.Drawing.Color.Transparent;
            this.QAPANEL.Location = new System.Drawing.Point(466, 224);
            this.QAPANEL.Name = "QAPANEL";
            this.QAPANEL.Size = new System.Drawing.Size(400, 300);
            this.QAPANEL.TabIndex = 1;
            // 
            // QuickAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.QAPANEL);
            this.Controls.Add(this.addFolder);
            this.Name = "QuickAccess";
            this.Size = new System.Drawing.Size(1332, 749);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label addFolder;
        private System.Windows.Forms.Panel QAPANEL;
    }
}
