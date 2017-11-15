using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.StatisticsControllerTests
{
    [TestClass]
    public class ChangeViewStatistic_Should
    {
        [TestMethod]
        public void ReturnUserGridPartialView_WhenTypeIsUser()
        {
            // Assert
            var statServiceMock = new Mock<IStatisticsService>();
            string type = "user";

            var controller = new StatisticsController(statServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.ChangeViewStatistic(type))
                .ShouldRenderPartialView("_UserGrid");
        }

        [TestMethod]
        public void ReturnCourseGridPartialView_WhenTypeIsCourse()
        {
            // Assert
            var statServiceMock = new Mock<IStatisticsService>();
            string type = "course";

            var controller = new StatisticsController(statServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.ChangeViewStatistic(type))
                .ShouldRenderPartialView("_CourseGrid");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        public void ReturnUserGridPartialView_WhenTypeIsNullOrEmpty(string type)
        {
            // Assert
            var statServiceMock = new Mock<IStatisticsService>();

            var controller = new StatisticsController(statServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.ChangeViewStatistic(type))
                .ShouldRenderPartialView("_UserGrid");
        }
    }
}
