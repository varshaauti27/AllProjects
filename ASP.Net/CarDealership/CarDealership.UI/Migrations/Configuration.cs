namespace CarDealership.UI.Migrations
{
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.UI.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Roles.AddOrUpdate(r => r.Name,
                 new IdentityRole { Name = "Admin" },
                 new IdentityRole { Name = "Sales" },
                 new IdentityRole { Name = "Disabled" }
             );

            context.SaveChanges();

            //Admin user
            CreateNewUser(context, "admin" ,"admin@car.com","Admin","admin@123");
            //Sale Role user
            CreateNewUser(context, "sales","sales@car.com", "Sales","sales@123");
            //Disable Role user
            CreateNewUser(context, "disables", "disabled@car.com", "Disabled", "disabled@123");

            CreateNewUser(context,"varsha", "varsha@car.com", "Admin", "varsha@123");
            CreateNewUser(context,"ashish", "Ashish@car.com", "Sales", "ashish@123");
        }

        private void CreateNewUser(ApplicationDbContext context, string userName, string email, string role, string password)
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
