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
    public partial class IssueDescription : UserControl
    {
        ComicInfo info = new ComicInfo();

        ComicIssue comicIssue;

        public IssueDescription(ComicIssue comicIssue)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MainScreen.Instance.OpenReader(comicIssue);
        }

        private async void IssueDescription_Load(object sender, EventArgs e)
        {
            if (!File.Exists(MainScreen.ComicInfoPath + "\\" + comicIssue.SeriesId + "\\" + comicIssue.IssueId + "\\ComicInfo.xml"))
            {
                info = ComicFunctions.GetComicInfo(comicIssue);
            }
            else
            {
                info = ComicFunctions.DesrializeComicInfo(MainScreen.ComicInfoPath + "\\" + comicIssue.SeriesId + "\\" + comicIssue.IssueId + "\\ComicInfo.xml");
            }

            lblTitle.Text = comicIssue.ComicName.ToLower() + " - issue " + comicIssue.IssueNumber;
            lblDescription.Text = info.Summary;
            pbThumbnail.Image = await GlobalFunctions.LocationToImage(comicIssue.Thumbnail);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (pbThumbnail.Image != null)
                pbThumbnail.Image.Dispose();
            this.Dispose();
        }
    }
}
