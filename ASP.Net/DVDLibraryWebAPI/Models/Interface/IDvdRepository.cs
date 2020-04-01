using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryWebAPI.Models.Interface
{
    public interface IDvdRepository
    {
        List<DVD> GetAllDvds();
        DVD GetDvd(int id);
        List<DVD> GetDvdByTitle(string title);
        List<DVD> GetDvdByYear(int releaseYear);
        List<DVD> GetDvdByDirectorName(string directorName);
        List<DVD> GetDvdByRating(string rating);
        void Add(DVD dvd);
        void Edit(DVD dvd);
        void Delete(int id);
    }
}
