using GraphAlgorithms.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Controllers
{
    public class FloydController
    {
        public int NodesCount { get; set; }
        public int[][] Table { get; set; }
        public string FileName { get; set; }

        public FloydController(string fileName)
        {
            FileName = fileName;
        }

        public void PerformFloyd()
        {
            FileReader reader = new FileReader(FileName);
            NodesCount = reader.GetNodesCount();
            SetTable();
            reader.FillTable(Table);
            FloydView.PrintTable(Table);

            RunFloydAlgorithm();

            FloydView.PrintResultMessage();
            FloydView.PrintTable(Table);
        }

        private void RunFloydAlgorithm()
        {
            for(int k = 0; k < NodesCount; k++)
            {
                for(int i = 0; i < NodesCount; i++)
                {
                    for(int j = 0; j < NodesCount; j++)
                    {
                        Table[i][j] = Math.Min(Table[i][j], Table[i][k] + Table[k][j]);
                    }
                }

                FloydView.PrintTableIndex(k + 1);
                FloydView.PrintTable(Table);
            }
        }

        private void SetTable()
        {
            Table = new int[NodesCount][];
            for (int i = 0; i < NodesCount; i++)
            {
                Table[i] = new int[NodesCount];
                for(int j = 0; j < Table[i].Length; j++)
                {
                    if(i == j)
                    {
                        Table[i][j] = 0;
                    }
                    else
                    {
                        Table[i][j] = 99999;
                    }
                }
            }
        }
    }
}
