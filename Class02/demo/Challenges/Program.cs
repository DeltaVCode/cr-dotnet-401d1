using System;
using System.Linq;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] empty = new int[0];
            int[] emptyReversed = ArrayReverse(empty);
            Console.WriteLine("Empty reversed length: {0}", emptyReversed.Length);

            int[] notEmpty = new int[] { 1, 2, 3 };
            int[] notEmptyReversed = ArrayReverse(notEmpty);
            Console.WriteLine("Not empty reversed: {0}", string.Join(",", notEmptyReversed));
        }

        static int[] ArrayReverse(int[] array)
        {
            return array.Reverse().ToArray();
        }
    }
}
