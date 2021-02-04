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
using System.Threading;

namespace ComicPeeps.UserControls
{
    public partial class AddComic : UserControl
    {
        public AddComic()
        {
            InitializeComponent();
        }

        private void AddComic_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    AddIndividualComic(fbd.SelectedPath);

                    GlobalFunctions.SwitchTo<Library>(MainScreen.Instance.pnlContent, "Library");
                }
            }
        }

        private async void pnlAddComicDirectory_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] comics = Directory.EnumerateDirectories(fbd.SelectedPath).ToArray();

                    if (comics.Length != 0)
                    {
                        if (MessageBox.Show($"{comics.Length} directories found. Are you sure you want to add them all? This may take a while...", $"{comics.Length} comics found", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            foreach (var comic in comics)
                            {
                                await AddIndividualComic(comic);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No Comic Series found in this directory: {fbd.SelectedPath}");
                    }
                    
                    GlobalFunctions.SwitchTo<Library>(MainScreen.Instance.pnlContent, "Library");
                }
            }
        }

        private Task<bool> AddIndividualComic(string selectedPath)
        {
            try
            {
                ComicSeries comicSeries = new ComicSeries()
                {
                    FolderPath = selectedPath,
                    ComicName = Path.GetFileName(selectedPath),
                    Thumbnail = ""
                };

                GlobalFunctions.AddComicIssues(comicSeries);

                if (comicSeries.Issues.Count != 0)
                {
                    comicSeries.Thumbnail = comicSeries.Issues[0].Thumbnail;
                }

                MainScreen.UserData.ComicSeries.Add(comicSeries);

                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");

                return Task.FromResult(false);
            }
        }
    }
}
