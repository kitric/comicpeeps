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
                    AddIndividualComic(fbd.SelectedPath);
                }
            }
        }

        private void AddIndividualComic(string selectedPath)
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

            GlobalFunctions.SwitchTo<Library>(MainScreen.Instance.pnlContent, "Library");
        }
    }
}
