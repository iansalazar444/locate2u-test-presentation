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
        public async Task Divide_WhenGivenValidValues_ThenReturnResult()
        {
            // MethodName_WhenCondition_ThenExpectedBehavior
            // AAA Arrange Act Assert
            // Arrange
            // SUT system under test
            // NSubstitute
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal)5.0;
            decimal expectedResult = (decimal)5.0;
            // Act
            var actual = await sut.Divide(dividend, divisor);

            // Assert
            Assert.Equal(expectedResult, actual);
        }

        [Fact]
        public async Task Divide_WhenValidValuesPassed_ThenStoreToCache()
        {
            // Arrange
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal)5.0;
            decimal expectedResult = (decimal)5.0;
            // Act
            await sut.Divide(dividend, divisor);

            // Assert
            await mockCache.Received(1).Execute(expectedResult);
        }

        //[Fact]
        public async Task Divide_WhenValidValuesPassed_ShouldCallLogger()
        {
            // Arrange
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal)5.0;
            decimal expectedResult = (decimal)5.0;
            // Act
            await sut.Divide(dividend, divisor);

            // Assert
            mockLogger.Received(1).LogInformation(Arg.Any<string>());
        }

        [Fact]
        public async Task Divide_WhenDivisorIsZero_ShouldThrowActivityException()
        {

            // Arrange
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal)0.0;

            // Act
            // await sut.Divide(dividend, divisor);
            var exception = await Record.ExceptionAsync(
                async () => await sut.Divide(dividend, divisor)
                );

            Assert.IsType<ActivityException>(exception);
        }
    }
}
