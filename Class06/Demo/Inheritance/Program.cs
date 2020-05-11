using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Illegal because Party is abstract
            // new Party();
            // new BirthdayParty();

            Party happy21 = new BarBirthdayParty("Quarter Barrel")
            {
                // Venue = "Quarter Barrel",
            };
            try
            {
                happy21.Setup();
                Console.WriteLine($"Will there be cake? {(happy21.HasCake ? "Yes!" : "No!")}");
                // Can't access this because happy21 is Party
                // happy21.OpenPresents()

                Console.WriteLine("How old are you?");
                int age = int.Parse(Console.ReadLine());
                if (happy21.AgeIsAllowed(age))
                {
                    Console.WriteLine("Welcome!");
                    // happy21.ReceivePresent("Booze");
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }
            finally
            {
                happy21.Teardown();
            }
        }
    }
}
