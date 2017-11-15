using Ignite.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Admin.Services.Interfaces
{
    public interface IUploadCourseService
    {
        int GetCourseId();

        bool ValidateJson(HttpPostedFileBase json);

        Task SaveCourse(HttpPostedFileBase json);

        byte[] ImageToByteArray(HttpPostedFileBase image);

        Task SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView);
    }
}
