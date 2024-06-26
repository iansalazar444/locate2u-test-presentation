﻿using Calculator.ConsoleApp;
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
        [Theory]
        [InlineData(25.0, 5.0, 5.0)]
        [InlineData(10.0, 3.0, 3.33)]
        [InlineData(-10.0, 3.0, -3.33)]
        public async Task Divide_WhenValidValuesPassed_ReturnResult(double dividend, double divisor, double expectedResult)
        {
            // Arrange
            var logger = Substitute.For<ILogger<CalculatorApp>>();
            var mockCache = Substitute.For<ICalculatorResultCache>();
            var sut = new CalculatorApp(logger, mockCache);

            // Act
            var result = await sut.Divide(dividend, divisor);

            // Assert
            // Assert.Equal(expectedResult, result);
            result.Should().Be(expectedResult);
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
            //Assert.IsType<DivideByZeroException>(exception);
            exception.Should().BeOfType<DivideByZeroException>();
        }
    }
}
