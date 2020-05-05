using Xunit;

namespace Challenges.Tests
{
    public class ArrayShiftTests
    {
        [Fact]
        public void Can_shit_empty_array()
        {
            // Arrange
            int[] input = new int[0];

            // Act
            int[] result = ArrayChallenges.ArrayShift(input);

            // Assert
            // TODO
            Assert.NotNull(result);
        }
    }
}
