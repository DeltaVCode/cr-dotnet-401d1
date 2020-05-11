using System;

namespace Inheritance
{
    public abstract class BirthdayParty : Party
    {
        public override int MaxNumGuests => 100;

        public override decimal Budget => 1000m;

        public virtual bool WatchClown()
        {
            Console.WriteLine("No clowns here.");
            return false;
        }

        // Concrete
        public int PresentCount { get; set; }
        public int OpenPresents()
        {
            return PresentCount;
        }

        public virtual void ReceivePresent(string present)
        {
            Console.WriteLine($"Thanks for {present}!");
            PresentCount++;
        }
    }
}
