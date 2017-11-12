using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.ViewModels
{
    public class AnsweViewModel
    {
        public AnsweViewModel(string text, string letter)
        {
            this.Text = text;
            this.Letter = letter;
        }

        public int Id { get; set; }

        public string Text { get; set; }

        public string Letter { get; set; }
    }
}