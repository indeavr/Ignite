using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.Data;
using Moq;
using Ignite.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class CheckStateChange_Should
    {
        [TestMethod]
        public void ShouldCheckStateChange_WhenParametersAreValid()
        {
            var username = "Mitko";
            var context = new Mock<ApplicationDbContext>();

            var assignments = new List<Assignment>();

            assignments.Add(new Assignment() { CourseId = 1 });

            var user = new ApplicationUser() { UserName = username };

            var userDbSetMock = new Mock<DbSet<Assignment>>();

            //var assignment = this.context.Assignments.First(a => a.CourseId == courseId && a.User.UserName == username);

            //if (assignment.State == AssignmentState.Pending)
            //{
            //    assignment.State = AssignmentState.Started;
            //}
        }
    }
}
