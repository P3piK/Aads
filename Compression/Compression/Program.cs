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
            int bufferOffset = 0;

            while(!CompressionController.IsEncoded(compressionDto, bufferOffset))
            {
                compressionDto.Buffer = CompressionController.SetBuffer(bufferOffset);

                CompressionController.EncodeWord(compressionDto, ref bufferOffset);
                View.PrintStage(compressionDto);
            }
            
        }
    }
}
