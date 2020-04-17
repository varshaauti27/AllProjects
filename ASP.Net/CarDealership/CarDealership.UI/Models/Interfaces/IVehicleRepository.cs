using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.UI.Models.Interfaces
{
    public interface IVehicleRepository
    {
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetFeatureVehicle();
        List<Vehicle> SearchVehicles(SearchRequest searchParam);
        Vehicle GetVehicleByVin(string id);
        bool AddVehicle(Vehicle vehicle);
        void SetVehicleIsSold(string vin);
        void EditVehicle(Vehicle vehicle);
        InventoryReportViewModel GetInventoryReports();
        void DeleteVehicle(string id);
    }
}
