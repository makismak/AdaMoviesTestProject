using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaMoviesTestProject.Interfaces
{
    interface IExamples
    {
        List<MovieModel> Example1(List<MovieByFileModel> movieByFileModels);
        List<MoviesWithWatchingPercent> Example2(List<MovieByFileModel> movieByFileModels);
        List<GenreAndAvgTimeModel> Example4(List<MoviesWithWatchingPercent> moviesWithWatchingPercents);
        string Example5(List<MoviesWithWatchingPercent> moviesWithWatchingPercents);
    }
}
