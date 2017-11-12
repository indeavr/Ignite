using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class Assignment2ViewModel
    {

        public Assignment2ViewModel()
        {
            this.Courses = new List<Course>();
        }

        public IEnumerable<Course> Courses;
    }
}