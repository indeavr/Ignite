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

        private readonly ApplicationDbContext context;

        public StatisticsController(IStatisticsService statService, ApplicationDbContext context)
        {
            this.statService = statService;
            this.context = context;
        }

        public StatisticsController()
        {

        }

        // GET: Admin/Statistics
        public ActionResult Home()
        {
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
                var assignments = this.statService.GetDataFromServer();

                var result = new
                {
                    total = assignments.Count / rows + 1,
                    page = page,
                    records = assignments.Count,
                    rows = assignments.Skip((page - 1) * rows).Take(rows).ToList()
                };

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(this.statService.SearchAndGetData(filters), JsonRequestBehavior.AllowGet);
            }
        }
    }
}