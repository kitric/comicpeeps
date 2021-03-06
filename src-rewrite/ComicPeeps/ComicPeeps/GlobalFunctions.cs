using ComicPeeps.Models;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

		public static async Task<string> GenerateCover(string comic, string comicSeriesId, int comicNumber)
		{
			Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicSeriesId);

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

							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, true);

							using (var image = await CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
                            {
								image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
                            }

							File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

							return await Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
						}
						else if (entry.FullName.EndsWith(".png"))
						{
							string fileName = entry.FullName.Replace('/', '\\');

							if (fileName.Contains("\\"))
							{
								fileName = entry.FullName.Split('\\').Last();
							}

							entry.ExtractToFile(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, true);

							using (var image = await CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
							{
								image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
							}

							File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

							return await Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
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

							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, new SharpCompress.Common.ExtractionOptions() { ExtractFullPath = false, Overwrite = true });

							using (var image = await CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
							{
								image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
							}

							File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

							return await Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
						}
						else if (entry.Key.EndsWith(".png"))
						{
							string fileName = entry.Key;

							if (entry.Key.Contains("\\"))
							{
								fileName = entry.Key.Split('\\').Last();
							}

							entry.WriteToFile(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, new SharpCompress.Common.ExtractionOptions() { ExtractFullPath = false, Overwrite = true });

							using (var image = await CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
							{
								image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
							}

							File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

							return await Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
						}
					}
				}
			}

			return await Task.FromResult("");
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
						entry.ExtractToFile(dir + "\\ComicInfo.xml");

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

		public static async Task<Bitmap> CompressImage(string ImageFilePath, int CompressSize)
		{
			try
			{
				if (ImageFilePath != "")
				{
					using (Image img = Image.FromFile(ImageFilePath))
					{
						Bitmap bmp = new Bitmap(img.Width / CompressSize, img.Height / CompressSize);
						Stopwatch watch = new Stopwatch();
						watch.Start();
						using (Graphics g = Graphics.FromImage(bmp))
						{
							watch.Stop();
							Console.WriteLine(watch.ElapsedMilliseconds + "ms: " + ImageFilePath);

							g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
						}

						return await Task.FromResult(bmp);
					}
				}

				return null;
			}
            catch
            {
				throw new Exception("File missing: " + ImageFilePath);
			}
		}

		public static async Task<Bitmap> LocationToImage(string ImageFilePath)
        {
			try
			{
				if (ImageFilePath != "")
				{
					using (Image img = Image.FromFile(ImageFilePath))
					{
						Bitmap bmp = new Bitmap(img.Width, img.Height);
						using (Graphics g = Graphics.FromImage(bmp))
						{
							g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height));
						}

						return await Task.FromResult(bmp);
					}
				}

				return null;
			}
			catch
            {
				throw new Exception("File missing: " + ImageFilePath);
            }
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
			string dir = Directory.CreateDirectory(MainScreen.ComicExtractLocation + "\\" + issue.SeriesId + "\\" + issue.IssueId).FullName;
			
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
		public static async Task<bool> AddComicIssues(ComicSeries comicSeries)
		{
			try
			{
				comicSeries.Issues.Clear();

				var issues = Directory.EnumerateFiles(comicSeries.FolderPath, "*.*", SearchOption.AllDirectories).Where(s => s.ToLower().EndsWith(".cbr") || s.ToLower().EndsWith(".cbz")).ToArray();
				Array.Sort(issues);

				for (int i = 0; i < issues.Length; i++)
				{
					ComicIssue comicIssue = new ComicIssue()
					{
						ComicName = comicSeries.ComicName,
						SeriesId = comicSeries.ComicSeriesId,
						Location = issues[i],
						Thumbnail = await GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1),
						IssueNumber = i + 1
					};

					comicSeries.Issues.Add(comicIssue);
				}

				return await Task.FromResult(true);
			}
			catch (Exception e)
            {
				Console.WriteLine($"There was an error: {e.Message}");

				return await Task.FromResult(false);
            }
		}

		public static async Task<bool> UpdateComic(ComicSeries series)
        {
			if (Directory.Exists(series.FolderPath))
			{
				// Getting new files
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
						Thumbnail = await GenerateCover(newFile, series.ComicSeriesId, series.Issues.Count + 1)
					};

					series.Issues.Add(issue);
				}

				// Get new details
				series.ComicName = Path.GetFileName(series.FolderPath);

				// Write function to update ComicSeries + IssueNumbers
				UpdateIssues(series);

				return true;
			}
            else
            {
				if (MessageBox.Show("This directory no longer exists. Do you want to remove the comic from your directory?", "Directory not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
					// Delete the comic
					MainScreen.UserData.ComicSeries.Remove(series);

					return false;
                }

				return true;
            }
		}

		public static void UpdateIssues(ComicSeries series)
        {
			for (int i = 0; i < series.Issues.Count; i++)
            {
				series.Issues[i].IssueNumber = i + 1;
            }
        }

		public static void AddToScreenWithoutSwitch<T>(Panel Content, string type, object[] args = null) where T : UserControl
		{
			//Creates a new UserControl from T. 
			UserControl control = (UserControl)Activator.CreateInstance(typeof(T), args ?? new object[] { });
			control.Dock = DockStyle.Fill;
			Content.Controls.Add(control);
			control.BringToFront();
		}

		public static IList<T> GetPage<T>(IList<T> list, int page, int pageSize)
		{
			return list.Skip(page * pageSize).Take(pageSize).ToList();
		}

		public static ComicSeries GetComicFromId(string id)
        {
			try
			{
				return MainScreen.UserData.ComicSeries.Where(comic => comic.ComicSeriesId == id).First();
			}
            catch
            {
				return null;
            }
        }
	}
}
