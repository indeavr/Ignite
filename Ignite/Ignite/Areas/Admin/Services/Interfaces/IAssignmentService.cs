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

        Task<Course> GetById(int id);

        Task CreateAssignment(CourseNameViewModel courseModel);

        IEnumerable<Assignment> GetAllAssignments();

        void RemoveAssignment(int assignmentId);
    }
}
