﻿using Compression.Controllers;
using Compression.Dto;
using Compression.Helpers;
using System;

namespace Compression
{
    public class Program
    {
        public static string WORD_TO_COMPRESS = "ABABCDABCABCDCADABCA";
        public const int BUFFER_LENGTH = 4;
        public const int DICTIONARY_LENGTH = 8;
        public const string READ_FILE_NAME = "ToCompress.txt";
        public const string WRITE_FILE_NAME = "Compressed.txt";
        public const bool READ_WRITE_TO_FILE = true;


        static void Main(string[] args)
        {
            if (READ_WRITE_TO_FILE)
            {
                WORD_TO_COMPRESS = FileAssistant.ReadFile(READ_FILE_NAME);
            }

            var compressionDto = new CompressionDto();
            var decompressionDto = new DecompressionDto();
            int bufferOffset = 0;

            View.PrintStartCompressionMessage();
            CompressionController.PerformCompression(compressionDto, bufferOffset);

            View.PrintStartDecompressionMessage();
            DecompressionController.PerformDecompression(compressionDto, READ_WRITE_TO_FILE);
            
        }
    }
}
