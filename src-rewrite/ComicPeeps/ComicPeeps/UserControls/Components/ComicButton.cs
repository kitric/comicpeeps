using ComicPeeps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.UserControls.Components
{
    public partial class ComicButton : UserControl
    {
        ComicSeries comicSeries;

        Library library;

        public EventHandler OnRemove;

        public ComicButton(ComicSeries comicSeries, Library library)
        {
            InitializeComponent();

            this.library = library;
            this.comicSeries = comicSeries;

            cmMain.Renderer = new Renderer();
            cmMain.ForeColor = Color.White;
            cmMain.BackColor = Color.FromArgb(5, 5, 5);

            tsmRemove.ForeColor = Color.White;
            tsmRemove.BackColor = Color.FromArgb(5, 5, 5);

            tsmUpdateIssues.ForeColor = Color.White;
            tsmUpdateIssues.BackColor = Color.FromArgb(5, 5, 5);
        }

        ~ComicButton()
        {
            if (this.pbCover.Image != null)
                this.pbCover.Image.Dispose();
        }

        private void ComicButton_Click(object sender, EventArgs e)
        {
            //GlobalFunctions.SwitchTo<ComicLibrary>(MainScreen.Instance.pnlContent, "ComicLibrary", new object[] { comicSeries });
            if (Directory.Exists(comicSeries.FolderPath))
            {
                GlobalFunctions.AddToScreenWithoutSwitch<ComicLibrary>(MainScreen.Instance.pnlContent, "ComicLibrary", new object[] { comicSeries });
            }
            else
            {
                if (MessageBox.Show("This directory no longer exists. Do you want to remove the comic from your directory?", "Directory not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    // Delete the comic 
                    MainScreen.UserData.ComicSeries.Remove(comicSeries);
                    // Delete from the form
                    if (this.BackgroundImage != null)
                        this.BackgroundImage.Dispose();
                    this.Dispose();
                }
            }
        }

        private async void ComicButton_Load(object sender, EventArgs e)
        {
            lblComicName.Text = comicSeries.ComicName.ToLower() + ".";
            lblIssueCount.Text = comicSeries.Issues.Count + " issues.";

            if (comicSeries.Thumbnail != "")
            {
                if (File.Exists(comicSeries.Thumbnail))
                    this.pbCover.Image = await GlobalFunctions.CompressImage(comicSeries.Thumbnail, 5);
            }
            else
            {
                // Try getting the first issues thumbnail.
                if (comicSeries.Issues.Count > 0)
                {
                    comicSeries.Thumbnail = comicSeries.Issues[0].Thumbnail;
                }

                if (File.Exists(comicSeries.Thumbnail))
                    this.pbCover.Image = await GlobalFunctions.CompressImage(comicSeries.Thumbnail, 5);
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            RemoveComic();
        }

        private void tsmUpdateIssues_Click(object sender, EventArgs e)
        {
            UpdateComic();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveComic();
        }

        private void RemoveComic()
        {
            // Delete the thumbnails
            Directory.Delete(MainScreen.ThumbnailPath + "\\" + comicSeries.ComicSeriesId, true);
            MainScreen.Logger.Log($"Removing comic {comicSeries.ComicName}: Deleted thumbnails");
            MainScreen.UserData.ComicSeries.Remove(comicSeries);
            MainScreen.Logger.Log($"Removing comic {comicSeries.ComicName}: Comic deleted from library");
            MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
            MainScreen.Logger.ClearLogs();
            library.pnlComics.Controls.Remove(this);
            if (this.BackgroundImage != null)
            {
                this.BackgroundImage.Dispose();
            }
            if (OnRemove != null)
                OnRemove.Invoke(this, EventArgs.Empty);
            this.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateComic();
        }

        private async void UpdateComic()
        {
            if (await ComicFunctions.UpdateComic(comicSeries) == false)
            {
                // Delete from the form
                if (this.BackgroundImage != null)
                    this.BackgroundImage.Dispose();
                this.Dispose();
            }
        }
    }
}
