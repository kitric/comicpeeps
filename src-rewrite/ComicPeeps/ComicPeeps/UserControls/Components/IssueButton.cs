﻿using ComicPeeps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.UserControls.Components
{
    public partial class IssueButton : UserControl
    {
        ComicIssue issue;

        public IssueButton(ComicIssue comicIssue)
        {
            InitializeComponent();
            this.issue = comicIssue;
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            //MainScreen.Instance.ShowNewPage(new IssueDescription(issue) { Dock = DockStyle.Fill });

            GlobalFunctions.SwitchTo<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { issue });
        }

        private async void IssueButton_Load(object sender, EventArgs e)
        {
            if (issue.Thumbnail != "")
            {
                this.BackgroundImage = await GlobalFunctions.CompressImage(issue.Thumbnail, 15);
            }
        }
    }
}
