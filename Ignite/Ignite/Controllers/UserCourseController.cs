using Bytes2you.Validation;
using Ignite.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Controllers
{
    public class UserCourseController : Controller
    {
        private readonly IUserCourseService userCourseService;
        private readonly ApplicationUserManager userManager;

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
        public ActionResult Home()
        {
            var username = this.User.Identity.Name;

            var allAssignments = this.userCourseService.GetAllAssignmentsPerUser(username);
                    

            return this.View();
        }

        



    }
}