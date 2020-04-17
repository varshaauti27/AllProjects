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
    public class PurchaseTypeADORepository : IPurchaseTypeRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public PurchaseTypeADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public List<PurchaseType> GetAllPurchaseTypes()
        {
            List<PurchaseType> _allPurchase = new List<PurchaseType>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllPurchaseTypes", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        PurchaseType purchase = new PurchaseType
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Type = reader["Description"].ToString(),
                        };

                        _allPurchase.Add(purchase);
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
            return _allPurchase;
        }

        public PurchaseType GetPurchaseType(int id)
        {
            PurchaseType purchase = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetPurchaseById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@PurchaseId", id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        purchase = new PurchaseType
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Type = reader["Description"].ToString(),
                        };
                    }
                }
                sqlConnection.Close();
                sqlCommand.Dispose();
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
            return purchase;
        }
    }
}