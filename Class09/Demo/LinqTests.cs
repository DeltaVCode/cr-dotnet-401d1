using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo
{
    public class LinqTests
    {
        [Fact]
        public void Can_map_Book_to_titles()
        {
            // Arrange
            Book[] books = new[]
            {
                new Book {Title = "HP 1"},
                new Book {Title = "HP 2"},
                new Book {Title = "HP 3"},
            };

            // Act
            IEnumerable<string> titles = books.Select(book => book.Title);

            // Assert
            Assert.Equal(new[] { "HP 1", "HP 2", "HP 3" }, titles);
        }

        [Fact]
        public void Can_filter_Book_by_title()
        {
            // Arrange
            Book[] books = new[]
            {
                new Book {Title = "HP 1"},
                new Book {Title = "HP 2"},
                new Book {Title = "HP 3"},
            };

            // Act
            IEnumerable<Book> notOne = books.Where(book => !book.Title.EndsWith("1"));

            // Assert
            Assert.Equal(new[] { books[1], books[2] }, notOne);
        }

        [Fact]
        public void Can_filter_Book_by_title_and_then_select_title()
        {
            // Arrange
            Book[] books = new[]
            {
                new Book {Title = "HP 1"},
                new Book {Title = "HP 2"},
                new Book {Title = "HP 3"},
            };

            // Act
            IEnumerable<Book> booksWithoutOne = books.Where(book => !book.Title.EndsWith("1"));

            IEnumerable<string> titlesWithoutOne = booksWithoutOne.Select(book => book.Title);

            // Assert
            Assert.Equal(new[] { "HP 2", "HP 3" }, titlesWithoutOne);

            // Act
            IEnumerable<string> chaining =
                books
                    .Where(book => !book.Title.EndsWith("1"))
                    .Select(book => book.Title);

            // Assert
            Assert.Equal(new[] { "HP 2", "HP 3" }, chaining);

            // Act
            // now sort them
            IEnumerable<string> reverseOrder = chaining.OrderByDescending(title => title);

            Assert.Equal(new[] { "HP 3", "HP 2" }, reverseOrder);

            // Sort directly
            IEnumerable<string> reverseOrderChaining =
                books
                    .OrderByDescending(book => book.Title)
                    .Select(book => book.Title);

            Assert.Equal(new[] { "HP 3", "HP 2", "HP 1" }, reverseOrderChaining);
        }

        [Fact]
        public void Can_use_query_syntax()
        {
            Book[] books = new[]
            {
                new Book {Title = "HP 1"},
                new Book {Title = "HP 2"},
                new Book {Title = "HP 3"},
            };

            IEnumerable<Book> sortedBooks =
                from book in books
                where !book.Title.EndsWith("1")
                orderby book.Title descending
                select book;

            Assert.Equal(new[] { books[2], books[1] }, sortedBooks);
        }

        [Fact]
        public void Can_group_by_Author()
        {
            Book[] books = new[]
            {
                new Book {Title = "HP 1", Author = "JKR" },
                new Book {Title = "HP 2", Author = "JKR" },
                new Book {Title = "HP 3", Author = "JKR" },
                new Book {Title = "HP 4", Author = "JKR" },
                new Book {Title = "HP 5", Author = "JKR" },
                new Book {Title = "HP 6", Author = "JKR" },
                new Book {Title = "HP 7", Author = "JKR" },
                new Book {Title = "LoTR1", Author = "JRRT" },
                new Book {Title = "LoTR2", Author = "JRRT" },
                new Book {Title = "LoTR3", Author = "JRRT" },
            };

            var booksByAuthor =
                from book in books
                group book by book.Author into authorBooks
                // Grouping { JKR, Books = 1,2,3,5 }
                // Grouping { JRRT, Books = 1,2,3 }
                select new
                {
                    Author = authorBooks.Key, // Thing we grouped by
                    BookCount = authorBooks.Count(),
                    BookTitles = authorBooks.Select(book => book.Title).ToArray(),
                };

            // books.GroupBy(book => book.Author).Select(...)

            var booksByAuthorList = booksByAuthor.ToList();
            Assert.Equal(2, booksByAuthorList.Count);

            Assert.Equal("JKR", booksByAuthorList[0].Author);
            Assert.Equal(7, booksByAuthorList[0].BookCount);

            Assert.Equal("JRRT", booksByAuthorList[1].Author);
            Assert.Equal(3, booksByAuthorList[1].BookCount);
            Assert.Equal(new[] { "LoTR1", "LoTR2", "LoTR3" }, booksByAuthorList[1].BookTitles);
        }

        [Fact]
        public void Can_reduce_numbers_for_sum()
        {
            var numbers = new MyGenericList<int>
            {
                1,1,2,3,5,8,
            };

            // numbers = "oops"; // Not legal even though type was inferred

            int result = numbers.Aggregate(0, (sum, next) => sum + next);

            Assert.Equal(20, result);
        }
    }
}
