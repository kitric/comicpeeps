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

namespace ComicPeeps.UserControls.Components
{
    public partial class IssueButton : UserControl
    {
        ComicIssue issue;

        public EventHandler DisposeObject;

        public IssueButton(ComicIssue comicIssue)
        {
            InitializeComponent();
            this.issue = comicIssue;

            issue.OnCompleted += OnIssueCompleted;

            cmsMain.Renderer = new Renderer();
            cmsMain.ForeColor = Color.White;
            cmsMain.BackColor = Color.FromArgb(5, 5, 5);

            tsmMarkAsRead.ForeColor = Color.White;
            tsmMarkAsRead.BackColor = Color.FromArgb(5, 5, 5);

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

        private async void IssueButton_Click(object sender, EventArgs e)
        {
            //GlobalFunctions.SwitchTo<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { issue });
            if (File.Exists(issue.Location))
            {
                GlobalFunctions.AddToScreenWithoutSwitch<IssueDescription>(MainScreen.Instance.pnlContent, "IssueDescription", new object[] { issue });
            }
            else
            {
                if (MessageBox.Show("This file no longer exists. Do you want to update this comic?", "File not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    // Update the comic
                    var comic = GlobalFunctions.GetComicFromId(issue.SeriesId);
                    if (comic != null)
                    {
                        await ComicFunctions.UpdateComic(comic);
                        
                        if (DisposeObject != null)
                        {
                            DisposeObject.Invoke(sender, e);
                        }

                        this.Dispose();
                    }
                }
            }
        }

        private async void IssueButton_Load(object sender, EventArgs e)
        {
            if (issue.Thumbnail != "")
            {
                try
                {
                    this.BackgroundImage = await GlobalFunctions.LocationToImage(issue.Thumbnail);
                }
                catch
                {
                    // Regenerate the cover again.
                    issue.Thumbnail = await ComicFunctions.GenerateCover(issue.Location, issue.SeriesId, issue.IssueNumber);
                    this.BackgroundImage = await GlobalFunctions.LocationToImage(issue.Thumbnail);
                }
            }
            else
            {
                // Regenerate the cover again.
                issue.Thumbnail = await ComicFunctions.GenerateCover(issue.Location, issue.SeriesId, issue.IssueNumber);
                this.BackgroundImage = await GlobalFunctions.LocationToImage(issue.Thumbnail);
            }

            if (issue.Completed == true)
            {
                this.pbCompleted.Visible = true;
                tsmMarkAsRead.Text = "Mark as unread";
            }
        }

        private void OnIssueCompleted(object sender, EventArgs e)
        {
            if (issue.Completed == true)
            {
                this.pbCompleted.Visible = true;
            }
            else
            {
                this.pbCompleted.Visible = false;
            }
        }

        private void tsmMarkAsRead_Click(object sender, EventArgs e)
        {
            if (!issue.Completed)
            {
                issue.Completed = true;
                tsmMarkAsRead.Text = "Mark as unread";
            }
            else
            {
                issue.Completed = false;
                tsmMarkAsRead.Text = "Mark as read";
            }
        }
    }
}
