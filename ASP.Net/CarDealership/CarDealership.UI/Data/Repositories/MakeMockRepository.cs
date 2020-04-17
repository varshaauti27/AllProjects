using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class MakeMockRepository : IMakeRepository
    {
        private static readonly List<Make> _allMakes = new List<Make>()
        {
            new Make{ Id = 1, Name = "Honda", DateAdded = DateTime.Parse("2020-04-03"), UserId= "195111be-3f63-449d-bd6c-0323c7ec67a8",UserName = "admin"},
            new Make{ Id = 2, Name = "Toyota", DateAdded = DateTime.Parse("2020-04-03"), UserId ="c65b9ccd-7bec-48e8-aade-8811d4769fa7", UserName="varsha"},
            new Make{ Id = 3, Name = "Lexus", DateAdded = DateTime.Parse("2020-04-03"), UserId = "c65b9ccd-7bec-48e8-aade-8811d4769fa7", UserName = "admin"}
        };

        public void AddMake(Make make)
        {
            make.Id = _allMakes.Max(i => i.Id) + 1;
            _allMakes.Add(make);
        }

        public List<Make> GetAllMakes()
        {
            return _allMakes;
        }

        public Make GetMake(int id)
        {
            return _allMakes.FirstOrDefault(c => c.Id == id);
        }
    }
}