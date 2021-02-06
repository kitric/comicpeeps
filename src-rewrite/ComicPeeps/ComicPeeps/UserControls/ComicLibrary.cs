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

        public ComicLibrary(ComicSeries comicSeries)
        {
            InitializeComponent();
            this.comicSeries = comicSeries;
        }

        Task<bool> LoadComics()
        {
            foreach (var issue in comicSeries.Issues)
            {
                pnlComics.Controls.Add(new IssueButton(issue));
            }

            return Task.FromResult(true);
        }

        private async void ComicLibrary_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"{comicSeries.ComicName.ToLower()}.";

            await LoadComics();

            GlobalFunctions.HideScrollBars(pnlComics);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
