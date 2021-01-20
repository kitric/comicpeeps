using NUnrar.Archive;
using System;
using System.Collections.Generic;
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
				RarArchive archive = RarArchive.Open(comic);
				foreach (var entry in archive.Entries)
                {
					if (entry.FilePath.EndsWith(".jpg"))
                    {
						entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FilePath);
						return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FilePath;
					}
					else if (entry.FilePath.EndsWith(".png"))
                    {
						entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FilePath);
						return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + entry.FilePath;
					}
                }
			}

			return "";
        }
	}
}
