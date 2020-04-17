using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class SalesADORepository : ISalesRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public SalesADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }

        public List<Sales> GetAllSales()
        {
            List<Sales> _allSales = new List<Sales>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllSales", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Sales sales = new Sales
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            CustomerId = Convert.ToInt32(reader["CustomerId"]),
                            UserId = reader["UserId"].ToString(),
                            Vin = reader["Vin"].ToString(),
                            PurchaseDate = DateTime.Parse(reader["Date"].ToString()),
                            PurchasePrice = Convert.ToDecimal(reader["PurchasePrice"]),
                            PurchaseTypeId = Convert.ToInt32(reader["PurchaseTypeId"]),
                            PurchaseType = reader["Description"].ToString()
                        };
                        _allSales.Add(sales);
                    }
                }
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
            return _allSales;
        }

        public SalesReportViewModel GetSalesReport(string userId, DateTime? fromDate, DateTime? toDate)
        {
            var _allSales = GetAllSales();
            SalesReportViewModel salesReport = new SalesReportViewModel
            {
                SalesReport = new List<SalesReportModel>()
            };
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

        public void PurchaseVehicle(Sales purchaseVM)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddSalesInformation", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                
                sqlCommand.Parameters.AddWithValue("@CustId",purchaseVM.CustomerId );
                sqlCommand.Parameters.AddWithValue("@UserId", purchaseVM.UserId);
                sqlCommand.Parameters.AddWithValue("@Vin", purchaseVM.Vin);
                sqlCommand.Parameters.AddWithValue("@Date",purchaseVM.PurchaseDate);
                sqlCommand.Parameters.AddWithValue("@PurchasePrice", purchaseVM.PurchasePrice);
                sqlCommand.Parameters.AddWithValue("@PurchaseTypeId", purchaseVM.PurchaseTypeId);

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
    }
}