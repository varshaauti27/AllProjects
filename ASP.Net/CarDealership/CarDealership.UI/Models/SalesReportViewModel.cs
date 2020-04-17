using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class SalesReportViewModel
    {
        public List<SalesReportModel> SalesReport { get; set; }
        public string Users { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<SelectListItem> UserItems { get; set; }
   

        public SalesReportViewModel()
        {
            UserItems = new List<SelectListItem>();
        }
        internal void SetUserItems(IDbSet<ApplicationUser> users)
        {
            foreach (var u in users)
            {
                UserItems.Add(new SelectListItem()
                {
                    Value = u.Id,
                    Text = u.UserName
                }); ;
            }
        }

        //public void SetUserItems(IEnumerable<Users> states)
        //{
        //    foreach (var state in states)
        //    {
        //        StateItems.Add(new SelectListItem()
        //        {
        //            Value = state.Id.ToString(),
        //            Text = state.Name
        //        });
        //    }
        //}
    }
    public class SalesReportModel
    {
        public string UserName { get; set; }
        public decimal? TotalSales { get; set; }
        public int TotalVehicles { get; set; }
    }
}