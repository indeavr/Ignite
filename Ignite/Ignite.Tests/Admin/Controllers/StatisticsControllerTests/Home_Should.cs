using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
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
    public class Home_Should
    {
        [TestMethod]
        public void RenderDefaultView_WithCorrectModel()
        {
            var statServiceMock = new Mock<IStatisticsService>();

            var overdueCourses = new List<OverdueCourse>();
            overdueCourses.Add(new OverdueCourse() { CourseName = "Selenium" });

            statServiceMock.Setup(m => m.GetAllOverdue()).Returns(overdueCourses);

            var controller = new StatisticsController(statServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.Home())
                .ShouldRenderDefaultView()
                .WithModel(overdueCourses);
        }

        [TestMethod]
        public void Call_CheckForOverdueAndUpdateMethod()
        {
            var statServiceMock = new Mock<IStatisticsService>();

            var overdueCourses = new List<OverdueCourse>();
            overdueCourses.Add(new OverdueCourse() { CourseName = "Copy-Paste" });

            statServiceMock.Setup(m => m.GetAllOverdue()).Returns(overdueCourses);

            var controller = new StatisticsController(statServiceMock.Object);

            // Act
            controller.Home();

            // Assert
            statServiceMock.Verify(m => m.CheckForOverdueAndUpdate(), Times.Once);
        }
    }
}
