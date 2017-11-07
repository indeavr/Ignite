using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class HomeGet_Should
    {
        [TestMethod]
        public void ReturnDefaultView()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.Home())
                .ShouldRenderDefaultView();
        }
    }
}
