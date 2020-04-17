using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Sales
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string UserId { get; set; }
        public string Vin { get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchaseTypeId { get; set; }

        public string PurchaseType { get; set; } 
    }
}