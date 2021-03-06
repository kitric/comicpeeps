﻿using ComicPeeps.Models;
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
    public partial class ComicViewer : Form
    {
        private int currentPage = 0;

        private ComicIssue comicIssue;

        string[] images;

        int ZoomSize = 1;

        public ComicViewer(ComicIssue comicIssue)
        {
            InitializeComponent();
            
            this.comicIssue = comicIssue;
            this.KeyPreview = true;

            this.Text = comicIssue.ComicName + " " + comicIssue.IssueNumber;
        }

        private void ComicViewer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    e.SuppressKeyPress = true;
                    this.pbPageImage.Image.Dispose();
                    this.Close();
                    break;
                case Keys.Right:
                    e.SuppressKeyPress = true;
                    NextPage();
                    break;
                case Keys.Left:
                    e.SuppressKeyPress = true;
                    PreviousPage();
                    break;
                case Keys.Up:
                    e.SuppressKeyPress = true;
                    NextPage();
                    break;
                case Keys.Down:
                    e.SuppressKeyPress = true;
                    PreviousPage();
                    break;
                case Keys.Oemplus:
                    e.SuppressKeyPress = true;
                    ZoomIn();
                    break;
                case Keys.OemMinus:
                    e.SuppressKeyPress = true;
                    ZoomOut();
                    break;
            }
        }

        private void pnlRight_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void pnlLeft_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }

        async void NextPage()
        {
            if (currentPage < comicIssue.Pages - 1)
            {
                pnlPages.VerticalScroll.Value = 0;
                currentPage++;
                pbPageImage.Image.Dispose();

                if (File.Exists(images[currentPage]))
                {
                    pbPageImage.Image = await GlobalFunctions.CompressImage(images[currentPage], MainScreen.UserData.Settings.CompressSize);
                }
                else
                {
                    using (Image image = Properties.Resources.errorImage)
                    {
                        pbPageImage.Image = Properties.Resources.errorImage;
                    }
                }

                tbPageInput.Text = $"{currentPage + 1}";

                if (currentPage + 1 > comicIssue.Pages - 2)
                {
                    comicIssue.Completed = true;
                }

                if (MainScreen.UserData.Settings.UseAutoRead)
                {
                    AutoRead.Stop();
                    AutoRead.Start();
                }
            }
        }

        async void PreviousPage()
        {
            if (currentPage > 0)
            {
                pnlPages.VerticalScroll.Value = 0;
                currentPage--;
                pbPageImage.Image.Dispose();

                if (File.Exists(images[currentPage]))
                {
                    pbPageImage.Image = await GlobalFunctions.CompressImage(images[currentPage], MainScreen.UserData.Settings.CompressSize);
                }
                else
                {
                    using (Image image = Properties.Resources.errorImage)
                    {
                        pbPageImage.Image = Properties.Resources.errorImage;
                    }
                }

                tbPageInput.Text = $"{currentPage + 1}";
                if (MainScreen.UserData.Settings.UseAutoRead)
                {
                    AutoRead.Stop();
                    AutoRead.Start();
                }
            }
        }

        private void ComicViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(MainScreen.ComicExtractLocation + "\\" + comicIssue.SeriesId, true);
            if (MainScreen.UserData.Settings.SaveLastPage)
            {
                comicIssue.CurrentPage = currentPage + 1;
            }
        }

        private void ZoomOut()
        {
            if (ZoomSize > 1)
            {
                //Zoom ratio by which the images will be zoomed by default
                int zoomRatio = 10;
                //Set the zoomed width and height
                int widthZoom = pnlPages.Width * zoomRatio / 100;
                int heightZoom = pnlPages.Height * zoomRatio / 100;
                //zoom = true --> zoom in
                //zoom = false --> zoom out
                widthZoom *= -1;
                heightZoom *= -1;
                //Add the width and height to the picture box dimensions
                pbPageImage.Width += widthZoom;
                pbPageImage.Height += heightZoom;

                ZoomSize--;
            }
        }

        private void ZoomIn()
        {
            if (ZoomSize < 15)
            {
                //Zoom ratio by which the images will be zoomed by default
                int zoomRatio = 10;
                //Set the zoomed width and height
                int widthZoom = pnlPages.Width * zoomRatio / 100;
                int heightZoom = pnlPages.Height * zoomRatio / 100;

                //Add the width and height to the picture box dimensions
                pbPageImage.Width += widthZoom;
                pbPageImage.Height += heightZoom;

                ZoomSize++;
            }
        }

        private async void ComicViewer_Load(object sender, EventArgs e)
        {
            images = await ComicFunctions.ReadComic(comicIssue);

            comicIssue.Pages = images.Length;

            pbPageImage.Size = pnlPages.Size;

            currentPage = comicIssue.CurrentPage - 1;

            lblPageCount.Text = $"{comicIssue.Pages}";
            tbPageInput.Text = $"{currentPage + 1}";

            this.Focus();

            pbPageImage.Image = await GlobalFunctions.CompressImage(images[currentPage], MainScreen.UserData.Settings.CompressSize);

            if (MainScreen.UserData.Settings.UseAutoRead)
            {
                AutoRead.Interval = MainScreen.UserData.Settings.AutoReadSpeed * 1000;
                AutoRead.Start();
            }
        }

        private void AutoRead_Tick(object sender, EventArgs e)
        {
            NextPage();
        }

        private async void FlipToPage(int page)
        {
            if (page > 0 && page < comicIssue.Pages + 1)
            {
                pnlPages.VerticalScroll.Value = 0;
                currentPage = page - 1;
                pbPageImage.Image.Dispose();
                pbPageImage.Image = await GlobalFunctions.CompressImage(images[currentPage], MainScreen.UserData.Settings.CompressSize);
                tbPageInput.Text = $"{currentPage + 1}";

                if (currentPage + 1 > comicIssue.Pages - 2)
                {
                    comicIssue.Completed = true;
                }

                if (MainScreen.UserData.Settings.UseAutoRead)
                {
                    AutoRead.Stop();
                    AutoRead.Start();
                }
            }
        }

        private void tbPageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbPageInput.Text != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;

                    FlipToPage(Convert.ToInt32(tbPageInput.Text));
                }
            }
        }
    }
}
