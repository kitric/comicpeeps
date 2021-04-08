using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPeeps.Models
{
    [Serializable]
    public class ComicSeries
    {
        public string FolderPath { get; set; } = "";

        public List<ComicIssue> Issues { get; set; } = new List<ComicIssue>();

        public string Thumbnail { get; set; } = "";

        public string ComicName { get; set; } = "";

        public string ComicSeriesId { get; set; } = "";

        public ComicSeries()
        {
            ComicSeriesId = $"comic{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Millisecond}";
        }
    }
}
