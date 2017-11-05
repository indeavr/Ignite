using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUploadCourseService uploadService;

        public AdminController()
        {

        }

        public AdminController(IUploadCourseService uploadService)
        {
            this.uploadService = uploadService;
        }

        // GET: Admin/Admin
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult UploadCourse()
        {
            var jsonModel = new UploadJsonModel();

            return this.View(jsonModel);
        }

        [HttpPost]
        public ActionResult UploadCourse(UploadJsonModel file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Json != null && file.Json.ContentLength > 0)
                {
                    // var fileName = Path.GetFileName(file.Json.FileName);
                    this.uploadService.ValidateJson(file.Json);

                    // make it async
                    this.uploadService.SaveCourse(file.Json);

                    return this.RedirectToAction("UploadSlides");
                }
            }
            return this.View();
        }

        public ActionResult UploadSlides()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult UploadSlides(List<ImageViewModel> images)
        {
            // this.uploadService.SaveSlides();
            return this.View();
        }
    }
}