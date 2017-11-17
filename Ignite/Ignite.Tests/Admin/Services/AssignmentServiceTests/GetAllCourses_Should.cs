using Ignite.Areas.Admin.Services;
using Ignite.Data;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Admin.Services.AssignmentServiceTests
{
    [TestClass]
    public class GetAllCourses_Should
    {
        private IQueryable<Course> GetData()
        {
            return new List<Course>
            {
               new Course(),
               new Course(),
               new Course()
            }.AsQueryable();
        }

        [TestMethod]
        public void CallContextCoursesOnce()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<DbSet<Course>>();
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            
            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Courses).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act
            service.GetAllCourses();

            // Assert
            contextMock.Verify(s => s.Courses, Times.Once);
        }

        [TestMethod]
        public void ReturnCourses()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<DbSet<Course>>();
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Courses).Returns(mockedSet.Object);
            
            var service = new AssignmentService(contextMock.Object);

            // Act
            var result = service.GetAllCourses();
            
            // Assert
            CollectionAssert.AreEqual(data.ToList(), result.ToList());
        }
    }
}
