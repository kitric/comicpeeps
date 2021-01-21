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

		public static string GenerateCover(string comic, string comicName)
		{
			Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicName);

			if (comic.EndsWith(".cbz"))
			{
				// its a cbz file.
				using (ZipArchive archive = ZipFile.OpenRead(comic))
				{
					List<ZipArchiveEntry> entries = archive.Entries.OrderBy(entry => entry.FullName).ToList();
					foreach (var entry in entries)
					{
						if (entry.FullName.EndsWith(".jpg"))
						{
							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName, true);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName;
						}
						else if (entry.FullName.EndsWith(".png"))
						{
							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FullName, true);
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
					List<RarArchiveEntry> entries = archive.Entries.OrderBy(entry => entry.Key).Where(entry => !entry.IsDirectory).ToList();
					foreach (var entry in entries)
					{
						if (entry.Key.EndsWith(".jpg"))
						{
							string fileName = entry.Key;

							if (entry.Key.Contains("\\"))
                            {
								fileName = entry.Key.Split('\\').Last();
                            }

							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, new SharpCompress.Common.ExtractionOptions() { ExtractFullPath = false, Overwrite = true });
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName;
						}
						else if (entry.Key.EndsWith(".png"))
						{
							string fileName = entry.Key;

							if (entry.Key.Contains("\\"))
							{
								fileName = entry.Key.Split('\\').Last();
							}

							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, new SharpCompress.Common.ExtractionOptions() { ExtractFullPath = false, Overwrite = true });
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName;
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
