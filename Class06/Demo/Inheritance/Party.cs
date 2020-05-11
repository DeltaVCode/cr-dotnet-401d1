namespace Inheritance
{
    public abstract class Party
    {
        // Properties
        public abstract int MaxNumGuests { get; }
        public virtual decimal Budget { get; } = 0;

        public string Venue { get; protected set; }

        public virtual bool HasCake => true;
        // public virtual bool HasCake { get { return true; } }

        public virtual bool AgeIsAllowed(int age)
        {
            return true;
        }

        // Methods
        public abstract void Setup();

        public virtual void Teardown()
        {
            // No cleanup required
        }
    }
}
