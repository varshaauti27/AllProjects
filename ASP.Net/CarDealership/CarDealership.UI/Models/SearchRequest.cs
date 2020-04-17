using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SearchRequest
    {
        public string SearchText { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
        public bool? IsNewVehicle { get; set; }
    }
}