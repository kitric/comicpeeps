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
        MainScreen mainScreen;

        public Library(MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;

            GlobalFunctions.HideScrollBars(pnlComics);

            LoadComics();
        }

        void LoadComics()
        {
            foreach (var comic in MainScreen.UserComics)
            {
                pnlComics.Controls.Add(new ComicButton(comic));
            }

            pnlComics.Controls.Add(new AddButton(mainScreen));
        }
    }
}
