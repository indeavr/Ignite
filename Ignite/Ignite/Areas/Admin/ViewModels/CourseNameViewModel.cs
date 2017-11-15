using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignite.Areas.Admin.ViewModels
{
    public class CourseNameViewModel
    {
        public CourseNameViewModel()
        {
            this.Users = new List<UserAssignedViewModel>();
        }

        [Required(ErrorMessage = "Course Name is Required !")]
        public string Name { get; set; }

        [MyDate(ErrorMessage = "Invalid date")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Type is Required !")]
        public bool Type { get; set; }


        [Required(ErrorMessage = "Users field is Required !")]
        public List<UserAssignedViewModel> Users { get; set; }

        public int CourseId { get; set; }

    }

    public class MyDateAttribute : ValidationAttribute//, IClientValidatable
    {
        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;

        }
    }
}