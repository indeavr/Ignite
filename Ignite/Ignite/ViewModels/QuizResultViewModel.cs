using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class QuizResultViewModel
    {
        public double Score { get; set; }

        public string Passed { get; set; }

        public double RequiredScore { get; set; }

        public int CorrectAnswers { get; set; }
    }
}