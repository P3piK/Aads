using DynamicProgramming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming.Controllers
{
    public class LcsController
    {
        public static void PrepareDataTable(string firstString, string secondString)
        {
            var data = new int[secondString.Length + 1][];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new int[firstString.Length + 1];
            }

            LcsData.lcsDataTable = data;
        }

        internal static void CalculateLcsLength()
        {
            var data = LcsData.lcsDataTable;
            for (int i = 1; i < data.Length; i++)
            {
                for(int j = 1; j < data[i].Length; j++)
                {
                    if (Program.FIRST_WORD[j - 1] == Program.SECOND_WORD[i - 1])
                    {
                        data[i][j] = data[i - 1][j - 1] + 1;
                    }
                    else
                    {
                        data[i][j] = Math.Max(data[i][j - 1], data[i - 1][j]);
                    }
                }
            }
        }

        internal static void ConvertTableToString()
        {
            var data = LcsData.lcsDataTable;
            int i = data.Length - 1;
            int j = data[0].Length - 1;

            while (i != 0 && j != 0)
            {
                if (data[i - 1][j] == data[i][j - 1])
                {
                    LcsData.LcsString = LcsData.LcsString.Insert(0, Program.FIRST_WORD[j - 1].ToString());
                    i--;
                    j--;
                }
                else
                {
                    if (data[i - 1][j] > data[i][j - 1])
                    {
                        i -= 1;
                    }
                    else
                    {
                        j -= 1;
                    }
                }
            }

        }
    }
}
