using System;

namespace Inheritance
{
    public class BarBirthdayParty : BirthdayParty
    {
        public BarBirthdayParty(string venue)
        {
            Venue = venue;
        }

        public override bool HasCake => false;

        public override void Setup()
        {
            Console.WriteLine("Go to a bar.");
        }

        public override bool AgeIsAllowed(int age)
        {
            return age >= 18;
        }
    }
}
