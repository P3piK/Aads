using Compression.Controllers;
using Compression.Dto;
using System;

namespace Compression
{
    public class Program
    {
        public const string WORD_TO_COMPRESS = "ABABCDABCABCDCADABCA";
        public const int BUFFER_LENGTH = 4;
        public const int DICTIONARY_LENGTH = 8;


        static void Main(string[] args)
        {
            var compressionDto = new CompressionDto();
            var decompressionDto = new DecompressionDto();
            int bufferOffset = 0;

            View.PrintStartCompressionMessage();
            CompressionController.PerformCompression(compressionDto, bufferOffset);

            View.PrintStartDecompressionMessage();
            DecompressionController.PerformDecompression(compressionDto);

            // add decompression, 
            // add read /save from file
            
        }
    }
}
