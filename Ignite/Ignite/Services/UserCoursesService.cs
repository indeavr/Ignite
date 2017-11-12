using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignite.Data.Enums;

namespace Ignite.Services
{
    public class UserCoursesService : IUserCourseService
    {
        private readonly ApplicationDbContext context;
        
        public UserCoursesService(ApplicationDbContext context)
        {
            //Guard todo
            this.context = context;
        }

        public AllAssignmentsPerUserViewModels GetAllAssignmentsPerUser(string username)
        {
            var allAssignments = new AllAssignmentsPerUserViewModels();
            
            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 1,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Pending.Add(new AssignmentViewModel()
            {
                CourseId = 1,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Pending,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Started.Add(new AssignmentViewModel()
            {
                CourseId = 1,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,  
                Type = "Something",
                State = AssignmentState.Started,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 2,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 3,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 4,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 5,
                Course = new Course() { Name = "Maina" },
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });

            allAssignments.Completed.Add(new AssignmentViewModel()
            {
                CourseId = 6,
                Course = new Course() { Name="Maina"},
                DueDate = DateTime.Now,
                DateOfAssignment = DateTime.Today,
                Type = "Something",
                State = AssignmentState.Completed,
                TestResult = 100,
                DateOfCompletion = DateTime.Now
            });


            var dbAssignments = this.context.Users.FirstOrDefault(u => u.UserName == username).Assignments.ToList();

            
            //foreach (var assignment in dbAssignments)
            //{
            //    if (assignment.State == AssignmentState.Started)
            //    {
            //        allAssignments.Started.Enqueue(assignment);
            //    }
            //    else if (assignment.State == AssignmentState.Pending)
            //    {
            //        allAssignments.Pending.Enqueue(assignment);
            //    }
            //    else if (assignment.State == AssignmentState.Completed)
            //    {
            //        allAssignments.Completed.Enqueue(assignment);
            //    }
            //}
            //context.SaveChanges();
            return allAssignments;

        }
    }
}