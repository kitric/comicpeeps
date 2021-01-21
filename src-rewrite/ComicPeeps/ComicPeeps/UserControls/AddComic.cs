using ComicPeeps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComicPeeps.UserControls
{
    public partial class AddComic : UserControl
    {
        MainScreen mainScreen;

        public AddComic(MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
        }

        private void AddComic_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    ComicSeries comicSeries = new ComicSeries()
                    {
                        FolderPath = fbd.SelectedPath,
                        ComicName = Path.GetFileName(fbd.SelectedPath),
                        Thumbnail = ""
                    };

                    List<string> cbz = Directory.GetFiles(fbd.SelectedPath, "*.cbz").ToList();
                    List<string> issues = Directory.GetFiles(fbd.SelectedPath, "*.cbr").ToList().Concat(cbz).ToList();
                    issues.Sort();
                    cbz.Clear();

                    foreach (var issue in issues)
                    {
                        ComicIssue comicIssue = new ComicIssue()
                        {
                            ComicName = comicSeries.ComicName,
                            Location = issue,
                            Thumbnail = GlobalFunctions.GenerateCover(issue, comicSeries.ComicName)
                        };

                        comicSeries.Issues.Add(comicIssue);
                    }

                    if (comicSeries.Issues.Count != 0)
                    {
                        comicSeries.Thumbnail = comicSeries.Issues[0].Thumbnail;
                    }

                    MainScreen.UserComics.Add(comicSeries);

                    mainScreen.ShowNewPage(new Library(mainScreen) { Dock = DockStyle.Fill });
                }
            }
        }
    }
}
