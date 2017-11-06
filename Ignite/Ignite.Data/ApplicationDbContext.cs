using Ignite.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignite.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("IgniteDatabase", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Question> Questions { get; set; }

        public IDbSet<Assignment> Assignments { get; set; }

        public IDbSet<Image> Images { get; set; }
    }
}
