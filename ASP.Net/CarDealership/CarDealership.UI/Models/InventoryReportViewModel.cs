using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryReportViewModel
    {
      public List<InventoryReportModel> NewInventory { get; set; }
      public List<InventoryReportModel> OldInventory { get; set; }

        public InventoryReportViewModel()
        {
            NewInventory = new List<InventoryReportModel>();
            OldInventory = new List<InventoryReportModel>();
        }
    }

    public class InventoryReportModel
    {
        public int? Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public decimal? StockValue { get; set; }
    }
}