using Bytes2you.Validation;
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
    public class ManageUserController : Controller
    {
        private readonly ApplicationUserManager userManager;

        public ManageUserController(ApplicationUserManager userManager)
        { 
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();

            this.userManager = userManager;
        }

        // GET: Admin/ManageUser
        public ActionResult ListUsers()
        {
            var manageUsersViewModel = this.userManager.Users.Select(u => new ManageUserViewModel { Username = u.UserName }).ToList();

            return View(manageUsersViewModel);
        }

        public async Task<ActionResult> EditUser(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            var manageUsersViewModel = ManageUserViewModel.Create.Compile()(user);
            manageUsersViewModel.IsAdmin = await this.userManager.IsInRoleAsync(user.Id, "Admin");

            return this.PartialView("_EditUser", manageUsersViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(ManageUserViewModel manageUsersViewModel)
        {
            if (manageUsersViewModel.IsAdmin)
            {
                await this.userManager.AddToRoleAsync(manageUsersViewModel.Id, "Admin");
            }
            else
            {
                await this.userManager.RemoveFromRoleAsync(manageUsersViewModel.Id, "Admin");
            }

            return this.RedirectToAction("ListUsers");
        }

    }
}