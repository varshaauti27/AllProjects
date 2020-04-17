using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialsViewModel
    {
        public List<Specials> Specials { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}