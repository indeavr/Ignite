using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class QuizQuestion
    {
        public string Statement { get; set; }

        public List<AnsweViewModel> Answers;
    }
}