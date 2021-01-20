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
                    ComicSeries comicSeries = new ComicSeries()
                    {
                        FolderPath = fbd.SelectedPath
                    };

                    List<string> cbz = Directory.GetFiles(fbd.SelectedPath, "*.cbz").ToList();
                    comicSeries.Issues = Directory.GetFiles(fbd.SelectedPath, "*.cbr").ToList().Concat(cbz).ToList();
                    comicSeries.Issues.Sort();
                    cbz.Clear();

                    comicSeries.Thumbnail = GlobalFunctions.GenerateCover(comicSeries.Issues[0]);

                    MessageBox.Show(comicSeries.FolderPath + " " + comicSeries.Issues.Count + " " + comicSeries.Thumbnail);
                }
            }
        }
    }
}
