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
                MainScreen.UserData.Settings.CompressSize = Convert.ToInt32(tbCompressSize.Text);
            }
            catch 
            {
                errors += "Compress Size must be a number\n";
            }

            try
            {
                MainScreen.UserData.Settings.AutoReadSpeed = Convert.ToInt32(tbAutoFlip.Text);
            }
            catch
            {
                errors += "Auto Flip Speed must be a number\n";
            }

            if (errors != "")
            {
                MessageBox.Show($"There was an error:\n{errors}Settings have been reverted");
            }

            LoadSettings();
        }
    }
}
