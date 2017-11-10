using Bytes2you.Validation;
using Ignite.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Controllers
{
    public class TestQuizController : Controller
    {
        public IQuizService quizService;

        public TestQuizController(IQuizService quizService)
        {
            Guard.WhenArgument(quizService, "quizService").IsNull().Throw();

            this.quizService = quizService;
        }

        // GET: TestQuiz
        public ActionResult StartTest(int courseId)
        {
            var quiz = this.quizService.GetTest(courseId);



            return View(quiz);
        }
    }
}