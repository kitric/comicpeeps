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
                    ZoomInImage();
                    break;
                case Keys.OemMinus:
                    ZoomOutImage();
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

        public void ZoomInImage()
        {
            if (ZoomSize < 15)
            {
                int Left = pbPageImage.Left;
                int Height = pbPageImage.Height;
                int Width = pbPageImage.Width;

                pbPageImage.Left = (int)(Left - (pnlPages.Width * 0.025));
                pbPageImage.Height = (int)(Height + (pnlPages.Height * 0.05));
                pbPageImage.Width = (int)(Width + (pnlPages.Width * 0.05));

                ZoomSize++;
            }
        }

        public void ZoomOutImage()
        {
            if (ZoomSize > 1)
            {
                int Left = pbPageImage.Left;
                int Height = pbPageImage.Height;
                int Width = pbPageImage.Width;

                pbPageImage.Left = (int)(Left + (pnlPages.Width * 0.025));
                pbPageImage.Height = (int)(Height - (pnlPages.Height * 0.05));
                pbPageImage.Width = (int)(Width - (pnlPages.Width * 0.05));

                ZoomSize--;
            }
        }

        private void ComicViewer_Load(object sender, EventArgs e)
        {
            pbPageImage.Size = pnlPages.Size;
        }
    }
}
