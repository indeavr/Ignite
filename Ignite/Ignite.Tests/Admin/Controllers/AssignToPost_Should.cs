using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers
{
    [TestClass]
    public class AssignToPost_Should
    {
        [TestMethod]
        public void RedirectToAction()
        {
            // Assert
            var courseModel = new CourseNameViewModel();
            var serviceMock = new Mock<IAssignmentService>();

            var userStore = new Mock<IUserStore<ApplicationUser>>();
            var userManagerMock = new Mock<ApplicationUserManager>(userStore.Object);

            var controller = new AssignmentController(serviceMock.Object, userManagerMock.Object);
            // Act && Assert
            controller
                .WithCallTo(c => c.AssignTo(courseModel))
                .ShouldRedirectTo<AdminController>(r => r.Home());

        }
    }
}
