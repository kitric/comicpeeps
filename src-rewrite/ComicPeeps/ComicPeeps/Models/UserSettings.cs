using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicPeeps.Models
{
    [Serializable]
    public class UserSettings
    {
        public bool UseAutoRead { get; set; } = false;

        public int AutoReadSpeed { get; set; } = 40;

        public bool SaveLastPage { get; set; } = true;

        public int CompressSize { get; set; } = 2;
    }
}
