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
    public partial class AddButton : UserControl
    {
        MainScreen mainScreen;

        public AddButton(MainScreen mainScreen)
        {
            InitializeComponent();

            this.mainScreen = mainScreen;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            mainScreen.ShowNewPage(new AddComic() { Dock = DockStyle.Fill });
        }
    }
}
