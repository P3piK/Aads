using GraphAlgorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms
{
    public class FloydView
    {
        public FloydModel Model { get; set; }

        public FloydView(FloydModel model)
        {
            Model = model;
        }

        public void PrintTable()
        {
            Console.Write("\t");

            for(int i = 1; i < Model.Table.Length + 1; i++)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            int rowIndex = 1;

            foreach(var row in Model.Table)
            {
                Console.Write(rowIndex + "|\t");
                rowIndex++;

                foreach(var element in row)
                {
                    Console.Write(element + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public void PrintPaths()
        {
            Console.WriteLine("Paths:");
            foreach (var path in Model.Paths)
            {
                Console.Write("d[" + path.FirstNode + "][" + path.LastNode + "] : " + path.FirstNode);
                foreach(var node in path.IntermediateNodes)
                {
                    Console.Write("-" + node);
                }
                Console.Write("-" + path.LastNode + "\n");
            }
        }

        public void PrintResultMessage()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Result:");
        }

        public void PrintTableIndex(int index)
        {
            Console.WriteLine("Table[" + index + "]:");
        }

        public void PrintIntermediateVertexTable()
        {
            Console.WriteLine("Intermediate node table:");
            Console.Write("\t");

            for (int i = 1; i < Model.IntermediateVertexTable.Length + 1; i++)
            {
                Console.Write(i + "\t");
            }

            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------");

            int rowIndex = 1;

            for(int i = 0; i < Model.IntermediateVertexTable.Length; i++)
            {
                Console.Write(rowIndex + "|\t");
                rowIndex++;

                for(int j = 0; j < Model.IntermediateVertexTable[i].Length; j++)
                {
                    int val = Model.IntermediateVertexTable[i][j];
                    if(i != j && val != FloydModel.INF)
                    {
                        val = val + 1;
                    }

                    if(val == FloydModel.INF)
                    {
                        val = j + 1;
                    }

                    Console.Write(val + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
