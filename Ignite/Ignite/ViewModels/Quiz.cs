using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class Quiz
    {
        public List<QuizQuestion> Questions { get; set; }

        public int AssignmentId { get; set; }
    }
}