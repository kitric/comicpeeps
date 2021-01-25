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
    public partial class ComicViewer : Form
    {
        public ComicViewer()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void ComicViewer_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
