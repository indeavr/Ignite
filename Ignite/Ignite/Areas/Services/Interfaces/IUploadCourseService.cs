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
        bool ValidateJson(HttpPostedFileBase json);

        void SaveCourse(HttpPostedFileBase json);
    }
}
