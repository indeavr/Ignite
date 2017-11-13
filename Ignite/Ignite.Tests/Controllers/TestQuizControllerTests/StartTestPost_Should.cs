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
    public class StartTestPost_Should
    {
        [TestMethod]
        public void RenderVisualizeTestResultView_WhenModelStateIsValid()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();

            var quizMock = new Quiz();
            var quizResult = new QuizResulViewModel();

            quizServiceMock.Setup(m => m.SubmitTest(quizMock)).Returns(quizResult);

            var controller = new TestQuizController(quizServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.SubmitTest(quizMock))
                .ShouldRenderView("VisualizeTestResult")
                .WithModel(quizResult);
        }
        [TestMethod]
        public void ThrowArgumentNullException_WhenModelStateIsValidAndQuizResultIsNull()
        {
            // Arange
            var quizServiceMock = new Mock<IQuizService>();

            var quizMock = new Quiz();
            QuizResulViewModel quizResult = null;

            quizServiceMock.Setup(m => m.SubmitTest(quizMock)).Returns(quizResult);

            var controller = new TestQuizController(quizServiceMock.Object);

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

            var controller = new TestQuizController(quizServiceMock.Object);

            // Act && Assert
            controller
                .WithCallTo(c => c.SubmitTest(quizMock))
                .ShouldRenderView("StartTest")
                .WithModel(quizMock)
                .AndModelError("quizQuestion");
        }

    }
}
*/