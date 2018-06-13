using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionController
    {

        #region Controller

        public static void EncodeWord(CompressionDto ret, ref int bufferOffset)
        {
            var tempBuffer = ret.Buffer;

            if (!IsLetterInDictionary(ret))
            {
                ret.compressions.Add(new CompressionTranslatorDto { Status = 1, NewChar = tempBuffer[0] });
                ret.CompressionDictionary += tempBuffer[0];
                ret.CompressionDictionary = ret.CompressionDictionary.Remove(default(int), 1);
                bufferOffset++;
            }
            else
            {
                while (!ret.CompressionDictionary.Contains(tempBuffer))
                {
                    tempBuffer = tempBuffer.Remove(tempBuffer.Length - 1);
                }

                int offset = ret.CompressionDictionary.Length - ret.CompressionDictionary.LastIndexOf(tempBuffer) - 1;
                ret.CompressionDictionary += tempBuffer;
                ret.CompressionDictionary = ret.CompressionDictionary.Remove(default(int), tempBuffer.Length);
                ret.compressions.Add(new CompressionTranslatorDto { Status = 0, Length = tempBuffer.Length, Offset = offset });
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

        public static bool IsEncoded(CompressionDto ret, int bufferOffset)
        {
            return bufferOffset >= Program.WORD_TO_COMPRESS.Length ? true : false;
        }

        private static bool IsLetterInDictionary(CompressionDto ret)
        {
            return ret.CompressionDictionary.Contains(ret.Buffer[0].ToString());
        }

        #endregion
    }
}
