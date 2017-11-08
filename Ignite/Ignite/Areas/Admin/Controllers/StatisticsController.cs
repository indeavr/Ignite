using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels.statistics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statService;

        public StatisticsController(IStatisticsService statService)
        {
            this.statService = statService;
        }

        public StatisticsController()
        {

        }

        // GET: Admin/Statistics
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult DataProviderForTable()
        {
            var assignments = this.statService.GetDataFromServer();

            assignments.Select(a => new
            {
                Id = a.Id,
                Username = a.Username,
                CourseName = a.CourseName,
                DueDate = a.DueDate,
                DateOfAssignment = a.DateOfAssignment,
                Type = a.Type,
                State = a.State
            });

            var result = new { total = 1, page = 1, records = assignments.Count, rows = assignments };
            Console.WriteLine("Bravo");

            return Json(result, JsonRequestBehavior.AllowGet);
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
    }
}