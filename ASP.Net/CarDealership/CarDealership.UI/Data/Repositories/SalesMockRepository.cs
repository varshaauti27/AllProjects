using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class SalesMockRepository : ISalesRepository
    {
        private static readonly List<Sales> _allSales = new List<Sales>()
        {
            new Sales{ Id = 1, CustomerId = 1, UserId = "195111be-3f63-449d-bd6c-0323c7ec67a8", Vin = "3ABCDEFG", 
                        PurchaseDate = DateTime.Parse("4/5/2020"), PurchasePrice = 19000.00M, PurchaseType="Cash" },
        };

        public List<Sales> GetAllSales()
        {
            return _allSales;
        }

        public SalesReportViewModel GetSalesReport(string userId, DateTime? fromDate, DateTime? toDate)
        {
            SalesReportViewModel salesReport = new SalesReportViewModel();
            salesReport.SalesReport = new List<SalesReportModel>();
            var salesQuery = _allSales.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userId))
            {
                salesQuery = salesQuery.Where(s => s.UserId.Equals(userId));
            }
            if (fromDate.HasValue && toDate.HasValue)
            {
                salesQuery = salesQuery.Where(s => s.PurchaseDate >= fromDate.Value && s.PurchaseDate <= toDate.Value);
            }
            else
            {
                if (fromDate.HasValue)
                {
                    salesQuery = salesQuery.Where(s => s.PurchaseDate >= fromDate.Value);
                }
                if (toDate.HasValue)
                {
                    salesQuery = salesQuery.Where(s => s.PurchaseDate <= toDate.Value);
                }
            }

            var salesReportGroupedByUser = salesQuery.GroupBy(s => s.UserId);

            foreach (var item in salesReportGroupedByUser)
            {
                SalesReportModel model = new SalesReportModel();

                var context = new ApplicationDbContext();
                var user = context.Users.FirstOrDefault(u => u.Id == item.Key);

                if (user != null)
                {
                    model.UserName = user.UserName;
                }
                model.TotalVehicles = item.Count();
                model.TotalSales = item.Sum(s => s.PurchasePrice);

                salesReport.SalesReport.Add(model);
            }

            return salesReport;
        }

        public void PurchaseVehicle(Sales sales)
        {
            _allSales.Add(sales);
        }
    }
}