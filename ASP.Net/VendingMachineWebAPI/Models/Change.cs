using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VendingMachineWebAPI.Models
{
    public class Change
    {
        public int Quarters { get; set; }
        public int Dimes { get; set; }
        public int Nickels { get; set; }
        public int Pennies { get; set; }
    }
}