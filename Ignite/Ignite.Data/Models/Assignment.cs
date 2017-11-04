using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data.Models
{
    public class Assignment
    {
        public Assignment()
        {

        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public DateTime DateOfAssignment { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string State { get; set; }

        public decimal? TestResult { get; set; }

        public DateTime? DateOfCompletion { get; set; }
    }
}
