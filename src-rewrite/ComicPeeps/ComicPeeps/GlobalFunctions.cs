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
						//Thumbnail = await GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1),
						IssueNumber = i + 1
					};

					if (i == 0)
						comicIssue.Thumbnail = await ComicFunctions.GenerateCover(issues[i], comicSeries.ComicSeriesId, i + 1);

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
						Thumbnail = await ComicFunctions.GenerateCover(newFile, series.ComicSeriesId, series.Issues.Count + 1)
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
