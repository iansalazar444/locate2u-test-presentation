using Calculator.ConsoleApp;
using Castle.Core.Logging;
using FluentAssertions;
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
        // Unit - 
        [Theory]
        [InlineData(25.0, 5.0, 5.0)]
        [InlineData(-25.0, 5.0, -5.0)]
        public async Task Divide_WhenValidDataIsPassed_ShouldReturnResult(decimal dividend, decimal divisor, decimal expectedResult)
        {
            // arrange
            // arrange dependencies or the class / method to test
            // SUT system undert test
            // NSubstitute to mock dependencies
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);

            // act
            var result = await sut.Divide(dividend, divisor);

            // assert
            //Assert.Equal( result, expectedResult);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public async Task Divide_WhenValidValueIsPassed_ShouldCallCache()
        {
            // arrange dependencies or the class / method to test
            // SUT system undert test
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal) 5.0;
            // NSubstitute to mock dependencies
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);

            // act
            await sut.Divide(dividend, divisor);

            // assert
            await mockCache.Received(1).Execute(Arg.Any<decimal>());
        }

        [Fact]
        public async Task Divide_WhenDivisorIsZero_ShouldThrowActivityException()
        {
            // arrange dependencies or the class / method to test
            // SUT system undert test
            decimal dividend = (decimal) 25.0;
            decimal divisor = (decimal) 0.0;
            // NSubstitute to mock dependencies
            var mockLogger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(mockLogger, mockCache);

            // act
            var exception = await Record.ExceptionAsync(async () => await sut.Divide(dividend, divisor));

            // assert
            //Assert.IsType<ActivityException>(exception);
            exception.Should().BeOfType<ActivityException>();
            
        }
    
    }
}
