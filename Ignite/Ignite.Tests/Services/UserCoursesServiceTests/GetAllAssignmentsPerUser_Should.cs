<<<<<<< HEAD
﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.ViewModels;
using Moq;
using Ignite.Data;
using Ignite.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using Ignite.Data.Enums;
using Ignite.Services.Contracts;
using Ignite.Services;
using System.Linq;
using Ignite.Areas.Admin.ViewModels.statistics;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class GetAllAssignmentsPerUser_Should
    {
        [TestMethod]
        public void GetAllAssignmentsPerUser()    
        {
            //arrange
            var username = "User";
            var allAssignments = new Mock<AllAssignmentsPerUserViewModels>();
            var context = new Mock<ApplicationDbContext>();

            var usersCollection = new List<ApplicationUser>();

            var assignments = new List<Assignment>();

            var courseName = new Course() { Name = username };

            assignments.Add(new Assignment() { State = AssignmentState.Started, Course = courseName });
            assignments.Add(new Assignment() { State = AssignmentState.Pending, Course = courseName });
            assignments.Add(new Assignment() { State = AssignmentState.Completed, Course = courseName });
            assignments.Add(new Assignment() { State = AssignmentState.Overdue, Course = courseName });

            var user = new ApplicationUser() { UserName = username, Assignments = assignments};

            usersCollection.Add(user);

            var userDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersCollection);
            context.SetupGet(u => u.Users).Returns(userDbSetMock.Object);

            var userCourseService = new UserCoursesService(context.Object);

            //act
            var actualResult = userCourseService.GetAllAssignmentsPerUser(username);

            //assert
            Assert.AreEqual(1, actualResult.Started.Count);
            Assert.AreEqual(1, actualResult.Pending.Count);
            Assert.AreEqual(1, actualResult.Completed.Count);
            Assert.AreEqual(1, actualResult.Overdue.Count);

        }
    }
}
=======
﻿//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Ignite.ViewModels;
//using Moq;
//using Ignite.Data;
//using Ignite.Data.Models;
//using System.Collections.Generic;
//using System.Data.Entity;
//using Ignite.Data.Enums;
//using Ignite.Services.Contracts;
//using Ignite.Services;
//using System.Linq;

//namespace Ignite.Tests.Services.UserCoursesServiceTests
//{
//    [TestClass]
//    public class GetAllAssignmentsPerUser_Should
//    {
//        [TestMethod]
//        public void GetAllAssignmentsPerUser()    
//        {
//            //arrange
//            var username = "User";
//            var allAssignments = new AllAssignmentsPerUserViewModels();
//            var context = new Mock<ApplicationDbContext>();

//            var usersCollection = new List<ApplicationUser>();

//            var assignments = new List<DisplayAssignmentsViewModel>();

//            //assignments.Add(new DisplayAssignmentsViewModel() { State = AssignmentState.Started,
//            //    Course = new Course() { Name = "Gincho" } });

//            //assignments.Add(new DisplayAssignmentsViewModel() { State = AssignmentState.Pending,
//            //    Course = new Course() { Name = "Gincho" } });

//            //assignments.Add(new DisplayAssignmentsViewModel() { State = AssignmentState.Completed,
//            //    Course = new Course() { Name = "Gincho" } });

//            //assignments.Add(new DisplayAssignmentsViewModel() { State = AssignmentState.Overdue,
//            //    Course = new Course() { Name = "Gincho" } });


//            var user = new ApplicationUser() { UserName = username, Assignments = assignments };

//            usersCollection.Add(user);

//            var userDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(usersCollection);
//            context.SetupGet(u => u.Users).Returns(userDbSetMock.Object);


//            var userCourseService = new UserCoursesService(context.Object);

//            //act
//            var actualResult = userCourseService.GetAllAssignmentsPerUser(username);

//            //assert
//            Assert.AreEqual(1, actualResult.Started.Count);
//            Assert.AreEqual(1, actualResult.Pending.Count);
//            Assert.AreEqual(1, actualResult.Completed.Count);
//            Assert.AreEqual(1, actualResult.Overdue.Count);

//            Assert.AreEqual(AssignmentState.Started, actualResult.Started.First().State);
//            Assert.AreEqual(AssignmentState.Pending, actualResult.Pending.First().State);
//            Assert.AreEqual(AssignmentState.Completed, actualResult.Completed.First().State);
//            Assert.AreEqual(AssignmentState.Overdue, actualResult.Overdue.First().State);
//        }
//    }
//}
>>>>>>> 055679a8517f8d032d5cc5755e1c937de411e696
