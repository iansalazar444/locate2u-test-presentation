using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleApp
{
    public interface ICalculatorApp
    {
        Task<float> Divide(double dividend, double divisor);
    }
    public class CalculatorApp : ICalculatorApp
    {
        public Task<float> Divide(double dividend, double divisor)
        {
            throw new NotImplementedException();
        }
    }
}
