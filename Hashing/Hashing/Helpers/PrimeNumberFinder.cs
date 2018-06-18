using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hashing.Helpers
{
    public class PrimeNumberFinder
    {
        public static int FindLargestPrime(int range)
        {
            for (int i = range - 1; i >= 0; i--)
            {
                if (IsPrime(i))
                {
                    return i;
                }
            }

            return -1;
        }

        private static bool IsPrime(int number)
        {
            if (number > 1)
            {
                return Enumerable.Range(1, number).Where(x => number % x == 0)
                                 .SequenceEqual(new[] { 1, number });
            }

            return false;
        }
    }
}
