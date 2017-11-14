using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class CourseNameViewModel
    {
        public CourseNameViewModel()
        {
            this.Users = new List<ApplicationUser>();
        }

        public string Name { get; set; }

        public DateTime DueDate { get; set; }

        public bool Type { get; set; }

        public AssignmentState State { get; set; }

        public string UserId { get; set; }

        public IEnumerable<ApplicationUser> Users { get; set; }

        public int CourseId { get; set; }

        public bool Checked { get; set; }
    }
}