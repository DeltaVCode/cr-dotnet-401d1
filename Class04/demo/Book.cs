using System;
using Xunit;

namespace demo
{
    /*
    function Book(title) {
        this.title = title;
    }
    */
    class Book
    {
        // Static Fields
        private static int bookCount = 0;

        // Static Properties
        public static int BookCount => bookCount;
        // public static int BookCount { get { return bookCount; } }

        // Fields
        private readonly string title;
        private Author author;

        public Book(string title, Author bookAuthor)
        {
            this.title = title;

            if (bookAuthor == null)
                throw new ArgumentNullException(nameof(bookAuthor));
            this.author = bookAuthor;

            bookCount++;
        }

        // Properties
        public string Title
        {
            get { return title; }
        }

        public Author Author
        {
            get { return author; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                author = value;
            }
        }

        // Automatic, not readonly
        public string Publisher { get; set; }

        // Methods

        // In Java we might do this instead of a Property
        public string GetTitle()
        {
            return title;
        }

        public void LogTitle()
        {
            Console.WriteLine(title);
        }

        /// <summary>
        /// This formats book and author as "title, author"
        /// </summary>
        /// <returns>The formated string</returns>
        public string FormatBookAndAuthor()
        {
            return $"{title}, by {Author.FirstName} {Author.LastName}";
        }

        // Overload of FormatBookAndAuthor() method
        public string FormatBookAndAuthor(bool showPublisher)
        {
            if (showPublisher)
            {
                return "...";
            }
            else
            {
                return FormatBookAndAuthor();
            }
        }
    }

    public class BookTests
    {
        [Fact]
        public void Can_construct_a_Book()
        {
            Author author = new Author("Joseph", "Albahari");
            Book book = new Book("C# 7.0 in a Nutshell", author);
            Assert.NotNull(book);

            // book.title = "C# 8.0"; // Can't! Private!
            Assert.Equal("C# 7.0 in a Nutshell", book.GetTitle());

            Assert.Equal("C# 7.0 in a Nutshell", book.Title);

            Assert.Equal("Joseph", book.Author.FirstName);


            Assert.Equal(
                "C# 7.0 in a Nutshell, by Joseph Albahari",
                book.FormatBookAndAuthor());

            // Assert.Equal(1, Book.BookCount);
        }

        [Fact]
        public void Can_change_Author()
        {
            // Arrange
            Author author = new Author("Joseph", "Albahari");
            Book book = new Book("C# 7.0 in a Nutshell", author);

            // Act
            book.Author = new Author("Ben", "Albahari");

            // Assert
            Assert.Equal("Ben", book.Author.FirstName);
            Console.WriteLine(Book.BookCount);
        }

        [Fact]
        public void Cannot_set_Author_to_null()
        {
            Author author = new Author("Can't touch", "this");
            Book book = new Book("Hammer Time", author);
            Console.WriteLine(Book.BookCount);

            Assert.Throws<ArgumentNullException>(() =>
            {
                book.Author = null;
            });

            // This works, but it's kind of gross
            try
            {
                book.Author = null;
                throw new Exception("Test should have failed!");
            }
            catch (ArgumentNullException)
            {
                // Yay!
            }
        }

        [Fact]
        public void Can_set_Publisher()
        {
            Author author = new Author("Keith", "Dahlby");

            Book book = new Book("Git is Cool", author)
            {
                Publisher = "Keith Dahlby", // Object Initializer
            };

            Assert.Equal("Keith Dahlby", book.Publisher);

            book.Publisher = "Keith E Dahlby";

            Assert.Equal("Keith E Dahlby", book.Publisher);
        }
    }
}
