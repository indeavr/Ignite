using Ignite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ignite.Services.Contracts;

namespace Ignite.Tests.Controllers.Controller_Mocks
{
    public class TestQuizControllerMock : TestQuizController
    {
        public TestQuizControllerMock(IQuizService quizService)
            : base(quizService)
        {
        }

        protected override string RenderViewToString(string stringToReturn, object model = null)
        {
            return stringToReturn;
        }
    }
}
