using Ignite.Data;
using Ignite.Data.Models;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignite.Data.Enums;
using Bytes2you.Validation;

namespace Ignite.Services
{
    public class UserCoursesService : IUserCourseService
    {
        private readonly ApplicationDbContext context;
        

        public UserCoursesService(ApplicationDbContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public ImagesToCourosel DisplayingCoursesSlides(int courseId)
        {
            var listOfImages = context.Images.ToList();

            var imageViewModel = new ImagesToCourosel();
            foreach (var image in listOfImages)
            {
                imageViewModel.Images.Add(image);
            }

            imageViewModel.CourseName = context.Courses.First(c => c.Id == 1).Name;

            return imageViewModel;
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
                else if (assignment.State == AssignmentState.Overdue)
                {
                    allAssignments.Overdue.Add(assignment);
                }
            }
            return allAssignments;
            
        }

        public byte[] RenderImg(int imgId)
        {
            Image image = this.context.Images.First(i => i.Id == imgId);
            return image.Content;
        }
     
        public void CheckStateChange(int courseId, string username)
        { 
            var assignment = this.context.Assignments.First(a => a.CourseId == courseId && a.User.UserName == username);

            if (assignment.State == AssignmentState.Pending)
            {
                assignment.State = AssignmentState.Started;
            }
        }

    }
}