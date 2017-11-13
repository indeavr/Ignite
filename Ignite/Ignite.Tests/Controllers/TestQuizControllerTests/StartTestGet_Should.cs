/*using Ignite.Controllers;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            quizServiceMock
                .Setup(m => m.GetTest(It.IsAny<int>()))
                .Returns(quizMock);

            var controller = new TestQuizController(quizServiceMock.Object);

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

            quizServiceMock
                .Setup(m => m.GetTest(It.IsAny<int>()))
                .Returns(quizMock);

            var controller = new TestQuizController(quizServiceMock.Object);

            // Act && Assert
            Assert
                .ThrowsException<ArgumentNullException>(() => controller.StartTest(It.IsAny<int>()));
        }
    }
}
*/