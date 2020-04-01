using DVDLibraryWebAPI.Models;
using DVDLibraryWebAPI.Models.EF;
using DVDLibraryWebAPI.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDLibraryWebAPI.Data
{
    public class DvdRepositoryEF : IDvdRepository
    {
        readonly DVDLibraryCatalogEntities _dvdCatalog = new DVDLibraryCatalogEntities();
        public void Add(DVD dvd)
        {
            //dvd.DvdId = _dvdCatalog.Dvd.Max(d => d.DvdId) + 1;
            _dvdCatalog.Dvd.Add(dvd);
            _dvdCatalog.SaveChanges();
        }

        public void Delete(int id)
        {
            _dvdCatalog.Dvd.Remove(_dvdCatalog.Dvd.FirstOrDefault(i=>i.DvdId ==id));
            _dvdCatalog.SaveChanges();
        }

        public void Edit(DVD dvd)
        {
            var found = _dvdCatalog.Dvd.FirstOrDefault(d => d.DvdId == dvd.DvdId);

            if (found != null)
                found = dvd;
            //_dvdCatalog.Entry().State = EntityState.Modified;
            _dvdCatalog.SaveChanges();
        }

        public List<DVD> GetAllDvds()
        {
            return _dvdCatalog.Dvd.ToList();
        }

        public DVD GetDvd(int id)
        {
            return _dvdCatalog.Dvd.FirstOrDefault(i => i.DvdId == id);
        }

        public List<DVD> GetDvdByDirectorName(string directorName)
        {
            return _dvdCatalog.Dvd.ToList().FindAll(i => i.Director.ToLower().Contains(directorName));
        }

        public List<DVD> GetDvdByRating(string rating)
        {
            return _dvdCatalog.Dvd.ToList().FindAll(i => i.Rating.Equals(rating));
        }

        public List<DVD> GetDvdByTitle(string title)
        {
            return _dvdCatalog.Dvd.ToList().FindAll(i => i.Title.ToLower().Contains(title));
        }

        public List<DVD> GetDvdByYear(int releaseYear)
        {
            return _dvdCatalog.Dvd.ToList().FindAll(i => i.ReleaseYear.Equals(releaseYear));
        }
    }
}