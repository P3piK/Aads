using System;
using System.Linq;

namespace Compression
{
    public class View
    {
        #region View

        public static void PrintStage(CompressionDto compressionDao)
        {
            Console.WriteLine(compressionDao.CompressedDictionary + "\t" + compressionDao.Buffer + "\t" + PrintTranslator(compressionDao));
        }

        public static string PrintTranslator(CompressionDto compressionDao)
        {
            if (compressionDao.compressionSteps.LastOrDefault().Status == 0)
            {
                return String.Format("{0}, {1}, {2}",
                    compressionDao.compressionSteps.LastOrDefault().Status,
                    compressionDao.compressionSteps.LastOrDefault().Offset,
                    compressionDao.compressionSteps.LastOrDefault().Length);
            }

            return String.Format("{0}, {1}",
                compressionDao.compressionSteps.LastOrDefault().Status,
                compressionDao.compressionSteps.LastOrDefault().NewChar);
        }

        public static void PrintStartDecompressionMessage()
        {
            Console.WriteLine("Started decompression...");
        }

        public static void PrintStartCompressionMessage()
        {
            Console.WriteLine("Started compression...");
        }

        #endregion
    }
}
