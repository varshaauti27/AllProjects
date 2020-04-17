using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class VehicleMockRepository : IVehicleRepository
    {
        private static readonly List<Vehicle> _allVehicles = new List<Vehicle>()
        {
            new Vehicle(){Vin = "1ABCDEFG", ModelName="Civic", MakeName="Honda", Year = 2017, IsNew = true, BodyStyle="Car", TransmissionText = "Automatic", InteriorColor = "Black", ExteriorColor = "White", Mileage = 50, MSRP = 22000.00M, SalesPrice=21000.00M, Description = "New Honda Acc", ImageFile = "icon.png",  IsFeaturedVehicle=true, InStock = true},
            new Vehicle(){Vin = "2ABCDEFG", ModelName = "Accord", MakeName ="Honda", Year = 2017, IsNew = false, BodyStyle = "Suv", TransmissionText = "Manual", InteriorColor = "Gray", ExteriorColor = "White", Mileage = 50, MSRP = 34000.00M, SalesPrice=33000.00M, Description = "Old Toyota Corolla", ImageFile = "icon.png",  IsFeaturedVehicle=true, InStock = true },
            new Vehicle(){Vin = "3ABCDEFG", ModelName = "Corolla", MakeName="Lexus", Year = 2015, IsNew = false, BodyStyle = "Car", TransmissionText = "Automatic", InteriorColor = "Black", ExteriorColor = "White", Mileage = 50, MSRP = 20000.00M, SalesPrice=19000.00M, Description = "Used Lexus IS", ImageFile = "icon.png",  IsFeaturedVehicle=true, InStock = false },
            new Vehicle(){Vin = "4ABCDEFG", ModelName = "Civic", MakeName="Honda", Year = 2015, IsNew = true, BodyStyle = "Suv", TransmissionText = "Manual", InteriorColor = "Grap", ExteriorColor = "Red", Mileage = 50, MSRP = 20000.00M, SalesPrice=19000.00M, Description = "Used Lexus IS", ImageFile = "icon.png",  IsFeaturedVehicle=true, InStock = false }
        };

        public bool AddVehicle(Vehicle vehicle)
        {
            if (_allVehicles.Contains(vehicle))
            {
                return false;
            }
            else
            {
                _allVehicles.Add(vehicle);
                return true;
            }
        }

        public List<Vehicle> GetFeatureVehicle()
        {
            return _allVehicles.FindAll(i => i.IsFeaturedVehicle && i.InStock);
        }

        public Vehicle GetVehicleByVin(string id)
        {
            return _allVehicles.FirstOrDefault(i => i.Vin.Equals(id));
        }

        public List<Vehicle> SearchVehicles(SearchRequest searchParam)
        {
            var vehicleQuery = _allVehicles.Where(i=> (i.InStock)).AsQueryable();

            if (searchParam.IsNewVehicle.HasValue)
            {
                vehicleQuery = vehicleQuery.Where(i => i.IsNew == searchParam.IsNewVehicle);
            }

            if ((!string.IsNullOrWhiteSpace(searchParam.SearchText)) || (searchParam.MinPrice.HasValue) || (searchParam.MaxPrice.HasValue) ||
                  (searchParam.MinYear.HasValue) || (searchParam.MaxYear.HasValue))
            {
                if (!string.IsNullOrWhiteSpace(searchParam.SearchText))
                {
                    vehicleQuery = vehicleQuery.Where(i => i.ModelName.Contains(searchParam.SearchText)
                                         || i.MakeName.Contains(searchParam.SearchText)
                                         || i.Year.ToString().Equals(searchParam.SearchText));
                }

                if (searchParam.MinPrice.HasValue && searchParam.MaxPrice.HasValue)
                {
                    vehicleQuery = vehicleQuery.Where(i => i.MSRP >= searchParam.MinPrice.Value && i.MSRP <= searchParam.MaxPrice.Value);
                }
                else
                {
                    if (searchParam.MinPrice.HasValue)
                    {
                        vehicleQuery = vehicleQuery.Where(i => i.MSRP >= searchParam.MinPrice.Value);
                    }
                    if (searchParam.MaxPrice.HasValue)
                    {
                        vehicleQuery = vehicleQuery.Where(i => i.MSRP >= searchParam.MaxPrice.Value);
                    }
                }

                if (searchParam.MinYear.HasValue && searchParam.MaxYear.HasValue)
                {
                    vehicleQuery = vehicleQuery.Where(i => i.Year >= searchParam.MinYear.Value && i.Year <= searchParam.MaxYear.Value);
                }
                else
                {
                    if (searchParam.MinYear.HasValue)
                    {
                        vehicleQuery = vehicleQuery.Where(i => i.Year >= searchParam.MinYear.Value);
                    }
                    if (searchParam.MaxYear.HasValue)
                    {
                        vehicleQuery = vehicleQuery.Where(i => i.Year >= searchParam.MaxYear.Value);
                    }
                }
            }
            else
            {
                vehicleQuery = vehicleQuery.OrderBy(i => i.MSRP).Take(20);
            }

            List<Vehicle> _searchVehicle = new List<Vehicle>();
            foreach (var item in vehicleQuery.ToList())
            {
                _searchVehicle.Add(MapVehicleToView(item));
            }
            return _searchVehicle;
        }

        public void SetVehicleIsSold(string vin)
        {
            var purchasedVehicle = _allVehicles.First(i => i.Vin.Equals(vin));

            purchasedVehicle.InStock = false;
        }

        private Vehicle MapVehicleToView(Vehicle item)
        {
            Vehicle vehicle = new Vehicle
            {
                Vin = item.Vin,
                IsNew = item.IsNew,
                Year = item.Year,
                Mileage = item.Mileage,
                SalesPrice = item.SalesPrice,
                MSRP = item.MSRP,
                Description = item.Description,
                ImageFile = item.ImageFile,
                IsFeaturedVehicle = item.IsFeaturedVehicle,
                UserId = item.UserId,
                ModelName = item.ModelName,
                MakeName = item.MakeName,
                BodyStyle = item.BodyStyle,
                TransmissionText = item.TransmissionText,
                InteriorColor = item.InteriorColor,
                ExteriorColor = item.ExteriorColor,
                InStock = item.InStock
            };

            if (!string.IsNullOrWhiteSpace(item.ImageFile))
            {
                if (File.Exists(HttpContext.Current.Server.MapPath("~/Images/" + item.ImageFile)))
                {
                    vehicle.ImageFile = item.ImageFile;
                }
                else
                {
                    vehicle.ImageFile = "icon.png";
                }
            }
            return vehicle;
        }

        public void EditVehicle(Vehicle vehicle)
        {
            int index = _allVehicles.FindIndex(i => i.Vin == vehicle.Vin);
            if (index != -1)
            {
                _allVehicles[index] = vehicle;
            }
        }

        public InventoryReportViewModel GetInventoryReports()
        {
            InventoryReportViewModel inventoryReportVM = new InventoryReportViewModel();

            var NewVehicleGroupedByModelAndYear = from v in _allVehicles
                                               where v.IsNew == true
                                               group v by new
                                               {
                                                   v.Year,
                                                   v.ModelName
                                               } into grp
                                               select new
                                               {
                                                   Year = grp.Key.Year,
                                                   Model = grp.Key.ModelName,
                                                   Make = grp.FirstOrDefault() == null ? string.Empty : grp.FirstOrDefault().MakeName,
                                                   Vehicles = grp.ToList()
                                               };

            foreach (var item in NewVehicleGroupedByModelAndYear)
            {
                InventoryReportModel model = new InventoryReportModel();
                model.Count = item.Vehicles.Count;
                model.Model = item.Model;
                model.Year = item.Year;
                model.Make = item.Make;
                model.StockValue = item.Vehicles.Sum(s => s.MSRP);
                inventoryReportVM.NewInventory.Add(model);
            }

            var OldVehicleGroupedByModelAndYear = from v in _allVehicles
                                                  where v.IsNew == false
                                                  group v by new
                                                  {
                                                      v.Year,
                                                      v.ModelName
                                                  } into grp
                                                  select new
                                                  {
                                                      Year = grp.Key.Year,
                                                      Model = grp.Key.ModelName,
                                                      Make = grp.FirstOrDefault() == null ? string.Empty : grp.FirstOrDefault().MakeName,
                                                      Vehicles = grp.ToList()
                                                  };

            foreach (var item in OldVehicleGroupedByModelAndYear)
            {
                InventoryReportModel model = new InventoryReportModel();
                model.Count = item.Vehicles.Count;
                model.Model = item.Model;
                model.Year = item.Year;
                model.Make = item.Make;
                model.StockValue = item.Vehicles.Sum(s => s.MSRP);
                inventoryReportVM.OldInventory.Add(model);
            }

            return inventoryReportVM;
        }

        public void DeleteVehicle(string id)
        {
            _allVehicles.RemoveAll(i => i.Vin.Equals(id));
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _allVehicles.Where(i=>i.InStock).ToList();
        }
    }
}