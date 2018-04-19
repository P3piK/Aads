using System.Collections.Generic;

namespace Lab1
{
    public class SelectionSort
    {
        public static void Exec(List<int> data)
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
    }
}
