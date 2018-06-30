using GraphAlgorithms.Controllers;
using GraphAlgorithms.Helpers;
using GraphAlgorithms.Models;
using System;

namespace GraphAlgorithms
{
    class Program
    {
        public const string FLOYD_FILE = "floyd.txt";

        static void Main(string[] args)
        {
            FloydModel floydModel = new FloydModel(FLOYD_FILE);
            FloydController floydController = new FloydController(floydModel);
            floydController.PerformFloyd();

        }

    }
}
