using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Compression.Helpers
{
    public class FileAssistant
    {
        public static string ReadFile(string fileName)
        {
            string fileBuffer = "";

            try
            {
                using (StreamReader stream = new StreamReader(fileName))
                {
                     fileBuffer = stream.ReadToEnd();
                }
            }
            catch(FileNotFoundException e)
            {
                Console.WriteLine("Could not load a specified file.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception occured while reading a file " + fileName);
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("Stack trace: " + e.StackTrace);
            }

            return fileBuffer;
        }

        public static bool WriteFile(string fileName, string fileContent)
        {
            bool ret = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(fileContent);
                }

                ret = true;
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Could not load a specified file.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured while writing to file " + fileName);
                Console.WriteLine("Message: " + e.Message);
                Console.WriteLine("Stack trace: " + e.StackTrace);
            }

            return ret;
        }
    }
}
