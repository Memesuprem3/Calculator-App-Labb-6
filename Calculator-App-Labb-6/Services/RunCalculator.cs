using Calculator_App_Labb_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_App_Labb_6.Services
{
    public class RunCalculator
    {
        private readonly Calculator _calculator;
        private readonly CalculationHistory _history;
        private readonly TextReader _reader;
        private readonly TextWriter _writer;
        private readonly bool _isTesting;

        public RunCalculator(TextReader reader = null, TextWriter writer = null)
        {
            _calculator = new Calculator();
            _history = new CalculationHistory();
            _reader = reader ?? Console.In;
            _writer = writer ?? Console.Out;
            _isTesting = reader != null && writer != null;
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                if (!_isTesting)
                {
                    Console.Clear();
                }

                _writer.WriteLine("Choose an operation: +, -, *, / or type 'history' to see past calculations or 'exit' to quit:");
                string operation = GetUserInput();

                if (operation == "exit")
                {
                    running = false;
                }
                else if (operation == "history")
                {
                    ShowHistory();
                }
                else
                {
                    PerformCalculation(operation);
                }
            }
        }

        private string GetUserInput()
        {
            return _reader.ReadLine();
        }

        public void ShowHistory()
        {
            foreach (var calc in _history.GetHistory())
            {
                _writer.WriteLine(calc);
            }
        }

        private void PerformCalculation(string operation)
        {
            _writer.WriteLine("Enter the first number:");
            if (!double.TryParse(_reader.ReadLine(), out double num1))
            {
                _writer.WriteLine("Invalid number!");
                return;
            }

            _writer.WriteLine("Enter the second number:");
            if (!double.TryParse(_reader.ReadLine(), out double num2))
            {
                _writer.WriteLine("Invalid number!");
                return;
            }

            double result = 0;
            string calculation = "";

            switch (operation)
            {
                case "+":
                    result = _calculator.Add(num1, num2);
                    calculation = $"{num1} + {num2} = {result}";
                    break;
                case "-":
                    result = _calculator.Subtract(num1, num2);
                    calculation = $"{num1} - {num2} = {result}";
                    break;
                case "*":
                    result = _calculator.Multiply(num1, num2);
                    calculation = $"{num1} * {num2} = {result}";
                    break;
                case "/":
                    try
                    {
                        result = _calculator.Divide(num1, num2);
                        calculation = $"{num1} / {num2} = {result}";
                    }
                    catch (DivideByZeroException ex)
                    {
                        calculation = ex.Message;
                    }
                    break;
                default:
                    _writer.WriteLine("Invalid operation!");
                    return;
            }

            _writer.WriteLine(calculation);
            _history.AddCalculation(calculation);
        }
    }
}