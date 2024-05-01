using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleApp
{
    public class CalculatorApp
    {
        private readonly ILogger<CalculatorApp> _logger;
        private readonly ICalculatorResultCache _calculatorResultCache;

        public CalculatorApp(ILogger<CalculatorApp> logger, ICalculatorResultCache cache)
        {
            _logger = logger;
            _calculatorResultCache = cache;
        }

        public async Task<decimal> Divide(decimal dividend, decimal divisor)
        {
            // do some normal division
            if (divisor == 0)
            {
                throw new ActivityException();
            }
            var result = dividend / divisor;
            await _calculatorResultCache.Execute(result);

            return result;
        }
    }
}
