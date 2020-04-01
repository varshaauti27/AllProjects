using DVDLibraryWebAPI.Models;
using DVDLibraryWebAPI.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryWebAPI.Data
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static readonly List<DVD> _allDvds = new List<DVD>()
        {
            new DVD
            {       
                DvdId= 0,
                Title="A Great Tale",
                ReleaseYear = 2015, 
                Director = "Sam Jones", 
                Rating = "PG", 
                Notes = "This really is a great tale!!"
            },
            new DVD
            {
                DvdId= 1,
                Title="A Good Tale",
                ReleaseYear = 2012,
                Director = "Joe Smith",
                Rating = "PG-13",
                Notes = "This really is a good tale!!"
            }
        };

        public void Add(DVD dvd)
        {
            dvd.DvdId = _allDvds.Max(d => d.DvdId) + 1;
            _allDvds.Add(dvd);
        }

        public void Delete(int id)
        {
            _allDvds.RemoveAll(d => d.DvdId == id);
        }

        public void Edit(DVD dvd)
        {
            var found = _allDvds.FirstOrDefault(d => d.DvdId == dvd.DvdId);

            if (found != null)
                found = dvd;
        }

        public List<DVD> GetAllDvds()
        {
            return _allDvds;
        }

        public DVD GetDvd(int id)
        {
            return _allDvds.FirstOrDefault(i => i.DvdId == id);
        }

        public List<DVD> GetDvdByDirectorName(string directorName)
        {
            return _allDvds.FindAll(i => i.Director.ToLower().Contains(directorName));
        }

        public List<DVD> GetDvdByRating(string rating)
        {
            return _allDvds.FindAll(i => i.Rating.Equals(rating));
        }

        public List<DVD> GetDvdByTitle(string title)
        {
            return _allDvds.FindAll(i=> i.Title.ToLower().Contains(title));
            //return _allDvds.FindAll(i => i.Title.Equals(title));
        }

        public List<DVD> GetDvdByYear(int releaseYear)
        {
            return _allDvds.FindAll(i => i.ReleaseYear == releaseYear);
        }
    }
}