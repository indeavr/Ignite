using Bytes2you.Validation;
using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ignite.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext context;

        public QuizService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public List<QuizQuestion> GetTest(int courseId)
        {
            var questions = this.context.Courses.Single(c => c.Id == courseId).Questions.ToList();

            var quiz = new List<QuizQuestion>();
            foreach (var question in questions)
            {
                var currentQ = new QuizQuestion();
                currentQ.Statement = question.Statement;
                foreach (var answer in question.Answers)
                {
                    var answerView = new AnsweViewModel(answer, question.CorrectAnswer == answer ? true : false);

                    currentQ.Answers.Add(answerView);
                }
                quiz.Add(currentQ);
            }

            return quiz;
        }
    }
}