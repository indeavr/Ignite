using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.Data;
using Moq;
using Ignite.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class RenderImage_Should
    {
        [TestMethod]
        public void RenderImage_ByImageId()
        {
            int imgId = 1;
            var context = new Mock<ApplicationDbContext>();

            var arrToByte = new byte[255];
            var image = new Image() {Id = 1, Content = arrToByte };
            var listOfImages = new List<Image>();
            listOfImages.Add(image);

            var userDbSetMock = new Mock<DbSet<Image>>().SetupData(listOfImages);
            context.Setup(c => c.Images).Returns(userDbSetMock.Object);
            //public byte[] RenderImg(int imgId)
            //{
            //    Image image = this.context.Images.First(i => i.Id == imgId);
            //    return image.Content;
            //}
            Assert.AreEqual(context.Object.Images.First().Id , imgId);
        
        }

        [TestMethod]
        public void RenderImage_ByImageContent()
        {
            int imgId = 1;
            var context = new Mock<ApplicationDbContext>();

            var arrToByte = new byte[255];
            var image = new Image() { Id = 1, Content = arrToByte };
            var listOfImages = new List<Image>();
            listOfImages.Add(image);

            var userDbSetMock = new Mock<DbSet<Image>>().SetupData(listOfImages);
            context.Setup(c => c.Images).Returns(userDbSetMock.Object);
            
            Assert.AreEqual(context.Object.Images.First().Content, arrToByte);
        }
    }
}
