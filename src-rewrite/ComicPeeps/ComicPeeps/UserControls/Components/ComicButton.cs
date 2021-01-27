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
        }

        private void ComicButton_Click(object sender, EventArgs e)
        {
            //MainScreen.Instance.ShowNewPage(new ComicLibrary(comicSeries));

            GlobalFunctions.SwitchTo<ComicLibrary>(MainScreen.Instance.pnlContent, "ComicLibrary", new object[] { comicSeries });
        }

        private async void ComicButton_Load(object sender, EventArgs e)
        {
            if (comicSeries.Thumbnail != "")
            {
                this.BackgroundImage = await GlobalFunctions.CompressImage(comicSeries.Thumbnail, 15);
            }
        }
    }
}
