using AdaMoviesTestProject.Interfaces;
using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdaMoviesTestProject
{
    public class FileManager : IFileManager
    {
        //C:\Users\Ajesivano\Documents\temp\file1.txt C:\Users\Ajesivano\Documents\temp\file2.txt C:\Users\Ajesivano\Documents\temp\file3.txt C:\Users\Ajesivano\Documents\temp\file4.txt
        public List<FileManagerModel> FileManagerList(List<string> filePaths)
        {
            List<FileManagerModel> fmmList = new List<FileManagerModel>();
            for (int i = 0; i < filePaths.Count(); i++)
            {
                fmmList.Add(i != 3 ? new FileManagerModel { IsRead = 1, FileName = (filePaths[i].Split('\\').Last().ToString()), FilePath = filePaths[i] } : new FileManagerModel { IsRead = 0, FileName = filePaths[i].Split('\\').Last(), FilePath = filePaths[i] });
            }

            return fmmList;
        }
        public List<MovieByFileModel> ReadedFile(List<FileManagerModel> fmmList)
        {
            List<string[]> moviesByFileList;
            List<MovieModel> movieModelList;
            List<MovieByFileModel> movieByFileModelLsit = new List<MovieByFileModel>();
            string line;
            string regexData = "^(\\d+)/(\\d+)/(\\d+) (.*) (\\d+)min (\\d+)min (\\S+)$";
            for (int i = 0; i < fmmList.Count - 1; i++)
            {
                StreamReader file = new StreamReader(fmmList[i].FilePath);

                movieModelList = new List<MovieModel>();
                moviesByFileList = new List<string[]>();
                while ((line = file.ReadLine()) != null)
                {
                    moviesByFileList.Add(Regex.Split(line, regexData));
                }
                foreach (string[] item in moviesByFileList)
                {
                    movieModelList.Add(new MovieModel
                    {
                        MovieName = item[4],
                        CurrentDate = DateTime.Parse(item[3] + "-" + item[1] + "-" + item[2]),
                        MovieTimeInMinutes = Int32.Parse(item[5]),
                        MovieWatchedTime = Int32.Parse(item[6]),
                        MovieCategory = item[7]
                    });
                }
                file.Close();
                movieByFileModelLsit.Add(new MovieByFileModel { FileName = fmmList[i].FileName, AllMovieModel = movieModelList });


            }

            return movieByFileModelLsit;
        }

        public void WriteOnFileExample1(string filePath, List<MovieModel> movieModels)
        {
            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath))
            {
                sw.WriteLine("---------------------------- Example1 -----------------------");
                foreach (MovieModel item in movieModels)
                {
                    sw.WriteLine(item.CurrentDate.Date + " " + item.MovieName + " " + item.MovieTimeInMinutes + " " + item.MovieWatchedTime + " " + item.MovieCategory + "");
                }

            }
        }
        public void WriteOnFileExample2(string filePath, List<MoviesWithWatchingPercent> moviesWithWatchingPercents, int exampleNumber)
        {
            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath))
            {
                string personName = null;
                sw.WriteLine("---------------------------- Example{0} -----------------------", exampleNumber);
                foreach (MoviesWithWatchingPercent item in moviesWithWatchingPercents)
                {
                    if (String.IsNullOrEmpty(personName) || personName != item.FileName)
                    {
                        personName = item.FileName;
                        sw.WriteLine("---------------------------- Person Name : {0} -----------------------", item.FileName);
                    }
                    if (exampleNumber == 2)
                    {
                        sw.WriteLine("MovieName: {0} AverageWathedTime: {1}%", item.MovieName, item.WatchedPercent);
                    }
                    else
                    {
                        sw.WriteLine("MovieName: {0} AverageWathedTime: {1}% Genre: {2}", item.MovieName, item.WatchedPercent, item.Genre);
                    }
                    

                }

            }
        }
        public void WriteOnFileExample4(string filePath, List<GenreAndAvgTimeModel> genreAndAvgTimes)
        {
            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath))
            {
                sw.WriteLine("---------------------------- Example4 -----------------------");
                for(int i=0; i< genreAndAvgTimes.Count; i++)
                {
                    sw.WriteLine("-------------------------- {0} Most PopularCategory : {1} by Avg Watched Time {2}-----------------------" , i, genreAndAvgTimes[i].Genre, genreAndAvgTimes[i].MaxWatcedDate);

                }

            }
        }

        public void WriteOnFileExample5(string filePath, string bestRecomendedMovie)
        {
            using (StreamWriter sw = (File.Exists(filePath)) ? File.AppendText(filePath) : File.CreateText(filePath))
            {
                
                sw.WriteLine("---------------------------- Example5 -----------------------");
                sw.WriteLine("-------------------------- Best recomended Movie is {0} -----------------------", bestRecomendedMovie);


            }
        }
    }
}
