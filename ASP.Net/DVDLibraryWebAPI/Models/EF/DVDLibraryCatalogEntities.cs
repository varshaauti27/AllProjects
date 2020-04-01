using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryWebAPI.Models.EF
{
    public class DVDLibraryCatalogEntities : DbContext
    {
        public DVDLibraryCatalogEntities() : base("DVDLibraryEF")
        {
        }

        public DbSet<DVD> Dvd { get; set; }
    }
}