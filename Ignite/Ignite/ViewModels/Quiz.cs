using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class Quiz
    {
        public Quiz()
        {
            this.Questions = new List<QuizQuestion>();
        }

        public List<QuizQuestion> Questions { get; set; }

        public int AssignmentId { get; set; }
    }
}