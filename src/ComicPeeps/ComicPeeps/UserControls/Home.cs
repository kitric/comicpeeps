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
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Comic Files|*.cbr;*.cbz;*.pdf";
                ofd.Title = "Open comic";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ComicIssue issue = new ComicIssue()
                    {
                        Location = ofd.FileName,
                        ComicName = Path.GetFileName(Path.GetDirectoryName(ofd.FileName))
                    };

                    MainScreen.Instance.OpenReader(issue);
                }
            }
        }
    }
}
