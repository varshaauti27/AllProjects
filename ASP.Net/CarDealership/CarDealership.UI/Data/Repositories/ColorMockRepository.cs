using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ColorMockRepository : IColorRepository
    {
        private static readonly List<Color> _allColors = new List<Color>()
        {
            new Color{ Id = 1,Name = "Black"},
            new Color{ Id = 2,Name = "White"},
            new Color{ Id = 3,Name = "Gray"},
            new Color{ Id = 4,Name = "Red"},
            new Color{ Id = 5,Name = "Silver"}
        };
        public List<Color> GetAllColors()
        {
            return _allColors;
        }

        public Color GetColor(int colorId)
        {
            return _allColors.FirstOrDefault(i => i.Id == colorId);
        }
    }
}