using Calculator_App_Labb_6.Models;
using Calculator_App_Labb_6.Services;
using System.ComponentModel;

namespace Calculator_XUnit.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator = new Calculator();

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -1, -2)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 200, 300)]
        [InlineData(-50, 50, 0)]
        [Description("Test addition of two numbers with various inputs.")]
        public void Add_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange

            // Act
            var result = _calculator.Add(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3, 2, 1)]
        [InlineData(-1, -1, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(200, 100, 100)]
        [InlineData(50, -50, 100)]
        [Description("Test subtraction of two numbers with various inputs.")]
        public void Subtract_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange

            // Act
            var result = _calculator.Subtract(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(-1, -1, 1)]
        [InlineData(0, 10, 0)]
        [InlineData(100, 200, 20000)]
        [InlineData(-5, 5, -25)]
        [Description("Test multiplication of two numbers with various inputs.")]
        public void Multiply_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange

            // Act
            var result = _calculator.Multiply(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(6, 2, 3)]
        [InlineData(-4, -2, 2)]
        [InlineData(10, 2.5, 4)]
        [InlineData(100, 25, 4)]
        [InlineData(9, 3, 3)]
        [Description("Test division of two numbers with various inputs.")]
        public void Divide_ReturnsCorrectResult(double a, double b, double expected)
        {
            // Arrange

            // Act
            var result = _calculator.Divide(a, b);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Description("Test that dividing by zero throws a DivideByZeroException.")]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange

            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }
    }
}