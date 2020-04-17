using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Address
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public int? Zipcode { get; set; }
    }
}