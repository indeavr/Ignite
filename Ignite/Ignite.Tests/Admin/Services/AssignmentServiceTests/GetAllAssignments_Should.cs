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
    public class GetAllAssignments_Should
    {
        private IQueryable<Assignment> GetData()
        {
            return new List<Assignment>
            {
               new Assignment(),
               new Assignment(),
               new Assignment()
            }.AsQueryable();
        }

        [TestMethod]
        public void CallContextAssignmentsOnce()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<DbSet<Assignment>>();
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Assignments).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act
            service.GetAllAssignments();
            
            // Assert
            contextMock.Verify(s => s.Assignments, Times.Once);
        }

        [TestMethod]
        public void ReturnAssignments()
        {
            // Arrange
            var data = this.GetData();

            var mockedSet = new Mock<DbSet<Assignment>>();
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Assignments).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act
            var result = service.GetAllAssignments();

            // Assert
            CollectionAssert.AreEqual(data.ToList(), result.ToList());
        }
    }
}
