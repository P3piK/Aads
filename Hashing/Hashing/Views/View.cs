using Hashing.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing.Views
{
    public class View
    {
        public static void PrintFileNotFoundMessage()
        {
            Console.WriteLine("File not found.");
        }

        public static void PrintLinearSearchCount()
        {
            Console.WriteLine("Linear probing search count:");
            Console.WriteLine(LinearProbingController.searchCount);
        }

        public static void PrintDoubleSearchCount()
        {
            Console.WriteLine("Double hashing search count:");
            Console.WriteLine(DoubleHashingController.searchCount);
        }
    }
}
