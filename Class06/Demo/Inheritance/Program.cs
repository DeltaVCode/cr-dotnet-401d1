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


            Party happy21 = new BarBirthdayParty("Quarter Barrel", 25)
            {
                // Venue = "Quarter Barrel",
            };

            LetsHaveAParty(happy21);

            LetsHaveAParty(new HouseParty(8));
            LetsHaveAParty(new GraduationParty());

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
                if (happy21 is IRequireTeardown tearMeDown)
                {
                    // This is how we do this before C# 7
                    // IRequireTeardown tearMeDown = (IRequireTeardown)happy21;
                    tearMeDown.Teardown();

                }
            }
        }

        public static void LetsHaveAParty(Party party)
        {
            try
            {
                party.Setup();

                if (party is IWishYouAHappyBirthday happyBirthday)
                {
                    SingHappyBirthday(happyBirthday);
                }
            }
            finally
            {
                if (party is IRequireTeardown tearMeDown)
                {
                    // This is how we do this before C# 7
                    // IRequireTeardown tearMeDown = (IRequireTeardown)happy21;
                    tearMeDown.Teardown();
                }
            }
        }

        private static void SingHappyBirthday(IWishYouAHappyBirthday bday)
        {
            Console.WriteLine($"Let's sing to the {bday.AgeWeAreCelebrating} year old!");
            Console.WriteLine(bday.HappyBirthday());
            Console.WriteLine("Time to open presents!");
        }
    }
}
