using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ignite.Services.Contracts;
using Ignite.Controllers;
using TestStack.FluentMVCTesting;
using Ignite.ViewModels;
using System.Collections.Generic;

namespace Ignite.Tests.Controllers.UserCourseControllerTests
{
    [TestClass]
    public class Home_Should
    {
        [TestMethod]
        public void ReturnViewsInOrderOfAssignmentState_WhenParametersAreValid()
        {
            //Arrange
            var username = "Mitko";

            var userSirvice = new Mock<IUserCourseService>();

            var AssignmentPerUser = new AllAssignmentsPerUserViewModels();
            var listOfAssignmentPerUser = new List<AllAssignmentsPerUserViewModels>();
            listOfAssignmentPerUser.Add(AssignmentPerUser.Completed.Add();

            var allAssignments = userSirvice.Setup(a => a.GetAllAssignmentsPerUser(username)).Returns();
            //kolekciq koqto az shte si q suzdam

            //Act
            var controller = new UserCourseController();

            //Assert
            //controller.WithCallTo(c => c.Home("completed"))
            //    .ShouldRenderPartialView("_CompletedCourses")
            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Completed.ToString() == "completed");

            //controller.WithCallTo(c => c.Home("pending")).ShouldRenderPartialView("_CompletedCourses")
            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Pending.ToString() == "pending");

            //controller.WithCallTo(c => c.Home("started")).ShouldRenderPartialView("_CompletedCourses")
            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Started.ToString() == "started");

            //controller.WithCallTo(c => c.Home("overdue")).ShouldRenderPartialView("_CompletedCourses")
            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Overdue.ToString() == "overdue");

        }
        [TestMethod]
        public void ReturnDeafaultView_WhenParametersAreValid()
        {
            //Arrange
            //var username = "Mitko";
            //var state = "unconsciousness";

            ////var userSirvice = new Mock<IUserCourseService>();
            //var allAssignments = userSirvice.Setup(a => a.GetAllAssignmentsPerUser(username).
            //Return(allAssignments));

            //Act
            //var controller = new UserCourseController();

            //Assert
<<<<<<< HEAD
            //controller.WithCallTo(c => c.Home(state)).
            //    ShouldRenderPartialView().
            //    WithModel<AllAssignmentsPerUserViewModels>();
=======
            controller.WithCallTo(c => c.Home()).
                ShouldRenderDefaultView().
                WithModel<AllAssignmentsPerUserViewModels>();
>>>>>>> 65c118282a70587e6a97e6719ce8dbc856d3438c
        }
    }
}
