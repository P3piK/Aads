using System;

namespace Compression
{
    public class Program
    {
        public const string WORD_TO_COMPRESS = "ABABCDABCABCDCADABCA";
        public const int BUFFER_LENGTH = 4;


        static void Main(string[] args)
        {
            var compressionDao = new CompressionDao();
            int bufferOffset = 0;

            while(!CompressionController.IsEncoded(compressionDao, bufferOffset))
            {
                compressionDao.Buffer = CompressionController.SetBuffer(bufferOffset);

                CompressionController.EncodeWord(compressionDao, ref bufferOffset);
                View.PrintStage(compressionDao);
            }
            
        }
    }
}
