using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms
{
    public class FloydView
    {
        public static void PrintTable(int[][] table)
        {
            Console.Write("\t");

            for(int i = 1; i < table.Length + 1; i++)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            int rowIndex = 1;

            foreach(var row in table)
            {
                Console.Write(rowIndex + "|\t");
                rowIndex++;

                foreach(var element in row)
                {
                    Console.Write(element + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintResultMessage()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Result:");
        }

        public static void PrintTableIndex(int index)
        {
            Console.WriteLine("Table[" + index + "]:");
        }
    }
}
