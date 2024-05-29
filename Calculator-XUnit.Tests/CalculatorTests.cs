using Calculator_App_Labb_6.Models;

namespace Calculator_XUnit.Tests
{
    public class CalculatorTests
    {
       private readonly Calculator _calculator = new Calculator();

        [Theory]
        [InlineData(1,2,3)]
        [InlineData(-1,-1,-2)]
        [InlineData(0,0,0)]
        [InlineData(100,200,300)]
        [InlineData(-50,50,0)]
        public void Add_ReturnsCorrenctResult(double a, double b, double expected)
        {
            var result = _calculator.Add(a, b);
            Assert.Equal(expected, result);
        }



    }
}