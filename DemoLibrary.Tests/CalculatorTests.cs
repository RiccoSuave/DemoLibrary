using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary;
using Xunit;

namespace DemoLibrary.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(4,3,7)]
        [InlineData(21, 5.25, 26.25)]
        [InlineData(double.MaxValue,5,double.MaxValue)]
        [InlineData(double.MinValue, -1, double.MinValue)]
        public void Add_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange
            //double expected = 5;
            // Act 
            double actual = Calculator.Add(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }
        [Theory]
        [InlineData(6,3,2)]
        [InlineData(6,0,0)]
        public void Divide_SimpleValuesShouldCalculate(double x, double y, double expected)
        {
            // Arrange

            // Act
            double actual = Calculator.Divide(x, y);
            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
