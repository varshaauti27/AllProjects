namespace BlogPostWebsite.Migrations
{
    using BlogPostWebsite.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogPostWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogPostWebsite.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "User" }
                );

            context.SaveChanges();

            context.Categories.AddOrUpdate(r => r.Name,
                new Category { Name = "Food" },
                new Category { Name = "Health" },
                new Category { Name = "News" },
                new Category { Name = "Sports" },
                new Category { Name = "Books" },
                new Category { Name = "Science" }
                );

            CreateNewUser(context, "admin", "admin@blog.com", "Admin", "admin@123");
            CreateNewUser(context, "varsha", "varsha@blog.com", "User", "varsha@123");
        }

        private void CreateNewUser(BlogPostWebsite.Models.ApplicationDbContext context, string userName, string email, string role, string password)
        {
            if (!context.Users.Any(u => u.UserName == userName))
            {
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                var user = new ApplicationUser
                {
                    UserName = userName,
                    Email = email,
                };

                manager.Create(user, password);

                manager.AddToRole(user.Id, role);

                context.SaveChanges();
            }
        }
    }
}
