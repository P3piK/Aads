using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionDto
    {
        public string CompressedDictionary { get; set; }
        public string Buffer { get; set; }
        public char FirstLetter { get; private set; }

        public List<CommonTranslatorDto> compressionSteps;

        public CompressionDto()
        {
            FirstLetter = Program.WORD_TO_COMPRESS.ToLower()[0];
            CompressedDictionary = new string(FirstLetter, Program.DICTIONARY_LENGTH);
            compressionSteps = new List<CommonTranslatorDto>();
        }
    }
}
