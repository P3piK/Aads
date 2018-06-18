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

        public static void PrintAllResults()
        {
            PrintLinearInsertCount();
            PrintDoubleInsertCount();
            PrintLinearSearchCount();
            PrintLinearSearchMissCount();
            PrintDoubleSearchCount();
            PrintDoubleSearchMissCount();
        }

        private static void PrintLinearInsertCount()
        {
            Console.WriteLine("Linear probing insert count:");
            Console.WriteLine(LinearProbingController.insertCount);
        }

        private static void PrintDoubleInsertCount()
        {
            Console.WriteLine("Double hashing insert count:");
            Console.WriteLine(DoubleHashingController.insertCount);
        }

        private static void PrintLinearSearchCount()
        {
            Console.WriteLine("Linear probing search count:");
            Console.WriteLine(LinearProbingController.searchCount);
        }

        private static void PrintLinearSearchMissCount()
        {
            Console.WriteLine("Linear probing search miss count:");
            Console.WriteLine(LinearProbingController.searchMissCount);
        }

        private static void PrintDoubleSearchCount()
        {
            Console.WriteLine("Double hashing search count:");
            Console.WriteLine(DoubleHashingController.searchCount);
        }
        
        private static void PrintDoubleSearchMissCount()
        {
            Console.WriteLine("Double hashing search miss count:");
            Console.WriteLine(DoubleHashingController.searchMissCount);
        }
    }
}
