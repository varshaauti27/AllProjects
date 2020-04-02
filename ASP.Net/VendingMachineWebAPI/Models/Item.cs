using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineWebAPI.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        // id":0,"name":"Elephant","price":0.99,"quantity"
    }
}