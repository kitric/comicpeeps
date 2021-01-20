using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPeeps.Models
{
    public class ComicSeries
    {
        public string FolderPath { get; set; } = "";

        public List<string> Issues { get; set; } = new List<string>();

        public string Thumbnail { get; set; } = "";
    }
}
