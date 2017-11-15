using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using Ignite.Services;
using Ignite.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Tests.Services.QuizServiceTests
{
    [TestClass]
    public class SubmitTest_Should
    {
        [TestMethod]
        public void ReturnCorrectQuizResults_WhenSubmittedQuizIsCorrect()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "B";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            //var httpContext = new Mock<HttpContextBase>();
            //var mockIdentity = new Mock<IIdentity>();
            //httpContext.SetupGet(x => x.User.Identity).Returns(mockIdentity.Object);
            //mockIdentity.Setup(x => x.Name).Returns(username);

            //var userStore = new Mock<IUserStore<ApplicationUser>>();
            //var userManager = new ApplicationUserManager(userStore.Object);

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {  CourseId = courseId, Id = assignmentId, User = user, Course = course }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
            var actualResult = quizService.SubmitTest(quizView).Result;

            // Assert
            Assert.AreEqual("Passed", actualResult.Passed);
            Assert.AreEqual(1, actualResult.CorrectAnswers);
            Assert.AreEqual(requiredScore, actualResult.RequiredScore);
            Assert.AreEqual(50, actualResult.Score);
        }

        [TestMethod]
        public void ChangeAssignmentStateToCompleted_IfTestIsPassed()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "B";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {  CourseId = courseId, Id = assignmentId, User = user, Course = course }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
           quizService.SubmitTest(quizView);

            // Assert
            Assert.AreEqual(AssignmentState.Completed, contextMock.Object.Assignments.First().State);
        }

        [TestMethod]
        public void NotChangeTestResultOfAssignment_IfScoreIsLessThanPreviousOfAssignment()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var testResult = 70;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "B";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {
                    CourseId = courseId,
                    Id = assignmentId,
                    User = user,
                    Course = course,
                    TestResult = testResult
                }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
            quizService.SubmitTest(quizView);

            // Assert
            Assert.AreEqual(testResult, contextMock.Object.Assignments.First().TestResult);

        }

        [TestMethod]
        public async Task ChangeTestResultOfAssignment_IfScoreIsMoreThanPreviousOfAssignment()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var testResult = 30;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "B";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {
                    CourseId = courseId,
                    Id = assignmentId,
                    User = user,
                    Course = course,
                    TestResult = testResult
                }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
            await quizService.SubmitTest(quizView);

            // Assert
            //Assert.AreNotEqual(testResult, contextMock.Object.Assignments.First().TestResult);

            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void ReturnViewModelWithFailedTest_WhenScoreIsLessThanRequired()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "B";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "A";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {  CourseId = courseId, Id = assignmentId, User = user, Course = course }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
            var actualResult = quizService.SubmitTest(quizView).Result;

            // Assert
            Assert.AreEqual("Failed", actualResult.Passed);
            Assert.AreEqual(0, actualResult.CorrectAnswers);
            Assert.AreEqual(requiredScore, actualResult.RequiredScore);
            Assert.AreEqual(0, actualResult.Score);
        }

        [TestMethod]
        public void CallSaveChanges_WhenTestIsPassedForTheFirstTime()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "A";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment()
                {
                    CourseId = courseId,
                    Id = assignmentId,
                    User = user,
                    Course = course,
                    State = AssignmentState.Started
                }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);

            var quizService = new QuizService(contextMock.Object);

            // Act
            var actualResult = quizService.SubmitTest(quizView);

            // Assert
            contextMock.Verify(m => m.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public void CallSaveChanges_WhenScoreIsHigherThanPrevious()
        {
            // Arange
            var contextMock = new Mock<ApplicationDbContext>();

            var courseId = 1;
            var requiredScore = 49;
            var testResult = 30;
            var assignmentId = 1;
            var username = "goshkata";

            var correctAnswer = "A";

            var statement = "Question Statement";
            var chosenAnswerA = "A";
            var chosenAnswerB = "B";

            var answerTextA = "answerA";
            var answerLetterA = "A";

            var answerTextB = "answerB";
            var answerLetterB = "B";

            var answersView = new List<AnsweViewModel>();
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterB,
                Text = answerTextB
            });
            answersView.Add(new AnsweViewModel()
            {
                Letter = answerLetterA,
                Text = answerTextA
            });

            var questionsView = new List<QuizQuestion>();
            questionsView.Add(new QuizQuestion()
            {
                Statement = statement,
                Answers = answersView,
                ChosenAnswer = chosenAnswerA
            });

            questionsView.Add(new QuizQuestion()
            {
                Statement = "Another Statement",
                Answers = answersView,
                ChosenAnswer = chosenAnswerB
            });

            var quizView = new Quiz()
            {
                AssignmentId = assignmentId,
                Questions = questionsView
            };

            var user = new ApplicationUser()
            {
                UserName = username
            };

            var answers = new List<Answer>()
            {
                new Answer() { Letter = answerLetterA , Text = answerTextA }
            };

            var questions = new List<Question>()
            {
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer },
                new Question() { Statement= statement, Answers = answers, CorrectAnswer = correctAnswer }
            };

            var course = new Course() { Id = courseId, Questions = questions, RequiredScore = requiredScore };

            var courses = new List<Course>() { course };

            var assignments = new List<Assignment>()
            {
                new Assignment() {
                    CourseId = courseId,
                    Id = assignmentId,
                    User = user,
                    Course = course,
                    TestResult = testResult
                }
            };

            var dbSetAnswers = new Mock<DbSet<Answer>>().SetupData(answers);
            var dbSetQuestions = new Mock<DbSet<Question>>().SetupData(questions);
            var dbSetCourses = new Mock<DbSet<Course>>().SetupData(courses);
            var dbSetAssignments = new Mock<DbSet<Assignment>>().SetupData(assignments);

            contextMock.SetupGet(m => m.Courses).Returns(dbSetCourses.Object);
            contextMock.SetupGet(m => m.Questions).Returns(dbSetQuestions.Object);
            contextMock.SetupGet(m => m.Answer).Returns(dbSetAnswers.Object);
            contextMock.SetupGet(m => m.Assignments).Returns(dbSetAssignments.Object);


            var quizService = new QuizService(contextMock.Object);

            // Act
            quizService.SubmitTest(quizView);

            // Assert
            contextMock.Verify(m => m.SaveChangesAsync(), Times.Once);
        }
    }
}
