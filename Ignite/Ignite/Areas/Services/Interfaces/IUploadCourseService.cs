using Ignite.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ignite.Admin.Services.Interfaces
{
    public interface IUploadCourseService
    {
        int GetCourseId();

        bool ValidateJson(HttpPostedFileBase json);

        void SaveCourse(HttpPostedFileBase json);

        byte[] ImageToByteArray(HttpPostedFileBase ProfilePhoto);

        void SaveSlidesToCourse(int courseId, List<ImageViewModel> imagesView);
    }
}
