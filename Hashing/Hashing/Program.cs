using Hashing.Controllers;
using Hashing.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hashing
{
    class Program
    {
        private const string DATA_FILE_PATH = "data.txt";
        private const string DATA_MISS_FILE_PATH = "data_miss.txt";

        public static int TABLE_SIZE = 0;

        static void Main(string[] args)
        {
            TABLE_SIZE = SetTableSize();
            if (!(TABLE_SIZE > default(int)))
            {
                return;
            }

            HashtableDto[] hashtable = new HashtableDto[TABLE_SIZE];
            FillHashtableWithNulls(TABLE_SIZE, hashtable);

            InsertValuesLinearProbing(hashtable);
        }


        #region private

        private static void InsertValuesLinearProbing(HashtableDto[] hashtable)
        {
            try
            {
                using (StreamReader reader = new StreamReader(DATA_FILE_PATH))
                {
                    string data;
                    int value;
                    while ((data = reader.ReadLine()) != null)
                    {
                        value = Int32.Parse(data);
                        LinearProbingController.Insert(hashtable, new HashtableDto(value, value));
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                View.PrintFileNotFoundMessage();
            }
        }

        private static int SetTableSize()
        {
            try
            {
                return File.ReadLines(DATA_FILE_PATH).Count();
            }
            catch (FileNotFoundException e)
            {
                View.PrintFileNotFoundMessage();
            }

            return default(int);
        }

        private static void FillHashtableWithNulls(int tableSize, HashtableDto[] hashtable)
        {
            for (int i = 0; i < tableSize; i++)
            {
                hashtable[i] = null;
            }
        }

        #endregion
    }
}
