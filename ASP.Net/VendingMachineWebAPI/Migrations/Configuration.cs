namespace VendingMachineWebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VendingMachineWebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VendingMachineWebAPI.Models.EF.ItemCatalogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VendingMachineWebAPI.Models.EF.ItemCatalogEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Items.AddOrUpdate(
                 i => i.ItemId,
                new Item { Name = "Kit-Kat", Price = 2.99M, Quantity = 20 },
                new Item { Name = "Green Tea", Price = 1.99M, Quantity = 9 },
                new Item { Name = "Dairy Milk", Price = 2.99M, Quantity = 0 },
                new Item { Name = "Peanut-Butter", Price = 3.99M, Quantity = 15 },
                new Item { Name = "Kinder Eggs", Price = 0.99M, Quantity = 8 },
                new Item { Name = "M&M", Price = 0.99M, Quantity = 0 }
                );

            context.SaveChanges();
        }
    }
}