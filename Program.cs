using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2aads
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfElements = 64000;
            List<int> data = new List<int>();
            GenerateData(data, numberOfElements);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            /* Sorting methods */

            SelectionSort(data);
            //InsertionSort(data);
            //InsertionSortWithGuard(data);
            //BubbleSort(data);
            //CocktailSort(data);

            stopWatch.Stop();
            Console.WriteLine("time: " + stopWatch.ElapsedMilliseconds + " [ms]");

            PrintResultMessage(data);
        }

        static void GenerateData(List<int> data, int numberOfElements)
        {
            Random rnd = new Random();
            while (data.Count < numberOfElements)
            {
                data.Add(rnd.Next());
            }
        }

        static void SelectionSort(List<int> data)
        {
            int n = data.Count;
            for (int i = 0; i < n; i++)
            {
                int k = i;
                int minValue = data[i];

                FindMinElement(data, n, i, ref k, ref minValue);

                data[k] = data[i];
                data[i] = minValue;
            }
        }

        static void InsertionSort(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                int x = data[i];
                int j = i - 1;
                while (j >= 0 && x < data[j])
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = x;
            }
        }

        static void InsertionSortWithGuard(List<int> data)
        { 
            for (int i = 1; i < data.Count; i++)
            {
                int x = data[i];
                int guard = x;
                int j = i - 1;
                while (j > 0 && x < data[j])
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = x;
            }
        }

        static void BubbleSort(List<int> data)
        {
            for(int i = 0; i < data.Count; i++)
            {
                for(int j = 1; j < data.Count; j++)
                {
                    if(data[j-1] > data[j])
                    {
                        Swap(data, j - 1, j);
                    }
                }
            }
        }
        
        static void CocktailSort(List<int> data)
        {
            bool swapped;
            do
            {
                swapped = false;
                for(int i = 0; i <= data.Count - 2; i++)
                {
                    if(data[i] > data[i+1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }
                if(!swapped)
                {
                    break;
                }
                swapped = false;
                for(int i = data.Count - 2; i >=0; i--)
                {
                    if(data[i] > data[i+1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }

            } while (swapped);

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

        #region private
        private static void Swap(IList<int> list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        private static void FindMinElement(List<int> data, int n, int i, ref int k, ref int minValue)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (data[j] < minValue)
                {
                    k = j;
                    minValue = data[j];
                }
            }
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
        //private static void GetTimeDifference(Stopwatch stopWatch)
        //{
        //    int timeSecond, timeMillisecond;
        //    timeSecond = DateTime.Now.Second - beginTimeSecond;
        //    timeMillisecond = DateTime.Now.Millisecond - beginTimeMillisecond;

        //    if (timeMillisecond < 0)
        //    {
        //        timeSecond--;
        //        timeMillisecond = 1 + timeMillisecond;
        //    }

        //    Console.WriteLine("Time: " + timeSecond.ToString() + ":" + timeMillisecond.ToString());
        //}
        #endregion

    }
}
