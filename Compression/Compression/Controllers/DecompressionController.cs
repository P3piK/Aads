using Compression.Dto;
using Compression.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compression.Controllers
{
    public class DecompressionController
    {
        public static void PerformDecompression(CompressionDto compressionDto, bool writeOutputToFile)
        {
            DecompressionDto decompressionDto = new DecompressionDto();
            foreach(var step in compressionDto.compressionSteps)
            {
                if (!IsDecompressedWordEmpty(decompressionDto))
                {
                    DecompressWordStep(decompressionDto, step);
                }
                else
                {
                    decompressionDto.DecompressedWord += compressionDto.FirstLetter;
                }

                if(writeOutputToFile)
                {
                    FileAssistant.WriteFile(Program.WRITE_FILE_NAME, decompressionDto.DecompressedWord);
                }

                View.PrintDecompressionStage(decompressionDto);
            }
        }

        private static void DecompressWordStep(DecompressionDto decompressionDto, CommonTranslatorDto step)
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

        private static bool IsDecompressedWordEmpty(DecompressionDto decompressionDto)
        {
            return decompressionDto.DecompressedWord.Equals(String.Empty);
        }
    }
}
