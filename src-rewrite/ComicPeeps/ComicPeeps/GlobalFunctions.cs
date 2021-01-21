using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
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

		public static string GenerateCover(string comic)
        {
			string comicName = Path.GetFileNameWithoutExtension(comic);
			Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicName);

			if (comic.EndsWith(".cbz"))
            {
				// its a cbz file.
				using (ZipArchive archive = ZipFile.OpenRead(comic))
                {
					foreach (var entry in archive.Entries)
                    {
						if (entry.FullName.EndsWith(".jpg"))
                        {
							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName;
						}
						else if (entry.FullName.EndsWith(".png"))
                        {
							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName;
						}
                    }
                }
            }
			else if (comic.EndsWith(".cbr"))
            {
				// its a cbr file 
				using (RarArchive archive = RarArchive.Open(comic))
				{
					foreach (var entry in archive.Entries)
					{
						if (entry.Key.EndsWith(".jpg"))
						{
							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.Key);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.Key;
						}
						else if (entry.Key.EndsWith(".png"))
						{
							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.Key);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.Key;
						}
					}
				}
			}

			return "";
        }

		public static Bitmap CompressImage(string ImageFilePath, int CompressSize)
		{
			using (Image img = Image.FromFile(ImageFilePath))
			{
				Bitmap bmp = new Bitmap(img.Width / CompressSize, img.Height / CompressSize);
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
				}
				return bmp;
			}
		}
	}
}
