using ComicPeeps.Models;
using ComicPeeps.UserControls.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicPeeps.UserControls
{
    public partial class Library : UserControl
    {
        public Library()
        {
            InitializeComponent();
        }

        public Task<bool> LoadComics()
        {
            //Control[] arrayForComics = new Control[MainScreen.UserData.ComicSeries.Count];
            //
            //for (int i = 0; i < arrayForComics.Length; i++)
            //{
            //    arrayForComics[i] = new ComicButton(MainScreen.UserData.ComicSeries[i], this);
            //}
            //
            //pnlComics.Controls.AddRange(arrayForComics);

            foreach (var comic in MainScreen.UserData.ComicSeries)
            {
                pnlComics.Controls.Add(new ComicButton(comic, this));
                Thread.Sleep(3000);
            }

            return Task.FromResult(true);
        }

        private async void Library_Load(object sender, EventArgs e)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            await LoadComics();

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds + "ms");

            GlobalFunctions.HideScrollBars(pnlComics);
        }
    }
}
