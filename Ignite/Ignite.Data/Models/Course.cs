using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Questions = new HashSet<Question>();
            this.Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public double RequiredScore { get; set; }

        // content

        public virtual IEnumerable<Question> Questions { get; set; }

        public virtual IEnumerable<Assignment> Assignments { get; set; }

    }
}
