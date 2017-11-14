using Bytes2you.Validation;
using Ignite.Areas.Admin.Services.Interfaces;
using Ignite.Areas.Admin.ViewModels;
using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Course GetById(int id)
        {
            return this.context.Courses.Find(id);
        }

        public void CreateAssignment(CourseNameViewModel courseModel)
        {
            var assignment = new Assignment();

            assignment.DateOfAssignment = DateTime.Now;

            assignment.State = AssignmentState.Pending;

            assignment.DueDate = courseModel.DueDate;

            assignment.CourseId = courseModel.CourseId;


            foreach (var user in courseModel.Users)
            {
                if (user.Checked)
                {
                    if (courseModel.Type == false)
                    {
                        assignment.Type = "Optional";
                    }
                    else
                    {
                        assignment.Type = "Mandatory";
                    }

                    assignment.UserId = user.UserId;

                    context.Assignments.Add(assignment);

                    context.SaveChanges();
                }
            }
            //context.SaveChanges();
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
    }
}