using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
    }
}