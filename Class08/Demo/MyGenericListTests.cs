using System;
using Xunit;
using static System.DayOfWeek;

namespace Demo
{
    public class MyGenericListTests
    {
        [Fact]
        public void Initial_list_is_empty()
        {
            // Arrange

            // Act
            MyGenericList<string> myList = new MyGenericList<string>();

            // Assert
            Assert.Equal(0, myList.Count);
        }

        [Fact]
        public void Can_add_to_empty_list()
        {
            // Arrange
            MyGenericList<int> myList = new MyGenericList<int>();

            // Act
            myList.Add(5);

            // Assert
            Assert.Equal(1, myList.Count);
            Assert.Equal(5, myList[0]);
        }

        [Fact]
        public void Can_add_to_list_beyond_initial_capacity()
        {
            // Arrange
            const int Capacity = 1;
            MyGenericList<int> myList = new MyGenericList<int>(Capacity);
            myList.Add(5);

            // Act
            myList.Add(10);

            // Assert
            Assert.Equal(2, myList.Count);
            Assert.Equal(5, myList[0]);
            Assert.Equal(10, myList[1]);

            // Act
            myList.Add(20);
            myList.Add(40);
            myList.Add(80);

            // Assert
            Assert.Equal(5, myList.Count);
            Assert.Equal(80, myList[4]);
        }


        [Fact]
        public void Can_enumerate_a_list()
        {
            // Behind the scenes, just calls Add()
            MyGenericList<string> myList = new MyGenericList<string>
            {
                "Keith",
                "Craig",
                "Ian",
            };

            foreach (string item in myList)
            {
                Assert.NotNull(item);
            }

            Assert.Equal(
                new[] { "Keith", "Craig", "Ian" },
                myList);
        }

        [Fact]
        public void List_of_Dates()
        {
            MyGenericList<DateTime> nowish = new MyGenericList<DateTime>
            {
                DateTime.Now,
            };

            MyGenericList<DayOfWeek> days = new MyGenericList<DayOfWeek>
            {
                DayOfWeek.Tuesday,
                default(DayOfWeek),
                default,
                Wednesday,
            };

            bool result = days.Remove(default);

            Assert.True(result);
            Assert.Equal(new[] { Tuesday, Sunday, Wednesday }, days);
        }

        [Fact]
        public void Can_remove_from_list_with_null()
        {
            Book book1 = new Book { Title = "HP 1" };
            Book book2 = new Book { Title = "HP 2" };
            MyGenericList<Book> objects = new MyGenericList<Book>
            {
                book1,
                null,
                book2,
            };

            // Act
            bool result = objects.Remove(book2);

            // Assert
            Assert.True(result);
            Assert.Equal(new[] { book1, null }, objects);
        }

        class Book { public string Title { get; set; } }
    }
}
