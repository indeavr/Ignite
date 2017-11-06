using Ignite.Admin.Services;
using Ignite.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Tests.Admin.Services.UploadCourseServiceTests
{
    [TestClass]
    public class ImageToByteArray_Should
    {
        [TestMethod]
        public void ReturnByteArrayOfJson_WhenJsonIsNotNull()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();
            var stream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                @"files\Course.json"), FileMode.Open);

            var fileBaseMock = new Mock<HttpPostedFileBase>();
            fileBaseMock.Setup(m => m.InputStream).Returns(stream);

            byte[] rightByteArray;
            using (MemoryStream ms = new MemoryStream())
            {
                fileBaseMock.Object.InputStream.Seek(0, SeekOrigin.Begin);
                fileBaseMock.Object.InputStream.CopyTo(ms);
                rightByteArray = ms.GetBuffer();
            }

            var uploadService = new UploadCourseService(contextMock.Object);

            // Act
            var actualResult = uploadService.ImageToByteArray(fileBaseMock.Object);

            // Assert
            CollectionAssert.AreEqual(rightByteArray, actualResult);
        }

        [TestMethod]
        public void ReturnNull_WhenJsonIsNull()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();
            var uploadService = new UploadCourseService(contextMock.Object);

            // Act
            var actualResult = uploadService.ImageToByteArray(null);

            // Assert
            Assert.AreEqual(null, actualResult);
        }
    }
}
