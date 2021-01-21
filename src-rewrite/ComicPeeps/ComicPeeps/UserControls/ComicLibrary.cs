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
    public partial class ComicLibrary : UserControl
    {
        public ComicLibrary(ComicSeries comicSeries)
        {
            InitializeComponent();

            lblTitle.Text = $"{comicSeries.ComicName.ToLower()}.";
        }
    }
}
