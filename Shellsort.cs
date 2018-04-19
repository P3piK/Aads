using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Shellsort
    {
        public static void Exec(List<int> data, int k)
        {
            int h = 1;
            int n = data.Count;

            while (h < n / Math.Pow(k, 2.0))
            {
                h = k * h + 1;
            }
            while (h > 0)
            {
                for (int i = h; i < n; i++)
                {
                    int x = data[i];
                    int j = i;
                    while (j >= h && x < data[j - h])
                    {
                        data[j] = data[j - h];
                        j -= h;
                    }
                    data[j] = x;
                }
                h = h / k;
            }
        }
    }
}
