using AdaMoviesTestProject.Interfaces;
using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdaMoviesTestProject
{
    public class InitMoives : IInitMoives
    {
        public void InitParseArgument()
        {
            #region Arguments
            List<string> parseArgumentList = new List<string>();
            List<FileManagerModel> fmmList = new List<FileManagerModel>();
            List<MovieByFileModel> movieByFileModels = new List<MovieByFileModel>();
            List<MovieModel> movieModels = new List<MovieModel>();
            FileManager fileManager = new FileManager();
            Examples examples = new Examples();
            string parameters = "";
            string message = "Eneter first 3 FilePath to get Data and after 1 file path to export infos.";
            string writePath;
            bool check = true;
            #endregion

            parameters = ParseFromTerminal(message);

            parameters.Split(' ').ToList().ForEach(x => parseArgumentList.Add(x));
            if (parseArgumentList.Count() != 4)
                InitParseArgument();
            else
            {
                fmmList = fileManager.FileManagerList(parseArgumentList);
                try
                {
                    if (!CheckIfFileExits(fmmList))
                    {
                        throw new Exception(message: "ProblemWithData");
                    }


                    movieByFileModels = fileManager.ReadedFile(fmmList);
                    writePath = fmmList.Where(x => x.IsRead == 0).FirstOrDefault().FilePath;
                    // this need to run every time where i need to write somehting o file 
                    fileManager.WriteOnFileExample1(writePath, examples.Example1(movieByFileModels));
                    List<MoviesWithWatchingPercent> moviesWithWatchingPercents = new List<MoviesWithWatchingPercent>();
                    moviesWithWatchingPercents = examples.Example2(movieByFileModels);
                    fileManager.WriteOnFileExample2(writePath, moviesWithWatchingPercents, 2);
                    fileManager.WriteOnFileExample2(writePath, moviesWithWatchingPercents.Where(x => x.WatchedPercent > 60).OrderBy(y => y.FileName).ThenBy(y => y.Genre).ToList(), 3);
                    moviesWithWatchingPercents = examples.Example2(movieByFileModels);
                    fileManager.WriteOnFileExample4(writePath, examples.Example4(moviesWithWatchingPercents));
                    fileManager.WriteOnFileExample5(writePath, examples.Example5(moviesWithWatchingPercents));

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    InitParseArgument();
                }
               
            }

        }

        private string ParseFromTerminal(string message)
        {
            string getParameter;
            Console.WriteLine(message);
            getParameter = Console.ReadLine();

            if (String.IsNullOrEmpty(getParameter))
                ParseFromTerminal("need to add 4 parameters");
            return getParameter;
        }

        private bool CheckIfFileExits(List<FileManagerModel> fileLists)
        {
            bool correct = true;
            for (int i = 0; i < fileLists.Count; i++)
            {
                if (!File.Exists(fileLists[i].FilePath) && fileLists[i].IsRead == 1)
                {
                    Console.WriteLine("File With Name :{0}  and FilePath : {1} dose not exits in this path please provide correct file paths", fileLists[i].FileName, fileLists[i].FilePath);
                    correct = false;
                }
                else if (!Directory.Exists(Directory.GetParent(fileLists[i].FilePath).ToString()) && fileLists[i].IsRead == 0)
                {
                    Console.WriteLine("File  FilePath : {0} dose not exits in this directory please provide correct file directiry", fileLists[i].FilePath);
                    correct = false;
                }
            }
            return correct;
        }
    }
}
