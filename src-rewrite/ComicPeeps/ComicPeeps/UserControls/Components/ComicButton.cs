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
        ComicSeries comicSeries;

        public ComicButton(ComicSeries comicSeries)
        {
            InitializeComponent();

            this.comicSeries = comicSeries;
            this.DoubleBuffered = true;

            if (comicSeries.Thumbnail != "")
            {
                this.BackgroundImage = GlobalFunctions.CompressImage(comicSeries.Thumbnail, 15);
            }
        }

        private void ComicButton_Click(object sender, EventArgs e)
        {
            MainScreen.Instance.ShowNewPage(new ComicLibrary(comicSeries));
        }
    }
}
