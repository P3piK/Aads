using System;
using System.Collections.Generic;

namespace Lab3
{
    public class Quicksort
    {
        // First element
        public static void Exec1(List<int> data, int left, int right)
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
                Exec1(data, left, j);
            }
            if (i < right)
            {
                Exec1(data, i, right);
            }
        }

        // Random
        public static void Exec2(List<int> data, int left, int right)
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
                Exec2(data, left, j);
            }
            if (i < right)
            {
                Exec2(data, i, right);
            }
        }

        // Median of three
        public static void Exec3(List<int> data, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = median(left, (int)(left+right)/2, right);
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
                Exec3(data, left, j);
            }
            if (i < right)
            {
                Exec3(data, i, right);
            }
        }

        private static int median(int left, int mid, int right)
        {
            List<int> values = new List<int>() { left, mid, right };
            int max = values[0];
            foreach(var val in values)
            {
                if(max < val)
                {
                    max = val;
                }
            }
            values.Remove(max);
            int res = values[0] > values[1] ? 
                values[0] :
                values[1];

            return res;
        }


        #region private
        private static void Swap(List<int> list, int indexA, int indexB)
        {
            int tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
        #endregion
    }
}
