using ComicPeeps.Models;
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
using System.Xml.Serialization;

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
							string fileName = entry.FullName;

							if (fileName.Contains("\\"))
							{
								fileName = entry.FullName.Split('\\').Last();
							}
						    if (fileName.Contains("/"))
                            {
								fileName = fileName.Split('/').Last();
							}

							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, true);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName;
						}
						else if (entry.FullName.EndsWith(".png"))
						{
							string fileName = entry.FullName.Replace('/', '\\');

							if (fileName.Contains("\\"))
							{
								fileName = entry.FullName.Split('\\').Last();
							}

							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, true);
							return MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName;
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

		public static int GetNumberOfPages(string comic)
        {
			if (comic.EndsWith(".cbz"))
			{
				// its a cbz file.
				using (ZipArchive archive = ZipFile.OpenRead(comic))
				{
					List<ZipArchiveEntry> entries = archive.Entries.OrderBy(entry => entry.FullName).Where(entry => entry.FullName.Contains(".jpg")).ToList();
					List<ZipArchiveEntry> png = archive.Entries.OrderBy(entry => entry.FullName).Where(entry => entry.FullName.Contains(".png")).ToList();
					entries.Concat(png);
					return entries.Count;
				}
			}
			else if (comic.EndsWith(".cbr"))
			{
				// its a cbr file 
				using (RarArchive archive = RarArchive.Open(comic))
				{
					List<RarArchiveEntry> entries = archive.Entries.OrderBy(entry => entry.Key).Where(entry => !entry.IsDirectory).Where(entry => entry.Key.Contains(".jpg")).ToList();
					List<RarArchiveEntry> png = archive.Entries.OrderBy(entry => entry.Key).Where(entry => !entry.IsDirectory).Where(entry => entry.Key.Contains(".png")).ToList();
					entries.Concat(png);
					return entries.Count;
				}
			}

			return 0;
		}

		/// <summary>
		/// Must call `Directory.Delete(MainScreen.ComicInfoPath + "\\" + issue.ComicName);` after this
		/// </summary>
		/// <param name="issue"></param>
		/// <returns></returns>
		public static ComicInfo GetComicInfo(ComicIssue issue)
        {
			string dir = Directory.CreateDirectory(MainScreen.ComicInfoPath + "\\" + issue.ComicName + "\\" + issue.IssueNumber).FullName;

			if (issue.Location.EndsWith(".cbz"))
			{
				// its a cbz file.
				using (ZipArchive archive = ZipFile.OpenRead(issue.Location))
				{
                    try
                    {
						ZipArchiveEntry entry = archive.Entries.Where(e => e.FullName == "ComicInfo.xml").First();
						entry.ExtractToFile(dir + "\\" + issue.IssueNumber + "\\ComicInfo.xml");

						using (Stream S = new FileStream(dir + "\\ComicInfo.xml", FileMode.Open, FileAccess.Read))
						{
							XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

							return (ComicInfo)xmlSer.Deserialize(S);
						}
					}
					catch { }
				}
			}
			else if (issue.Location.EndsWith(".cbr"))
			{
				// its a cbr file 
				using (RarArchive archive = RarArchive.Open(issue.Location))
				{
                    try
                    {
						RarArchiveEntry entry = archive.Entries.Where(e => e.Key == "ComicInfo.xml").First();
						entry.WriteToFile(dir + "\\ComicInfo.xml");

						using (Stream S = new FileStream(dir + "\\ComicInfo.xml", FileMode.Open, FileAccess.Read))
						{
							XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

							return (ComicInfo)xmlSer.Deserialize(S);
						}
					}
					catch { }
				}
			}

			return new ComicInfo()
			{
				Summary = "This comic does not have a summary"
			};
		}

		public static ComicInfo DesrializeComicInfo(string filePath)
        {
			using (Stream S = new FileStream(filePath, FileMode.Open, FileAccess.Read))
			{
				XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

				return (ComicInfo)xmlSer.Deserialize(S);
			}
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

		/// <summary>
		/// Now, you only need one function for switching windows.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="args"></param>
		public static void SwitchTo<T>(Panel Content, object[] args = null) where T : UserControl
		{
			Control topControl = Content.Controls[0];

			//Creates a new UserControl from T. 
			UserControl control = (UserControl)Activator.CreateInstance(typeof(T), args ?? new object[] { });
			control.Dock = DockStyle.Fill;

			// If the window on the top is different:
			if (topControl.GetType() != control.GetType())
			{
				foreach (Control x in topControl.Controls) { x.Dispose(); }
				topControl.Dispose();

				Content.Controls.Clear();
				Content.Controls.Add(control);
			}
		}

		public static List<string> ReadComic(ComicIssue issue)
        {
			string dir = Directory.CreateDirectory(MainScreen.ComicExtractLocation + "\\" + issue.ComicName).FullName;

			List<string> images = new List<string>();

			if (issue.Location.EndsWith(".cbz"))
            {
				using (ZipArchive archive = ZipFile.OpenRead(issue.Location))
                {
					archive.ExtractToDirectory(dir);

					images = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).ToList();
					if (images.Count == 0)
					{
						images = Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories).ToList();
					}
					images.Sort();
				}
            }
			else if (issue.Location.EndsWith(".cbr"))
            {
				using (RarArchive archive = RarArchive.Open(issue.Location))
                {
					archive.WriteToDirectory(dir);

					images = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).ToList();
					if (images.Count == 0)
                    {
						images = Directory.GetFiles(dir, "*.png", SearchOption.AllDirectories).ToList();
					}
					images.Sort();
				}
            }

			return images;
        }
	}
}
