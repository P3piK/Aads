using DynamicProgramming.Controllers;
using DynamicProgramming.Models;
using DynamicProgramming.Views;
using System;

namespace DynamicProgramming
{
    class Program
    {
        public static string FIRST_WORD = "ABCBDAB";
        public static string SECOND_WORD = "BDCABA";

        static void Main(string[] args)
        {
            LcsController.PrepareDataTable(FIRST_WORD, SECOND_WORD);
            LcsController.CalculateLcsLength();
            LcsController.ConvertTableToString();

            EditDistanceController.PrepareEditDistanceTable();
            EditDistanceController.FillEditDistanceTable();

            View.PrintDataTable(LcsData.lcsDataTable);
            View.PrintLcsLength();
            View.PrintLcsString();

            View.PrintDataTable(EditDistanceData.edData);
            View.PrintEditDistanceLength();
        }
    }
}
