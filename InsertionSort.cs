﻿using System.Collections.Generic;

namespace Lab1
{
    public class InsertionSort
    {
        public static void Exec(List<int> data)
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

        public static void ExecWithGuard(List<int> data)
        {
            for (int i = 1; i < data.Count; i++)
            {
                int x = data[i];
                data.Insert(0, x);
                int j = i;
                while (x < data[j])
                {
                    data[j + 1] = data[j];
                    j--;
                }
                data[j + 1] = x;
                data.Remove(x);
            }
        }
    }
}
