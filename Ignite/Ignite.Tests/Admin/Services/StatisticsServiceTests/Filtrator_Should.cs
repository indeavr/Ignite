using Ignite.Areas.Admin.Services;
using Ignite.Data;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Admin.Services.StatisticsServiceTests
{
    [TestClass]
    public class Filtrator_Should
    {
        [TestMethod]
        [DataRow("Goshkata")]
        [DataRow("BigVick")]
        public void FilterUsersByInputField_WhenPropertyNameIsUsersAndOpIsEq(string inputField)
        {
            // Arrange
            var contextMock = new Mock<ApplicationDbContext>();
            var statisticsService = new StatisticsService(contextMock.Object);

            var user1 = new ApplicationUser() { UserName = "Goshkata" };
            var user2 = new ApplicationUser() { UserName = "BigVick" };
            var users = new List<ApplicationUser>() { user1, user2 };

            var op = "eq";
            var propertyName = "Username";

            // Act
            var result = statisticsService.Filtrator(propertyName, op, inputField, users);

            // Assert
            Assert.AreEqual(result.First().UserName, inputField);
        }

        [TestMethod]
        [DataRow("Pieene")]
        [DataRow("Codene")]
        public void FilterCourseStatesbyInputField_WhenPropertyNameIsCoursenameAndOpIsEq(string inputField)
        {
            //Arrange
            var contextMock = new Mock<ApplicationDbContext>();
            var statService = new StatisticsService(contextMock.Object);

            var assignment1 = new Assignment() { Course = new Course() { Name = "Pieene" } };
            var assignment2 = new Assignment() { Course = new Course() { Name = "Codene" } };
            var assignments = new List<Assignment>() { assignment1, assignment2 };

            var user1 = new ApplicationUser() { UserName = "Goshko", Assignments = assignments };
            var user2 = new ApplicationUser() { UserName = "BigVick" };
            var users = new List<ApplicationUser>() { user1, user2 };
            var op = "eq";
            var propertyName = "CourseName";


            //Act
            var result = statService.Filtrator(propertyName, op, inputField, users);

            //Assert
            Assert.AreEqual(result.First().UserName, user1.UserName);
        }
    }
}
