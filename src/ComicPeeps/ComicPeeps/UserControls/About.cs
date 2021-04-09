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
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();

            lblSummary.Text += Application.ProductVersion;
        }

        private void crxssed_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://crxssed7.github.io");
        }

        private void nordic_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://nordic16.github.io");
        }

        private void mattbull_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/MattBullDev");
        }

        private void btnWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kitric.github.io");
        }

        private void sharpCompress_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/adamhathcock/sharpcompress");
        }

        private void dotNetLogger_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/crxssed7/dotnet-logger");
        }

        private void gitHubUpdate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/nixxquality/GitHubUpdate");
        }

        private void pdfPig_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/UglyToad/PdfPig");
        }
    }
}
