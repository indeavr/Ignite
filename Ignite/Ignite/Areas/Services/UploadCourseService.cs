using Ignite.Admin.Services.Interfaces;
using Ignite.Data;
using Ignite.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ignite.Admin.Services
{
    public class UploadCourseService : IUploadCourseService
    {
        private readonly ApplicationDbContext context;

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
                this.context.Courses.Add(course);

                foreach (var question in course.Questions)
                {
                    question.CourseId = course.Id;
                    this.context.Questions.Add(question);
                }
                this.context.SaveChanges();
            }
        }

        public bool ValidateJson(HttpPostedFileBase json)
        {
            return true;
        }
    }
}