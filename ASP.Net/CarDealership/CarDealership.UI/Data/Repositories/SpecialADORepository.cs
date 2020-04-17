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
    public class SpecialADORepository : ISpecialsRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public SpecialADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public void AddSpecial(Specials specials)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddSpecial", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Name", specials.Name);
                sqlCommand.Parameters.AddWithValue("@Description", specials.Description);
             
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

        public void DeleteSpecial(int id)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_DeleteSpecial", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@SpecialId", id);

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

        public List<Specials> GetAllSpecials()
        {
            List<Specials> _allSpecial = new List<Specials>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllSpecials", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Specials special = new Specials
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString()
                        };

                        _allSpecial.Add(special);
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
            return _allSpecial;
        }
    }
}