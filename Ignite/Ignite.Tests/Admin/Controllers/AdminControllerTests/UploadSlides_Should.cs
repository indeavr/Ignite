using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class UploadSlides_Should
    {
        [TestMethod]
        public void ReturnDefaultView()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.UploadSlides(It.IsAny<int>()))
                .ShouldRenderDefaultView();
        }

        [TestMethod]
        public void FillViewBagWithCorrectCourseId()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            var expectedValue = 99;

            // Act && Assert
            Assert.AreEqual(expectedValue,
                controller.WithCallTo(c => c.UploadSlides(expectedValue)).Controller.ViewBag.courseId);
        }
    }
}
