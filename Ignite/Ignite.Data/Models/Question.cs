using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Statement { get; set; }

        [Required]
        public string A { get; set; }

        [Required]
        public string B { get; set; }

        [Required]
        public string C { get; set; }

        [Required]
        public string D { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
