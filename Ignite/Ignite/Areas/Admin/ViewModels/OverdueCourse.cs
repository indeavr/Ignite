using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class OverdueCourse
    {
        public string Username { get; set; }

        public TimeSpan OverdueWith { get; set; }

        public string CourseName { get; set; }
    }
}