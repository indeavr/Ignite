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

        public TestQuizController()
        {

        }

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
            // return json with HTML and State indicating if it passed or not

            //foreach (var quest in model.Questions)
            //{ 
            //    if (quest.ChosenAnswer == null)
            //    {
            //        ModelState.AddModelError("quizQuestion", "Please select an Answer !");
            //    }
            //}

            //if (ModelState.IsValid)
            //{
                var quizResult =  this.quizService.SubmitTest(model);
                Guard.WhenArgument(quizResult, "quizResult").IsNull().Throw();

                return this.PartialView("_VisualizeTestResult", quizResult);
            //}

            //return this.View("StartTest", model);
        }

    }
}