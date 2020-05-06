using System;
using System.Linq;

namespace Challenges
{
    public class ArrayChallenges
    {
        public static int[] ArrayReverse(int[] array)
        {
            return array.Reverse().ToArray();
        }

        public static int[] ArrayShift(int[] array, int valueToInsert)
        {
            if (array == null) return null;

            // Wrong:
            // decimal midPoint = array.Length / 2.0m;
            // int midPoint = array.Length / 2;

            // Right:
            // decimal midPoint = Math.Ceiling(array.Length / 2m);
            int midPoint = (array.Length + 1) / 2;

            int[] result = new int[array.Length + 1];

            for (int i = 0; i < result.Length; i++)
            {
                if (i < midPoint)
                {
                    result[i] = array[i];
                }
                else if (i == midPoint)
                {
                    result[i] = valueToInsert;
                }
                else
                {
                    result[i] = array[i - 1];
                }
            }

            return result;
        }

        public static bool BinarySearch(int[] array)
        {
            return false;
        }
    }
}
