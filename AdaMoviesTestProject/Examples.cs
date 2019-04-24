using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AdaMoviesTestProject.Interfaces;

namespace AdaMoviesTestProject
{
    public class Examples : IExamples
    {
        //order List Of all persons by Watching time desc 
        public List<MovieModel> Example1(List<MovieByFileModel> movieByFileModels)
        {
            List<MovieModel> movieModels = new List<MovieModel>();
            movieByFileModels.ForEach(x => x.AllMovieModel.ForEach(mvModel => movieModels.Add(new MovieModel
            {
                MovieName = mvModel.MovieName,
                CurrentDate = mvModel.CurrentDate,
                MovieCategory = mvModel.MovieCategory,
                MovieTimeInMinutes = mvModel.MovieTimeInMinutes,
                MovieWatchedTime = mvModel.MovieWatchedTime
            })));

            return movieModels.OrderByDescending(x => x.MovieWatchedTime).ToList();
        }
        public List<MoviesWithWatchingPercent> Example2(List<MovieByFileModel> movieByFileModels)
        {
            decimal AvgWatchedPercent;
            List<MoviesWithWatchingPercent> moviesWithWatchingPercents = new List<MoviesWithWatchingPercent>();

            foreach (MovieByFileModel mvByFile in movieByFileModels)
            {
                foreach (MovieModel mvModel in mvByFile.AllMovieModel)
                {
                    if (mvModel.MovieTimeInMinutes == 0)
                    {
                        Console.WriteLine("devide by 0 on this movie {0} for this Person {1}", mvModel.MovieName, mvByFile.FileName);
                        AvgWatchedPercent = 0;

                    }
                    else if ((mvModel.MovieTimeInMinutes - mvModel.MovieWatchedTime) < 0)
                    {
                        Console.WriteLine("movieTime - watched time is less than 0 on this movie {0} for this Person {1}", mvModel.MovieName, mvByFile.FileName);
                        AvgWatchedPercent = 0;
                    }
                    else
                    {
                        AvgWatchedPercent = (decimal)Math.Abs(mvModel.MovieTimeInMinutes - mvModel.MovieWatchedTime) / mvModel.MovieTimeInMinutes;
                        AvgWatchedPercent = 100 - (AvgWatchedPercent * 100);
                    }
                    moviesWithWatchingPercents.Add(new MoviesWithWatchingPercent
                    {
                        FileName = mvByFile.FileName,
                        MovieName = mvModel.MovieName,
                        WatchedPercent = Math.Round(AvgWatchedPercent, 2)
                    });


                }
            }
            return moviesWithWatchingPercents;
        }
        public string Example3(List<MovieByFileModel> movieByFileModels)
        {
            return "";
        }
        public string Example4(List<MovieByFileModel> movieByFileModels)
        { 
            return "";
        }

    }
}
