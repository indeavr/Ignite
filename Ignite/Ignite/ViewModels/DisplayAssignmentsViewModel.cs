using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class DisplayAssignmentsViewModel
    {
        [Required(ErrorMessage = "Course Id is Required")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is Required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Due Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Assignment Type is Required")]
        public string Type { get; set; }
    }
}