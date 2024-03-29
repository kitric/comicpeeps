﻿using ComicPeeps.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ComicPeeps.UserControls
{
    public partial class AddComic : UserControl
    {
        public AddComic()
        {
            InitializeComponent();

            ToolTip toolTip = new ToolTip
            {
                OwnerDraw = true
            };

            toolTip.Draw += (s, e) =>
            {
                e.DrawBackground();
                e.DrawBorder();
                e.DrawText();
            };

            toolTip.BackColor = Color.FromArgb(5, 5, 5);
            toolTip.ForeColor = Color.White;
            toolTip.SetToolTip(pnlAddIndividualComic, "Add one comic series to your library.");
            toolTip.SetToolTip(label1, "Add one comic series to your library.");
            toolTip.SetToolTip(pnlAddComicDirectory, "Add a whole directory of comics to your library. Will take a while, depending on how many comics you have.");
            toolTip.SetToolTip(label2, "Add a whole directory of comics to your library. This will take a while, depending on how many comics you have.");
        }

        private async void AddComic_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pnlAddComicDirectory.Visible = false;
                    pnlAddIndividualComic.Visible = false;
                    lblAddingComics.Visible = true;

                    await AddIndividualComic(fbd.SelectedPath);

                    GlobalFunctions.SwitchTo<Library>(MainScreen.Instance.pnlContent, "Library");
                }
            }
        }

        private async void pnlAddComicDirectory_DoubleClick(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] comics = Directory.EnumerateDirectories(fbd.SelectedPath).ToArray();

                    if (comics.Length != 0)
                    {
                        pnlAddComicDirectory.Visible = false;
                        pnlAddIndividualComic.Visible = false;
                        lblAddingComics.Visible = true;

                        if (MessageBox.Show($"{comics.Length} directories found. Are you sure you want to add them all? This may take a while...", $"{comics.Length} comics found", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            foreach (var comic in comics)
                            {
                                await AddIndividualComic(comic);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"No Comic Series found in this directory: {fbd.SelectedPath}");
                    }
                    
                    GlobalFunctions.SwitchTo<Library>(MainScreen.Instance.pnlContent, "Library");
                }
            }
        }

        private async Task<bool> AddIndividualComic(string selectedPath)
        {
            try
            {
                MainScreen.Logger.Log($"Adding comic from path: {selectedPath}");

                var existingComics = MainScreen.UserData.ComicSeries.Where(serie => serie.FolderPath == selectedPath).ToList();

                if (existingComics.Count == 0)
                {
                    ComicSeries comicSeries = new ComicSeries()
                    {
                        FolderPath = selectedPath,
                        ComicName = Path.GetFileName(selectedPath),
                        Thumbnail = ""
                    };

                    MainScreen.Logger.Log($"Comic tagged: Folder Location = {selectedPath}, ComicName = {comicSeries.ComicName}, Id = {comicSeries.ComicSeriesId}");

                    await ComicFunctions.AddComicIssues(comicSeries);

                    if (comicSeries.Issues.Count != 0)
                    {
                        comicSeries.Thumbnail = comicSeries.Issues[0].Thumbnail;
                    }

                    MainScreen.UserData.ComicSeries.Add(comicSeries);

                    MainScreen.Logger.Log($"Adding comic: Finish");

                    MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
                    MainScreen.Logger.ClearLogs();

                    return await Task.FromResult(true);
                }
                else
                {
                    MessageBox.Show("That comic already exists in your library.");
                    MainScreen.Logger.Log($"Comic already in library: {selectedPath}");
                    MainScreen.Logger.SaveLogs(MainScreen.LogFile, true);
                    MainScreen.Logger.ClearLogs();
                    return await Task.FromResult(false);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"There was an error adding comic series... Please see logs for more details: {MainScreen.LogFile}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MainScreen.Logger.Log(e.Message);
                GlobalFunctions.SaveLogsAndClear();

                return await Task.FromResult(false);
            }
        }
    }
}
