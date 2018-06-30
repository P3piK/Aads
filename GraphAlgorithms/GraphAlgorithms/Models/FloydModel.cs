using GraphAlgorithms.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Models
{
    public class FloydModel
    {
        public const int INF = 99999;

        public int NodesCount { get; set; }
        public int[][] Table { get; set; }
        public string FileName { get; set; }
        public int[][] IntermediateVertexTable { get; set; }
        public List<Path> Paths { get; set; } 

        public FloydModel(string fileName)
        {
            FileName = fileName;
            FileReader reader = new FileReader(FileName);
            NodesCount = reader.GetNodesCount();
            Table = SetArray();
            IntermediateVertexTable = SetArray();
            reader.FillTable(Table);
            Paths = new List<Path>();
        }

        private int[][] SetArray()
        {   
            int[][] array = new int[NodesCount][];
            for (int i = 0; i < NodesCount; i++)
            {
                array[i] = new int[NodesCount];
                for (int j = 0; j < array[i].Length; j++)
                {
                    if (i == j)
                    {
                        array[i][j] = 0;
                    }
                    else
                    {
                        array[i][j] = INF;
                    }
                }
            }

            return array;
        }
    }
}
