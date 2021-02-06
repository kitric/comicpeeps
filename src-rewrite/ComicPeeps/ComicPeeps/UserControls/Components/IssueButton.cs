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
        ComicIssue issue;

        public IssueButton(ComicIssue comicIssue)
        {
            InitializeComponent();
            this.issue = comicIssue;

            ToolTip toolTip = new ToolTip
            {
                OwnerDraw = true
            };

            toolTip.Draw += (s, e) =>
            {
                e.DrawBackground();
                e.DrawBorder();
                e.DrawText((TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter));
            };

            toolTip.BackColor = Color.FromArgb(5, 5, 5);
            toolTip.ForeColor = Color.White;
            toolTip.SetToolTip(this, $"{comicIssue.ComicName}, Issue {comicIssue.IssueNumber}");
        }

        private void IssueButton_Click(object sender, EventArgs e)
        {
            //GlobalFunctions.SwitchTo<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { issue });
            GlobalFunctions.AddToScreenWithoutSwitch<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { issue });
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
