using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sublime.Models
{
    public class PodModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime publishdateutc { get; set; }
        public string duration { get; set; }
        public string url { get; set; }
        public int programID { get; set; }

        public PodModel()
        {
            if (!string.IsNullOrEmpty(duration))
            {
                double doubleDuration = Double.Parse(duration);
                TimeSpan time = TimeSpan.FromSeconds(doubleDuration);
                duration = time.ToString();
            }
        }
    }
}
