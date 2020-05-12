using Xunit;

namespace Inheritance.Tests
{
    public class BarBirthdayPartyTests
    {
        [Fact]
        public void Can_open_presents()
        {
            // Arrange
            BirthdayParty party = new BarBirthdayParty("Here", 25);
            party.ReceivePresent("Gift");

            // Act
            int presentCount = party.OpenPresents();

            // Assert
            Assert.Equal(1, presentCount);
        }

        [Fact]
        public void Can_setup()
        {
            // Arrange
            BirthdayParty party = new BarBirthdayParty("Here", 78);

            // Act
            party.Setup();

            // Assert
            // does not throw
        }

    }
}
