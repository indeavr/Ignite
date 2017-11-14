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
            var dbAssignments = this.context.Users.FirstOrDefault(u => u.UserName == username).Assignments.ToList();
            foreach (var assignment in dbAssignments)
            {
                if (assignment.State == AssignmentState.Started)
                {
                    allAssignments.Started.Add(assignment);
                }
                else if (assignment.State == AssignmentState.Pending)
                {
                    allAssignments.Pending.Add(assignment);
                }
                else if (assignment.State == AssignmentState.Completed)
                {
                    allAssignments.Completed.Add(assignment);
                }
            }
            
            return allAssignments;
        }
    }
}