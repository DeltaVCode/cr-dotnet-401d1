using Xunit;

namespace Challenges.Tests
{
    public class ArrayShiftTests
    {
        [Fact]
        public void Can_shift_into_even_length()
        {
            // Arrange
            int[] input = new[] { 1, 2, 4, 5 };

            // Act
            int[] result = ArrayChallenges.ArrayShift(input, 3);

            // Assert
            Assert.Equal(new[] { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void Can_shift_into_odd_length()
        {
            // Arrange
            int[] input = new[] { 1, 2, 3, 5, 6 };

            // Act
            int[] result = ArrayChallenges.ArrayShift(input, 4);

            // Assert
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, result);
        }

        [Theory]
        [InlineData(1, new int[0], new[] { 1 })] // Even (Zero)
        [InlineData(2, new int[0], new[] { 2 })]
        [InlineData(3, new int[] { 2 }, new[] { 2, 3 })] // Odd (1)
        [InlineData(3, new int[] { 2, 4 }, new[] { 2, 3, 4 })] // Even (2)
        [InlineData(4, new int[] { 1, 2, 3, 5, 6 }, new[] { 1, 2, 3, 4, 5, 6 })] // Odd (5)
        public void Can_shift(int value, int[] input, int[] expected)
        {
            // Arrange
            // from parameters

            // Act
            int[] result = ArrayChallenges.ArrayShift(input, value);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Returns_null_given_null()
        {
            int[] result = ArrayChallenges.ArrayShift(null, 1);

            Assert.Null(result);
        }
    }
}
