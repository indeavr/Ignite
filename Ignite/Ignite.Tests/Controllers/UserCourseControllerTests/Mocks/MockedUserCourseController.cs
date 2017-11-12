using Ignite.Controllers;
using Ignite.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Controllers.UserCourseControllerTests.Mocks
{
    public class MockedUserCourseController : UserCourseController
    {
        public MockedUserCourseController(IUserCourseService userCourseService, ApplicationUserManager userManager)
            :base(userCourseService,userManager)
        {

        }

        public new void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
