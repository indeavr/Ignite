using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.ViewModels
{
    public class ImagesToCourosel
    {
        public ImagesToCourosel()
        {
            this.Images = new List<Image>();
        }

        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public List<Image> Images { get; set; }
    }
}