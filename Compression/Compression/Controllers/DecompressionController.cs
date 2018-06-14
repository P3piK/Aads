using Compression.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compression.Controllers
{
    public class DecompressionController
    {
        public static void PerformDecompression(CompressionDto compressionDto)
        {
            DecompressionDto decompressionDto = new DecompressionDto();
            foreach(var step in compressionDto.compressionSteps)
            {
                if (!IsDecompressedWordEmpty(decompressionDto))
                {
                    if (step.Status == 1)
                    {
                        decompressionDto.DecompressedWord += step.NewChar;
                    }
                    else
                    {
                        decompressionDto.DecompressedWord += decompressionDto.DecompressedWord
                            .Substring(decompressionDto.DecompressedWord.Length - step.Offset - 1, step.Length);
                    }
                }
                else
                {
                    decompressionDto.DecompressedWord += compressionDto.FirstLetter;
                }

                View.PrintDecompressionStage(decompressionDto);
            }
        }

        private static bool IsDecompressedWordEmpty(DecompressionDto decompressionDto)
        {
            return decompressionDto.DecompressedWord.Equals(String.Empty);
        }
    }
}
