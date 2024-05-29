using Calculator_App_Labb_6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_App_Labb_6.Services
{
    public class RunCalculator
    {
        private readonly Calculator _calculator;
        private readonly CalculationHistory _history;


        public RunCalculator()
        {
            _calculator = new Calculator();
            _history = new CalculationHistory();
        }

        public void Start()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Choose an operation: +, -, *, / or type 'history' to see past calculations or 'exit' to quit:");
                string operation = Console.ReadLine();

                if (operation == "exit")
                {
                    running = false;
                    break;
                }
                else if (operation == "history")
                {
                    foreach (var calc in _history.GetHistory())
                    {
                        Console.WriteLine(calc);
                    }
                    continue;
                }

                Console.WriteLine("Enter the first number: ");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number: ");
                double num2 = Convert.ToDouble(Console.ReadLine());

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
                        Console.WriteLine("Invalid operation!");
                        continue;
                }
                Console.Clear();
                Console.WriteLine(calculation);
                _history.AddCalculation(calculation);
            }
        }
    }
}