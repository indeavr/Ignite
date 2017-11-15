using Ignite.Areas.Admin.ViewModels;
using Ignite.Data.Enums;
using Ignite.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Areas.Admin.Services.Interfaces
{
    public interface IAssignmentService
    {
        IEnumerable<Course> GetAllCourses();

        Course GetById(int id);

        void CreateAssignment(CourseNameViewModel courseModel);

        IEnumerable<Assignment> GetAllAssignments();

        Assignment RemoveAssignment(int assignmentId);
    }
}
