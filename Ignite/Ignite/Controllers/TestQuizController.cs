using Bytes2you.Validation;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ignite.Controllers
{
    public class TestQuizController : Controller
    {
        private readonly IQuizService quizService;
        
        public TestQuizController(IQuizService quizService)
        {
            Guard.WhenArgument(quizService, "quizService").IsNull().Throw();

            this.quizService = quizService;
        }

        // GET: TestQuiz
        public ActionResult StartTest(int courseId)
        {
            var userName = this.User.Identity.Name;
            var model = this.quizService.GetTest(courseId, userName);
            Guard.WhenArgument(model, "quiz").IsNull().Throw();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitTest(Quiz model)
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
                var quizResult = await this.quizService.SubmitTest(model);
                Guard.WhenArgument(quizResult, "quizResult").IsNull().Throw();

                return Json(new { error = false, partialView = RenderViewToString("_VisualizeTestResult", quizResult) });
            }

            return Json(new { error = true, partialView = RenderViewToString("_TestForm", model) });
        }

        protected virtual string RenderViewToString(string viewName, object model)
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

    public class TestQuizControllerMock : TestQuizController
    {
        private readonly string viewString;

        public TestQuizControllerMock(IQuizService quizService, string viewString) 
            : base(quizService)
        {
            this.viewString = viewString;
        }

        protected override string RenderViewToString(string viewName, object model)
        {
            return this.viewString;
        }
    }
}