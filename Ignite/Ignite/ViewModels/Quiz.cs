using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "AssignmentId is Required")]
        public int AssignmentId { get; set; }
    }
}