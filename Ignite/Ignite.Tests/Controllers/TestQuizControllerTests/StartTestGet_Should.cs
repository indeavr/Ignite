using Ignite.Controllers;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Controllers.TestQuizControllerTests
{
    [TestClass]
    public class StartTestGet_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectModel()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();
            var quizMock = new Quiz();

            var username = "goshkataTest";

            var httpContext = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(x => x.Name).Returns(username);
            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);

            quizServiceMock
                .Setup(m => m.GetTest(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(quizMock);

            var controller = new TestQuizController(quizServiceMock.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object,
                                                                    new RouteData(), controller);
            // Act && Assert
            controller
                .WithCallTo(c => c.StartTest(It.IsAny<int>()))
                .ShouldRenderDefaultView()
                .WithModel(quizMock);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenQuizModelIsNull()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();
            Quiz quizMock = null;

            var username = "goshko";

            var httpContext = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(x => x.Name).Returns(username);
            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);

            quizServiceMock
                .Setup(m => m.GetTest(It.IsAny<int>(), It.IsAny<string>()))
                .Returns(quizMock);

            var controller = new TestQuizController(quizServiceMock.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object,
                                                                    new RouteData(), controller);

            // Act && Assert
            Assert
                .ThrowsException<ArgumentNullException>(() => controller.StartTest(It.IsAny<int>()));
        }
    }
}
