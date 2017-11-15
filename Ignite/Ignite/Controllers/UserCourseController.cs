using Bytes2you.Validation;
using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Services;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Controllers
{
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
 
        // GET: UserCourse

        public ActionResult Home(string state)
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
                    return this.PartialView("_CompletedCourses", allAssignments.Started);
                default:
                    return this.View(allAssignments);
                    //return this.View("_CompletedCourses", allAssignments.Completed);
            }          
        }

        public ActionResult DisplayingCourseSlides(int courseId)
        {
            var slides = this.userCourseService.DisplayingCoursesSlides(courseId);

            var username = this.User.Identity.Name;
            //add username
            this.userCourseService.CheckStateChange(courseId,username);
            
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