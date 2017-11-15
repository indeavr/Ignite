using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage ="Course Id is Required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is Required")]
        public string CourseName { get; set; }

        public List<Image> Images { get; set; }
    }
}