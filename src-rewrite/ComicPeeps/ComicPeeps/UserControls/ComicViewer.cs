using ComicPeeps.Models;
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

        List<string> images;

        int ZoomSize = 1;

        public ComicViewer(ComicIssue comicIssue)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
            this.KeyPreview = true;

            this.Text = comicIssue.ComicName + " " + comicIssue.IssueNumber;

            images = GlobalFunctions.ReadComic(comicIssue);

            currentPage = comicIssue.CurrentPage - 1;

            pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 2);

            lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
        }

        private void ComicViewer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.Right:
                    NextPage();
                    break;
                case Keys.Left:
                    PreviousPage();
                    break;
                case Keys.Up:
                    NextPage();
                    break;
                case Keys.Down:
                    PreviousPage();
                    break;
                case Keys.Oemplus:
                    ZoomInOut(true);
                    break;
                case Keys.OemMinus:
                    ZoomInOut(false);
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

        void NextPage()
        {
            if (currentPage < comicIssue.Pages - 1)
            {
                currentPage++;
                pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 2);
                lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
            }
        }

        void PreviousPage()
        {
            if (currentPage > 0)
            {
                currentPage--;
                pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 2);
                lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
            }
        }

        private void ComicViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(MainScreen.ComicExtractLocation + "\\" + comicIssue.ComicName, true);
            comicIssue.CurrentPage = currentPage + 1;
        }

        private void ZoomInOut(bool zoom)
        {
            //Zoom ratio by which the images will be zoomed by default
            int zoomRatio = 10;
            //Set the zoomed width and height
            int widthZoom = pbPageImage.Width * zoomRatio / 100;
            int heightZoom = pbPageImage.Height * zoomRatio / 100;
            //zoom = true --> zoom in
            //zoom = false --> zoom out
            if (!zoom)
            {
                widthZoom *= -1;
                heightZoom *= -1;
            }
            //Add the width and height to the picture box dimensions
            pbPageImage.Width += widthZoom;
            pbPageImage.Height += heightZoom;
        }

        private void ComicViewer_Load(object sender, EventArgs e)
        {
            pbPageImage.Size = pnlPages.Size;
        }
    }
}
