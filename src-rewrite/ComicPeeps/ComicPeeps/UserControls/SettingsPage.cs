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
    }
}
