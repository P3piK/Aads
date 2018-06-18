using Hashing.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing.Controllers
{
    public class DoubleHashingController
    {
        public static int insertCount;
        public static int searchCount;
        public static int searchMissCount;

        public static bool Insert(HashtableDto[] hashtable, HashtableDto data)
        {
            for (int i = 0; i < Program.TABLE_SIZE; i++)
            {
                int key = HashingJoint(data, i);
                insertCount++;

                if (hashtable[key] == null)
                {
                    hashtable[key] = data;
                    return true;
                }
            }

            return false;
        }

        public static bool Search(HashtableDto[] hashtable, HashtableDto data)
        {
            for (int i = 0; i < Program.TABLE_SIZE; i++)
            {
                int key = HashingJoint(data, i);
                searchCount++;

                if (hashtable[key] == data)
                {
                    return true;
                }
                else if (hashtable[key] == null)
                {
                    return false;
                }

                searchMissCount++;
            }

            return false;
        }

        private static int HashingJoint(HashtableDto data, int i)
        {
            return (Hashing1(data) + i * Hashing2(data)) % Program.TABLE_SIZE;
        }

        private static int Hashing1(HashtableDto data)
        {
            return data.Key % Program.TABLE_SIZE;
        }

        private static int Hashing2(HashtableDto data)
        {
            return Program.LARGEST_PRIME - (data.Key % Program.LARGEST_PRIME);
        }
    }
}
