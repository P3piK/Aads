using GraphAlgorithms.Helpers;
using GraphAlgorithms.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Controllers
{
    public class FloydController
    {
        public FloydModel Model { get; set; }
        public FloydView View { get; set; }

        public FloydController(FloydModel model)
        {
            Model = model;
            View = new FloydView(Model);
        }

        public void PerformFloyd()
        {
            View.PrintTable();

            RunFloydAlgorithm();
            FindPaths();
            
            View.PrintResultMessage();
            View.PrintTable();
            View.PrintPaths();
        }

        private void RunFloydAlgorithm()
        {
            for(int k = 0; k < Model.NodesCount; k++)
            {
                for(int i = 0; i < Model.NodesCount; i++)
                {
                    for(int j = 0; j < Model.NodesCount; j++)
                    {
                        int tempDist = Model.Table[i][k] + Model.Table[k][j];
                        if (Model.Table[i][j] > tempDist)
                        {
                            Model.Table[i][j] = tempDist;
                            Model.IntermediateVertexTable[i][j] = k;
                        }
                    }
                }

                View.PrintTableIndex(k + 1);
                View.PrintTable();
            }
        }

        private void FindPaths()
        {
            for(int i = 0; i < Model.NodesCount; i++)
            {
                for(int j = 0; j < Model.NodesCount; j++)
                {
                    if(i == j)
                    {
                        continue;
                    }

                    var path = new Path
                    {
                        FirstNode = i + 1,
                        LastNode = j + 1
                    };

                    int row = i;
                    while(Model.IntermediateVertexTable[row][j] != FloydModel.INF)
                    {
                        row = Model.IntermediateVertexTable[row][j];
                        path.IntermediateNodes.Add(row + 1);
                    }

                    Model.Paths.Add(path);
                }
            }
        }
    }
}
