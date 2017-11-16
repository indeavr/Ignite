using Bytes2you.Validation;
using Ignite.Areas.Admin.Services;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            var model = new ListAssignmentViewModel
            {
                Courses = this.assignmentService.GetAllCourses()
            };

            return this.View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AssignTo(int courseId)
        {
            var chosenCourse = await assignmentService.GetById(courseId);

            var model = new CourseNameViewModel();

            var allUsers = this.userManager.Users
                .Select(u => new UserAssignedViewModel()
                {
                    Username = u.UserName,
                    UserId = u.Id,
                    Checked = false,
                    Type = false
                })
                .ToList();

            model.Users = allUsers;
            model.Name = chosenCourse.Name;
            model.CourseId = courseId;

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AssignTo(CourseNameViewModel courseModel)
        {
            if (this.ModelState.IsValid)
            {
                await assignmentService.CreateAssignment(courseModel);

                return this.RedirectToAction("Home", "Admin");
            }

            return this.View(courseModel);
        }

        public ActionResult ListAssignments()
        {
            var allAssignments = assignmentService.GetAllAssignments();
            var model = new ListAssignmentViewModel();

            model.Assignments = allAssignments;

            return this.View(model);
        }

        public ActionResult RemoveAssignment(int assignmentId)
        {
            assignmentService.RemoveAssignment(assignmentId);

            return this.RedirectToAction("Home", "Admin");
        }
    }
}