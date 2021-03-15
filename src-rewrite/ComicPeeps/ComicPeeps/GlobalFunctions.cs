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
            catch (Exception e)
            {
				MessageBox.Show($"There was an error loading an image... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				SaveLogsAndClear();

				return null;
			}
		}

		public static async Task<Bitmap> CompressImage(Image image, int CompressSize)
		{
			try
			{
				Bitmap bmp = new Bitmap(image.Width / CompressSize, image.Height / CompressSize);
				Stopwatch watch = new Stopwatch();
				watch.Start();
				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height));
				}

				return await Task.FromResult(bmp);
			}
			catch (Exception e)
			{
				MessageBox.Show($"There was an error loading an image... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				SaveLogsAndClear();

				return null;
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
			catch (Exception e)
            {
				MessageBox.Show($"There was an error loading an image... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				MainScreen.Logger.Log(e.Message);
				SaveLogsAndClear();

				return null;
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

		public static void SaveLogsAndClear()
        {
			MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
			MainScreen.Logger.ClearLogs();
		}
	}
}
