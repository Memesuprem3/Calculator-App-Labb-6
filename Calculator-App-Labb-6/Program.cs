using Calculator_App_Labb_6.Services;

namespace Calculator_App_Labb_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunCalculator runCalculator = new RunCalculator();
            runCalculator.Start();
        }
    }
}
