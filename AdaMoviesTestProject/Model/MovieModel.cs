using System;
using System.Collections.Generic;
using System.Text;

namespace AdaMoviesTestProject.Model
{
    public class MovieModel
    {
        public string MovieName { get; set; }
        public DateTime CurrentDate { get; set; }
        public int MovieTimeInMinutes { get; set; }
        public int MovieWatchedTime { get; set; }
        public string MovieCategory { get; set; }
    }
}
