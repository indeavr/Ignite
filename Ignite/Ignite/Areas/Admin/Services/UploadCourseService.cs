using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Ignite.Admin.Services
{
    public class UploadCourseService : IUploadCourseService
    {
        private readonly ApplicationDbContext context;

        private int currentCourseId;

        public int GetCourseId()
        {
            return this.currentCourseId;
        }

        public UploadCourseService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void SaveCourse(HttpPostedFileBase json)
        {
            if (json.InputStream.CanRead)
            {
                string jsonString = string.Empty;

                using (BinaryReader biteReader = new BinaryReader(json.InputStream))
                {
                    byte[] biteArray = biteReader.ReadBytes(json.ContentLength);
                    jsonString = System.Text.Encoding.UTF8.GetString(biteArray);
                }

                Course course = JsonConvert.DeserializeObject<Course>(jsonString);

                // call validateJson method

                this.context.Courses.Add(course);

                foreach (var question in course.Questions)
                {
                    question.CourseId = course.Id;
                    this.context.Questions.Add(question);
                }
                this.context.SaveChanges();

                this.currentCourseId = course.Id;
            }
        }

        public bool ValidateJson(HttpPostedFileBase json)
        {

            return true;
        }

        public byte[] ImageToByteArray(HttpPostedFileBase image)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.InputStream.Seek(0, SeekOrigin.Begin);
                    image.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    return array;
                }
            }
            else
            {
                return null;
            }
        }

        public void SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView)
        {
           // var course = this.context.Courses.First(c => c.Id == courseId);

            foreach (var imageView in imagesView)
            {
                var image = new Image(imageView.Name, imageView.Content, imageView.Order);
                image.CourseId = courseId;
                this.context.Images.Add(image);
            }


            this.context.SaveChanges();
        }
    }
}