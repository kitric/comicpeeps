using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicsReader
{
    [Serializable]
    public class History
    {
        private List<OpenedComic> OpenedComics = new List<OpenedComic>();
        private List<string> OpenedComicLocations = new List<string>();

        public void AddComic(OpenedComic comic)
        {
            OpenedComics.Add(comic);
            OpenedComicLocations.Add(comic.ComicLocation);
        }

        public bool Contains(string location)
        {
            return OpenedComicLocations.Contains(location);
        }

        public OpenedComic GetComic(string location)
        {
            for (int i = 0; i < OpenedComicLocations.Count; i++)
            {
                if (OpenedComicLocations[i] == location)
                {
                    return OpenedComics[i];
                }
            }
            return null;
        }

        public void ClearHistory()
        {
            OpenedComicLocations.Clear();
            OpenedComics.Clear();
        }
    }
}
