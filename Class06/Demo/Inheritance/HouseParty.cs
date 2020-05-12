using System;

namespace Inheritance
{
    public class HouseParty : BirthdayParty, IRequireTeardown
    {
        public HouseParty(int age) : base(age)
        {
            Venue = "House";
        }

        public override void Setup()
        {
            Console.WriteLine("Cleaning up the house");
        }

        public void Teardown()
        {
            Console.WriteLine("Cleaning up the house");
        }
    }
}
