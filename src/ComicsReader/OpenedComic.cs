using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicsReader
{
    [Serializable]
    public class OpenedComic
    {
        public int PageNumber { get; set; } = 0;

        public string ComicLocation { get; set; }

        public string ComicName { get; set; }
    }
}
