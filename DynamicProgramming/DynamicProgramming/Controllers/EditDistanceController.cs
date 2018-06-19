using DynamicProgramming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Controllers
{
    public class EditDistanceController
    {
        public static void PrepareEditDistanceTable()
        {
            string firstString = Program.FIRST_WORD;
            string secondString = Program.SECOND_WORD;
            var data = new int[secondString.Length + 1][];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new int[firstString.Length + 1];
            }

            FillZeroRow(firstString, data);
            FillZeroColumn(secondString, data);

            EditDistanceData.edData = data;
        }

        public static void FillEditDistanceTable()
        {
            var data = EditDistanceData.edData;
            var firstString = Program.FIRST_WORD;
            var secondString = Program.SECOND_WORD;

            for(int i = 1; i < data.Length; i++)
            {
                for(int j = 1; j < data[i].Length; j++)
                {
                    if(firstString[j - 1] == secondString[i - 1])
                    {
                        data[i][j] = data[i - 1][j - 1];
                    }
                    else
                    {
                        data[i][j] = Math.Min(Math.Min(data[i - 1][j], data[i][j - 1]), data[i - 1][j - 1]) + 1;
                    }
                }
            }
        }

        #region private

        private static void FillZeroRow(string firstString, int[][] data)
        {
            for (int i = 1; i < data[0].Length; i++)
            {
                data[0][i] = i;
            }
        }

        private static void FillZeroColumn(string secondString, int[][] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                data[i][0] = i;
            }
        }

        #endregion
    }
}
