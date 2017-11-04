namespace Ignite.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ignite.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ignite.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            if (!context.Roles.Any())
            {
                var role = new IdentityRole("Admin");
                context.Roles.Add(role);
                context.SaveChanges();

            }
              

            //var userRole = new IdentityUserRole();
            //userRole.RoleId = role.Id;
            //userRole.UserId = context.Users.First(u => u.UserName == "admin").Id;
        
        }
    }
}
