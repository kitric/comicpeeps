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

namespace ComicPeeps.UserControls
{
    public partial class IssueDescription : UserControl
    {
        ComicInfo info = new ComicInfo();

        public IssueDescription(ComicIssue comicIssue)
        {
            InitializeComponent();

            info = GlobalFunctions.GetComicInfo(comicIssue);

            lblTitle.Text = comicIssue.ComicName.ToLower() + " - issue " + comicIssue.IssueNumber;
            lblDescription.Text = info.Summary;
            pbThumbnail.Image = GlobalFunctions.CompressImage(comicIssue.Thumbnail, 15);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            MainScreen.Instance.OpenReader();
        }
    }
}
