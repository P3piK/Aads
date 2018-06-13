using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionDto
    {
        public string CompressionDictionary { get; set; }
        public string Buffer { get; set; }

        public List<CompressionTranslatorDto> compressions;

        public CompressionDto()
        {
            CompressionDictionary = new string(Program.WORD_TO_COMPRESS.ToLower()[0], Program.DICTIONARY_LENGTH);
            compressions = new List<CompressionTranslatorDto>();
        }
    }
}
