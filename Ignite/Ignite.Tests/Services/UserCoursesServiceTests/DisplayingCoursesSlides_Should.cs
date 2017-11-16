using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ignite.Data;
using Ignite.Data.Models;
using System.Data.Entity;
using Ignite.ViewModels;
using System.Collections.Generic;
using Ignite.Services;
using Ignite.Areas.Admin.ViewModels;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class DisplayingCoursesSlides_Should
    {
        [TestMethod]
        public void ShouldDisplayingCoursesSlides()
        {
            //var context = new Mock<ApplicationDbContext>();
            //var listOfIMages = new List<Image>();
            //var MockedDbSet = new Mock<DbSet<Image>>().Setup(;
            
            
            //var imageViewModel = new ImagesToCourosel();

            //foreach (var image in listOfImages)
            //{
            //    imageViewModel.Images.Add(image);
            //}

            //imageViewModel.CourseName = context.Courses.First(c => c.Id == 1).Name;


            
            //var advertImageService = new UserCoursesService(mockedDbSet.Object);
            //int testAdvertId = 1;
            //int expectedResult = 2;

            //mockedDbSet.Setup(rep => rep.All()).Returns(() => new List<AdvertImage>() {
            //    new AdvertImage() { Id = 1, ImageName = "1.jpg", AdvertImageId = 1 },
            //    new AdvertImage() { Id = 2, ImageName = "2.jpg", AdvertImageId = 2},
            //    new AdvertImage() { Id = 3, ImageName = "3.jpg", AdvertImageId = 1 },
            //    new AdvertImage() { Id = 4, ImageName = "4.jpg", AdvertImageId = 3}
            //}.AsQueryable());

            var contextdbMock = new Mock<ApplicationDbContext>();
            var images = new List<Image>()
            {
                new Image() {Name="Img1"}
            };
            var dbSetImages = new Mock<DbSet<Image>>().SetupData(images);

            contextdbMock.SetupGet(m => m.Images).Returns(dbSetImages.Object);

            var listOfImages = new List<ImageViewModel>()
            {
                new ImageViewModel() { Name= "Img1" }               
            };

            

            //var userCourseService = new UserCoursesService(contextdbMock.Object);

            //var result = userCourseService.DisplayingCoursesSlides();
            //userCourseService.DisplayingCoursesSlides(It.IsAny<int>());

            //Assert.AreEqual(images, result.);

        }
    }
}
