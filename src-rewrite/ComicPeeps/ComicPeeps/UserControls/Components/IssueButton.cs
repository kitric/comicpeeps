using ComicPeeps.Models;
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
        MainScreen mainScreen;

        ComicIssue issue;

        public IssueButton(ComicIssue comicIssue, MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
            this.issue = comicIssue;

            if (comicIssue.Thumbnail != "")
            {
                this.BackgroundImage = GlobalFunctions.CompressImage(comicIssue.Thumbnail, 15);
            }
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            mainScreen.ShowNewPage(new IssueDescription(issue) { Dock = DockStyle.Fill });
        }
    }
}
