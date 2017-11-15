using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Web;
using TestStack.FluentMVCTesting;

namespace Ignite.Tests.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class UploadCoursePost_Should
    {
        [TestMethod]
        public void RedirectToUploadSlidesWithCorrectRouteValue_WhenModelStateIsValid()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();
            uploadServiceMock.Setup(m => m.GetCourseId()).Returns(1);

            var controller = new AdminController(uploadServiceMock.Object);

            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               @"files\Course.json"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns(469);

            var json = new UploadJsonModel();
            json.Json = fileBaseMock.Object;

            // Act && Assert
            controller
                .WithCallTo(c => c.UploadCourse(json))
                .ShouldRedirectTo<int>(c => c.UploadSlides);

            stream.Dispose();
        }

        [TestMethod]
        public void RenderDefaultViewWithErrors_WhenFileHasError()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               @"files\wrongFileExtension.css"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns((int)stream.Length);

            var json = new UploadJsonModel();
            json.Json = fileBaseMock.Object;

            controller.ModelState.AddModelError("fake", "fakeError");

            // Act && Arange
            controller
                .WithCallTo(c => c.UploadCourse())
                .ShouldRenderDefaultView()
                .WithModel<UploadJsonModel>()
                .AndModelError("fake");

            stream.Dispose();
        }

        public void RenderDefaultViewWithErrors_WhenFileIsNotJson()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               @"files\wrongFileExtension.css"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns((int)stream.Length);
            fileBaseMock.Setup(m => m.FileName).Returns("wrongFileExtension.css");

            var json = new UploadJsonModel();
            json.Json = fileBaseMock.Object;

            //controller.ModelState.AddModelError("json", "fakeError");

            // Act && Arange
            controller
                .WithCallTo(c => c.UploadCourse())
                .ShouldRenderDefaultView()
                .WithModel<UploadJsonModel>()
                .AndModelError("ade");

            stream.Dispose();
        }

        [TestMethod]
        public void CallSaveCourseMethod_WhenModelStateIsValid()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();

            var controller = new AdminController(uploadServiceMock.Object);

            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
               @"files\Course.json"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns((int)stream.Length);

            var json = new UploadJsonModel();
            json.Json = fileBaseMock.Object;

            // Act 
            controller.UploadCourse(json);

            // Assert
            uploadServiceMock.Verify(m => m.SaveCourse(json.Json), Times.Once);
        }
    }
}
