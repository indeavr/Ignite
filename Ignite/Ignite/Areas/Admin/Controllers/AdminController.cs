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

                    return this.RedirectToAction("UploadSlides", new { courseId = this.uploadService.GetCourseId() });
                }
            }
            return this.View();
        }

        [HttpGet]
        public ActionResult UploadSlides(int courseId)
        {
            this.ViewBag.courseId = courseId;

            return this.View();
        }

        [HttpPost]
        public ActionResult UploadSlidesToDb(int courseId)
        {
            var images = new List<ImageViewModel>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var fileName = Request.Files["file[" + i + "]"].FileName;

                HttpPostedFileBase file = Request.Files["file[" + i + "]"];
                var extension = file.FileName.Split('.')[1];

                var supportedTypes = new[] { "jpg", "jpeg", "png" };

                if (!supportedTypes.Contains(extension))
                {
                    ModelState.AddModelError("wrongExtension", "Invalid file type. Please upload an image");
                    return this.View("UploadSlides");
                }

                if (file != null && file.ContentLength > 0)
                {
                    var imageByteArray = this.uploadService.ImageToByteArray(file);
                    var image = new ImageViewModel();
                    image.Order = i + 1;
                    image.Name = fileName.ToString();
                    image.Content = imageByteArray;

                    images.Add(image);
                }
            }

            this.uploadService.SaveSlidesToCourse(courseId, images);

            return this.RedirectToAction("Home");
        }

        public ActionResult ProcessAllImages(List<ImageViewModel> images)
        {
            // TODO: Process the models

            foreach (var fileName in Request.Files)
            {
            }
            return this.View("UploadCourse");
        }

        public ActionResult DoneUploading()
        {
            // validate if files are uploaded

            return this.View("Home");
        }
    }
}