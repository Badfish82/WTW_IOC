using Moq;
using System.Web.Mvc;
using WTW_IOC.Logic.Logic;
using WTW_IOC.Web.Controllers;
using Xunit;

namespace WTW_IOC.Tests.Controllers
{
    public class HomeControllerTest
    {
        private Mock<ISampleLogic> _mockSampleLogic;

        public HomeControllerTest()
        {
            _mockSampleLogic = new Mock<ISampleLogic>();
        }

        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(_mockSampleLogic.Object);

            // Act
            ContentResult result = controller.Index() as ContentResult;

            // Assert
            _mockSampleLogic.Verify(sl => sl.AddMessage(1, 2), Times.Once);
            _mockSampleLogic.Verify(sl => sl.SubtractMessage(10, 7), Times.Once);
            _mockSampleLogic.Verify(sl => sl.MultiplyMessage(10000, 5), Times.Once);
            _mockSampleLogic.Verify(sl => sl.DivideMessage(2000, 2), Times.Once);
            Assert.NotNull(result);
        }
    }
}
