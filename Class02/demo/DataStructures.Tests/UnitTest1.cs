using Xunit;

namespace DataStructures.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void New_list_is_empty()
        {
            // Act
            LinkedList list = new LinkedList();

            // Assert
            Assert.Equal("", list.ToString());
        }

        [Fact]
        public void Can_add_to_list()
        {
            // Arrange
            LinkedList list = new LinkedList();

            // Act
            list.Insert(1);

            // Assert
            Assert.Equal("1", list.ToString());
        }
    }
}
