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

            this.BackgroundImage = GlobalFunctions.CompressImage(comicSeries.Thumbnail, 5);
            lblComicName.Text = comicSeries.ComicName;
        }
    }
}
