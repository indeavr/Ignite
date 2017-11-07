using Ignite.Admin.Services.Interfaces;
using Ignite.Areas.Admin.Controllers;
using Ignite.Areas.Admin.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Ignite.Tests.Admin.Controllers.AdminControllerTests
{
    [TestClass]
    public class UploadSlidesToDb_Should
    {
        [TestMethod]
        public void CallImageToByteArray_WhenFileIsValid()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();


            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"files\cognitive-bias.jpg"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns((int)stream.Length);
            fileBaseMock.Setup(m => m.FileName).Returns("cognitive-bias.jpg");

            var fileCollectionMock = new Mock<HttpFileCollectionBase>();
            fileCollectionMock.Setup(m => m.Count).Returns(1);

            fileCollectionMock.Setup(m => m["files[0]"].ContentLength).Returns(fileBaseMock.Object.ContentLength);
            fileCollectionMock.Setup(m => m["files[0]"].FileName).Returns("cognitive-bias.jpg");
            fileCollectionMock.Setup(m => m["files[0]"].InputStream).Returns(fileBaseMock.Object.InputStream);

            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(m => m.Files).Returns(fileCollectionMock.Object);

            var requestContextMock = new Mock<HttpContextBase>();
            requestContextMock.Setup(m => m.Request).Returns(requestMock.Object);

            var controller = new AdminController(uploadServiceMock.Object);
            controller.ControllerContext = new ControllerContext(requestContextMock.Object,
                                                                    new RouteData(), controller);

            // Act 
            controller.UploadSlidesToDb(1);

            // Assert
            uploadServiceMock.Verify(m => m.ImageToByteArray(It.IsAny<HttpPostedFileBase>()), Times.Once);

            stream.Dispose();
        }

        [TestMethod]
        public void CallSaveSlidesToCourse_WhenFileIsValid()
        {
            // Arange
            var uploadServiceMock = new Mock<IUploadCourseService>();


            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            @"files\cognitive-bias.jpg"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);
            fileBaseMock.Setup(m => m.ContentLength).Returns((int)stream.Length);
            fileBaseMock.Setup(m => m.FileName).Returns("cognitive-bias.jpg");

            var fileCollectionMock = new Mock<HttpFileCollectionBase>();
            fileCollectionMock.Setup(m => m.Count).Returns(1);

            fileCollectionMock.Setup(m => m["files[0]"].ContentLength).Returns(fileBaseMock.Object.ContentLength);
            fileCollectionMock.Setup(m => m["files[0]"].FileName).Returns("cognitive-bias.jpg");
            fileCollectionMock.Setup(m => m["files[0]"].InputStream).Returns(fileBaseMock.Object.InputStream);

            var requestMock = new Mock<HttpRequestBase>();
            requestMock.Setup(m => m.Files).Returns(fileCollectionMock.Object);

            var requestContextMock = new Mock<HttpContextBase>();
            requestContextMock.Setup(m => m.Request).Returns(requestMock.Object);

            var controller = new AdminController(uploadServiceMock.Object);
            controller.ControllerContext = new ControllerContext(requestContextMock.Object,
                                                                    new RouteData(), controller);

            // Act 
            controller.UploadSlidesToDb(1);

            // Assert
            uploadServiceMock.Verify(m => m.SaveSlidesToCourse(It.IsAny<int>(),
                It.IsAny<List<ImageViewModel>>()), Times.Once);

            stream.Dispose();
        }

    }
}
