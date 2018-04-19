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
            int numberOfElements = 2048000;
            List<int> data = new List<int>();
            GenerateData(data, numberOfElements);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            /* Sorting methods */
            //ShellSort(data, 3);
            //ShellSort(data, 2);
            //QuickSort1(data, 0, data.Count - 1);        // first element
            //QuickSort2(data, 0, data.Count - 1);        // random
            QuickSort3(data, 0, data.Count - 1);          // median of three

            stopWatch.Stop();
            Console.WriteLine("time: " + stopWatch.ElapsedMilliseconds + " [ms]");

            PrintResultMessage(data);
        }

        private static void QuickSort1(List<int> data, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = data[left];
            while (i < j)
            {
                while (data[i] < pivot) i++;
                while (data[j] > pivot) j--;
                if (i <= j)
                {
                    Swap(data, i, j);
                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuickSort1(data, left, j);
            }
            if (i < right)
            {
                QuickSort1(data, i, right);
            }
        }
        private static void QuickSort2(List<int> data, int left, int right)
        {
            Random random = new Random();
            int i = left;
            int j = right;
            int pivot = data[random.Next(left, right + 1)];
            while (i < j)
            {
                while (data[i] < pivot) i++;
                while (data[j] > pivot) j--;
                if (i <= j)
                {
                    Swap(data, i, j);
                    i++;
                    j--;
                }
            }
            if (left < j)
            {
                QuickSort2(data, left, j);
            }
            if (i < right)
            {
                QuickSort2(data, i, right);
            }
        }
        private static void QuickSort3(List<int> data, int v1, int v2)
        {
            throw new NotImplementedException();
        }


        private static void ShellSort(List<int> data, int k)
        {
            int h = 1;
            int n = data.Count;

            while (h < n / Math.Pow(k, 2.0))
            {
                h = k * h + 1;
            }
            while (h > 0)
            {
                for(int i = h; i < n; i++)
                {
                    int x = data[i];
                    int j = i;
                    while (j >= h && x < data[j-h])
                    {
                        data[j] = data[j - h];
                        j -= h;
                    }
                    data[j] = x;
                }
                h = h / k;
            }
        }

        static void GenerateData(List<int> data, int numberOfElements)
        {
            Random rnd = new Random();
            while (data.Count < numberOfElements)
            {
                data.Add(rnd.Next());
            }
        }


        #region private
        private static void Swap(List<int> list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        private static bool IsSorted(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                if (data[i - 1] > data[i])
                {
                    Console.WriteLine("fault indexes: " + (i - 1) + " " + i);
                    return false;
                }
            }

            return true;
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