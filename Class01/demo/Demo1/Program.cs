using System;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Keith says \n");
            Console.WriteLine("Hello World!");

            // Create a new instance
            Random random = new Random();
            // Call an instance method
            int nextNumber = random.Next();
            // Call static WriteLine method with variable
            Console.WriteLine(nextNumber);

            Console.WriteLine("What's your name? ");
            Console.Write("> ");
            string name = Console.ReadLine();
            Console.WriteLine($"Your name is {name}");

            int favNumber = PromptForFavoriteNumber(random);
            Console.WriteLine($"Your favorite number is {favNumber}");

        }

        private static int PromptForFavoriteNumber(Random random)
        {
            while (true)
            {
                try
                {
                    Console.Write("What's your favorite number?");
                    int favNumber = int.Parse(Console.ReadLine());
                    // int favNumber = checked((int)long.Parse(Console.ReadLine()));
                    // or Convert.ToInt32()
                    return favNumber;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Error: number is too big. Picking a random one instead!");
                    return random.Next();
                }
                catch (FormatException fex)
                {
                    Console.Write("Error: " + fex.Message);
                    Console.WriteLine(" Try again!");
                }
                //catch (Exception ex)
                //{
                //    Console.WriteLine("Something unexpected happened! " + ex.Message);
                //}
            }
        }

        bool IsPositive(int number)
        {
            if (number > 0)
            {
                return true;
            }

            return false;
        }
    }
}
