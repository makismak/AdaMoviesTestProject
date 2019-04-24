using System;

namespace AdaMoviesTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            InitMoives MvClass = new InitMoives();
            MvClass.InitParseArgument();
            Console.ReadKey();
        }
    }
}
