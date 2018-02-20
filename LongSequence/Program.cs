using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LongSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var sequence = ReadSequence("input.txt");
                var length = GetTheLongestSequenceOfOnesLength(sequence);
                Console.WriteLine(length);
                Console.ReadKey();
            }
            catch (IOException)
            {
                Console.WriteLine("Error ocured while opening the file");
            }
        }

        static string ReadSequence(string filePath)
        {
            var inputStream = new FileStream(filePath, FileMode.Open);
            StreamReader reader = new StreamReader(inputStream);
            return reader.ReadLine();
        }

        static int GetTheLongestSequenceOfOnesLength(string sequence)
        {
            var maxLength = 0;
            var currrentLength = 0;
            foreach(var digit in sequence)
            {
                if (String.Equals('1', digit))
                {
                    currrentLength++;
                }
                else if(String.Equals('0',digit))
                {
                    maxLength = Math.Max(currrentLength, maxLength);
                    currrentLength = 0;
                }
            }
            return maxLength;
        }
    }
}
