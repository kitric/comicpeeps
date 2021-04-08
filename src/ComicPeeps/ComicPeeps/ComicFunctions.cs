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
			try
			{
				Directory.CreateDirectory(MainScreen.ThumbnailPath + "\\" + comicSeriesId);

				MainScreen.Logger.Log($"Generating cover for {comic}");

				if (comic.ToLower().EndsWith(".cbz"))
				{
					using (ZipArchive archive = ZipFile.OpenRead(comic))
					{
						int index = 0;

						bool thumbnailFound = false;

						var entry = archive.Entries[index];

						do
						{
							string extension = Path.GetExtension(entry.FullName).ToLower();
							if (SupportedFileTypes.ImageFileTypes.Contains(extension))
							{
								thumbnailFound = true;
								MainScreen.Logger.Log($"Generating cover for {comic} - Cover found. (File name: {entry.FullName})");
							}
							else
							{
								MainScreen.Logger.Log($"Generating cover for {comic} - Cover not found. Retrying... (File name: {entry.FullName})");
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
						MainScreen.Logger.Log($"Generating cover for {comic} - Cover extracted");

						using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
						{
							image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
							MainScreen.Logger.Log($"Generating cover for {comic} - Thumnail generated from cover");
						}

						File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

						MainScreen.Logger.Log($"Generating cover for {comic} - Complete");
						GlobalFunctions.SaveLogsAndClear();

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
							string extension = Path.GetExtension(entry.Key).ToLower();
							if (SupportedFileTypes.ImageFileTypes.Contains(extension))
							{
								thumbnailFound = true;
								MainScreen.Logger.Log($"Generating cover for {comic} - Cover found. (File name: {entry.Key})");
							}
							else
							{
								MainScreen.Logger.Log($"Generating cover for {comic} - Cover not found. Retrying... (File name: {entry.Key})");
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
						MainScreen.Logger.Log($"Generating cover for {comic} - Cover extracted");

						using (var image = await GlobalFunctions.CompressImage(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName, 15))
						{
							image.Save(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
							MainScreen.Logger.Log($"Generating cover for {comic} - Thumnail generated from cover");
						}

						File.Delete(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + fileName);

						MainScreen.Logger.Log($"Generating cover for {comic} - Complete");
						GlobalFunctions.SaveLogsAndClear();

						return await Task.FromResult(MainScreen.ThumbnailPath + "\\" + comicSeriesId + "\\" + comicSeriesId + "-" + comicNumber);
					}
				}

				MainScreen.Logger.Log($"Generating cover for {comic} [NO COVER FOUND]");
				GlobalFunctions.SaveLogsAndClear();

				return await Task.FromResult("");
			}
			catch (Exception e)
            {
				MessageBox.Show($"There was an error generating comic cover... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

				return await Task.FromResult("");
			}
		}

		/// <summary>
		/// Must call `Directory.Delete(MainScreen.ComicInfoPath + "\\" + issue.SeriesId);` after this
		/// </summary>
		/// <param name="issue"></param>
		/// <returns></returns>
		public static ComicInfo GetComicInfo(ComicIssue issue)
		{
			string dir = Directory.CreateDirectory(MainScreen.ComicInfoPath + "\\" + issue.SeriesId + "\\" + issue.IssueId).FullName;

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
					catch (Exception e)
					{
						MainScreen.Logger.Log("Error getting comic info, ComicInfo.xml probably does not exist. Message: " + e.Message);
						GlobalFunctions.SaveLogsAndClear();
					}
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
					catch (Exception e)
					{
						MainScreen.Logger.Log("Error getting comic info, ComicInfo.xml probably does not exist. Message: " + e.Message);
						GlobalFunctions.SaveLogsAndClear();
					}
				}
			}

			return new ComicInfo()
			{
				Summary = "This comic does not have a summary"
			};
		}

		public static ComicInfo DesrializeComicInfo(string filePath)
		{
			try
			{
				using (Stream S = new FileStream(filePath, FileMode.Open, FileAccess.Read))
				{
					XmlSerializer xmlSer = new XmlSerializer(typeof(ComicInfo));

					return (ComicInfo)xmlSer.Deserialize(S);
				}
			}
			catch (Exception e)
            {
				MessageBox.Show($"There was an error retrieving comic info... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

				return new ComicInfo()
				{
					Summary = "This comic does not have a summary"
				};
			}
		}

		// Read the ComicIssue and return the images
		public static Task<string[]> ReadComic(ComicIssue issue)
		{
			try
			{
				string dir = Directory.CreateDirectory(MainScreen.ComicExtractLocation + "\\" + issue.SeriesId + "\\" + issue.IssueId).FullName;

				MainScreen.Logger.Log($"Reading comic issue {issue.ComicName} {issue.IssueNumber}");

				if (issue.Location.ToLower().EndsWith(".cbz"))
				{
					using (ZipArchive archive = ZipFile.OpenRead(issue.Location))
					{
						archive.ExtractToDirectory(dir);

						MainScreen.Logger.Log($"Reading comic issue {issue.ComicName} {issue.IssueNumber} - Comic extracted");

						var result = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(s => SupportedFileTypes.ImageFileTypes.Contains(Path.GetExtension(s).ToLower())).ToArray();
						Array.Sort(result);

						MainScreen.Logger.Log($"Reading comic issue {issue.ComicName} {issue.IssueNumber} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						return Task.FromResult(result);
					}
				}
				else if (issue.Location.ToLower().EndsWith(".cbr"))
				{
					using (RarArchive archive = RarArchive.Open(issue.Location))
					{
						archive.WriteToDirectory(dir);

						MainScreen.Logger.Log($"Reading comic issue {issue.ComicName} {issue.IssueNumber} - Comic extracted");

						var result = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories).Where(s => SupportedFileTypes.ImageFileTypes.Contains(Path.GetExtension(s).ToLower())).ToArray();
						Array.Sort(result);

						MainScreen.Logger.Log($"Reading comic issue {issue.ComicName} {issue.IssueNumber} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						return Task.FromResult(result);
					}
				}

				return Task.FromResult(new string[0]);
			}
			catch (Exception e)
            {
				MessageBox.Show($"There was an error opening comic... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

				return Task.FromResult(new string[0]);
			}
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

				var issues = Directory.EnumerateFiles(comicSeries.FolderPath, "*.*", SearchOption.AllDirectories).Where(s => SupportedFileTypes.ComicFileTypes.Contains(Path.GetExtension(s).ToLower())).ToArray();
				MainScreen.Logger.Log($"Adding comic issues: Found {issues.Length} issues");

				Array.Sort(issues);

				for (int i = 0; i < issues.Length; i++)
				{
					ComicIssue comicIssue = new ComicIssue()
					{
						ComicName = comicSeries.ComicName,
						SeriesId = comicSeries.ComicSeriesId,
						Location = issues[i],
						IssueNumber = i + 1,
					};
					comicIssue.IssueId += $"-{comicIssue.IssueNumber}";

					if (i == 0)
						comicIssue.Thumbnail = await ComicFunctions.GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1);

					comicSeries.Issues.Add(comicIssue);

					MainScreen.Logger.Log($"Adding comic, issue added: IssueNumber = {comicIssue.IssueNumber}, Id = {comicIssue.IssueId}, Location = {comicIssue.Location}");
				}

				return await Task.FromResult(true);
			}
			catch (Exception e)
			{
				MessageBox.Show($"There was an error adding comic... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

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
			try
			{
				// Delete all ComicInfo for the comic
				// MainScreen.ComicInfoPath + "\\" + seriesID
				if (Directory.Exists(MainScreen.ComicInfoPath + "\\" + series.ComicSeriesId))
					Directory.Delete(MainScreen.ComicInfoPath + "\\" + series.ComicSeriesId, true);

				if (Directory.Exists(series.FolderPath))
				{
					var files = Directory.EnumerateFiles(series.FolderPath, "*.*", SearchOption.AllDirectories)
								.Where(s => SupportedFileTypes.ComicFileTypes.Contains(Path.GetExtension(s).ToLower()))
								.ToArray();

					MainScreen.Logger.Log($"Updating comic {series.ComicName} - Collecting files");

					Array.Sort(files);

					// There a new comics
					if (files.Length > series.Issues.Count)
					{
						MainScreen.Logger.Log($"Updating comic {series.ComicName} - More files found than original");
						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Updating existing comics");

						// Update the existing comics.
						for (int i = 0; i < series.Issues.Count; i++)
						{
							series.Issues[i].Location = files[i];
							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Issue {series.Issues[i].IssueNumber} : {series.Issues[i].Location}");
							series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
						}

						// Add any new comics
						for (int i = series.Issues.Count; i < files.Length; i++)
						{
							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Adding new issues");

							ComicIssue issue = new ComicIssue()
							{
								Location = files[i],
								ComicName = series.ComicName,
								IssueNumber = series.Issues.Count + 1,
								Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1)
							};
							issue.IssueId += $"-{issue.IssueNumber}";

							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Location = {files[i]}, Issue = {issue.IssueNumber}, Id = {issue.IssueId}");

							series.Issues.Add(issue);
						}

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Cleaning up issues");
						UpdateIssues(series);

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						return true;
					}
					else if (files.Length < series.Issues.Count)
					{
						// There are less comics

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Less files found than original");
						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Updating existing comics");

						// Update the existing comics
						for (int i = 0; i < files.Length; i++)
						{
							series.Issues[i].Location = files[i];
							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Issue {series.Issues[i].IssueNumber} : {series.Issues[i].Location}");
							series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
						}

						// Remove the rest of the issues
						for (int i = files.Length; i < series.Issues.Count; i++)
						{
							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Removing issue {series.Issues[i].IssueNumber} with the ex-location of {series.Issues[i].Location}");
							series.Issues.Remove(series.Issues[i]);
						}

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Cleaning up issues");
						UpdateIssues(series);

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						return true;
					}
					else
					{
						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Same amount of files found");

						// Equal amount. Just update them
						for (int i = 0; i < series.Issues.Count; i++)
						{
							series.Issues[i].Location = files[i];
							MainScreen.Logger.Log($"Updating comic {series.ComicName} - Issue {series.Issues[i].IssueNumber} : {series.Issues[i].Location}");
							series.Issues[i].Thumbnail = await GenerateCover(files[i], series.ComicSeriesId, i + 1);
						}

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Cleaning up issues");
						UpdateIssues(series);

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						return true;
					}
				}
				else
				{
					MainScreen.Logger.Log($"Updating comic {series.ComicName} - Comic no longer exists.");

					if (MessageBox.Show("This directory no longer exists. Do you want to remove the comic from your directory?", "Directory not found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
					{
						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Removing comic");

						MainScreen.Logger.Log($"Updating comic {series.ComicName} - Complete");
						MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
						MainScreen.Logger.ClearLogs();

						// Delete the comic
						MainScreen.UserData.ComicSeries.Remove(series);

						return false;
					}

					MainScreen.Logger.Log($"Updating comic {series.ComicName} - Complete");
					MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
					MainScreen.Logger.ClearLogs();

					return true;
				}
			}
			catch (Exception e)
            {
				MessageBox.Show($"There was an error updating comic... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

				return false;
			}
		}

		public static ComicSeries GetComicFromId(string id)
		{
			try
			{
				return MainScreen.UserData.ComicSeries.Where(comic => comic.ComicSeriesId == id).First();
			}
			catch (Exception e)
			{
				MainScreen.Logger.Log(e.Message);
				GlobalFunctions.SaveLogsAndClear();

				return null;
			}
		}
	}
}
