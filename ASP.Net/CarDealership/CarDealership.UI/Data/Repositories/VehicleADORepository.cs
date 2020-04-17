using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class VehicleADORepository : IVehicleRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public VehicleADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            try
            {
                Vehicle foundVehicle = GetVehicleByVin(vehicle.Vin);

                if (foundVehicle != null)
                {
                    return false;
                }

                sqlCommand = new SqlCommand("sp_AddVehicle", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Vin", vehicle.Vin);
                sqlCommand.Parameters.AddWithValue("@ModelName", vehicle.ModelName);
                sqlCommand.Parameters.AddWithValue("@Year", vehicle.Year);
                sqlCommand.Parameters.AddWithValue("@New", Convert.ToByte(vehicle.IsNew));
                sqlCommand.Parameters.AddWithValue("@Feature", Convert.ToByte(vehicle.IsFeaturedVehicle));
                sqlCommand.Parameters.AddWithValue("@StyleName",vehicle.BodyStyle);
                sqlCommand.Parameters.AddWithValue("@TransName", vehicle.TransmissionText);
                sqlCommand.Parameters.AddWithValue("@InteriorName", vehicle.InteriorColor);
                sqlCommand.Parameters.AddWithValue("@ExteriorName", vehicle.ExteriorColor);
                sqlCommand.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                sqlCommand.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                sqlCommand.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                sqlCommand.Parameters.AddWithValue("@Description", vehicle.Description);
                sqlCommand.Parameters.AddWithValue("@ImageFile", vehicle.ImageFile);
                sqlCommand.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@UserId", vehicle.UserId);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
            return true;
        }

        public void DeleteVehicle(string id)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_DeleteVehicle", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Vin", id);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
        }

        public void EditVehicle(Vehicle vehicle)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_EditVehicle", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Vin", vehicle.Vin);
                sqlCommand.Parameters.AddWithValue("@ModelName", vehicle.ModelName);
                sqlCommand.Parameters.AddWithValue("@Year", vehicle.Year);
                sqlCommand.Parameters.AddWithValue("@New", Convert.ToByte(vehicle.IsNew));
                sqlCommand.Parameters.AddWithValue("@Feature", Convert.ToByte(vehicle.IsFeaturedVehicle));
                sqlCommand.Parameters.AddWithValue("@StyleName", vehicle.BodyStyle);
                sqlCommand.Parameters.AddWithValue("@TransName", vehicle.TransmissionText);
                sqlCommand.Parameters.AddWithValue("@InteriorName", vehicle.InteriorColor);
                sqlCommand.Parameters.AddWithValue("@ExteriorName", vehicle.ExteriorColor);
                sqlCommand.Parameters.AddWithValue("@Mileage", vehicle.Mileage);
                sqlCommand.Parameters.AddWithValue("@MSRP", vehicle.MSRP);
                sqlCommand.Parameters.AddWithValue("@SalesPrice", vehicle.SalesPrice);
                sqlCommand.Parameters.AddWithValue("@Description", vehicle.Description);
                sqlCommand.Parameters.AddWithValue("@ImageFile", vehicle.ImageFile);
                sqlCommand.Parameters.AddWithValue("@UserId", vehicle.UserId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
        }

        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> _allVehicle = new List<Vehicle>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllVehicle", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        var new1 = reader["New"].ToString();

                        Vehicle vehicle = new Vehicle
                        {
                            Vin = reader["Vin"].ToString(),
                            IsNew = BitConverter.ToBoolean((byte[])reader["New"], 0), 
                            Year = Convert.ToInt32(reader["Year"]),
                            Mileage = Convert.ToInt32(reader["Mileage"]),
                            SalesPrice = Convert.ToDecimal(reader["SalesPrice"]),
                            MSRP = Convert.ToDecimal(reader["MSRP"]),
                            Description = reader["VehicleDescription"].ToString(),
                            ImageFile = reader["ImageFile"].ToString(),
                            IsFeaturedVehicle = BitConverter.ToBoolean((byte[])reader["Feature"], 0),
                            UserId = reader["UserId"].ToString(),
                            InStock = BitConverter.ToBoolean((byte[])reader["InStock"], 0),
                            ModelName = reader["ModelName"].ToString(),
                            MakeName = reader["MakeName"].ToString(),
                            BodyStyle = reader["StyleDescription"].ToString(),
                            TransmissionText = reader["TransDescription"].ToString(),
                            InteriorColor = reader["Interior Color"].ToString(),
                            ExteriorColor = reader["Exterior Color"].ToString(),
                        };
                        
                        _allVehicle.Add(vehicle);
                    }
                }
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
            return _allVehicle;
        }

        public List<Vehicle> GetFeatureVehicle()
        {
            List<Vehicle> _allFeaturedVehicle = new List<Vehicle>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetFeatureVehicles", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle
                        {
                            Vin = reader["Vin"].ToString(),
                            IsNew = BitConverter.ToBoolean((byte[])reader["New"], 0),
                            Year = Convert.ToInt32(reader["Year"]),
                            Mileage = Convert.ToInt32(reader["Mileage"]),
                            SalesPrice = Convert.ToDecimal(reader["SalesPrice"]),
                            MSRP = Convert.ToDecimal(reader["MSRP"]),
                            Description = reader["VehicleDescription"].ToString(),
                            ImageFile = reader["ImageFile"].ToString(),
                            IsFeaturedVehicle = BitConverter.ToBoolean((byte[])reader["Feature"], 0),
                            UserId = reader["UserId"].ToString(),
                            InStock = BitConverter.ToBoolean((byte[])reader["InStock"], 0),
                            ModelName = reader["ModelName"].ToString(),
                            MakeName = reader["MakeName"].ToString(),
                            BodyStyle = reader["StyleDescription"].ToString(),
                            TransmissionText = reader["TransDescription"].ToString(),
                            InteriorColor = reader["Interior Color"].ToString(),
                            ExteriorColor = reader["Exterior Color"].ToString()
                        };
                        _allFeaturedVehicle.Add(vehicle);
                    }
                }
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
            return _allFeaturedVehicle;
        }

        public InventoryReportViewModel GetInventoryReports()
        {
            List<Vehicle> _allVehicles = new List<Vehicle>();
            _allVehicles = GetAllVehicles();

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
                InventoryReportModel model = new InventoryReportModel
                {
                    Count = item.Vehicles.Count,
                    Model = item.Model,
                    Year = item.Year,
                    Make = item.Make,
                    StockValue = item.Vehicles.Sum(s => s.MSRP)
                };
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
                InventoryReportModel model = new InventoryReportModel
                {
                    Count = item.Vehicles.Count,
                    Model = item.Model,
                    Year = item.Year,
                    Make = item.Make,
                    StockValue = item.Vehicles.Sum(s => s.MSRP)
                };
                inventoryReportVM.OldInventory.Add(model);
            }

            return inventoryReportVM;
        }

        public Vehicle GetVehicleByVin(string id)
        {
            Vehicle vehicle = null;
            
            try
            {
                sqlCommand = new SqlCommand("sp_GetVehicleByVin", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Vin", id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        vehicle = new Vehicle
                        {
                            Vin = reader["Vin"].ToString(),
                            IsNew = BitConverter.ToBoolean((byte[])reader["New"], 0),
                            Year = Convert.ToInt32(reader["Year"]),
                            Mileage = Convert.ToInt32(reader["Mileage"]),
                            SalesPrice = Convert.ToDecimal(reader["SalesPrice"]),
                            MSRP = Convert.ToDecimal(reader["MSRP"]),
                            Description = reader["VehicleDescription"].ToString(),
                            ImageFile = reader["ImageFile"].ToString(),
                            IsFeaturedVehicle = BitConverter.ToBoolean((byte[])reader["Feature"], 0),
                            UserId = reader["UserId"].ToString(),
                            InStock = BitConverter.ToBoolean((byte[])reader["InStock"], 0),
                            ModelName = reader["ModelName"].ToString(),
                            MakeName = reader["MakeName"].ToString(),
                            BodyStyle = reader["StyleDescription"].ToString(),
                            TransmissionText = reader["TransDescription"].ToString(),
                            InteriorColor = reader["Interior Color"].ToString(),
                            ExteriorColor = reader["Exterior Color"].ToString()
                        };
                    }
                }
                sqlConnection.Close();
                sqlCommand.Dispose();
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
            return vehicle;
        }

        public List<Vehicle> SearchVehicles(SearchRequest searchParam)
        {
            var _allVehicles = GetAllVehicles();
            var vehicleQuery = _allVehicles.Where(i => (i.InStock)).AsQueryable();

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

        public void SetVehicleIsSold(string vin)
        {
            try
            {
                Vehicle vehicle = GetVehicleByVin(vin);
                if (vehicle != null)
                {
                    sqlCommand = new SqlCommand("sp_SetVehicleIsSold", sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    sqlCommand.Parameters.AddWithValue("@Vin", vin);

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Dispose();
                    sqlConnection.Close();
                }
            }
            catch(Exception ex)
            {
                if (sqlCommand != null)
                {
                    sqlCommand.Dispose();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            finally
            {
                sqlCommand = null;
            }
        }
    }
}