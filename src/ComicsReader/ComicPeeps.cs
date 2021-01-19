using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnrar.Archive;
using NUnrar.Common;
using NUnrar.Reader;
using NUnrar;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms.VisualStyles;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComicsReader
{
    public partial class ComicPeeps : Form
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
        
        UserControl CurrentScreen;

        public static string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ComicPeeps";

        public static History UserHistory = new History();

        bool MouseIsDown = false;
        bool Maximized = false;

        Point LastLoc;

        List<string> Arguments = new List<string>();

        public ComicPeeps()
        {
            InitializeComponent();

            this.KeyPreview = true;

            DeserializeHistory();

            Directory.CreateDirectory(AppData);
            Directory.CreateDirectory(AppData + @"\comics\");

            //Clear cache | ComicPeeps.AppData + @"\comics\"
            if (Directory.Exists(AppData + @"\comics\"))
            {
                foreach (var i in Directory.GetDirectories(AppData + @"\comics\"))
                {
                    try
                    {
                        Directory.Delete(i, true);
                    }
                    catch (Exception) { continue; }
                }
            }

            Arguments = Environment.GetCommandLineArgs().ToList<string>();

            if (Arguments.Count > 1)
            {
                //App was opened with the file explorer

                string ComicLoc = Arguments[1];
                string ComicName = Path.GetFileNameWithoutExtension(Arguments[1]);

                if (Path.GetExtension(Arguments[1]) == ".cbr" || Path.GetExtension(Arguments[1]) == ".cbz")
                {
                    this.UpdateText("Loading comic...");

                    ComicReader cr = new ComicReader(this, ComicLoc, ComicName);
                    cr.Dock = DockStyle.Fill;

                    cr.Location = new Point(0, 30);

                    CurrentScreen = cr;

                    WindowPanel.Controls.Add(cr);
                }
                else
                {
                    MessageBox.Show("Could not open that file - " + Path.GetExtension(Arguments[1]));
                    StartPage();
                }
            }
            else
            {
                StartPage();
            }
        }

        void StartPage()
        {
            WelcomePage welcomePage = new WelcomePage(this);
            welcomePage.Dock = DockStyle.Fill;

            welcomePage.Location = new Point(0, 30);

            CurrentScreen = welcomePage;

            WindowPanel.Controls.Add(welcomePage);
        }

        public void ShowNewPage(UserControl ToClose, UserControl ToOpen)
        {
            ToClose.Dispose();
            WindowPanel.Controls.Remove(ToClose);

            ToOpen.Location = new Point(0, 30);
            ToOpen.Dock = DockStyle.Fill;
            WindowPanel.Controls.Add(ToOpen);

            CurrentScreen = ToOpen;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentScreen.GetType().Name == "ComicReader")
            {
                using (ComicReader cr = CurrentScreen as ComicReader)
                {
                    cr.DeleteAllFiles();
                }
            }

            SerializeHistory();
        }

        private void ComicPeeps_Load(object sender, EventArgs e)
        {
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (Maximized == false)
            {
                this.WindowState = FormWindowState.Maximized;
                Maximized = true;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                Maximized = false;
            }
        }

        void MouseDown_Drag(MouseEventArgs e)
        {
            MouseIsDown = true;
            LastLoc = e.Location;
        }

        void MouseMove_Drag(MouseEventArgs e)
        {
            if (MouseIsDown)
            {
                this.Location = new Point((this.Location.X - LastLoc.X) + e.X, (this.Location.Y - LastLoc.Y) + e.Y);
                this.Update();
            }
        }

        void MouseUp_Drag(MouseEventArgs e)
        {
            MouseIsDown = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_Drag(e);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove_Drag(e);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUp_Drag(e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_Drag(e);
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove_Drag(e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUp_Drag(e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown_Drag(e);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove_Drag(e);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUp_Drag(e);
        }

        public void UpdateText(string ComicName)
        {
            this.Text = $"ComicPeeps - {ComicName}";
            Title.Text = $"ComicPeeps - {ComicName}";
        }

        public void ClearText()
        {
            this.Text = "ComicPeeps";
            Title.Text = "ComicPeeps";
        }

        public void SerializeHistory()
        {
            using (Stream S = new FileStream(AppData + @"\history.dat", FileMode.Create, FileAccess.Write))
            {
                IFormatter formatter = new BinaryFormatter();

                formatter.Serialize(S, UserHistory);
            }
        }

        public void DeserializeHistory()
        {
            if (File.Exists(AppData + @"\history.dat"))
            {
                using (Stream S = new FileStream(AppData + @"\history.dat", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    IFormatter formatter = new BinaryFormatter();

                    UserHistory = (History)formatter.Deserialize(S);
                }
            }
        }

        private void ComicPeeps_KeyDown(object sender, KeyEventArgs e)
        {
            if (CurrentScreen.GetType().Name == "ComicReader")
            {
                ComicReader cr = CurrentScreen as ComicReader;

                if (e.KeyCode == Keys.Left)
                {
                    cr.Previous();
                }
                else if (e.KeyCode == Keys.Right)
                {
                    cr.Next();
                }
                else if (e.KeyCode == Keys.Oemplus)
                {
                    cr.ZoomInImage();
                }
                else if (e.KeyCode == Keys.OemMinus)
                {
                    cr.ZoomOutImage();
                }
                else if (e.Control && e.KeyCode == Keys.O)
                {
                    using (OpenFileDialog ofd = new OpenFileDialog())
                    {
                        ofd.Filter = "CBR files (*.cbr)|*.cbr|CBZ files (*.cbz)|*.cbz";
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            cr.DeleteAllFiles(false);

                            cr.ComicLocation = ofd.FileName;
                            cr.ComicName = Path.GetFileNameWithoutExtension(ofd.FileName);

                            cr.OpenFile();
                        }
                    }
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    cr.CloseFile();
                }
            }
        }
    }
}
