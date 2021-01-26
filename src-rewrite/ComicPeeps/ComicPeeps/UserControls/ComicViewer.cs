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

        List<string> images;

        public ComicViewer(ComicIssue comicIssue)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
            this.KeyPreview = true;

            images = GlobalFunctions.ReadComic(comicIssue);

            currentPage = comicIssue.CurrentPage - 1;

            pbPageImage.Image = GlobalFunctions.CompressImage(images[currentPage], 5);
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