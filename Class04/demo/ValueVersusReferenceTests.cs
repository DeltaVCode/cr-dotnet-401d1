using Xunit;

namespace demo
{
    public class ValueVersusReferenceTests
    {
        [Fact]
        public void Classes_copy_by_reference()
        {
            Book book1 = new Book("Jungle", new Author("Baloo", "the Bear"));

            Book book2 = book1;
            book2.Publisher = "Disney";

            Assert.Equal("Disney", book2.Publisher);

            Assert.Equal("Disney", book1.Publisher);

            Assert.True(object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void Structs_copy_by_value()
        {
            StructAuthor a0 = new StructAuthor();
            Assert.Null(a0.FirstName);
            Assert.Null(a0.LastName);

            StructAuthor a1 = new StructAuthor
            {
                FirstName = "Keith",
                LastName = "Dahlby",
            };

            StructAuthor a2 = a1;

            a2.LastName = "Smith";

            Assert.Equal("Smith", a2.LastName);

            Assert.Equal("Dahlby", a1.LastName);
        }
    }

    // Value Type
    public struct StructAuthor
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
