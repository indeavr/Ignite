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
                default:
                    return this.View(allAssignments);
                    //return this.View("_CompletedCourses", allAssignments.Completed);
            }          
        }

        public ActionResult DisplayingCourseSlides(int courseId)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // var listOfImages = context.Courses.First(c => c.Id == courseId).Images.ToList();

            var listOfImages = context.Images.ToList();

            var imageViewModel = new ImagesToCourosel();
            foreach (var image in listOfImages)
            {
                imageViewModel.Images.Add(image);
            }

            // imageViewModel.CourseName = imageViewModel.Images[0].Course.Name;

            imageViewModel.CourseName = context.Courses.First(c => c.Id == 1).Name;
            return this.View(imageViewModel);

            //LaunchTestViewModel course = new LaunchTestViewModel();
            //course.Course = new Course() { Name = "Pesho" };
            //var courseId = course.CourseId;
        //    //Call service => LaunchTestViewmodel pulen s img
        //    var slides = this.launchCourseService.GetImages(courseId);


           //return View(course);
        }

        public async Task<ActionResult> RenderImage(int imgId)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            Image image = await context.Images.FindAsync(imgId);

            return File(image.Content, "image/png");
        }

        //public ActionResult ShowCoursesByState()
        //{
        //    if (Request.IsAjaxRequest())
        //    {
        //        return Partial
        //    }
        //}

    }
}