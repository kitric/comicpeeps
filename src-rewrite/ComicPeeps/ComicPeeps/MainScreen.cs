using ComicPeeps.Models;
using ComicPeeps.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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
        public static string ComicInfoPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps\comicinfo";
        public static string ComicExtractLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps\comics";

        public static UserData UserData = new UserData();

        public static MainScreen Instance;

        UserControl CurrentScreen = new UserControl();

        public MainScreen()
        {
            InitializeComponent();

            Directory.CreateDirectory(AppData);
            Directory.CreateDirectory(ThumbnailPath);
            Directory.CreateDirectory(ComicInfoPath);
            Directory.CreateDirectory(ComicExtractLocation);

            CurrentScreen = new Home() { Dock = DockStyle.Fill };

            pnlContent.Controls.Add(CurrentScreen);

            Instance = this;
        }

        static MainScreen()
        {
            Deserialize();
        }

        //public void ShowNewPage(UserControl ToOpen) 
        //{
        //    if (ToOpen.GetType() != CurrentScreen.GetType())
        //    {
        //        ToOpen.Dock = DockStyle.Fill;
        //
        //        CurrentScreen.Dispose();
        //        pnlContent.Controls.Remove(CurrentScreen);
        //
        //        ToOpen.Dock = DockStyle.Fill;
        //        pnlContent.Controls.Add(ToOpen);
        //
        //        CurrentScreen = ToOpen;
        //    }
        //}

        public void OpenReader(ComicIssue comicIssue)
        {
            ComicViewer viewer = new ComicViewer(comicIssue);
            viewer.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            //ShowNewPage(new Home() { Dock = DockStyle.Fill });

            GlobalFunctions.SwitchTo<Home>(this.pnlContent, "Home");
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            //ShowNewPage(new Library() { Dock = DockStyle.Fill });

            GlobalFunctions.SwitchTo<Library>(this.pnlContent, "Library");
        }

        public static void Serialize()
        {
            IFormatter f = new BinaryFormatter();

            using (Stream stream = new FileStream(AppData + "\\comic.peeps", FileMode.Create, FileAccess.Write))
            {
                f.Serialize(stream, UserData);
            }
        }

        public static void Deserialize()
        {
            if (File.Exists(AppData + "\\comic.peeps"))
            {
                IFormatter f = new BinaryFormatter();

                using (Stream stream = new FileStream(AppData + "\\comic.peeps", FileMode.Open, FileAccess.Read))
                {
                    UserData = (UserData)f.Deserialize(stream);
                }
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize();
        }
    }
}
