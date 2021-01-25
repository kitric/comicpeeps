using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPeeps.Models
{

    [Serializable]
    public class UserData
    {
        public List<ComicSeries> ComicSeries { get; set; } = new List<ComicSeries>();
    }
}
