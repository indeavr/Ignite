using Bytes2you.Validation;
using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Models;
using Newtonsoft.Json;
using System;
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
                Course course;
                using (StreamReader reader = new StreamReader(json.InputStream))
                {
                    var content = reader.ReadToEnd();
                    Guard.WhenArgument(content, "content").IsNullOrWhiteSpace().IsEmpty().Throw();
                    course = JsonConvert.DeserializeObject<Course>(content);
                }

                this.context.Courses.Add(course);

                try
                {
                    context.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }

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