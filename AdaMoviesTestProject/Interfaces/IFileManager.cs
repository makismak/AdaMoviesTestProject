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
    }
}
