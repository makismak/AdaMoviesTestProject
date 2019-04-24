using System;

namespace AdaMoviesTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            InitMovies MvClass = new InitMovies();
            MvClass.InitParseArgument();
            Console.WriteLine("DONE");
            Console.ReadKey();
        }
    }
}

