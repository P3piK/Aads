using System;
using System.Linq;

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
                PrintStage(compressionDao);
            }
            
        }

        #region View

        private static void PrintStage(CompressionDao compressionDao)
        {
            Console.WriteLine(compressionDao.CompressionDictionary + "\t" + compressionDao.Buffer + "\t" + PrintTranslator(compressionDao));
        }

        private static string PrintTranslator(CompressionDao compressionDao)
        {
            if (compressionDao.compressions.LastOrDefault().Status == 0)
            {
                return String.Format("{0}, {1}, {2}",
                    compressionDao.compressions.LastOrDefault().Status,
                    compressionDao.compressions.LastOrDefault().Offset,
                    compressionDao.compressions.LastOrDefault().Length);
            }

            return String.Format("{0}, {1}",
                compressionDao.compressions.LastOrDefault().Status,
                compressionDao.compressions.LastOrDefault().NewChar);
        }

        #endregion
    }
}
