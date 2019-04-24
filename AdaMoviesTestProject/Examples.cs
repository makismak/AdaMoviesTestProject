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
                        WatchedPercent = Math.Round(AvgWatchedPercent, 2),
                        Genre = mvModel.MovieCategory
                    });


                }
            }
            return moviesWithWatchingPercents;
        }
        public List<GenreAndAvgTimeModel> Example4(List<MoviesWithWatchingPercent> moviesWithWatchingPercents)
        {
            List<GenreAndAvgTimeModel> genreAndAvgTimes = new List<GenreAndAvgTimeModel>();
            
            moviesWithWatchingPercents.GroupBy(x => x.Genre).Select(g => new { g.Key, MaxWatcedDate = g.Average(cm => cm.WatchedPercent) }).ToList().OrderByDescending(y=>y.MaxWatcedDate).Take(2).ToList().ForEach(x=> genreAndAvgTimes.Add(new GenreAndAvgTimeModel { Genre = x.Key,MaxWatcedDate = x.MaxWatcedDate}));
            
            return genreAndAvgTimes;
        }

        public string Example5(List<MoviesWithWatchingPercent> moviesWithWatchingPercents)
        {
            return moviesWithWatchingPercents.GroupBy(x => x.MovieName).Select(y => new { y.Key, countWatchedPersons = y.Count(), MaxWatcedDate = y.Average(cm => cm.WatchedPercent)}).OrderByDescending(z => z.countWatchedPersons).ThenByDescending(z=>z.MaxWatcedDate).ToList().FirstOrDefault().Key.ToString();
        }

    }

}
