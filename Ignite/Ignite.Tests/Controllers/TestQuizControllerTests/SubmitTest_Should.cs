using Ignite.Controllers;
using Ignite.Services;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Controllers.TestQuizControllerTests
{
    [TestClass]
    public class SubmitTest_Should
    {
        [TestMethod]
        public void RenderVisualizeTestResultView_WhenModelStateIsValid()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();

            var username = "BigVick";

            var stringRepresentingViewContent = "_renderPartial";

            var httpContext = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
            mockIdentity.Setup(x => x.Name).Returns(username);

            var quizMock = new Quiz();
            var quizResult = new QuizResultViewModel();

            quizServiceMock.Setup(m => m.SubmitTest(quizMock)).Returns(Task.FromResult(quizResult));

            var controller = new TestQuizControllerMock(quizServiceMock.Object,
                stringRepresentingViewContent);

            // Act && Assert
            controller
                .WithCallTo(c => c.SubmitTest(quizMock))
                .ShouldReturnJson()
                .Data
                .Equals(new { error = "true", renderedView = stringRepresentingViewContent });
        }
        [TestMethod]
        public void ThrowArgumentNullException_WhenModelStateIsValidAndQuizResultIsNull()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();

            var stringRepresentingViewContent = "_renderPartial";

            var quizMock = new Quiz();
            QuizResultViewModel quizResult = null;

            quizServiceMock.Setup(m => m.SubmitTest(quizMock)).Returns(Task.FromResult(quizResult));

            var controller = new TestQuizControllerMock(quizServiceMock.Object,
                stringRepresentingViewContent);

            // Act && Assert
            Assert
                .ThrowsException<ArgumentNullException>(() => controller.SubmitTest(quizMock));
        }

        [TestMethod]
        public void ReturnStartTestViewWithErrorMessage_WhenModelStateIsNotValid()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();

            var quizMock = new Quiz();
            quizMock.Questions.Add(new QuizQuestion() { ChosenAnswer = null });

            var stringRepresentingViewContent = "_renderPartial";

            var username = "goshko";

            var httpContext = new Mock<HttpContextBase>();
            var mockIdentity = new Mock<IIdentity>();
            mockIdentity.Setup(x => x.Name).Returns(username);
            httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);

            ////quizServiceMock
            ////    .Setup(m => m.GetTest(It.IsAny<int>(), It.IsAny<string>()))
            ////    .Returns(quizMock);

            var controller = new TestQuizControllerMock(quizServiceMock.Object,
                stringRepresentingViewContent);

            controller.ControllerContext = new ControllerContext(httpContext.Object,
                                                                    new RouteData(), controller);

            // Act && Assert
            controller
                .WithCallTo(c => c.SubmitTest(quizMock))
                .ShouldReturnJson()
                .Data
                .Equals(new { error = "false", renderedView = stringRepresentingViewContent }); ;
        }

    }
}
