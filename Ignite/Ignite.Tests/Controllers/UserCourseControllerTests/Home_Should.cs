//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Ignite.Services.Contracts;
//using Ignite.Controllers;
//using TestStack.FluentMVCTesting;
//using Ignite.ViewModels;

//namespace Ignite.Tests.Controllers.UserCourseControllerTests
//{
//    [TestClass]
//    public class Home_Should
//    {
//        [TestMethod]
//        public void ReturnViewsInOrderOfAssignmentState_WhenParametersAreValid()
//        {
//            //Arrange
//            var username = "Mitko";

//            var userSirvice = new Mock<IUserCourseService>();
//            var allAssignments = userSirvice.Setup(a => a.GetAllAssignmentsPerUser(username));


//            //Act
//            var controller = new UserCourseController();

//            //Assert
//            //controller.WithCallTo(c => c.Home("completed"))
//            //    .ShouldRenderPartialView("_CompletedCourses")
//            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Completed.ToString() == "completed");

//            //controller.WithCallTo(c => c.Home("pending")).ShouldRenderPartialView("_CompletedCourses")
//            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Pending.ToString() == "pending");

//            //controller.WithCallTo(c => c.Home("started")).ShouldRenderPartialView("_CompletedCourses")
//            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Started.ToString() == "started");

//            //controller.WithCallTo(c => c.Home("overdue")).ShouldRenderPartialView("_CompletedCourses")
//            //    .WithModel<AllAssignmentsPerUserViewModels>(a => a.Overdue.ToString() == "overdue");

//        }
//        [TestMethod]
//        public void ReturnDeafaultView_WhenParametersAreValid()
//        {
//            ////Arrange
//            //var username = "Mitko";
//            //var state = "unconsciousness";

//            //var userSirvice = new Mock<IUserCourseService>();
//            //var allAssignments = userSirvice.Setup(a => a.GetAllAssignmentsPerUser(username));

//            ////Act
//            //var controller = new UserCourseController();

//            ////Assert
//            //controller.WithCallTo(c => c.Home()).
//            //    ShouldRenderDefaultView().
//            //    WithModel<AllAssignmentsPerUserViewModels>();
//        }
//    }
//}
