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
    public partial class ee : Form
    {
        Random random = new Random();

        public ee()
        {
            InitializeComponent();

            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            pictureBox1.Image = Recolour(Color.FromArgb(r, g, b));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image.Dispose();
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            pictureBox1.Image = Recolour(Color.FromArgb(r, g, b));
        }

        // Recolours all white pixels in an image to another specified colour, can be useful if you need to change multiple 
        // assets for theming app.
        // Can be easily edited so that its more customizable.
        public static Bitmap Recolour(Color newColour)
        {
            using (Image originalImage = Properties.Resources.crx_logo_big)
            {
                Bitmap newImage = new Bitmap(originalImage);

                for (int i = 0; i < originalImage.Height; i++)
                {
                    for (int j = 0; j < originalImage.Width; j++)
                    {
                        if (newImage.GetPixel(j, i).R > 250 && newImage.GetPixel(j, i).G > 250 && newImage.GetPixel(j, i).B > 250)
                        {
                            newImage.SetPixel(j, i, newColour);
                        }
                    }
                }
                return newImage;
            }
        }

        private void ee_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                this.Close();
            }
        }
    }
}
