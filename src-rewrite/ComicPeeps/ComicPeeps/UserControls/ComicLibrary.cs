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

        int page = 0;
        int maximumPages = 0;

        List<IssueButton> currentResults = new List<IssueButton>();

        public ComicLibrary(ComicSeries comicSeries)
        {
            InitializeComponent();
            this.comicSeries = comicSeries;
            maximumPages = Convert.ToInt32(Math.Ceiling((double)comicSeries.Issues.Count / (double)MainScreen.UserData.Settings.PageSize));
        }

        Task<bool> LoadComics()
        {
            // Dispose of all current results
            for (int i = 0; i < currentResults.Count; i++)
            {
                if (currentResults[i].BackgroundImage != null)
                    currentResults[i].BackgroundImage.Dispose();
                currentResults[i].Dispose();
            }
            currentResults.Clear();
            pnlComics.Controls.Clear();

            var issues = GlobalFunctions.GetPage(comicSeries.Issues, page, MainScreen.UserData.Settings.PageSize);

            // Add a previous button if the number pf pages is greater than 0
            if (page > 0)
            {
                CustomButton loadLess = new CustomButton(Properties.Resources.prev);
                loadLess.Click += Previous;
                pnlComics.Controls.Add(loadLess);
            }

            foreach (var issue in issues)
            {
                IssueButton issueButton = new IssueButton(issue);
                issueButton.Disposed += btnClose_Click;
                pnlComics.Controls.Add(issueButton);
            }

            if (page + 1 < maximumPages)
            {
                // Load more 
                CustomButton loadMore = new CustomButton(Properties.Resources.next);
                loadMore.Click += Next;
                pnlComics.Controls.Add(loadMore);
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

        private void Previous(object sender, EventArgs e)
        {
            page--;
            LoadComics();
        }

        private void Next(object sender, EventArgs e)
        {
            page++;
            LoadComics();
        }
    }
}
