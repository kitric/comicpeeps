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

		public static Task<string> GenerateCover(string comic, string comicName)
		{
			Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicName);

			if (comic.ToLower().EndsWith(".cbz"))
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
							return Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName);
						}
						else if (entry.FullName.EndsWith(".png"))
						{
							string fileName = entry.FullName.Replace('/', '\\');

							if (fileName.Contains("\\"))
							{
								fileName = entry.FullName.Split('\\').Last();
							}

							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, true);
							return Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName);
						}
					}
				}
			}
			else if (comic.ToLower().EndsWith(".cbr"))
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
							return Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName);
						}
						else if (entry.Key.EndsWith(".png"))
						{
							string fileName = entry.Key;

							if (entry.Key.Contains("\\"))
							{
								fileName = entry.Key.Split('\\').Last();
							}

							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName, new SharpCompress.Common.ExtractionOptions() { ExtractFullPath = false, Overwrite = true });
							return Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicName + "\\" + fileName);
						}
					}
				}
			}

			return Task.FromResult("");
		}

		/// <summary>
		/// Must call `Directory.Delete(MainScreen.ComicInfoPath + "\\" + issue.ComicName);` after this
		/// </summary>
		/// <param name="issue"></param>
		/// <returns></returns>
		public static ComicInfo GetComicInfo(ComicIssue issue)
        {
			string dir = Directory.CreateDirectory(MainScreen.ComicInfoPath + "\\" + issue.ComicName + "\\" + issue.IssueNumber).FullName;

			if (issue.Location.ToLower().EndsWith(".cbz"))
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
			else if (issue.Location.ToLower().EndsWith(".cbr"))
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

		public static string SerializeComicInfo(ComicInfo info, string location)
        {
			using (Stream s = new FileStream(location, FileMode.Truncate, FileAccess.Write))
            {
				XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

				xmlSer.Serialize(s, info);

				return location;
			}
        }

		public static Task<Bitmap> CompressImage(string ImageFilePath, int CompressSize)
		{
			if (!string.IsNullOrWhiteSpace(ImageFilePath))
			{
				using (Image img = Image.FromFile(ImageFilePath))
				{
					Bitmap bmp = new Bitmap(img.Width / CompressSize, img.Height / CompressSize);
					using (Graphics g = Graphics.FromImage(bmp))
					{
						g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
					}
					return Task.FromResult(bmp);
				}
			}

			return null;
		}

		/// <summary>
		/// Now, you only need one function for switching windows.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="args"></param>
		public static void SwitchTo<T>(Panel Content, string type, object[] args = null) where T : UserControl
		{
			Control topControl = Content.Controls[0];

			// If the window on the top is different:
			if (topControl.GetType().Name.ToLower() != type.ToLower())
			{
				//Creates a new UserControl from T. 
				UserControl control = (UserControl)Activator.CreateInstance(typeof(T), args ?? new object[] { });
				control.Dock = DockStyle.Fill;

				foreach (Control x in topControl.Controls) { x.Dispose(); }
				topControl.Dispose();

				Content.Controls.Clear();
				Content.Controls.Add(control);
			}
		}

		// Read the ComicIssue and return the images
		public static Task<string[]> ReadComic(ComicIssue issue)
        {
			string dir = Directory.CreateDirectory(MainScreen.ComicExtractLocation + "\\" + issue.ComicName).FullName;
			
			if (issue.Location.ToLower().EndsWith(".cbz"))
            {
				using (ZipArchive archive = ZipFile.OpenRead(issue.Location))
                {
					archive.ExtractToDirectory(dir);
					
					var result = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(s => s.ToLower().EndsWith(".png") || s.ToLower().EndsWith(".jpg")).ToArray();
					Array.Sort(result);
					return Task.FromResult(result);
				}
            }
			else if (issue.Location.ToLower().EndsWith(".cbr"))
            {
				using (RarArchive archive = RarArchive.Open(issue.Location))
                {
					archive.WriteToDirectory(dir);

					var result = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(s => s.ToLower().EndsWith(".png") || s.ToLower().EndsWith(".jpg")).ToArray();
					Array.Sort(result);
					return Task.FromResult(result);
				}
            }

			return Task.FromResult(new string[0]);
        }

		/// <summary>
		/// Adds comics to a comic series
		/// </summary>
		/// <param name="comicSeries"></param>
		public static async void AddComicIssues(ComicSeries comicSeries)
		{
			comicSeries.Issues.Clear();

			var issues = Directory.EnumerateFiles(comicSeries.FolderPath, "*.*", SearchOption.AllDirectories).Where(s => s.ToLower().EndsWith(".cbr") || s.ToLower().EndsWith(".cbz")).ToArray();
			Array.Sort(issues);

			for (int i = 0; i < issues.Length; i++)
			{
				ComicIssue comicIssue = new ComicIssue()
				{
					ComicName = comicSeries.ComicName,
					Location = issues[i],
					Thumbnail = await GenerateCover(issues[i], comicSeries.ComicName),
					IssueNumber = i + 1
				};

				comicSeries.Issues.Add(comicIssue);
			}
		}

		public static async void UpdateComic(ComicSeries series)
        {
			List<string> existingComics = new List<string>();

			for (int i = 0; i < series.Issues.Count; i++)
            {
				if (File.Exists(series.Issues[i].Location))
                {
					existingComics.Add(series.Issues[i].Location);
                }
                else
                {
					// Mark as removed;
					series.Issues.Remove(series.Issues[i]);
                }
            }

			var newFiles = Directory.EnumerateFiles(series.FolderPath, "*.*", SearchOption.AllDirectories)
									.Where(s => s.ToLower().EndsWith(".cbr") || s.ToLower().EndsWith(".cbz"))
									.Where(s => !existingComics.Contains(s));

			foreach (var newFile in newFiles)
            {
				ComicIssue issue = new ComicIssue()
				{
					Location = newFile,
					ComicName = series.ComicName,
					IssueNumber = series.Issues.Count + 1,
					Thumbnail = await GenerateCover(newFile, series.ComicName)
				};

				series.Issues.Add(issue);
            }

			// Write function to update ComicSeries + IssueNumbers
			UpdateIssues(series);
		}

		public static void UpdateIssues(ComicSeries series)
        {
			for (int i = 0; i < series.Issues.Count; i++)
            {
				series.Issues[i].IssueNumber = i + 1;
            }
        }
	}
}
