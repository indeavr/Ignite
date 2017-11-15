using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.StatisticsControllerTests
{
    [TestClass]
    public class DataProviderForTable_Should
    {
        [TestMethod]
        public void CallSearchAndGetData_WhenSearchIsTrue()
        {
            //Arrange
            var statServiceMock = new Mock<IStatisticsService>();

            var controller = new StatisticsController(statServiceMock.Object);

            var _search = true;
            var rows = It.IsAny<int>();
            var pages = It.IsAny<int>();
            var filters = It.IsAny<string>();

            // Act
            controller.DataProviderForTable(_search, rows, pages, filters);

            // Assert
            statServiceMock.Verify(m => m.SearchAndGetData(filters), Times.Once);
        }

        [TestMethod]
        public void CallSearchAndGetData_WhenSearchIsFalse()
        {
            //Arrange
            var statServiceMock = new Mock<IStatisticsService>();

            var controller = new StatisticsController(statServiceMock.Object);

            var _search = false;
            var rows = It.IsAny<int>();
            var pages = It.IsAny<int>();
            var filters = It.IsAny<string>();

            // Act
            controller.DataProviderForTable(_search, rows, pages, filters);

            // Assert
            statServiceMock.Verify(m => m.GetDataFromServer(rows, pages), Times.Once);
        }

        [TestMethod]
        public void ReturnJSONFromStatService_WhenSearchIsTrue()
        {
            //Arrange
            var statServiceMock = new Mock<IStatisticsService>();

            var controller = new StatisticsController(statServiceMock.Object);

            var _search = true;
            var rows = It.IsAny<int>();
            var pages = It.IsAny<int>();
            var filters = It.IsAny<string>();

            //Act & Assert
            controller
                .WithCallTo(c => c.DataProviderForTable(_search, rows, pages, filters))
                .ShouldReturnJson(x => statServiceMock.Object.SearchAndGetData(filters))
                .JsonRequestBehavior.HasFlag(JsonRequestBehavior.AllowGet);
        }

        [TestMethod]
        public void ReturnJSONFromService_WhenSearchIsFalse()
        {
            //Arrange
            var statServiceMock = new Mock<IStatisticsService>();

            var controller = new StatisticsController(statServiceMock.Object);

            var _search = false;
            var rows = It.IsAny<int>();
            var pages = It.IsAny<int>();
            var filters = It.IsAny<string>();

            //Act & Assert
            controller
                .WithCallTo(c => c.DataProviderForTable(_search, rows, pages, filters))
                .ShouldReturnJson(x => statServiceMock.Object.GetDataFromServer(rows, pages))
                .JsonRequestBehavior.HasFlag(JsonRequestBehavior.AllowGet);
        }
    }
}
