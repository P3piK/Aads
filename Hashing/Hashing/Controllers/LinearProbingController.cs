using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing.Controllers
{
    public class LinearProbingController
    {
        public static int insertCount;
        public static int searchCount;
        public static int searchMissCount;

        public static bool Insert(HashtableDto[] hashtable, HashtableDto data)
        {
            for(int i = 0; i < hashtable.Length; i++)
            {
                int key = HashingFunction(data, i);
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
            for (int i = 0; i < hashtable.Length; i++)
            {
                int key = HashingFunction(data, i);
                searchCount++;

                if(hashtable[key] == data)
                {
                    return true;
                }
                else if(hashtable[key] == null)
                {
                    return false;
                }

                searchMissCount++;
            }

            return false;
        }

        private static int HashingFunction(HashtableDto data, int i)
        {
            return (data.Key + i) % Program.TABLE_SIZE;
        }
    }
}
