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
        private readonly ICalculatorResultCache _cache;

        public CalculatorApp(ILogger<CalculatorApp> logger, ICalculatorResultCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        public Task<decimal> Divide(decimal dividend, decimal divisor)
        {
            if(divisor == 0)
            {
                throw new ActivityException();
            }
            var result = dividend / divisor;




            _logger.LogInformation("result");
            _cache.Execute(result);

            return Task.FromResult(result);
        }
    }
}
