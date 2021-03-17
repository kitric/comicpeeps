using ComicPeeps.Models;
using ComicPeeps.UserControls;
using Newtonsoft.Json;
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
using dotnetlogger;

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

        public static string LogFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps\logs";

        public static UserData UserData = new UserData();

        public static MainScreen Instance;

        public static DotNetLogger Logger = new DotNetLogger();

        UserControl CurrentScreen = new UserControl();

        public MainScreen()
        {
            InitializeComponent();

            Directory.CreateDirectory(LogFile);
            LogFile += "\\" + Logger.GenerateLogFileName("ComicPeeps");

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
            GlobalFunctions.SwitchTo<Library>(this.pnlContent, "Library");
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            GlobalFunctions.SwitchTo<About>(this.pnlContent, "About");
        }

        public static void Serialize()
        {
            Logger.Log("Saving data...");

            try
            {
                using (StreamWriter writer = new StreamWriter(AppData + "\\comic.peeps"))
                {
                    using (JsonWriter jwriter = new JsonTextWriter(writer))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jwriter, UserData);
                    }
                }

                Logger.Log("Data saved");
                GlobalFunctions.SaveLogsAndClear();
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error saving data, check the logs ({LogFile}) for more info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(e.Message);
                GlobalFunctions.SaveLogsAndClear();
            }
        }

        public static void Deserialize()
        {
            Logger.Log("---------------------- HELLO ( ﾟ▽ﾟ)/ ----------------------");
            Logger.Log("Loading data...");

            try
            {
                if (File.Exists(AppData + "\\comic.peeps"))
                {
                    using (StreamReader reader = new StreamReader(AppData + "\\comic.peeps"))
                    {
                        string json = reader.ReadToEnd();

                        UserData = JsonConvert.DeserializeObject<UserData>(json);
                    }
                }

                Logger.Log("Data loaded");
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error loading data, check the logs ({LogFile}) for more info", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log(e.Message);
            }
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize();
            Logger.Log("----------------------  BYE ( ﾟ▽ﾟ)/  ----------------------");
            GlobalFunctions.SaveLogsAndClear();
        }

        private void MainScreen_Shown(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                if (args[1].ToLower().EndsWith(".cbr") || args[1].ToLower().EndsWith(".cbz"))
                {
                    ComicIssue issue = new ComicIssue()
                    {
                        Location = args[1],
                        ComicName = Path.GetFileName(Path.GetDirectoryName(args[1]))
                    };

                    OpenReader(issue);
                }
            }

            if (GlobalFunctions.TestVer)
                MessageBox.Show($"Hi!\n\nThis is a test version (version b-{Application.ProductVersion})! Consult TESTGUIDE_b-{Application.ProductVersion}.txt to see a list of features that need testing. Also, don't forget to submit feedback via the Google Form!\n\nThanks - crxssed @ Kitric", "Test build", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                GlobalFunctions.CheckForUpdates();

            //LoadFileWatchers();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            GlobalFunctions.SwitchTo<SettingsPage>(this.pnlContent, "SettingsPage");
        }

        private void btnAbout_DoubleClick(object sender, EventArgs e)
        {
            ee ee = new ee();
            ee.WindowState = FormWindowState.Maximized;
            ee.Show();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            GlobalFunctions.SaveLogsAndClear();
        }
    }
}
