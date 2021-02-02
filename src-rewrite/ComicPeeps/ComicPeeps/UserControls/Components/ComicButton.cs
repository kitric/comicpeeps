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

        Library library;

        public ComicButton(ComicSeries comicSeries, Library library)
        {
            InitializeComponent();

            this.library = library;
            this.comicSeries = comicSeries;
        }

        private void ComicButton_Click(object sender, EventArgs e)
        {
            GlobalFunctions.SwitchTo<ComicLibrary>(MainScreen.Instance.pnlContent, "ComicLibrary", new object[] { comicSeries });
        }

        private async void ComicButton_Load(object sender, EventArgs e)
        {
            if (comicSeries.Thumbnail != "")
            {
                this.BackgroundImage = await GlobalFunctions.CompressImage(comicSeries.Thumbnail, 15);
            }
        }

        private void tsmRemove_Click(object sender, EventArgs e)
        {
            MainScreen.UserData.ComicSeries.Remove(comicSeries);
            library.pnlComics.Controls.Remove(this);
            if (this.BackgroundImage != null)
            {
                this.BackgroundImage.Dispose();
            }
            this.Dispose();
        }

        private void tsmUpdateIssues_Click(object sender, EventArgs e)
        {
            GlobalFunctions.AddComicIssues(comicSeries);
        }
    }
}
