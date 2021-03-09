using ComicPeeps.Models;
using ComicPeeps.UserControls.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.UserControls
{
    public partial class Library : UserControl
    {
        int page = 0;
        int maximumPages = 0;

        List<ComicButton> currentResults = new List<ComicButton>();

        int y = 0;
        const int buffer = 45;

        public Library()
        {
            InitializeComponent();
            maximumPages = Convert.ToInt32(Math.Ceiling((double)MainScreen.UserData.ComicSeries.Count / (double)MainScreen.UserData.Settings.PageSize));
        }

        public Task<bool> LoadComics()
        {
            y = 0;

            // Dispose of all current results
            for (int i = 0; i < currentResults.Count; i++)
            {
                if (currentResults[i].BackgroundImage != null)
                    currentResults[i].BackgroundImage.Dispose();
                currentResults[i].Dispose();
            }
            currentResults.Clear();
            pnlComics.Controls.Clear();

            var comics = GlobalFunctions.GetPage(MainScreen.UserData.ComicSeries, page, MainScreen.UserData.Settings.PageSize);

            // Add a previous button if the number pf pages is greater than 0
            if (page > 0)
            {
                CustomButton loadLess = new CustomButton(Properties.Resources.up);
                loadLess.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                loadLess.Width = pnlComics.Width - 19;
                loadLess.Location = new Point(0, y);
                loadLess.Click += Previous;
                pnlComics.Controls.Add(loadLess);
                y += buffer;
            }

            foreach (var comic in comics)
            {
                ComicButton comicButton = new ComicButton(comic, this);
                comicButton.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                comicButton.Width = pnlComics.Width - 19;
                comicButton.Location = new Point(0, y);
                comicButton.OnRemove += UpdateView;
                pnlComics.Controls.Add(comicButton);
                currentResults.Add(comicButton);
                y += buffer;
            }

            if (page + 1 < maximumPages)
            {
                // Load more 
                CustomButton loadMore = new CustomButton(Properties.Resources.down);
                loadMore.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                loadMore.Width = pnlComics.Width - 19;
                loadMore.Location = new Point(0, y);
                loadMore.Click += Next;
                pnlComics.Controls.Add(loadMore);
                y += buffer;
            }

            //pnlComics.Controls.Add(new AddButton());

            return Task.FromResult(true);
        }

        private async void Library_Load(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            await LoadComics();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");

            GlobalFunctions.HideScrollBars(pnlComics);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GlobalFunctions.SwitchTo<AddComic>(MainScreen.Instance.pnlContent, "AddComic");
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

        private void UpdateView(object sender, EventArgs e)
        {
            LoadComics();
        }
    }
}
