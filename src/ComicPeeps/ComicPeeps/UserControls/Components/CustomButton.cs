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
    public partial class CustomButton : UserControl
    {
        public CustomButton(Image image)
        {
            InitializeComponent();
            this.pbImage.Image = image;
        }

        ~CustomButton()
        {
            if (this.pbImage.Image != null)
                this.pbImage.Image.Dispose();
        }
    }
}
