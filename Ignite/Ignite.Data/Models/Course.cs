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
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
       // [Range(1,100)]
        public double RequiredScore { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

    }
}
