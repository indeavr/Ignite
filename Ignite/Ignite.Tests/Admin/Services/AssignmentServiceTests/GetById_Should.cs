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
    public class GetById_Should
    {

        private IQueryable<Course> GetData()
        {
            return new List<Course>
            {
               new Course() {Id = 1 },
               new Course(),
               new Course()
            }.AsQueryable();
        }

        [TestMethod]
        public async Task CallContextCoursesOnce()
        {
            // Arrange
            var data = this.GetData();

            var course = new Course();

            var mockedSet = new Mock<DbSet<Course>>();
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockedSet.Setup(a => a.FindAsync(It.IsAny<object>())).ReturnsAsync(course);

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Courses).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act
            await service.GetById(1);

            // Assert
            contextMock.Verify(s => s.Courses, Times.Once);
        }

        [TestMethod]
        public async Task ReturnsCourseById()
        {
            // Arrange
            var data = this.GetData();

            var course = new Course();

            var mockedSet = new Mock<DbSet<Course>>();
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Course>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockedSet.Setup(a => a.FindAsync(It.IsAny<object>())).ReturnsAsync(course);

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Courses).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act
            var result = await service.GetById(1);

            // Assert
            Assert.AreEqual(course, result);
        }
    }
}
