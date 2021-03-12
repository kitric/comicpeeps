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
using System.Windows.Forms;
using System.Xml.Serialization;

namespace ComicPeeps
{
    public static class ComicFunctions
    {
		public static async Task<string> GenerateCover(string comic, string comicSeriesId, int comicNumber)
        {
			Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicSeriesId);

			if (comic.ToLower().EndsWith(".cbz"))
            {
				using (ZipArchive archive = ZipFile.OpenRead(comic))
                {
					int index = 0;

					bool thumbnailFound = false;

					var entry = archive.Entries[index];

					do
					{
						if (entry.FullName.EndsWith("jpg") || entry.FullName.EndsWith(".png"))
						{
							thumbnailFound = true;
						}
						else
						{
							index++;
							entry = archive.Entries[index];
						}
					}
					while (!thumbnailFound);

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
			}
			else if (comic.ToLower().EndsWith(".cbr"))
            {
				using (RarArchive archive = RarArchive.Open(comic))
                {
					List<RarArchiveEntry> entries = archive.Entries.OrderBy(e => e.Key).Where(e => !e.IsDirectory).ToList();

					int index = 0;

					bool thumbnailFound = false;

					var entry = entries[index];

					do
					{
						if (entry.Key.EndsWith("jpg") || entry.Key.EndsWith(".png"))
						{
							thumbnailFound = true;
						}
						else
						{
							index++;
							entry = entries[index];
						}
					}
					while (!thumbnailFound);

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
				MainScreen.Logger.Log($"Adding comic issues: Found {issues.Length} issues");

				Array.Sort(issues);

				for (int i = 0; i < issues.Length; i++)
				{
					ComicIssue comicIssue = new ComicIssue()
					{
						ComicName = comicSeries.ComicName,
						SeriesId = comicSeries.ComicSeriesId,
						Location = issues[i],
						//Thumbnail = await GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1),
						IssueNumber = i + 1
					};

					if (i == 0)
						comicIssue.Thumbnail = await ComicFunctions.GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1);

					comicSeries.Issues.Add(comicIssue);

					MainScreen.Logger.Log($"Adding comic, issue added: IssueNumber = {comicIssue.IssueNumber}, Id = {comicIssue.IssueId}, Location = {comicIssue.Location}");
				}

				return await Task.FromResult(true);
			}
			catch (Exception e)
			{
				Console.WriteLine($"There was an error: {e.Message}");

				return await Task.FromResult(false);
			}
		}

		/// <summary>
		/// Updates the issue numbering
		/// </summary>
		/// <param name="series"></param>
		public static void UpdateIssues(ComicSeries series)
		{
			for (int i = 0; i < series.Issues.Count; i++)
			{
				series.Issues[i].IssueNumber = i + 1;
			}
		}

		/// <summary>
		/// Updates a comic, especially its issues
		/// </summary>
		/// <param name="series"></param>
		/// <returns></returns>
		public static async Task<bool> UpdateComic(ComicSeries series)
		{
			if (Directory.Exists(series.FolderPath))
			{
				var files = Directory.EnumerateFiles(series.FolderPath, "*.*", SearchOption.AllDirectories)
							.Where(s => s.ToLower().EndsWith(".cbr") || s.ToLower().EndsWith(".cbz"))
							.ToArray();

				Array.Sort(files);

				// There a new comics
				if (files.Length > series.Issues.Count)
				{
					// Update the existing comics.
					for (int i = 0; i < series.Issues.Count; i++)
					{
						series.Issues[i].Location = files[i];
						series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
					}

					// Add any new comics
					for (int i = series.Issues.Count; i < files.Length; i++)
					{
						ComicIssue issue = new ComicIssue()
						{
							Location = files[i],
							ComicName = series.ComicName,
							IssueNumber = series.Issues.Count + 1,
							Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1)
						};

						series.Issues.Add(issue);
					}

					UpdateIssues(series);

					return true;
				}
				else if (files.Length < series.Issues.Count)
				{
					// There are less comics

					// Update the existing comics
					for (int i = 0; i < files.Length; i++)
					{
						series.Issues[i].Location = files[i];
						series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
					}

					// Remove the rest of the issues
					for (int i = files.Length; i < series.Issues.Count; i++)
					{
						series.Issues.Remove(series.Issues[i]);
					}

					UpdateIssues(series);

					return true;
				}
				else
				{
					// Equal amount. Just update them
					for (int i = 0; i < series.Issues.Count; i++)
					{
						series.Issues[i].Location = files[i];
						series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
					}

					UpdateIssues(series);

					return true;
				}
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
