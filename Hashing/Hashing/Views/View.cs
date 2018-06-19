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
            Console.WriteLine("Linear probing avarage search count:");
            Console.WriteLine((double)LinearProbingController.searchCount / Program.TABLE_SIZE);
        }

        private static void PrintLinearSearchMissCount()
        {
            Console.WriteLine("Linear probing avarage search miss count:");
            Console.WriteLine((double)LinearProbingController.searchMissCount / Program.TABLE_SIZE);
        }

        private static void PrintDoubleSearchCount()
        {
            Console.WriteLine("Double hashing avarage search count:");
            Console.WriteLine((double)DoubleHashingController.searchCount / Program.TABLE_SIZE);
        }
        
        private static void PrintDoubleSearchMissCount()
        {
            Console.WriteLine("Double hashing avarage search miss count:");
            Console.WriteLine((double)DoubleHashingController.searchMissCount / Program.TABLE_SIZE);
        }
    }
}
