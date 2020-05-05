using Xunit;

namespace FizzBuzz.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void FizzBuzz_returns_1_given_1()
        {
            // Arrange
            int number = 1;

            // Act
            string result = Program.FizzBuzz(number);

            // Assert
            Assert.Equal("1", result);
        }

        [Fact]
        public void FizzBuzz_returns_2_given_2()
        {
            // Arrange
            int number = 2;

            // Act
            string result = Program.FizzBuzz(number);

            // Assert
            Assert.Equal("2", result);
        }

        [Fact]
        public void FizzBuzz_returns_Fizz_given_3()
        {
            // Arrange
            int number = 3;

            // Act
            string result = Program.FizzBuzz(number);

            // Assert
            Assert.Equal("Fizz", result);
        }

        [Theory]
        // Handle numbers
        [InlineData(4, "4")]
        [InlineData(7, "7")]
        // Handle Buzz
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        // Handle Fizz
        [InlineData(6, "Fizz")]
        [InlineData(15, "FizzBuzz")]
        public void FizzBuzz_returns_expected_for_given_input(int number, string expected)
        {
            // Arrange
            // from parameters

            // Act
            string result = Program.FizzBuzz(number);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        public void FizzBuzz_returns_Buzz_for_divisible_by_5_but_not_4(int number)
        {
            // Arrange
            // from parameters

            // Act
            string result = Program.FizzBuzz(number);

            // Assert
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void FizzBuzz_test_badly()
        {
            Program.FizzBuzz(5);

            // only way for this to fail is an exception
        }
    }
}
