using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AssignmentControllerTests
{
    [TestClass]
    public class ManageAssignments_Should
    {
        [TestMethod]
        public void ReturnDefaultView()
        {
            // Arange
            var assignmentServiceMock = new Mock<IAssignmentService>();
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);

            var controller = new AssignmentController(assignmentServiceMock.Object, applicationUserManagerMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.ManageAssignments())
                .ShouldRenderDefaultView();
        }
    }
}
