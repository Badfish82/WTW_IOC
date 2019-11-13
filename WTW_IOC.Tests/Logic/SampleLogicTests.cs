using Moq;
using WTW_IOC.Logic.Data;
using WTW_IOC.Logic;
using Xunit;

namespace WTW_IOC.Tests.Logic
{
    public class SampleLogicTests
    {
        private Mock<ISampleData> _mockSampleData;
        private Mock<ICalculator> _mockCalculator;

        private ISampleLogic _sampleLogic;

        public SampleLogicTests()
        {
            _mockSampleData = new Mock<ISampleData>();
            _mockCalculator = new Mock<ICalculator>();

            _sampleLogic = new SampleLogic(_mockCalculator.Object, _mockSampleData.Object);
        }

        [Fact]
        public void SampleLogic_LoadSampleModel()
        {
            string[] returnVal = new string[] { "1", "2" };
            _mockSampleData.Setup(sd => sd.LoadData()).Returns(returnVal);

            var result = _sampleLogic.LoadSampleModel();

            Assert.NotNull(result);
            Assert.True(returnVal.Length == result.Length);
        }

        [Fact]
        public void SampleLogic_AddMessage()
        {
            int first = 1, second = 2;
            int returnVal = 3;
            _mockCalculator.Setup(c => c.Add(first, second)).Returns(returnVal);

            var result = _sampleLogic.AddMessage(1,2);

            Assert.NotNull(result);
            Assert.Equal($"{first} + {second} = {returnVal}", result);
        }

        [Fact]
        public void SampleLogic_SubtractMessage()
        {
            int first = 5, second = 3;
            int returnVal = 2;
            _mockCalculator.Setup(c => c.Subtract(first, second)).Returns(returnVal);

            var result = _sampleLogic.SubtractMessage(first,second);

            Assert.NotNull(result);
            Assert.Equal($"{first} - {second} = {returnVal}", result);
        }

        [Fact]
        public void SampleLogic_MultiplyMessage()
        {
            int first = 10, second = 10;
            int returnVal = 100;
            _mockCalculator.Setup(c => c.Multiply(first, second)).Returns(returnVal);

            var result = _sampleLogic.MultiplyMessage(first,second);

            Assert.NotNull(result);
            Assert.Equal($"{first} x {second} = {returnVal}", result);
        }

        [Fact]
        public void SampleLogic_DivideMessage()
        {
            int first = 100, second = 10;
            int returnVal = 10;
            _mockCalculator.Setup(c => c.Divide(first, second)).Returns(returnVal);

            var result = _sampleLogic.DivideMessage(first, second);
            Assert.Equal($"{first} % {second} = {returnVal}", result);
        }
    }
}
