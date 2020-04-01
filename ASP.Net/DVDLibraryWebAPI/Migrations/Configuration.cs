namespace DVDLibraryWebAPI.Migrations
{
    using DVDLibraryWebAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDLibraryWebAPI.Models.EF.DVDLibraryCatalogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDLibraryWebAPI.Models.EF.DVDLibraryCatalogEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Dvd.AddOrUpdate(
                i => i.DvdId,
               new DVD { Title = "Batman Begins", ReleaseYear = 2005, Director = "Christopher Nolan", Rating = "PG-13", Notes = "After training with his mentor, Batman begins his fight to free crime-ridden Gotham City from corruption." },
               new DVD { Title = "Best in Show", ReleaseYear = 2000, Director = "Christopher Guest", Rating = "PG-13", Notes = "A colorful array of characters compete at a national dog show." },
               new DVD { Title = "Big", ReleaseYear = 1998, Director = "Penny Marshall", Rating = "PG", Notes = "After wishing to be made big, a teenage boy wakes the next morning to find himself mysteriously in the body of an adult." },
               new DVD { Title = "Cast Away", ReleaseYear = 2000, Director = "Robert Zemeckis", Rating = "PG-13", Notes = "A FedEx executive undergoes a physical and emotional transformation after crash landing on a deserted island." },
               new DVD { Title = "Chicago", ReleaseYear = 2002, Director = "Rob Marshall", Rating = "PG-13", Notes = "Two death-row murderesses develop a fierce rivalry while competing for publicity, celebrity, and a sleazy lawyer's attention" },
               new DVD { Title = "Elephant", ReleaseYear = 2003, Director = "Gus Van Sant", Rating = "R", Notes = "Several ordinary high school students go through their daily routine as two others prepare for something more malevolent." }
               );

            context.SaveChanges();
        }
    }
}
