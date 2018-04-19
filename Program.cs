using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> data = new List<int>();

            Menu(data);
        }

        private static void Menu(List<int> data)
        {
            NewData(out data);
            while(true)
            {
                List<int> tempData = new List<int>(data);

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
                    case 6:
                        BubbleSort.ExecOddEven(tempData);
                        break;
                    case 9:
                        NewData(out data);
                        break;
                    case 0:
                        return;
                }
                stopWatch.Stop();
                Console.WriteLine("time: " + stopWatch.ElapsedMilliseconds + " [ms]");
                PrintResultMessage(tempData);
            }
            
        }

        private static void NewData(out List<int> data)
        {
            Console.Write("Enter size of data sample: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int numberOfElements);
            data = new List<int>();
            GenerateData(data, numberOfElements);
        }

        #region private

        private static void GenerateData(List<int> data, int numberOfElements)
        {
            Random rnd = new Random();
            while (data.Count < numberOfElements)
            {
                data.Add(rnd.Next());
            }
        }

        static bool IsSorted(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                if (data[i - 1] > data[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static void PrintMenuMessage()
        {
            Console.WriteLine("\nChoose sorting method: ");
            Console.WriteLine("\t1. Selection Sort\n" +
                "\t2. Insertion Sort\n" +
                "\t3. Insertion Sort with Guard\n" +
                "\t4. Bubble Sort\n" +
                "\t5. Cocktail Sort\n" +
                "\t6. Odd-even Sort\n" +
                "\t9. New data set\n" +
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
