using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.Controllers;
using System.Web.Mvc;

namespace Ignite.Tests.Controllers
{
    [TestClass]
    public class UserCourseControllerTest
    {
        [TestMethod]
        public void Home()
        {
                // Arrange
            UserCourseController controller = new UserCourseController();

            // Act
            //ViewResult result = controller.Home("completed") as ViewResult;           

            // Assert
           // Assert.IsNotNull(result);
            Assert.IsNull(false);
        }

        [TestMethod]
        public void DisplayingCourseSlides()
        {
            // Arrange
            UserCourseController controller = new UserCourseController();

            // Act
            //ViewResult result = controller.Home("completed") as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
          //  Assert.IsNull(result);
        }


    }
}
