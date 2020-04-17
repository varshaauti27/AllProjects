using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class SpecialsMockRepository : ISpecialsRepository
    {
        private static readonly List<Specials> _allSpecials = new List<Specials>()
        {
            new Specials{ Id = 1, Name = "Special Title", Description = "This is special description for id 1."},
            new Specials{ Id = 2, Name = "Special Title", Description = "This is special description for id 2."},
            new Specials{ Id = 3, Name = "Special Title", Description = "This is special description for id 3."}
        };

        public void AddSpecial(Specials specials)
        {
            specials.Id = _allSpecials.Max(s => s.Id) + 1;
            _allSpecials.Add(specials);
        }

        public void DeleteSpecial(int id)
        {
            _allSpecials.RemoveAll(i => i.Id == id);
        }

        public List<Specials> GetAllSpecials()
        {
            return _allSpecials;
        }
    }
}