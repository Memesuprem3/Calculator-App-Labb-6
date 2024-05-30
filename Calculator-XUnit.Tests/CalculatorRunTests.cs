using Calculator_App_Labb_6.Models;
using Calculator_App_Labb_6.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_XUnit.Tests
{
    public class RunCalculatorTests
    {


        [Fact]
        [Description("Test addition of two numbers.")]
        public void Test_Addition()
        {
            // Arrange
            using var reader = new StringReader("+" + Environment.NewLine + "5" + Environment.NewLine + "3" + Environment.NewLine + "exit" + Environment.NewLine);
            using var writer = new StringWriter();
            var runCalculator = new RunCalculator(reader, writer);

            // Act
            runCalculator.Start();
            var output = writer.ToString();

            // Assert
            Assert.Contains("5 + 3 = 8", output);
        }

        [Fact]
        [Description("Test subtraction of two numbers.")]
        public void Test_Subtraction()
        {
            // Arrange
            using var reader = new StringReader("-" + Environment.NewLine + "5" + Environment.NewLine + "3" + Environment.NewLine + "exit" + Environment.NewLine);
            using var writer = new StringWriter();
            var runCalculator = new RunCalculator(reader, writer);

            // Act
            runCalculator.Start();
            var output = writer.ToString();

            // Assert
            Assert.Contains("5 - 3 = 2", output);
        }

        [Fact]
        [Description("Test multiplication of two numbers.")]
        public void Test_Multiplication()
        {
            // Arrange
            using var reader = new StringReader("*" + Environment.NewLine + "5" + Environment.NewLine + "3" + Environment.NewLine + "exit" + Environment.NewLine);
            using var writer = new StringWriter();
            var runCalculator = new RunCalculator(reader, writer);

            // Act
            runCalculator.Start();
            var output = writer.ToString();

            // Assert
            Assert.Contains("5 * 3 = 15", output);
        }

        [Fact]
        [Description("Test division of two numbers.")]
        public void Test_Division()
        {
            // Arrange
            using var reader = new StringReader("/" + Environment.NewLine + "6" + Environment.NewLine + "3" + Environment.NewLine + "exit" + Environment.NewLine);
            using var writer = new StringWriter();
            var runCalculator = new RunCalculator(reader, writer);

            // Act
            runCalculator.Start();
            var output = writer.ToString();

            // Assert
            Assert.Contains("6 / 3 = 2", output);
        }

        [Fact]
        [Description("Test division by zero throws exception.")]
        public void Test_Division_ByZero()
        {
            // Arrange
            using var reader = new StringReader("/" + Environment.NewLine + "6" + Environment.NewLine + "0" + Environment.NewLine + "exit" + Environment.NewLine);
            using var writer = new StringWriter();
            var runCalculator = new RunCalculator(reader, writer);

            // Act
            runCalculator.Start();
            var output = writer.ToString();

            // Assert
            Assert.Contains("Division by zero is not allowed.", output);
        }

        [Fact]
        [Description("Test that the calculation history contains values.")]
        public void Test_History()
        {
            // Arrange
            var history = new CalculationHistory();

            // Act
            var calculations = history.GetHistory();

            // Assert
            Assert.Contains("5 + 3 = 8", calculations);
            Assert.Contains("10 - 4 = 6", calculations);
            Assert.Contains("2 * 3 = 6", calculations);
        }

    }
}