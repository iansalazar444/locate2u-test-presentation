﻿using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ConsoleApp
{
    public interface ICalculatorResultCache
    {
        Task Execute(double result);
    }
    public class CalculatorResultCache: ICalculatorResultCache
    {
        private readonly ILogger<CalculatorResultCache> _logger;

        public CalculatorResultCache(ILogger<CalculatorResultCache> logger)
        {
            _logger = logger;
        }

        public Task Execute(double result)
        {
            // THink Think of this as a third party dependency
            return Task.FromResult(0);
        }
    }
}
