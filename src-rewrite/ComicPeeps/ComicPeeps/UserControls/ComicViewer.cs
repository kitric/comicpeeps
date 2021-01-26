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

        public ComicViewer(ComicIssue comicIssue)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
            this.KeyPreview = true;

            this.Text = comicIssue.ComicName + " " + comicIssue.IssueNumber;

            images = GlobalFunctions.ReadComic(comicIssue);

            currentPage = comicIssue.CurrentPage - 1;

            pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 5);

            lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
        }

        private void ComicViewer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
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
                pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 5);
                lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
            }
        }

        void PreviousPage()
        {
            if (currentPage > 0)
            {
                currentPage--;
                pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 5);
                lblPageCount.Text = $"{currentPage + 1} / {comicIssue.Pages}";
            }
        }

        private void ComicViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            Directory.Delete(MainScreen.ComicExtractLocation + "\\" + comicIssue.ComicName, true);
            comicIssue.CurrentPage = currentPage + 1;
        }
    }
}
