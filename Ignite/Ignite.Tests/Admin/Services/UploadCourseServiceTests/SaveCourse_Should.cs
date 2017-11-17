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
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Tests.Admin.Services.UploadCourseServiceTests
{
    [TestClass]
    public class SaveCourse_Should
    {

        [TestMethod]
        public async Task CallReadCourseFromJson_WhenInputStreamCanBeRead()
        {
            // Assert
            var contextMock = new Mock<ApplicationDbContext>();

            var service = new Mock<UploadCourseService>(contextMock.Object);

            service
                .Setup(m => m.ReadCourseFromJson(It.IsAny<HttpPostedFileBase>()))
                .Returns(It.IsAny<Course>());

            await service.Object.SaveCourse(It.IsAny<HttpPostedFileBase>());
            // Act 
            // Assert
            service.Verify(s => s.ReadCourseFromJson(It.IsAny<HttpPostedFileBase>()), Times.Once);
        }

        [TestMethod]
        public void CallSaveToDb_WhenInputStreamCanBeRead()
        {

        }

        [TestMethod]
        public void AddCourseToDatabase_WhenParamsAreCorrect()
        {
            // Arange
            var dbMock = new Mock<ApplicationDbContext>();

            var courses = new List<Course>();
            var questions = new List<Question>();
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);

            dbMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            dbMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);

            var course = new Course();

            var uploadService = new Mock<UploadCourseService>(dbMock.Object);

            uploadService.Setup(m => m.ReadCourseFromJson(It.IsAny<HttpPostedFileBase>())).Returns(course);

            // Act
            uploadService.Object.SaveCourse(It.IsAny<HttpPostedFileBase>());

            // Assert
            Assert.AreEqual(2, dbMock.Object.Courses.ToList().Count);
            Assert.AreEqual(course, dbMock.Object.Courses.ToList()[1]);
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

            stream.Dispose();
        }
    }
}
