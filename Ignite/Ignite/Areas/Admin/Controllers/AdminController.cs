using Bytes2you.Validation;
using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            Guard.WhenArgument(uploadService, "uploadService").IsNull().Throw();

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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadCourse(UploadJsonModel file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Json != null && file.Json.ContentLength > 0)
                {
                    // var fileName = Path.GetFileName(file.Json.FileName);
                    this.uploadService.ValidateJson(file.Json);

                    // make it async
                    await this.uploadService.SaveCourse(file.Json);

                    return this.RedirectToAction("UploadSlides", new { courseId = this.uploadService.GetCourseId() });
                }
            }
            return this.View(file);
        }

        [HttpGet]
        public ActionResult UploadSlides(int courseId)
        {
            this.ViewBag.courseId = courseId;

            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UploadSlidesToDb(int courseId)
        {
            var images = new List<ImageViewModel>();

            for (int i = 0; i < Request.Files.Count; i++)
            {
                var fileName = Request.Files["file[" + i + "]"].FileName;

                HttpPostedFileBase file = Request.Files["file[" + i + "]"];

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

            await this.uploadService.SaveSlidesToCourse(courseId, images);

            return this.RedirectToAction("Home");
        }
       
        public ActionResult DoneUploading()
        {
            // validate if files are uploaded

            return this.View("Home");
        }
    }
}