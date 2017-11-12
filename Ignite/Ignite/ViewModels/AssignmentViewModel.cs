using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class AssignmentViewModel
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime DueDate { get; set; }
      
        public DateTime DateOfAssignment { get; set; }
       
        public string Type { get; set; }
      
        public AssignmentState State { get; set; }

        public decimal? TestResult { get; set; }

        public DateTime? DateOfCompletion { get; set; }
    }
}