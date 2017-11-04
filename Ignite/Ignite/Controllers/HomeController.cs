using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationUserManager userManager;

        public HomeController()
        {

        }

        public HomeController(ApplicationUserManager userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
           
            return View();
        }

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}