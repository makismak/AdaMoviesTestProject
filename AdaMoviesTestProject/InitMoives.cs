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
            string parameters = "";
            string message = "Eneter first 3 FilePath to get Data and after 1 file path to export infos.";
            bool check = true;
            FileManager fileManager = new FileManager();
            #endregion

            parameters = ParseFromTerminal(message);
            parameters.Split(' ').ToList().ForEach(x => parseArgumentList.Add(x));
            if (parseArgumentList.Count() != 4)
                InitParseArgument();
            else
            {
                fmmList = fileManager.FileManagerList(parseArgumentList);
                if (!CheckIfFileExits(fmmList))
                    InitParseArgument();
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
        private bool CheckIfFileExits(List<Model.FileManagerModel> fileLists)
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
