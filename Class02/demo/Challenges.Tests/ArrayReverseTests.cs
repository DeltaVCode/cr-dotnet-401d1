using Xunit;

namespace Challenges.Tests
{
    public class ArrayReverseTests
    {
        [Fact]
        public void Can_reverse_empty_array()
        {
            // Arrange
            int[] input = new int[0];

            // Act
            int[] result = ArrayReverse.ArrayReverse(input);

            // Assert
            Assert.Empty(result);

            // Not in-place reversal
            Assert.NotSame(input, result);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
        [InlineData(new[] { 1, 2, 3, 4 }, new[] { 4, 3, 2, 1 })]
        public void Can_reverse_array_of_numbers(int[] input, int[] expected)
        {
            // Arrange
            // from input

            // Act
            int[] result = ArrayReverse.ArrayReverse(input);

            // Assert
            Assert.Equal(expected, result);

            // Not in-place reversal
            Assert.NotSame(input, result);
        }
    }
}
