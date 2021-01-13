using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ComicsReader
{
    public partial class WelcomePage : UserControl
    {
        ComicPeeps MainScreen;

        public WelcomePage(ComicPeeps cp)
        {
            InitializeComponent();

            MainScreen = cp;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            string ComicLocation = "";
            string ComicName = "";

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "CBR files (*.cbr)|*.cbr|CBZ files (*.cbz)|*.cbz";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    MainScreen.UpdateText("Loading comic...");

                    ComicLocation = ofd.FileName;
                    ComicName = Path.GetFileNameWithoutExtension(ofd.FileName);

                    MainScreen.ShowNewPage(this, new ComicReader(MainScreen, ComicLocation, ComicName));
                }
            }

            
        }

        private void qaBtn_Click(object sender, EventArgs e)
        {
            MainScreen.UpdateText("Quick Access");
            MainScreen.ShowNewPage(this, new QuickAccessModels.QuickAccess());
        }
    }
}
