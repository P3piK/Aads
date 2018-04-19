using System.Collections.Generic;

namespace Lab1
{
    public class BubbleSort
    {
        public static void Exec(List<int> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                for (int j = 1; j < data.Count; j++)
                {
                    if (data[j - 1] > data[j])
                    {
                        Swap(data, j - 1, j);
                    }
                }
            }
        }

        public static void ExecCocktail(List<int> data)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i <= data.Count - 2; i++)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                {
                    break;
                }
                swapped = false;
                for (int i = data.Count - 2; i >= 0; i--)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        swapped = true;
                    }
                }

            } while (swapped);

        }

        public static void ExecOddEven(List<int> data)
        {
            var sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < data.Count - 1; i += 2)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < data.Count - 1; i += 2)
                {
                    if (data[i] > data[i + 1])
                    {
                        Swap(data, i, i + 1);
                        sorted = false;
                    }
                }
            }
        }

        private static void Swap(IList<int> list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
