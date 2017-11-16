using Bytes2you.Validation;
using Ignite.Data;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using Ignite.Services.Contracts;
using Ignite.ViewModels;
using System.Linq;
using System.Threading.Tasks;

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
                var assignmentViewModel = new DisplayAssignmentsViewModel();
                assignmentViewModel.CourseId = assignment.CourseId;
                assignmentViewModel.CourseName = assignment.Course.Name; 
                assignmentViewModel.DueDate = assignment.DueDate;
                assignmentViewModel.Type = assignment.Type;

                if (assignment.State == AssignmentState.Started)
                {
                    allAssignments.Started.Add(assignmentViewModel);
                }
                else if (assignment.State == AssignmentState.Pending)
                {
                    allAssignments.Pending.Add(assignmentViewModel);
                }
                else if (assignment.State == AssignmentState.Completed)
                {
                    allAssignments.Completed.Add(assignmentViewModel);
                }
                else if (assignment.State == AssignmentState.Overdue)
                {
                    allAssignments.Overdue.Add(assignmentViewModel);
                }
            }
            return allAssignments;
        }

        public byte[] RenderImg(int imgId)
        {
            Image image = this.context.Images.First(i => i.Id == imgId);
            return image.Content;
        }
     
        public async Task CheckStateChange(int courseId, string username)
        { 
            var assignment = this.context.Assignments.First(a => a.CourseId == courseId && a.User.UserName == username);

            if (assignment.State == AssignmentState.Pending)
            {
                assignment.State = AssignmentState.Started;
                await SaveToDb();
            }
        }

        private async Task SaveToDb()
        {
            await this.context.SaveChangesAsync();
        }

    }
}