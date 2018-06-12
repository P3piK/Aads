using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionController
    {

        #region Controller

        public static void EncodeWord(CompressionDao ret, ref int bufferOffset)
        {
            var tempBuffer = ret.Buffer;

            if (!IsLetterInDictionary(ret))
            {
                ret.compressions.Add(new CompressionTranslator { Status = 1, NewChar = tempBuffer[0] });
                ret.CompressionDictionary += tempBuffer[0];
                bufferOffset++;
            }
            else
            {
                while (!ret.CompressionDictionary.Contains(tempBuffer))
                {
                    tempBuffer = tempBuffer.Remove(tempBuffer.Length - 1);
                }

                // TODO:
                // Change Offset value
                ret.CompressionDictionary += tempBuffer;
                ret.compressions.Add(new CompressionTranslator { Status = 0, Length = tempBuffer.Length, Offset = 0 });
                bufferOffset += tempBuffer.Length;
            }
        }

        public static string SetBuffer(int bufferOffset)
        {
            if (bufferOffset < Program.WORD_TO_COMPRESS.Length - Program.BUFFER_LENGTH)
            {
                return Program.WORD_TO_COMPRESS.ToLower().Substring(bufferOffset, Program.BUFFER_LENGTH);
            }

            return Program.WORD_TO_COMPRESS.ToLower().Substring(bufferOffset, Program.WORD_TO_COMPRESS.Length - bufferOffset);
        }

        public static bool IsEncoded(CompressionDao ret, int bufferOffset)
        {
            return bufferOffset >= Program.WORD_TO_COMPRESS.Length ? true : false;
        }

        private static bool IsLetterInDictionary(CompressionDao ret)
        {
            return ret.CompressionDictionary.Contains(ret.Buffer[0].ToString());
        }

        #endregion
    }
}
