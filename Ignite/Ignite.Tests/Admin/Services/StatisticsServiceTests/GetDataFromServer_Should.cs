using Ignite.Areas.Admin.Services;
using Ignite.Areas.Admin.ViewModels.statistics;
using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Admin.Services.StatisticsServiceTests
{
    [TestClass]
    public class GetDataFromServer_Should
    {
        [TestMethod]
        public void ReturnObjectWithFilledProperties()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var gridServices = new StatisticsService(dbMock.Object);

            var user = new ApplicationUser() { UserName = "das", Id = "1" };
            var page = 1;
            var rows = 30;

            var userDbSetMock = new Mock<DbSet<ApplicationUser>>();
            var course = new Course() { Id = 1, Name = "das" };
            var assignment = new Assignment()
            {
                UserId = "1",
                User = user,
                TestResult = 0,
                State = AssignmentState.Completed,
                Course = course,
                CourseId = 1
            };
            user.Assignments = new List<Assignment>() { assignment };
            var modelExpected = new AssignmentViewModel()
            {
                DateOfAssignment = assignment.DateOfAssignment,
                State = assignment.State.ToString(),
                CourseName = course.Name,
                DueDate = assignment.DueDate,
                Username = user.UserName,
                Id = 1
            };
            var userList = new List<ApplicationUser>() { user };
            userDbSetMock.SetupData(userList);
            dbMock.Setup(x => x.Users).Returns(userDbSetMock.Object);
            var expected = new { total = 1, page = 1, records = userList.Count, rows = new List<AssignmentViewModel>() { modelExpected } };
            //Act
            var result = gridServices.GetDataFromServer(rows,page);

            //Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

       
    }
}
