using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.Models
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
            get { return Color.FromArgb(15, 15, 15); }
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(5, 5, 5); }
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
        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(5, 5, 5); }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(5, 5, 5); }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(5, 5, 5); }
        }
    }
}
