using Bytes2you.Validation;
using Ignite.Data.Models;
using Ignite.Services.Contracts;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Ignite.Controllers
{
    [Authorize]
    public class UserCourseController : Controller
    {
        private readonly ApplicationUserManager userManager;
        private readonly IUserCourseService userCourseService;
        

        public UserCourseController()
        {

        }

        public UserCourseController(IUserCourseService userCourseService, ApplicationUserManager userManager)
        {
            Guard.WhenArgument(userCourseService, "userCourseService").IsNull().Throw();
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            

            this.userCourseService = userCourseService;
            this.userManager = userManager;
            
        }
 
        public ActionResult Home()
        {
            var username = this.User.Identity.Name;
            var allAssignments = this.userCourseService.GetAllAssignmentsPerUser(username);

            return this.View(allAssignments);
        }

        // GET: UserCourse
        [OutputCache(Duration = 180)]
        public ActionResult ReturnCollectionPartialView(string state)
        {
            var username = this.User.Identity.Name;

            var allAssignments = this.userCourseService.GetAllAssignmentsPerUser(username);

            switch (state)
            {
                case "completed":
                    return this.PartialView("_CompletedCourses", allAssignments.Completed);
                case "pending":
                    return this.PartialView("_CompletedCourses", allAssignments.Pending);
                case "started":
                    return this.PartialView("_CompletedCourses", allAssignments.Started);
                case "overdue":
                    return this.PartialView("_CompletedCourses", allAssignments.Overdue);
                default:
                    return this.View("Home", allAssignments);

            }
        }

        public async Task<ActionResult> DisplayingCourseSlides(int courseId)
        {
            var username = this.User.Identity.Name;

            var slides = this.userCourseService.DisplayingCoursesSlides(courseId, username);

            //add username
            await this.userCourseService.CheckStateChange(courseId,username);
            slides.CourseId = courseId;

            return this.View(slides);
        }

        public ActionResult RenderImage(int imgId)
        {
            var imgService = this.userCourseService.RenderImg(imgId);

            Image image = new Image();
            image.Content = imgService;

            return File(image.Content, "image/png");
        }

    }
}