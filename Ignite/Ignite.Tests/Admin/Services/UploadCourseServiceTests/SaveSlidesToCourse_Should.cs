using Ignite.Admin.Services;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Admin.Services.UploadCourseServiceTests
{
    [TestClass]
    public class SaveSlidesToCourse_Should
    {
        [TestMethod]
        public void AddImagesToContext_WhenParametersAreCorrect()
        {
            // Arange
            var dbMock = new Mock<ApplicationDbContext>();
            var images = new List<Image>()
            {
                new Image()
            };
            var dbSetImages = new Mock<DbSet<Image>>().SetupData(images);
            dbMock.SetupGet(m => m.Images).Returns(dbSetImages.Object);

            var listOfImages = new List<ImageViewModel>()
            {
                new ImageViewModel() { Name= "Image1" },
                new ImageViewModel() { Name= "Image2" },
                new ImageViewModel() { Name= "Image3" }
            };
            var uploadService = new UploadCourseService(dbMock.Object);

            // Act
            uploadService.SaveSlidesToCourse(It.IsAny<int>(), listOfImages);

            // Assert
            Assert.AreEqual(listOfImages.Count + 1,
                dbSetImages.Object.ToList().Count);

            for (int i = 1; i < dbSetImages.Object.ToList().Count; i++)
            {
                Assert.AreEqual(dbSetImages.Object.ToList()[i].Name,
                    listOfImages[i - 1].Name);
            }
        }
    }
}
