using System;
using System.Collections.Generic;
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

        public int Id { get; set; }

        public int CourseId { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Course Course { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime DateOfAssignment { get; set; }

        public string Type { get; set; }

        public string State { get; set; }

        public decimal TestResult { get; set; }

        public DateTime DateOfCompletion { get; set; }
    }
}
