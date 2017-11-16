using Ignite.Admin.Services;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
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
    public class ReadCourseFromJson_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenModelCourseFileIsNull()
        {
            //Arrange
            var contextMock = new Mock<ApplicationDbContext>();
            var service = new UploadCourseService(contextMock.Object);

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => service.ReadCourseFromJson(null));
        }

        [TestMethod]
        public void ThrowException_WhenJsonInputStreamIsEmpty()
        {
            //Arrange
            var contextMock = new Mock<ApplicationDbContext>();
            var services = new UploadCourseService(contextMock.Object);
            var jsonFileMock = new Mock<HttpPostedFileBase>();

            FileStream stream = new FileStream(@"..\..\Empty.json", FileMode.Open);
            jsonFileMock.Setup(x => x.InputStream).Returns(stream);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => services.ReadCourseFromJson(jsonFileMock.Object));

            stream.Dispose();
        }

        [TestMethod]
        public void ReturnCourse_WhenParametersAreCorrect()
        {
            //Arrange
            var dbMock = new Mock<ApplicationDbContext>();
            var services = new UploadCourseService(dbMock.Object);
            var jsonFileMock = new Mock<HttpPostedFileBase>();

            Course expected = new Course() { Id = 1, Description = "just", Name = "Gincho" };
            var courseJson = JsonConvert.SerializeObject(expected);

            MemoryStream memoryStream = new MemoryStream();
            StreamWriter writer = new StreamWriter(memoryStream);
            writer.Write(courseJson);
            writer.Flush();

            memoryStream.Position = 0;

            jsonFileMock.SetupGet(m => m.InputStream).Returns(memoryStream);

            //Act 
            Course actual = services.ReadCourseFromJson(jsonFileMock.Object);

            //Assert
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);

            writer.Dispose();
        }
    }
}
