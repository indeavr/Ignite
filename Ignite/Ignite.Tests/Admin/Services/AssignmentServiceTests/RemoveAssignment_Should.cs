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
    public class RemoveAssignment_Should
    {
        private IQueryable<Assignment> GetData()
        {
            return new List<Assignment>
            {
               new Assignment() { Id = 1},
               new Assignment(),
               new Assignment()
            }.AsQueryable();
        }

        [TestMethod]      
        public void CallContextAssignmentsOnce()
        {
            // Arrange

            var data = this.GetData();

            var neshtosi = new Assignment();

            var mockedSet = new Mock<DbSet<Assignment>>();
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Provider).Returns(data.Provider);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.Expression).Returns(data.Expression);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockedSet.As<IQueryable<Assignment>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mockedSet.Setup(a => a.Find(It.IsAny<object>())).Returns(neshtosi);

            var contextMock = new Mock<ApplicationDbContext>();

            contextMock.Setup(c => c.Assignments).Returns(mockedSet.Object);

            var service = new AssignmentService(contextMock.Object);

            // Act

            service.RemoveAssignment(1);

            // Assert

            contextMock.Verify(s => s.Assignments, Times.Once);
        }

    }
}
