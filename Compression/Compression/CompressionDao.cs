using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionDao
    {
        public string CompressionDictionary { get; set; }
        public string Buffer { get; set; }

        public List<CompressionTranslator> compressions;

        public CompressionDao()
        {
            CompressionDictionary = "";
            compressions = new List<CompressionTranslator>();
        }
    }
}
