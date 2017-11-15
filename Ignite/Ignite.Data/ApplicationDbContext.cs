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

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Assignment> Assignments { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Answer> Answer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Assignment>()
            //    .HasOptional(x => x.Course)
            //    .WithMany(c => c.Assignments)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Assignment>()
            //   .HasOptional(x => x.User)
            //   .WithMany(c => c.Assignments)
            //   .WillCascadeOnDelete(false);


            base.OnModelCreating(modelBuilder);
        }
    }
}
