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
    public class MakeADORepository : IMakeRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public MakeADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public void AddMake(Make make)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddMake", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
            
                sqlCommand.Parameters.AddWithValue("@Name", make.Name);
                sqlCommand.Parameters.AddWithValue("@UserId", make.UserId);
                sqlCommand.Parameters.AddWithValue("@DateAdded", make.DateAdded);

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

        public List<Make> GetAllMakes()
        {
            List<Make> _allMake = new List<Make>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllMakes", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Make make = new Make
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            DateAdded = DateTime.Parse(reader["DateAdded"].ToString()),
                            UserId = reader["UserId"].ToString(),
                            UserName = reader["UserName"].ToString()
                        };

                        _allMake.Add(make);
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
            return _allMake;
        }

        public Make GetMake(int id)
        {
            Make make = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetMakeById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@MakeId", id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        make = new Make
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            DateAdded = DateTime.Parse(reader["DateAdded"].ToString()),
                            UserId = reader["UserId"].ToString(),
                            UserName = reader["UserName"].ToString()
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
            return make;
        }
    }
}