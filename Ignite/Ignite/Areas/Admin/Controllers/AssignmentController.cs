using Bytes2you.Validation;
using Ignite.Areas.Admin.Services;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AssignmentController : Controller
    {
        private readonly IAssignmentService assignmentService;
        private readonly ApplicationUserManager userManager;

        public AssignmentController(IAssignmentService assignmentService, ApplicationUserManager userManager)
        {
            Guard.WhenArgument(assignmentService, "assignmentService").IsNull().Throw();
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.userManager = userManager;
            this.assignmentService = assignmentService;
        }

        // GET: Admin/Assignment
        public ActionResult ManageAssignments()
        {
            return this.View();
        }

        public ActionResult AssignCourse()
        {
            var allCourses = this.assignmentService.GetAllCourses();
            var model = new Assignment2ViewModel();

            model.Courses = allCourses;

            return this.View(model);
        }

        [HttpGet]
        public ActionResult AssignTo(int courseId)
        {
            var chosenCourse = assignmentService.GetById(courseId);

            var model = new CourseNameViewModel();

            var allUsers = this.userManager.Users
                .Select(u => new UserAssignedViewModel()
                {
                    Username = u.UserName,
                    UserId = u.Id,
                    Checked = false
                })
                .ToList();

            model.Users = allUsers;
            model.Name = chosenCourse.Name;
            model.Type = true;
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignTo(CourseNameViewModel model)
        {
            // assignmentService.CreateAssignment(model.DueDate, model.Type, model.CourseId);

            return this.RedirectToAction("Home", "Admin");
        }

        public ActionResult RemoveAssignment()
        {
            var allAssignments = assignmentService.GetAllAssignments();
            var model = new Assignment2ViewModel();

            model.Assignments = allAssignments;

            return this.View(model);
        }
    }
}