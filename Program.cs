using Lab1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = 16000;
            List<int> data = new List<int>();
            GenerateData(data, numberOfElements);

            Menu(data);
        }

        private static void Menu(List<int> data)
        {
            while(true)
            {
                List<int> tempData = data;

                PrintMenuMessage();
                string input = Console.ReadLine();
                Int32.TryParse(input, out int option);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                switch (option)
                {
                    case 1:
                        SelectionSort.Exec(tempData);
                        break;
                    case 2:
                        InsertionSort.Exec(tempData);
                        break;
                    case 3:
                        InsertionSort.ExecWithGuard(tempData);
                        break;
                    case 4:
                        BubbleSort.Exec(tempData);
                        break;
                    case 5:
                        BubbleSort.ExecCocktail(tempData);
                        break;
                    case 0:
                        return;
                }
                stopWatch.Stop();
                Console.WriteLine("time: " + stopWatch.ElapsedMilliseconds + " [ms]");
                PrintResultMessage(tempData);
            }
            
        }

        #region private

        static void GenerateData(List<int> data, int numberOfElements)
        {
            Random rnd = new Random();
            while (data.Count < numberOfElements)
            {
                data.Add(rnd.Next());
            }
        }

        private static void PrintMenuMessage()
        {
            Console.WriteLine("\nChoose sorting method: ");
            Console.WriteLine("\t1. Selection Sort\n" +
                "\t2. Insertion Sort\n" +
                "\t3. Insertion Sort with Guard - not working\n" +
                "\t4. Bubble Sort\n" +
                "\t5. Cocktail Sort\n" +
                "\t0. Exit");
        }

        private static void PrintResultMessage(List<int> data)
        {
            if (IsSorted(data))
            {
                Console.WriteLine("The input data is sorted correctly!");
            }
            else
            {
                Console.WriteLine("Oops.. I'm affraid it's not sorted, sir.");
            }
        }
        #endregion
    }
}
