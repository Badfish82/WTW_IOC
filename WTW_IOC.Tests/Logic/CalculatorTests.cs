using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTW_IOC.Logic.Data;
using WTW_IOC.Logic;
using Xunit;

namespace WTW_IOC.Tests.Logic
{
    public class CalculatorTests
    {
        private Mock<ISampleData> _mockSampleData;

        private ICalculator _calculator;

        public CalculatorTests()
        {
            _mockSampleData = new Mock<ISampleData>();

            _calculator = new Calculator(_mockSampleData.Object);
        }

        [Fact]
        public void Calculator_Add()
        {
            int first = 1, second = 2;

            var result = _calculator.Add(first, second);

            Assert.Equal(3, result);
        }

        [Fact]
        public void Calculator_SubtractM()
        {
            int first = 5, second = 3;

            var result = _calculator.Subtract(first, second);

            Assert.Equal(2, result);
        }

        [Fact]
        public void Calculator_Multiply()
        {
            int first = 10, second = 10;

            var result = _calculator.Multiply(first, second);

            Assert.Equal(100, result);
        }

        [Fact]
        public void Calculator_Divide()
        {
            int first = 100, second = 10;

            var result = _calculator.Divide(first, second);

            Assert.Equal(10, result);
        }
    }
}
