using ComicPeeps.Models;
using SharpCompress.Archives;
using SharpCompress.Archives.Rar;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComicPeeps
{
    public class ComicFunctions
    {
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

							using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
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

							using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
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

							using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
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

							using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
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
	}
}
