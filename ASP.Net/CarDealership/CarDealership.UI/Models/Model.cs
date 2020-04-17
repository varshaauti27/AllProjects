using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int MakeId { get; set; }

        public string MakeName { get; set; }

        public DateTime DateAdded { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}