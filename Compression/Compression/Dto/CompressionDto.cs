using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionDto
    {
        public string CompressedDictionary { get; set; }
        public string Buffer { get; set; }

        public List<CommonTranslatorDto> compressionSteps;

        public CompressionDto()
        {
            CompressedDictionary = new string(Program.WORD_TO_COMPRESS.ToLower()[0], Program.DICTIONARY_LENGTH);
            compressionSteps = new List<CommonTranslatorDto>();
        }
    }
}
