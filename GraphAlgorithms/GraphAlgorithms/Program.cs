using GraphAlgorithms.Controllers;
using GraphAlgorithms.Helpers;
using System;

namespace GraphAlgorithms
{
    class Program
    {
        public const string FLOYD_FILE = "floyd.txt";

        static void Main(string[] args)
        {
            FloydController floydController = new FloydController(FLOYD_FILE);
            floydController.PerformFloyd();

        }

    }
}
