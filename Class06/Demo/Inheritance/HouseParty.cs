using System;

namespace Inheritance
{
    public class HouseParty : BirthdayParty
    {
        public HouseParty()
        {
            Venue = "House";
        }

        public override void Setup()
        {
            Console.WriteLine("Cleaning up the house");
        }

        public override void Teardown()
        {
            Console.WriteLine("Cleaning up the house");
        }
    }
}
