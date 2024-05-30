using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_App_Labb_6.Models
{
    public class CalculationHistory
    {
        private List<string> _history = new List<string>
        {
             "5 + 3 = 8",
            "10 - 4 = 6",
            "2 * 3 = 6"

        };

        public void AddCalculation(string calculation)
        {
            _history.Add(calculation);
        }

        public IEnumerable<string> GetHistory()
        {
            Console.WriteLine("Calculation History:");
            return _history;

        }
    }
}
