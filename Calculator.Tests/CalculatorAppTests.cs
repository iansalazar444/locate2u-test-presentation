using Calculator.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    public class CalculatorAppTests
    {
        public async Task Divide_WhenValidValuesPassed_ReturnResult()
        {
            // Arrange
            var sut = new CalculatorApp();
            var dividend = 25.0;
            var divisor = 5.0;
            var expectedResult = 5.0;

            // Act
            var result = await sut.Divide(dividend, divisor);
            
            // Assert
            Assert.True(expectedResult == result);
        }
    }
}
