using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class StyleMockRepository : IStyleRepository
    {
        private static readonly List<Style> _allStyle = new List<Style>()
        {
            new Style{ Id = 1, Description = "Car" },
            new Style{ Id = 2, Description = "Suv" },
            new Style{ Id = 3, Description = "Truck" },
            new Style{ Id = 1, Description = "Van" }
        };

        public List<Style> GetAllStyles()
        {
            return _allStyle;
        }

        public Style GetStyle(int id)
        {
            return _allStyle.FirstOrDefault(c => c.Id == id);
        }
    }
}