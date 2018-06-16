using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing.Controllers
{
    public class LinearProbingController
    {
        public static bool Insert(HashtableDto[] hashtable, HashtableDto data)
        {
            for(int i = 0; i < hashtable.Length; i++)
            {
                int offset = 0;

                while (true)
                {
                    int key = HashingFunction(data, i, offset);

                    if (hashtable[key] == null)
                    {
                        hashtable[key] = data;
                        return true;
                    }

                    offset++;
                }
            }

            return false;
        }

        public static bool Search(HashtableDto[] hashtable, HashtableDto data)
        {
            throw new NotImplementedException();
        }

        private static int HashingFunction(HashtableDto data, int i, int offset)
        {
            return (data.Key + offset) % Program.TABLE_SIZE;
        }
    }
}
