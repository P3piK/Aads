using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionTranslator
    {
        public int Status { get; set; }
        public char NewChar { get; set; }
        public int Offset { get; set; }
        public int Length { get; set; }
    }
}
