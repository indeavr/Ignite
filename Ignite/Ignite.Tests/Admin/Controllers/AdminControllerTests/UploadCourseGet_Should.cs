using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class UploadCourseGet_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectModel() 
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            var expectedModel = new UploadJsonModel();
            // Act && Assert

            controller
                .WithCallTo(c => c.UploadCourse())
                .ShouldRenderDefaultView()
                .WithModel<UploadJsonModel>(m => Assert.AreEqual(expectedModel.Json, m.Json));
        }
    }
}
