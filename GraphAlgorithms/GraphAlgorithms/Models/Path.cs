using System;
using System.Collections.Generic;
using System.Text;

namespace GraphAlgorithms.Models
{
    public class Path
    {
        public int FirstNode { get; set; }
        public int LastNode { get; set; }
        public List<int> IntermediateNodes { get; set; }

        public Path()
        {
            IntermediateNodes = new List<int>();
        }
    }
}
