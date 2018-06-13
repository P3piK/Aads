using System;
using System.Collections.Generic;
using System.Text;

namespace Compression
{
    public class CompressionController
    {
        public static void PerformCompression(CompressionDto compressionDto, int bufferOffset)
        {
            while (!IsCompressed(compressionDto, bufferOffset))
            {
                compressionDto.Buffer = SetBuffer(bufferOffset);

                CompressWord(compressionDto, ref bufferOffset);
                View.PrintStage(compressionDto);
            }
        }


        #region private

        private static void CompressWord(CompressionDto ret, ref int bufferOffset)
        {
            var tempBuffer = ret.Buffer;

            if (!IsLetterInDictionary(ret))
            {
                ret.compressionSteps.Add(new CommonTranslatorDto { Status = 1, NewChar = tempBuffer[0] });
                ret.CompressedDictionary += tempBuffer[0];
                ret.CompressedDictionary = ret.CompressedDictionary.Remove(default(int), 1);
                bufferOffset++;
            }
            else
            {
                while (!ret.CompressedDictionary.Contains(tempBuffer))
                {
                    tempBuffer = tempBuffer.Remove(tempBuffer.Length - 1);
                }

                int offset = ret.CompressedDictionary.Length - ret.CompressedDictionary.LastIndexOf(tempBuffer) - 1;
                ret.CompressedDictionary += tempBuffer;
                ret.CompressedDictionary = ret.CompressedDictionary.Remove(default(int), tempBuffer.Length);
                ret.compressionSteps.Add(new CommonTranslatorDto { Status = 0, Length = tempBuffer.Length, Offset = offset });
                bufferOffset += tempBuffer.Length;
            }
        }

        private static string SetBuffer(int bufferOffset)
        {
            if (bufferOffset < Program.WORD_TO_COMPRESS.Length - Program.BUFFER_LENGTH)
            {
                return Program.WORD_TO_COMPRESS.ToLower().Substring(bufferOffset, Program.BUFFER_LENGTH);
            }

            return Program.WORD_TO_COMPRESS.ToLower().Substring(bufferOffset, Program.WORD_TO_COMPRESS.Length - bufferOffset);
        }

        private static bool IsCompressed(CompressionDto ret, int bufferOffset)
        {
            return bufferOffset >= Program.WORD_TO_COMPRESS.Length ? true : false;
        }

        private static bool IsLetterInDictionary(CompressionDto ret)
        {
            return ret.CompressedDictionary.Contains(ret.Buffer[0].ToString());
        }

        #endregion
    }
}
