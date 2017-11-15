using Bytes2you.Validation;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Areas.Admin.ViewModels.statistics;
using Ignite.Data;
using Ignite.Data.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statService;

        public StatisticsController(IStatisticsService statService)
        {
            Guard.WhenArgument(statService, "statService").IsNull().Throw();

            this.statService = statService;
        }

        public StatisticsController()
        {

        }

        // GET: Admin/Statistics
        public ActionResult Home()
        {
            this.statService.CheckForOverdueAndUpdate();
            var overdueUsers = this.statService.GetAllOverdue();

            return View(overdueUsers);
        }

        public ActionResult ChangeViewStatistic(string type)
        {
            switch (type)
            {
                case "user":
                    return this.PartialView("_UserGrid");
                case "course":
                    return this.PartialView("_CourseGrid");
                default:
                    return this.PartialView("_UserGrid");
            }
        }

        public ActionResult DataProviderForTable(bool _search, int rows, int page, string filters)
        {
            if (_search == false)
            {
                var assignments = this.statService.GetDataFromServer(rows, page);

                return Json(assignments, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(this.statService.SearchAndGetData(filters), JsonRequestBehavior.AllowGet);
            }
        }
    }
}