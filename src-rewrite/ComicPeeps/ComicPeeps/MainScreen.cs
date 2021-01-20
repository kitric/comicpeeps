using ComicPeeps.UserControls;
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
    public partial class MainScreen : Form
    {
        UserControl CurrentScreen = new UserControl();

        public MainScreen()
        {
            InitializeComponent();

            CurrentScreen = new Home() { Dock = DockStyle.Fill };

            pnlContent.Controls.Add(CurrentScreen);
        }

        public void ShowNewPage(UserControl ToOpen)
        {
            if (ToOpen.GetType() != CurrentScreen.GetType())
            {
                ToOpen.Dock = DockStyle.Fill;

                CurrentScreen.Dispose();
                pnlContent.Controls.Remove(CurrentScreen);

                ToOpen.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(ToOpen);

                CurrentScreen = ToOpen;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowNewPage(new Home() { Dock = DockStyle.Fill });
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            ShowNewPage(new Library(this) { Dock = DockStyle.Fill });
        }
    }
}
