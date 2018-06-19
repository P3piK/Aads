using DynamicProgramming.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming.Views
{
    public class View
    {
        public static void PrintDataTable(int[][] data)
        {
            PrintFirstStringTabbed();

            for(int i = 0; i < data.Length; i++)
            {
                PrintSecondWordVertically(i);
                PrintDataRow(data, i);

                Console.WriteLine();
            }
        }

        public static void PrintLcsLength()
        {
            Console.WriteLine();
            Console.WriteLine("Longest Common Subsequence Length equals:\t" + LcsData.lcsDataTable.Last().Last());
        }

        internal static void PrintLcsString()
        {
            Console.WriteLine();
            Console.WriteLine("Lcs:\t" + LcsData.LcsString);
        }

        internal static void PrintEditDistanceLength()
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("Edit Distance Length:\t{0}", EditDistanceData.edData.Last().Last()));
        }

        #region private

        private static void PrintDataRow(int[][] data, int i)
        {
            if (i == 0)
            {
                Console.Write("\t");
            }

            for (int j = 0; j < data[i].Length; j++)
            {
                Console.Write(data[i][j] + "\t");
            }
        }

        private static void PrintSecondWordVertically(int i)
        {
            if (i > 0)
            {
                Console.Write(Program.SECOND_WORD[i - 1] + "\t");
            }
        }

        private static void PrintFirstStringTabbed()
        {
            Console.Write("\t");

            for(int i = 0; i < Program.FIRST_WORD.Length; i++)
            {
                Console.Write("\t" + Program.FIRST_WORD[i]);
            }

            Console.WriteLine();
        }

        #endregion
    }
}
