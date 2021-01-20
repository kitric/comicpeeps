using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps
{
    public static class GlobalFunctions
    {
		public static void HideScrollBars(Panel panel)
		{
			panel.VerticalScroll.Maximum = 0;
			panel.AutoScroll = false;
			panel.HorizontalScroll.Visible = false;
			panel.AutoScroll = true;
		}
	}
}
