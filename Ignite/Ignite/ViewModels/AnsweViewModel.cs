using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class AnsweViewModel
    {
        public AnsweViewModel(string text, bool isCorrect)
        {
            this.Text = text;
            this.IsCorrect = isCorrect;
        }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}