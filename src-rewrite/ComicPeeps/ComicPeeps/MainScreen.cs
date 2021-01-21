using ComicPeeps.Models;
using ComicPeeps.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps
{
    public partial class MainScreen : Form
    {
        //     ______                _      ____                      
        //    / ____/___  ____ ___  (_)____/ __ \___  ___  ____  _____
        //   / /   / __ \/ __ `__ \/ / ___/ /_/ / _ \/ _ \/ __ \/ ___/
        //  / /___/ /_/ / / / / / / / /__/ ____/  __/  __/ /_/ (__  ) 
        //  \____/\____/_/ /_/ /_/_/\___/_/    \___/\___/ .___/____/  
        //    ___________  _______________  ____/ /    /_/            
        //   / ___/ ___/ |/_/ ___/ ___/ _ \/ __  /                    
        //  / /__/ /  _>  <(__  |__  )  __/ /_/ /                     
        //  \___/_/  /_/|_/____/____/\___/\__,_/                      

        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps";
        public static string ThumbnailPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps\thumbs";

        public static List<ComicSeries> UserComics = new List<ComicSeries>();

        UserControl CurrentScreen = new UserControl();

        public MainScreen()
        {
            InitializeComponent();

            Directory.CreateDirectory(AppData);
            Directory.CreateDirectory(ThumbnailPath);

            CurrentScreen = new Home() { Dock = DockStyle.Fill };

            pnlContent.Controls.Add(CurrentScreen);
        }

        public void ShowNewPage(UserControl ToOpen)
        {
            if (ToOpen.GetType() != CurrentScreen.GetType())
            {
                ToOpen.Dock = DockStyle.Fill;

                CurrentScreen.Dispose();
                pnlContent.Controls.Remove(CurrentScreen);

                ToOpen.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(ToOpen);

                CurrentScreen = ToOpen;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowNewPage(new Home() { Dock = DockStyle.Fill });
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            ShowNewPage(new Library(this) { Dock = DockStyle.Fill });
        }
    }
}
