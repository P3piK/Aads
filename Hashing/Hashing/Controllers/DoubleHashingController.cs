using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing.Controllers
{
    public class DoubleHashingController
    {
        public static int searchCount;
        public static bool Insert(HashtableDto[] hashtable, HashtableDto data)
        {
            for (int i = 0; i < hashtable.Length; i++)
            {
                int key = HashingJoint(data, i);

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
            for (int i = 0; i < hashtable.Length; i++)
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
            return Program.TABLE_SIZE / 2 - (data.Key % (Program.TABLE_SIZE / 2));
        }
    }
}
