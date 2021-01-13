using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicsReader
{
    public partial class KeyboardShortcuts : Form
    {
        public KeyboardShortcuts()
        {
            InitializeComponent();
            richTextBox1.LoadFile("shortcuts.rtf");
        }
    }
}
