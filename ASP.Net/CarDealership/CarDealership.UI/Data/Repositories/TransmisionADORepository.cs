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
    public class TransmisionADORepository : ITransmissionRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public TransmisionADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public List<Transmission> GetAllTransmissions()
        {
            List<Transmission> _allTransmission = new List<Transmission>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllTransmission", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Transmission transmission = new Transmission
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Description = reader["Description"].ToString()
                        };

                        _allTransmission.Add(transmission);
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
            return _allTransmission;
        }

        public Transmission GetTransmission(int id)
        {
            Transmission transmission = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetTransmissionById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@TransmissionId", id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        transmission = new Transmission
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Description = reader["Description"].ToString()
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
            return transmission;
        }
    }
}