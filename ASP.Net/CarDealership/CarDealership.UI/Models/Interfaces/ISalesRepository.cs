using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface ISalesRepository
    {
        List<Sales> GetAllSales();
        void PurchaseVehicle(Sales purchaseVM);
       
        SalesReportViewModel GetSalesReport(string userId, DateTime? fromDate, DateTime? toDate);
    }
}
