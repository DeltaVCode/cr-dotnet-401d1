using System;

namespace Inheritance
{
    public class GraduationParty : Party
    {
        public override int MaxNumGuests { get; }

        public override void Setup()
        {
            Console.WriteLine("Setting up for Graduation!");
        }
    }
}
