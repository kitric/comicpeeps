using ComicPeeps.UserControls.Components;
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
    public partial class Library : UserControl
    {
        public Library()
        {
            InitializeComponent();

            GlobalFunctions.HideScrollBars(pnlComics);

            pnlComics.Controls.Add(new AddButton());
        }
    }
}
