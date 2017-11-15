using Bytes2you.Validation;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        [Authorize]
        public ActionResult StartTest(int courseId)
        {
            var userName = this.User.Identity.Name;
            var model = this.quizService.GetTest(courseId, userName);
            Guard.WhenArgument(model, "quiz").IsNull().Throw();

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitTest(Quiz model)
        {
            // return json with HTML and State indicating if it passed or not

            foreach (var quest in model.Questions)
            {
                if (quest.ChosenAnswer == null)
                {
                    ModelState.AddModelError("quizQuestion", "Please select an Answer !");
                }
            }

            if (ModelState.IsValid)
            {
                var quizResult =  this.quizService.SubmitTest(model);
                Guard.WhenArgument(quizResult, "quizResult").IsNull().Throw();

                return Json(new { error = false, partialView = RenderViewToString("_VisualizeTestResult", quizResult) });
            }

            return Json(new { error = true, partialView = RenderViewToString("_TestForm", model) });
        }

        private string RenderViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}