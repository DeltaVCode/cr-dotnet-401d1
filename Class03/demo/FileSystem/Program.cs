using System;
using System.IO;

namespace FileSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void AppendSingleLine(string path, string valueToAppend)
        {
            string[] contentsToAppend = new[] { valueToAppend };
            File.AppendAllLines(path, contentsToAppend);
        }

        public static void RemoveLine(string path, string valueToRemove)
        {
            string[] existingLines = File.ReadAllLines(path);

            string[] result = RemoveItemFromArray(existingLines, valueToRemove);

            File.WriteAllLines(path, result);
        }

        public static string[] RemoveItemFromArray(string[] array, string valueToRemove)
        {
            int valueCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == valueToRemove)
                {
                    valueCount++;
                }
            }
            // valueCount = number of times valueToRemove is in array

            string[] result = new string[array.Length - valueCount];
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (array[i] != valueToRemove)
                {
                    result[j++] = array[i];
                }
            }
            return result;
        }
    }
}
