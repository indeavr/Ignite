using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.Services;
using Ignite.Data;
using Moq;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class Ctor_Should
    {
        [TestMethod]
        public void ThrowNullException_WhenContextIsNull()
        {
            //Arrange
            var context = new ApplicationDbContext();
            //var context2 = new Mock<ApplicationDbContext>();
            context = null;
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new UserCoursesService(context));
        }
    }
}
