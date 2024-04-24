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
        private readonly ICalculatorResultCache _cache;

        public CalculatorApp(
            ILogger<CalculatorApp> logger,
            ICalculatorResultCache cache
            )
        {
            _logger = logger;
            _cache = cache;
        }

        public Task<double> Divide(double dividend, double divisor)
        {
            _logger.LogInformation($"Divide() called with dividend {dividend} divisor {divisor}");
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            var result = Math.Round(dividend / divisor, 2);
            _cache.Execute(result);
            return Task.FromResult(result);
        }
    }
}
