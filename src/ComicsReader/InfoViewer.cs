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
    public partial class InfoViewer : Form
    {
        public InfoViewer(ComicInfo info)
        {
            InitializeComponent();
            this.Text = info.Series;
            richTextBox1.Text = $"Series: {info.Series}{Environment.NewLine}{Environment.NewLine}Volume: {info.Volume}, Issue: {info.Number}, Page Count: {info.PageCount}{Environment.NewLine}{Environment.NewLine}Publisher: {info.Publisher}, Genre: {info.Genre}{Environment.NewLine}{Environment.NewLine}Summary: {info.Summary}";
        }
    }
}
