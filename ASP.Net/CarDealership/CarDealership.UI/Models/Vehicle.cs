using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Vehicle
    {
        public string Vin { get; set; }
        public bool IsNew { get; set; }
        public int? Year { get; set; }
        public int? Mileage { get; set; }
        public decimal? SalesPrice { get; set; }
        public decimal? MSRP { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public bool IsFeaturedVehicle { get; set; }
        public string UserId { get; set; }
        public bool InStock { get; set; }       
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public string BodyStyle { get; set; }
        public string TransmissionText { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
    }
}