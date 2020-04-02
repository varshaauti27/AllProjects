using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VendingMachineWebAPI.Models.EF
{
    public class ItemCatalogEntities : DbContext
    {
        public ItemCatalogEntities() : base("ItemCatalog")
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}