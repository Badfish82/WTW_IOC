using Moq;
using System.Collections.Generic;
using WTW_IOC.Logic;
using WTW_IOC.Web.Controllers;
using Xunit;

namespace WTW_IOC.Tests.Controllers
{
    public class ValuesControllerTest
    {
        private Mock<ISampleLogic> _mockSampleLogic;

        public ValuesControllerTest()
        {
            _mockSampleLogic = new Mock<ISampleLogic>();
        }

        [Fact]
        public void Get()
        {
            // Arrange
            ValuesController controller = new ValuesController(_mockSampleLogic.Object);

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            _mockSampleLogic.Verify(sl => sl.AddMessage(1,2), Times.Once);
            _mockSampleLogic.Verify(sl => sl.SubtractMessage(5, 3), Times.Once);
            _mockSampleLogic.Verify(sl => sl.MultiplyMessage(99, 99), Times.Once);
            _mockSampleLogic.Verify(sl => sl.DivideMessage(100, 10), Times.Once);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            int val = 5;
            string returnVal = $"1 + {val} = 6";
            ValuesController controller = new ValuesController(_mockSampleLogic.Object);
            _mockSampleLogic.Setup(sl => sl.AddMessage(1, val)).Returns(returnVal);

            // Act
            string result = controller.Get(val);

            // Assert
            _mockSampleLogic.Verify(sl => sl.AddMessage(1, val), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(returnVal, result);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            ValuesController controller = new ValuesController(_mockSampleLogic.Object);

            // Act
            controller.Post("value");

            // Assert
        }

        [Fact]
        public void Put()
        {
            // Arrange
            ValuesController controller = new ValuesController(_mockSampleLogic.Object);

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            ValuesController controller = new ValuesController(_mockSampleLogic.Object);

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
