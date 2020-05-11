using Xunit;

namespace Inheritance.Tests
{
    public class BarBirthdayPartyTests
    {
        [Fact]
        public void Can_open_presents()
        {
            // Arrange
            BirthdayParty party = new BarBirthdayParty("Here");
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
            BirthdayParty party = new BarBirthdayParty("Here");

            // Act
            party.Setup();

            // Assert
            // does not throw
        }

    }
}
