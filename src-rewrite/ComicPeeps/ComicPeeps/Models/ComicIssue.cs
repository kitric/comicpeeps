using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComicPeeps.Models
{
    [Serializable]
    public class ComicIssue
    {
        [NonSerialized] [XmlIgnore]
        public EventHandler OnCompleted;

        public string ComicName { get; set; } = "";

        public string SeriesId { get; set; } = "";

        public string Location { get; set; } = "";

        public string Thumbnail { get; set; } = "";

        public int CurrentPage { get; set; } = 1;

        public int Pages { get; set; } = 0;

        public int IssueNumber { get; set; } = 0;

        private bool completed { get; set; } = false;

        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                // Invoke event handler
                completed = value;
                if (OnCompleted != null)
                {
                    OnCompleted.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public string IssueId { get; set; } = "";

        public ComicIssue()
        {
            IssueId = $"issue{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Millisecond}";
        }
    }
}
