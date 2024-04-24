using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleApp
{
    public interface ICalculatorApp
    {
        Task<double> Divide(double dividend, double divisor);
    }
    public class CalculatorApp : ICalculatorApp
    {
        private readonly ILogger<CalculatorApp> _logger;

        public CalculatorApp(ILogger<CalculatorApp> logger)
        {
            _logger = logger;
        }

        public Task<double> Divide(double dividend, double divisor)
        {
            _logger.LogInformation($"Divide() called with dividend {dividend} divisor {divisor}");
            var result = dividend / divisor;
            return Task.FromResult(result);
        }
    }
}
