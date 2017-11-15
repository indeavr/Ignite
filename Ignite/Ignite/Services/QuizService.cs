using Bytes2you.Validation;
using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

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

        public Quiz GetTest(int courseId, string username)
        {
            var questions = this.context.Courses
                .First(c => c.Id == courseId)
                .Questions
                .ToList();

            var quizQuestions = new List<QuizQuestion>();

            foreach (var question in questions)
            {
                var currentQ = new QuizQuestion();
                currentQ.Statement = question.Statement;
                foreach (var answer in question.Answers)
                {
                    var answerView = new AnsweViewModel(answer.Text, answer.Letter);

                    currentQ.Answers.Add(answerView);
                }
                quizQuestions.Add(currentQ);
            }

            var quiz = new Quiz();
            quiz.Questions = quizQuestions;

            quiz.AssignmentId = this.context.Assignments
                .First(a => a.CourseId == courseId && a.User.UserName == username)
                .Id;

            return quiz;
        }

        public async Task<QuizResultViewModel> SubmitTest(Quiz quiz)
        {
            var shouldSaveChanges = false;

            var questionsCount = quiz.Questions.Count;
            var correctAnswersCount = CountCorrectAnswers(quiz);

            double score = Math.Round((correctAnswersCount / (double)questionsCount) * 100, 2);

            var quizResult = new QuizResultViewModel();

            double requiredScore = this.context.Assignments
                .First(a => a.Id == quiz.AssignmentId)
                .Course
                .RequiredScore;

            quizResult.Passed = "Failed";
            if (score >= requiredScore)
            {
                quizResult.Passed = "Passed";

                shouldSaveChanges = true;
                this.context.Assignments
                    .First(a => a.Id == quiz.AssignmentId)
                    .State = AssignmentState.Completed;
            }

            var assignment = this.context.Assignments
                .First(a => a.Id == quiz.AssignmentId);

            if (assignment.TestResult < score && assignment.State != AssignmentState.Completed)
            {
                shouldSaveChanges = true;

                this.context.Assignments
                    .First(a => a.Id == quiz.AssignmentId)
                    .TestResult = score;
            }

            quizResult.Score = score;
            quizResult.CorrectAnswers = correctAnswersCount;
            quizResult.RequiredScore = requiredScore;

            if (shouldSaveChanges)
            {
                await SaveToDb();
            }

            return quizResult;
        }

        private int CountCorrectAnswers(Quiz quiz)
        {
            var correctAnswerCount = 0;

            var courseId = this.context.Assignments
                .First(a => a.Id == quiz.AssignmentId)
                .CourseId;

            var questionsInDb = this.context.Courses
                .First(c => c.Id == courseId)
                .Questions
                .ToList();

            for (int i = 0; i < quiz.Questions.Count; i++)
            {
                var question = quiz.Questions[i];
                Guard.WhenArgument(question.ChosenAnswer, "ChosenAnswer").IsNull().Throw();

                if (questionsInDb[i].CorrectAnswer == question.ChosenAnswer)
                {
                    correctAnswerCount++;
                }
            }

            return correctAnswerCount;
        }

        private async Task SaveToDb()
        {
            await this.context.SaveChangesAsync();
        }
    }
}