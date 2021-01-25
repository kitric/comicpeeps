using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPeeps.Models
{
    [Serializable]
    public class ComicIssue
    {
        public string ComicName { get; set; } = "";

        public string Location { get; set; } = "";

        public string Thumbnail { get; set; } = "";

        public int CurrentPage { get; set; } = 1;

        public int Pages { get; set; } = 0;

        public int IssueNumber { get; set; }
    }
}
