using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ignite.Areas.Admin.ViewModels
{
    public class UserAssignedViewModel : IValidatableObject
    {
        [Required(ErrorMessage = "Username is Required !")]
        public string Username { get; set; }

        [Required(ErrorMessage = "UserId is Required ! ")]
        public string UserId { get; set; }

        public bool Checked { get; set; }

        //[MyDate(ErrorMessage = "Date is Invalid !")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Type is Required !")]
        public bool Type { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DueDate < DateTime.Now && Checked == true)
                yield return new ValidationResult("Date is Invalid!", new[] { "DueDate" });
        }
    }
}