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
        public IssueButton(ComicIssue comicIssue)
        {
            InitializeComponent();

            if (comicIssue.Thumbnail != "")
            {
                this.BackgroundImage = GlobalFunctions.CompressImage(comicIssue.Thumbnail, 15);
            }
        }
    }
}
