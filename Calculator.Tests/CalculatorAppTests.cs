using Calculator.ConsoleApp;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    public class CalculatorAppTests
    {
        [Fact]
        public async Task Divide_WhenValidValuesPassed_ReturnResult()
        {
            // Arrange
            var logger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(logger, mockCache);

            var dividend = 25.0;
            var divisor = 5.0;
            var expectedResult = 5.0;

            // Act
            var result = await sut.Divide(dividend, divisor);
            
            // Assert
            Assert.True(expectedResult == result);
        }

        [Fact]
        public async Task Divide_WhenValidValuesPassed_StoreResultCache()
        {
            // Arrange
            var logger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();

            var sut = new CalculatorApp(logger, mockCache);


            // Act
            await sut.Divide(1.0, 1.0);

            await mockCache.Received(1).Execute(Arg.Any<double>());
        }

        [Fact]
        public async Task Divide_WhenDivisorIsZero_ThrowDivisionByZeroExceDivideByZeroException()
        {
            var logger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();

            var sut = new CalculatorApp(logger, mockCache);

            // Act
            var exception = await Record.ExceptionAsync(async () => await sut.Divide(1.0, 0));

            // Assert
            Assert.IsType<DivideByZeroException>(exception);
        }
    }
}
