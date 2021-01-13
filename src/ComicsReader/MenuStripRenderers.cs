using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicsReader
{
    public class Renderer : ToolStripProfessionalRenderer
    {
        public Renderer() : base(new RendererCols())
        {

        }
    }

    public class RendererCols : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color MenuBorder
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(26, 26, 26); }
        }
        public override Color SeparatorDark
        {
            get { return Color.White; }
        }
    }
}
