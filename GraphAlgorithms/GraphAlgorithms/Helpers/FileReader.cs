using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GraphAlgorithms.Helpers
{
    public class FileReader
    {
        public string FileName { get; set; }

        public FileReader(string fileName)
        {
            FileName = fileName;
        }

        public int GetNodesCount()
        {
            string[] line;

            using (StreamReader stream = new StreamReader(FileName))
            {
                line = stream.ReadLine().Split();
            }

            return int.Parse(line[0]);
        }

        public void FillTable(int[][] table)
        {
            string line;
            using (StreamReader stream = new StreamReader(FileName))
            {
                stream.ReadLine();
                while((line = stream.ReadLine()) != null)
                {
                    var splitLine = line.Split();
                    int i = int.Parse(splitLine[0]);
                    int j = int.Parse(splitLine[1]);
                    int dist = int.Parse(splitLine[2]);

                    table[i - 1][j - 1] = dist;
                }
            }
        }
    }
}
