using System;
using System.Collections.Generic;
using System.Text;

namespace AdaMoviesTestProject.Model
{
    public class MovieByFileModel
    {
        public string FileName { get; set; }
        public virtual List<MovieModel> AllMovieModel { get; set; }
    }
}
