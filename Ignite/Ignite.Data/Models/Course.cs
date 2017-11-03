using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateCreated { get; set; }

        public double RequredScore { get; set; }

        // content

        public virtual IEnumerable<Question> Questions { get; set; }

        public virtual IEnumerable<Assignment> Assignments { get; set; }

    }
}
