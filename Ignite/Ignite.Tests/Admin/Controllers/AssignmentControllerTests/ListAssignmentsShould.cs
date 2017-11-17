using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AssignmentControllerTests
{
    [TestClass]
    public class ListAssignmentsShould
    {
        [TestMethod]
        public void CallGetAllAssignmentsOnce()
        {
            // Arange
            var assignmentServiceMock = new Mock<IAssignmentService>();
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);

            var assignments = new List<Assignment>();

            assignmentServiceMock.Setup(m => m.GetAllAssignments()).Returns(assignments);

            var controller = new AssignmentController(assignmentServiceMock.Object, applicationUserManagerMock.Object);

            // Act
            controller.ListAssignments();

            // Assert
            assignmentServiceMock.Verify(a => a.GetAllAssignments(), Times.Once);
        }

        [TestMethod]
        public void ReturnDefaultViewWithCorrectModel()
        {
            // Arange
            var assignmentServiceMock = new Mock<IAssignmentService>();
            var storeMock = new Mock<IUserStore<ApplicationUser>>();
            var applicationUserManagerMock = new Mock<ApplicationUserManager>(storeMock.Object);

            var assignments = new List<Assignment>();

            assignmentServiceMock.Setup(m => m.GetAllAssignments()).Returns(assignments);

            var expectedModel = new ListAssignmentViewModel()
            {
                Assignments = assignments
            };

            var controller = new AssignmentController(assignmentServiceMock.Object, applicationUserManagerMock.Object);

            // Act & Assert
            controller
                .WithCallTo(c => c.ListAssignments())
                .ShouldRenderDefaultView()
                .WithModel<ListAssignmentViewModel>(m => Assert.AreSame(expectedModel.Assignments, m.Assignments));
        }
    }
}
