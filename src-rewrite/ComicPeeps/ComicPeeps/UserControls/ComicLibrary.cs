using ComicPeeps.Models;
using ComicPeeps.UserControls.Components;
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

namespace ComicPeeps.UserControls
{
    public partial class ComicLibrary : UserControl
    {
        ComicSeries comicSeries;

        MainScreen mainScreen;

        public ComicLibrary(ComicSeries comicSeries, MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
            this.comicSeries = comicSeries;

            GlobalFunctions.HideScrollBars(pnlComics);

            lblTitle.Text = $"{comicSeries.ComicName.ToLower()}.";

            LoadComics();
        }

        void LoadComics()
        {
            foreach (var issue in comicSeries.Issues)
            {
                pnlComics.Controls.Add(new IssueButton(issue, mainScreen));
            }
        }
    }
}
