using System;
using System.Collections.Generic;
using System.Text;

namespace Compression.Dto
{
    public class DecompressionDto
    {
        public string DecompressedWord { get; set; }

        public DecompressionDto()
        {
            DecompressedWord = "";
        }
    }
}
