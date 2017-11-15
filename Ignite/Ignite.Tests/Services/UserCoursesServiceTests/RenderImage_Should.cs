using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ignite.Data;
using Moq;
using Ignite.Data.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace Ignite.Tests.Services.UserCoursesServiceTests
{
    [TestClass]
    public class RenderImage_Should
    {
        [TestMethod]
        public void RenderImageWithPassedParameter()
        {
            int imgId = 1;
            var context = new Mock<ApplicationDbContext>();

            var image = new Image();

            var listOfImages = new List<Image>();

            var userDbSetMock = new Mock<DbSet<Image>>().SetupData();


        }
    }
}
