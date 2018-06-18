using Hashing.Controllers;
using Hashing.Helpers;
using Hashing.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Hashing
{
    class Program
    {
        public static int TABLE_SIZE = 0;
        public static int LARGEST_PRIME = 0;

        private const string DATA_FILE_PATH = "data.txt";
        private const string DATA_MISS_FILE_PATH = "data_miss.txt";
        private const double FILL_PERCENTAGE = 0.9;

        static void Main(string[] args)
        {
            string filePath = DATA_FILE_PATH;
            string searchFilePath = DATA_FILE_PATH;

            TABLE_SIZE = SetTableSize(filePath);
            LARGEST_PRIME = PrimeNumberFinder.FindLargestPrime(TABLE_SIZE);


            if (!(TABLE_SIZE > default(int)))
            {
                return;
            }

            List<int> insertFileData = FillListWithData(filePath);
            List<int> searchFileData = FillListWithData(searchFilePath);
            HashtableDto[] hashtableLinear = new HashtableDto[TABLE_SIZE];
            FillHashtableWithNulls(TABLE_SIZE, hashtableLinear);
            HashtableDto[] hashtableDouble = new HashtableDto[TABLE_SIZE];
            Array.Copy(hashtableLinear, hashtableDouble, TABLE_SIZE);

            InsertValuesLinearProbing(insertFileData, hashtableLinear, FILL_PERCENTAGE);
            InsertValuesDoubleHashing(insertFileData, hashtableDouble, FILL_PERCENTAGE);

            foreach(var value in searchFileData)
            {
                LinearProbingController.Search(hashtableLinear, new HashtableDto(value, value));
                DoubleHashingController.Search(hashtableDouble, new HashtableDto(value, value));
            }

            View.PrintAllResults();

        }


        #region private


        private static void InsertValuesLinearProbing(List<int> dataValues, HashtableDto[] hashtable, double fillPercentage)
        {
            int filledValues = 0;

            foreach (var value in dataValues)
            {
                LinearProbingController.Insert(hashtable, new HashtableDto(value, value));
                filledValues++;

                if(filledValues / (double)TABLE_SIZE > FILL_PERCENTAGE)
                {
                    return;
                }
            }
        }

        private static void InsertValuesDoubleHashing(List<int> dataValues, HashtableDto[] hashtable, double fillPercentage)
        {
            int filledValues = 0;

            foreach (var value in dataValues)
            {
                DoubleHashingController.Insert(hashtable, new HashtableDto(value, value));
                filledValues++;

                if (filledValues / (double)TABLE_SIZE > FILL_PERCENTAGE)
                {
                    return;
                }
            }
        }

        private static List<int> FillListWithData(string filePath)
        {
            List<int> ret = new List<int>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string data;
                    int value;
                    while ((data = reader.ReadLine()) != null)
                    {
                        value = Int32.Parse(data);
                        ret.Add(value);
                    }

                }
            }
            catch (FileNotFoundException e)
            {
                View.PrintFileNotFoundMessage();
            }

            return ret;
        }

        private static int SetTableSize(string filePath)
        {
            try
            {
                return File.ReadLines(filePath).Count();
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
