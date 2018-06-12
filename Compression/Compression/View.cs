using System;
using System.Linq;

namespace Compression
{
    public class View
    {
        #region View

        public static void PrintStage(CompressionDao compressionDao)
        {
            Console.WriteLine(compressionDao.CompressionDictionary + "\t" + compressionDao.Buffer + "\t" + PrintTranslator(compressionDao));
        }

        public static string PrintTranslator(CompressionDao compressionDao)
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
