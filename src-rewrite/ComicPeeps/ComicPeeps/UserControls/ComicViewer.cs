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
        // 6private int currentPage = 0;

        private ComicIssue comicIssue;

        public ComicViewer(ComicIssue comicIssue)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
            this.KeyPreview = true;

            var images = GlobalFunctions.ReadComic(comicIssue);
            foreach (var image in images)
            {
                MessageBox.Show(image);
            }
        }

        private void ComicViewer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                Directory.Delete(MainScreen.ComicExtractLocation + "\\" + comicIssue.ComicName, true);
                this.Close();
            }
        }
    }
}
