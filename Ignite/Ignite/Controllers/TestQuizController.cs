using Bytes2you.Validation;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
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
        public ActionResult StartTest(int? courseId)
        {
            var model = this.quizService.GetTest(courseId);
            Guard.WhenArgument(model, "quiz").IsNull().Throw();

            return View(model);
        }

        [HttpPost]
        public ActionResult SubmitTest(Quiz model)
        {
            if (ModelState.IsValid)
            {
                var score =  this.quizService.SubmitTest(model);

                return this.RedirectToAction("VisualizeTestResult");
            }

            return this.View("StartTest", model);
        }
    }
}