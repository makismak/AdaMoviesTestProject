using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdaMoviesTestProject
{
    public class InitMoives
    {
        public void InitParseArgument()
        {
            #region Arguments
            List<string> parseArgumentList = new List<string>();
            string parameters = "";
            string message = "Eneter first 3 FilePath to get Data and after 1 file path to export infos.";
            bool check = true;
            #endregion

            parameters = ParseFromTerminal(message);
            parameters.Split(' ').ToList().ForEach(x => parseArgumentList.Add(x));
            if (parseArgumentList.Count() != 4)
                InitParseArgument();
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
    }
}
