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

<<<<<<< HEAD
            var username = this.User.Identity.Name;
            //add username
            this.userCourseService.CheckStateChange(courseId,username);
            
            return this.View(slides);
=======
            var listOfImages = context.Images.ToList();

            var imageViewModel = new ImagesToCourosel();
            foreach (var image in listOfImages)
            {
                imageViewModel.Images.Add(image);
            }
            imageViewModel.CourseId = courseId;

            // imageViewModel.CourseName = imageViewModel.Images[0].Course.Name;

            imageViewModel.CourseName = context.Courses.First(c => c.Id == 1).Name;
            return this.View(imageViewModel);

            //LaunchTestViewModel course = new LaunchTestViewModel();
            //course.Course = new Course() { Name = "Pesho" };
            //var courseId = course.CourseId;
        //    //Call service => LaunchTestViewmodel pulen s img
        //    var slides = this.launchCourseService.GetImages(courseId);


           //return View(course);
>>>>>>> 6c9760c4c285bee34ed56a5fd2634a0215326a36
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