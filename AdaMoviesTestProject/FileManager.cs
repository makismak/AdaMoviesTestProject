using AdaMoviesTestProject.Interfaces;
using AdaMoviesTestProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaMoviesTestProject
{
    public class FileManager: IFileManager
    {
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
            throw new NotImplementedException();
        }
    }
}
