using System;

namespace FizzBuzz
{
    public class Program
    {
        public static string FizzBuzz(int number)
        {
            if (number % 15 == 0)
                return "FizzBuzz";

            if (number % 3 == 0)
                return "Fizz";

            if (number % 5 == 0)
                return "Buzz";

            return number.ToString();
        }

        // FizzBuzz!
        // Output the numbers 1 - 100, except
        // If a number is divisible by 3, output Fizz
        // If a number is divisible by 5, output Buzz
        // If it's divisible by both, output FizzBuzz
        // Otherwise output the number
        static void Main(string[] args)
        {
            // Enumerable.Range(1, 100)
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(FizzBuzz(i));
            }
        }
    }
}
