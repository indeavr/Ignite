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
        public Question()
        {
            this.Answers = new HashSet<Answer>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 6)]
        public string Statement { get; set; }

        [Required]
        //[MinLength(2, ErrorMessage = "You must add at least two Answers!")]
        //[MaxLength(8, ErrorMessage = "Max number of allowed answers is 8!")]
        public virtual ICollection<Answer> Answers { get; set; }

        [Required]
        public string CorrectAnswer { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
