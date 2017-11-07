using Ignite.Areas.Admin.ViewModels;
using System.Collections.Generic;
using System.Web;

namespace Ignite.Admin.Services.Interfaces
{
    public interface IUploadCourseService
    {
        int GetCourseId();

        bool ValidateJson(HttpPostedFileBase json);

        void SaveCourse(HttpPostedFileBase json);

        byte[] ImageToByteArray(HttpPostedFileBase image);

        void SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView);
    }
}
