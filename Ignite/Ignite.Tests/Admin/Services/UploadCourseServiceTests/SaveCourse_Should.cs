using Ignite.Admin.Services;
using Ignite.Data;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Tests.Admin.Services.UploadCourseServiceTests
{
    [TestClass]
    public class SaveCourse_Should
    {
        [TestMethod]
        public void AddCourseWithTheRightQuestions_WhenJsonIsValid()
        {
            // Arange
            var dbMock = new Mock<ApplicationDbContext>();
            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"files\Course.json"), FileMode.Open);

            var courses = new List<Course>();
            var questions = new List<Question>();

            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);

            dbMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            dbMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns(469);

            var uploadService = new UploadCourseService(dbMock.Object);

            // Act
            uploadService.SaveCourse(fileBaseMock.Object);

            // Assert
            Assert.AreEqual(dbMock.Object.Courses.ToList().Count, 1);
            Assert.AreEqual(dbMock.Object.Questions.ToList().Count, 2);
        }

        [TestMethod]
        public void SetTheCourseIdProperty_WhenJsonIsValid()
        {
            // Arange
            var dbMock = new Mock<ApplicationDbContext>();
            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"files\Course.json"), FileMode.Open);

            var courses = new List<Course>()
            {
                new Course()
            };
            var questions = new List<Question>();

            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);

            dbMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            dbMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns(469);

            var uploadService = new UploadCourseService(dbMock.Object);

            var expectedId = courses.Count - 1;

            // Act
            uploadService.SaveCourse(fileBaseMock.Object);

            // Assert
            Assert.AreEqual(expectedId, uploadService.GetCourseId());
        }
    }
}
