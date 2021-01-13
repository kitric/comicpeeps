using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NUnrar.Archive;
using System.IO.Compression;
using System.Xml.Serialization;
using System.Diagnostics;

namespace ComicsReader
{
    public partial class ComicReader : UserControl
    {
        // SUPPORTED FILE TYPES: JPG, JPEG, PNG

        public string ComicLocation = "";
        public string ComicName = "";

        List<string> strImages = new List<string>();

        List<DirectoryInfo> Directories = new List<DirectoryInfo>();

        int CurrentImage = 0;

        ComicPeeps MainScreen;

        int ZoomSize = 1;

        OpenedComic comic;

        ComicInfo info;

        DirectoryInfo Dir;

        public ComicReader(ComicPeeps cp, string comicloc, string comicname)
        {
            InitializeComponent();

            menuStrip1.Renderer = new Renderer();
            menuStrip1.BackColor = Color.FromArgb(35, 35, 35);
            menuStrip1.ForeColor = Color.White;

            openToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            openToolStripMenuItem.ForeColor = Color.White;

            closeFileToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            closeFileToolStripMenuItem.ForeColor = Color.White;

            aboutComicToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            aboutComicToolStripMenuItem.ForeColor = Color.White;

            clearCacheToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            clearCacheToolStripMenuItem.ForeColor = Color.White;

            fAQToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            fAQToolStripMenuItem.ForeColor = Color.White;

            comicPeepsToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            comicPeepsToolStripMenuItem.ForeColor = Color.White;

            madPeepsToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            madPeepsToolStripMenuItem.ForeColor = Color.White;

            clearHistoryToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            clearHistoryToolStripMenuItem.ForeColor = Color.White;

            keyboardShortcutsToolStripMenuItem.BackColor = Color.FromArgb(35, 35, 35);
            keyboardShortcutsToolStripMenuItem.ForeColor = Color.White;

            this.ComicLocation = comicloc;
            this.ComicName = comicname;
            MainScreen = cp;

            PageCount.Text = (CurrentImage + 1).ToString();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CBR files (*.cbr)|*.cbr|CBZ files (*.cbz)|*.cbz";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    DeleteAllFiles(false);

                    ComicLocation = ofd.FileName;
                    ComicName = Path.GetFileNameWithoutExtension(ofd.FileName);

                    OpenFile();
                }
            }
        }

        //Retrieve comic info from xml file, if any
        void GetComicInfo(string XmlLoc)
        {
            using (Stream S = new FileStream(XmlLoc, FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

                info = (ComicInfo)xmlSer.Deserialize(S);
            }
        }

        //Previous
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Previous();
        }

        public void Previous()
        {
            panel2.VerticalScroll.Value = 0;

            CurrentImage--;
            if (CurrentImage >= 0)
            {
                using (Image img = Image.FromFile(strImages[CurrentImage]))
                {
                    Bitmap bmp = new Bitmap(img.Width / 3, img.Height / 3);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                    pictureBox1.Image = bmp;
                }
            }
            else
            {
                CurrentImage = 0;
            }

            comic.PageNumber = CurrentImage;

            PageCount.Text = (CurrentImage + 1).ToString() + " / " + strImages.Count;
        }

        //Next
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Next();
        }

        public void Next()
        {
            panel2.VerticalScroll.Value = 0;

            CurrentImage++;
            if (CurrentImage < strImages.Count)
            {
                using (Image img = Image.FromFile(strImages[CurrentImage]))
                {
                    Bitmap bmp = new Bitmap(img.Width / 3, img.Height / 3);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                    pictureBox1.Image = bmp;
                }
            }
            else
            {
                CurrentImage = strImages.Count - 1;
            }

            comic.PageNumber = CurrentImage;

            if (CurrentImage + 1 == strImages.Count)
            {
                comic.PageNumber = 0;
            }

            PageCount.Text = (CurrentImage + 1).ToString() + " / " + strImages.Count;
        }

        public void OpenFile()
        {
            CurrentImage = 0;

            if (ComicLocation.Contains(".cbr"))
            {
                //Unrar
                Dir = Directory.CreateDirectory(ComicPeeps.AppData + @"\comics\" + ComicName);
                Directories.Add(Dir);

                using (FileStream s = new FileStream(ComicLocation, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (FileStream copyto = new FileStream(Dir.FullName + @"\" + ComicName + ".rar", FileMode.Create, FileAccess.Write))
                        {
                            s.CopyTo(copyto);
                        }
                    }
                    catch (Exception) { }
                }

                RarArchive.WriteToDirectory(Dir.FullName + @"\" + ComicName + ".rar", Dir.FullName);

                //foreach (var image in Directory.GetFiles(Dir.FullName, "*.jpg", SearchOption.AllDirectories))
                //{
                //    try
                //    {
                //        strImages.Add(image);
                //    }
                //    catch (Exception) { MessageBox.Show("There was a problem opening the file - there may be some pages missing."); }
                //}

                strImages = Directory.GetFiles(Dir.FullName, "*.jpg", SearchOption.AllDirectories).ToList();
                //No .jpg images found, check for .jpeg images
                if (strImages.Count == 0)
                {
                    strImages = Directory.GetFiles(Dir.FullName, "*.jpeg", SearchOption.AllDirectories).ToList();
                }
                //No .jpeg files found, check for .png images
                if (strImages.Count == 0)
                {
                    strImages = Directory.GetFiles(Dir.FullName, "*.png", SearchOption.AllDirectories).ToList();
                }

                using (Image img = Image.FromFile(strImages[CurrentImage]))
                {
                    Bitmap bmp = new Bitmap(img.Width / 3, img.Height / 3);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                    pictureBox1.Image = bmp;
                }
            }
            else if (ComicLocation.Contains(".cbz"))
            {
                //Unzip
                Dir = Directory.CreateDirectory(ComicPeeps.AppData + @"\comics\" + ComicName);
                Directories.Add(Dir);

                using (FileStream s = new FileStream(ComicLocation, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream copyto = new FileStream(Dir.FullName + @"\" + ComicName + ".zip", FileMode.Create, FileAccess.Write))
                    {
                        s.CopyTo(copyto);
                    }
                }

                ZipFile.ExtractToDirectory(Dir.FullName + @"\" + ComicName + ".zip", Dir.FullName);

                //foreach (var image in Directory.GetFiles(Dir.FullName, "*.jpg", SearchOption.AllDirectories))
                //{
                //    strImages.Add(image);
                //}

                strImages = Directory.GetFiles(Dir.FullName, "*.jpg", SearchOption.AllDirectories).ToList();
                //No .jpg images found, check for .jpeg images
                if (strImages.Count == 0)
                {
                    strImages = Directory.GetFiles(Dir.FullName, "*.jpeg", SearchOption.AllDirectories).ToList();
                }
                //No .jpeg files found, check for .png images
                if (strImages.Count == 0)
                {
                    strImages = Directory.GetFiles(Dir.FullName, "*.png", SearchOption.AllDirectories).ToList();
                }

                using (Image img = Image.FromFile(strImages[CurrentImage]))
                {
                    Bitmap bmp = new Bitmap(img.Width / 3, img.Height / 3);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                    pictureBox1.Image = bmp;
                }
            }

            prev.Enabled = true;
            next2.Enabled = true;

            MainScreen.UpdateText(ComicName);

            //if not in history
            if (!ComicPeeps.UserHistory.Contains(ComicLocation))
            {
                comic = new OpenedComic()
                {
                    ComicLocation = ComicLocation,
                    ComicName = ComicName,
                    PageNumber = CurrentImage
                };
                ComicPeeps.UserHistory.AddComic(comic);
            }
            else
            {
                //is in history, load.
                comic = ComicPeeps.UserHistory.GetComic(ComicLocation);
                CurrentImage = comic.PageNumber;

                using (Image img = Image.FromFile(strImages[CurrentImage]))
                {
                    Bitmap bmp = new Bitmap(img.Width / 3, img.Height / 3);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                    pictureBox1.Image = bmp;
                }
            }

            PageCount.Text = (CurrentImage + 1).ToString() + " / " + strImages.Count;
        }

        public void DeleteAllFiles(bool dispose = true)
        {
            if (dispose == true)
            {
                pictureBox1.Dispose();
            }

            //foreach (var img in Images)
            //{
            //    img.Dispose();
            //}

            strImages.Clear();

            foreach (var dir in Directories)
            {
                try
                {
                    dir.Delete(true);
                }
                catch (IOException) { continue; }
            }
        }

        private void closeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseFile();
        }

        public void CloseFile()
        {
            DeleteAllFiles();

            MainScreen.ClearText();
            MainScreen.ShowNewPage(this, new WelcomePage(MainScreen));
        }

        public void ZoomInImage()
        {
            if (ZoomSize < 15)
            {
                int Left = pictureBox1.Left;
                int Height = pictureBox1.Height;
                int Width = pictureBox1.Width;

                pictureBox1.Left = (int)(Left - (pictureBox1.Width * 0.025));
                pictureBox1.Height = (int)(Height + (pictureBox1.Height * 0.05));
                pictureBox1.Width = (int)(Width + (pictureBox1.Width * 0.05));
                ZoomSize++;
            }
        }

        public void ZoomOutImage()
        {
            if (ZoomSize > 1)
            {
                int Left = pictureBox1.Left;
                int Height = pictureBox1.Height;
                int Width = pictureBox1.Width;

                pictureBox1.Left = (int)(Left + (pictureBox1.Width * 0.025));
                pictureBox1.Height = (int)(Height - (pictureBox1.Height * 0.05));
                pictureBox1.Width = (int)(Width - (pictureBox1.Width * 0.05));
                ZoomSize--;
            }
        }

        private void ZoomOut_Click(object sender, EventArgs e)
        {
            ZoomOutImage();
        }

        private void ZoomIn_Click(object sender, EventArgs e)
        {
            ZoomInImage();
        }

        private void ComicReader_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        public void ScrollUp()
        {
            if (panel2.VerticalScroll.Value > 0)
            {
                if (panel2.VerticalScroll.Value - 10 <= 0)
                {
                    panel2.VerticalScroll.Value = 0;
                }
                else
                {
                    panel2.VerticalScroll.Value -= 10;
                }
            }
        }

        public void ScrollDown()
        {
            if (panel2.VerticalScroll.Value < panel2.VerticalScroll.Maximum)
            {
                if (panel2.VerticalScroll.Value + 10 >= panel2.VerticalScroll.Maximum)
                {
                    panel2.VerticalScroll.Value = panel2.VerticalScroll.Maximum;
                }
                else
                {
                    panel2.VerticalScroll.Value += 10;
                }
            }
        }

        private void aboutComicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xmlloc = Directory.GetFiles(Dir.FullName, "*.xml").ToList<string>();
            if (xmlloc.Count > 0)
            {
                //Metadata exists, read it.
                var MetaDataFile = xmlloc.First();
                GetComicInfo(MetaDataFile);

                InfoViewer v = new InfoViewer(info);
                v.Show();
            }
            else
            {
                MessageBox.Show("This comic file does not have any metadata.", "No metadata found");
            }
        }

        //clear cache
        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var i in Directory.GetDirectories(ComicPeeps.AppData + @"\comics\"))
            {
                try
                {
                    Directory.Delete(i, true);
                }
                catch (Exception) { continue; }
            }

            MessageBox.Show("Cache has been cleared.");
        }

        //Clear history
        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure want to clear your history? This will remove all your bookmarks and close the current file.", "Are you sure?", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    ComicPeeps.UserHistory.ClearHistory();
                    MainScreen.SerializeHistory();
                    DeleteAllFiles();

                    MainScreen.ClearText();
                    MainScreen.ShowNewPage(this, new WelcomePage(MainScreen));

                    MessageBox.Show("History has been cleared.");
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void fAQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FAQ fAQ = new FAQ();
            fAQ.Show(this);
        }

        private void keyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyboardShortcuts s = new KeyboardShortcuts();
            s.Show(this);
        }

        private void ComicReader_Load(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void comicPeepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutCP a = new AboutCP();
            a.Show();
        }

        private void madPeepsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://madpeepsoftware.weebly.com/");
        }
    }
}
