using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab3
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
            while (true)
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
                        Quicksort.Exec1(tempData, 0, data.Count - 1);
                        break;
                    case 2:
                        Quicksort.Exec2(tempData, 0, data.Count - 1);
                        break;
                    case 3:
                        Quicksort.Exec3(tempData, 0, data.Count - 1);
                        break;
                    case 4:
                        Console.WriteLine("Not implemented");
                        break;
                    case 5:
                        Shellsort.Exec(tempData, 2);
                        break;
                    case 6:
                        Shellsort.Exec(tempData, 3);
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

        #region private
        private static void NewData(out List<int> data)
        {
            Console.Write("Enter size of data sample: ");
            string input = Console.ReadLine();
            Int32.TryParse(input, out int numberOfElements);
            data = new List<int>();
            GenerateData(data, numberOfElements);
        }

        private static void GenerateData(List<int> data, int numberOfElements)
        {
            Random rnd = new Random();
            while (data.Count < numberOfElements)
            {
                data.Add(rnd.Next());
            }
        }

        private static bool IsSorted(List<int> data)
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
            Console.WriteLine("\t1. Quick Sort - first element\n" +
                "\t2. Quick Sort - random element\n" +
                "\t3. Quick Sort - median of three elements\n" +
                "\t4. Quick Sort + Insertion\n" +
                "\t5. Shell Sort 1\n" +
                "\t6. Shell Sort 2\n" +
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