using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels.statistics
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string CourseName { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime DateOfAssignment { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public decimal? TestResult { get; set; }

        public DateTime? DateOfCompletion { get; set; }
    }
}