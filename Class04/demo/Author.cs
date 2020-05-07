namespace demo
{
    public class Author
    {
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // Automatic, readonly properties
        public string FirstName { get; }
        public string LastName { get; }
    }
}