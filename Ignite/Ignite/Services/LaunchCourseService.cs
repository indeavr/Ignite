using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Ignite.Data.Models;
using Ignite.Data;
using Ignite.Services.Contracts;

namespace Ignite.Services
{
    public class LaunchCourseService: ILaunchCourseService
    {
        //TODO method TakeSLidesFromCourses(int id) {}  
        private readonly ApplicationDbContext context;

        public LaunchCourseService(ApplicationDbContext context)
        {
            //Guard todo
            this.context = context;
        }


        //public async Task<ActionResult> RenderImage(int id)
        //{

        //    Image item = await context.Images.FindAsync(id);      //FindAsync(id);

        //    byte[] photoBack = item.Content;

        //    return FileContentResult(photoBack, "image/png");
        //}
            
            
    }
}