using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Statement { get; set; }

        public string A { get; set; }

        public string B { get; set; }

        public string C { get; set; }

        public string D { get; set; }

        public string CorrectAnswer { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
