using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdaMoviesTestProject.Interfaces
{
    interface IFileManager
    {
        List<FileManagerModel> FileManagerList(List<string> filePaths);
        List<MovieByFileModel> ReadedFile(List<FileManagerModel> fmmList);
        void WriteOnFileExample1(string filePath, List<MovieModel> movieModels);
        void WriteOnFileExample2(string filePath, List<MoviesWithWatchingPercent> moviesWithWatchingPercents, int exampleNumber);
        void WriteOnFileExample4(string filePath, List<GenreAndAvgTimeModel> genreAndAvgTimes);
        void WriteOnFileExample5(string filePath, string bestRecomendedMovie);
    }
}
