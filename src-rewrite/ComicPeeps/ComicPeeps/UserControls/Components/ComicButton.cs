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
    public partial class ComicButton : UserControl
    {
        public ComicButton(ComicSeries comicSeries)
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            if (comicSeries.Thumbnail != "")
            {
                this.BackgroundImage = GlobalFunctions.CompressImage(comicSeries.Thumbnail, 5);
            }
            lblComicName.Text = comicSeries.ComicName;
        }

        private void ComicButton_MouseEnter(object sender, EventArgs e)
        {
            pnlMain.Visible = true;
        }

        private void ComicButton_MouseLeave(object sender, EventArgs e)
        {
            pnlMain.Visible = false;
        }
    }
}
