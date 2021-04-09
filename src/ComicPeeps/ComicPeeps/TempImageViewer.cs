using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps
{
    public partial class TempImageViewer : Form
    {
        public TempImageViewer(Image image)
        {
            InitializeComponent();
            pictureBox1.Image = image;
        }
    }
}
