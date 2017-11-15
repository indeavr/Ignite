using Bytes2you.Validation;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Areas.Admin.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly ApplicationDbContext context;

        public AssignmentService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            var dbCourses = this.context.Courses.ToList();

            return dbCourses;
        }

        public async Task<Course> GetById(int id)
        {
            return await this.context.Courses.FindAsync(id);
        }

        public async Task CreateAssignment(CourseNameViewModel courseModel)
        {
            foreach (var user in courseModel.Users.Where(u => u.Checked))
            {
                var assignment = new Assignment();
                assignment.DateOfAssignment = DateTime.Now;
                assignment.State = AssignmentState.Pending;
                assignment.DueDate = courseModel.DueDate;
                assignment.CourseId = courseModel.CourseId;
                assignment.UserId = user.UserId;

                if (courseModel.Type == false)
                {
                    assignment.Type = "Optional";
                }
                else
                {
                    assignment.Type = "Mandatory";
                }

                this.context.Assignments.Add(assignment);
            }
            
           await SaveToDb();
        }

        public IEnumerable<Assignment> GetAllAssignments()
        {
            var dbAssignments = this.context.Assignments.ToList();

            return dbAssignments;
        }

        public Assignment RemoveAssignment(int assignmentId)
        {
            return null;
        }

        private async Task SaveToDb()
        {
            await this.context.SaveChangesAsync();
        }
    }
}