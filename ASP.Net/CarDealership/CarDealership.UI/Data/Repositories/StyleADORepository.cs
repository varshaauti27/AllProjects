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
    public class StyleADORepository : IStyleRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        public StyleADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }

        public List<Style> GetAllStyles()
        {
            List<Style> _allStyle = new List<Style>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllStyles", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Style style = new Style
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Description = reader["Description"].ToString()
                        };

                        _allStyle.Add(style);
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
            return _allStyle;
        }

        public Style GetStyle(int id)
        {
            Style style = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetStyleById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@StyleId", id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        style = new Style
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
            return style;
        }
    }
}