using Ignite.Data.Models;
using Ignite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Services.Contracts
{
    public interface IUserCourseService
    {
        byte[] RenderImg(int imgId);
        AllAssignmentsPerUserViewModels GetAllAssignmentsPerUser(string user);
        ImagesToCourosel DisplayingCoursesSlides(int courseId, string username);
        Task CheckStateChange(int courseId, string username);
    }
}
