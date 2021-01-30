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
    public partial class Editor : UserControl
    {
        ComicIssue comicIssue;
        ComicInfo info;
        string comicInfoLocation;

        public Editor(ComicIssue comicIssue, string comicInfo, ComicInfo info)
        {
            InitializeComponent();

            this.comicIssue = comicIssue;
            this.info = info;
            this.comicInfoLocation = comicInfo;
        }

        private void Editor_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"{comicIssue.ComicName} - issue {comicIssue.IssueNumber} - editor";

            tbSeries.Text = info.Series;
            tbNumber.Text = info.Number;
            tbSummary.Text = info.Summary;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            GlobalFunctions.SwitchTo<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { comicIssue });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            info.Series = tbSeries.Text.Trim();
            info.Number = tbNumber.Text.Trim();
            info.Summary = tbSummary.Text.Trim();

            GlobalFunctions.SerializeComicInfo(info, MainScreen.ComicInfoPath + "\\" + comicIssue.ComicName + "\\" + comicIssue.IssueNumber + "\\ComicInfo.xml");

            GlobalFunctions.SwitchTo<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { comicIssue });
        }
    }
}
