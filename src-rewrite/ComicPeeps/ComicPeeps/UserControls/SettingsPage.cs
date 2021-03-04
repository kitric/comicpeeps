using ComicPeeps.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.UserControls
{
    public partial class SettingsPage : UserControl
    {
        private bool autoFlipPages = false;
        private int autoFlipSpeed = 40;
        private bool saveLastPage = true;
        private int compressSize = 2;
        private int pageSize = 10;

        public SettingsPage()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            autoFlipPages = MainScreen.UserData.Settings.UseAutoRead;
            autoFlipSpeed = MainScreen.UserData.Settings.AutoReadSpeed;
            saveLastPage = MainScreen.UserData.Settings.SaveLastPage;
            compressSize = MainScreen.UserData.Settings.CompressSize;
            pageSize = MainScreen.UserData.Settings.PageSize;

            if (autoFlipPages)
            {
                btnAutoFlip.Image = Resources.untickButton;
            }

            if (saveLastPage)
            {
                btnSaveLastPage.Image = Resources.untickButton;
            }

            tbAutoFlip.Text = autoFlipSpeed.ToString();
            tbCompressSize.Text = compressSize.ToString();
            tbPageSize.Text = pageSize.ToString();
        }

        private void btnAutoFlip_Click(object sender, EventArgs e)
        {
            autoFlipPages = !autoFlipPages;
            
            if (autoFlipPages)
            {
                btnAutoFlip.Image = Resources.untickButton;
            }
            else
            {
                btnAutoFlip.Image = Resources.tickButton;
            }
        }

        private void btnSaveLastPage_Click(object sender, EventArgs e)
        {
            saveLastPage = !saveLastPage;
            
            if (saveLastPage)
            {
                btnSaveLastPage.Image = Resources.untickButton;
            }
            else
            {
                btnSaveLastPage.Image = Resources.tickButton;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MainScreen.UserData.Settings.UseAutoRead = autoFlipPages;
            MainScreen.UserData.Settings.SaveLastPage = saveLastPage;

            string errors = "";

            try
            {
                int tempSize = Convert.ToInt32(tbCompressSize.Text);

                if (tempSize < 1)
                {
                    errors += "Compress Size must be bigger than 1\n";
                }
                else
                {
                    MainScreen.UserData.Settings.CompressSize = tempSize;
                }
            }
            catch 
            {
                errors += "Compress Size must be a number\n";
            }

            try
            {
                int tempSpeed = Convert.ToInt32(tbAutoFlip.Text);

                if (tempSpeed < 15)
                {
                    errors += "Auto Flip Speed must be greater than 15\n";
                }
                else
                {
                    MainScreen.UserData.Settings.AutoReadSpeed = tempSpeed;
                }
            }
            catch
            {
                errors += "Auto Flip Speed must be a number\n";
            }

            try
            {
                int tempPageSize = Convert.ToInt32(tbPageSize.Text);

                if (tempPageSize < 1)
                {
                    errors += "Page Size must be greater than 0\n";
                }
                else
                {
                    MainScreen.UserData.Settings.PageSize = tempPageSize;
                }
            }
            catch
            {
                errors += "Auto Flip Speed must be a number\n";
            }

            if (errors != "")
            {
                MessageBox.Show($"Settings were saved, but there was an error:\n{errors}\nAffected settings have been reverted", "Saved");
            }
            else
            {
                MessageBox.Show($"Settings were saved.", "Saved");
            }

            LoadSettings();
        }
    }
}
