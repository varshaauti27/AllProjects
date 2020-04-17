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
    public class ColorADORepository : IColorRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public ColorADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public List<Color> GetAllColors()
        {
            List<Color> _allColors = new List<Color>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllColors", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Color color = new Color
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };

                        _allColors.Add(color);
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
            return _allColors;
        }

        public Color GetColor(int colorId)
        {
            Color color = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetColorById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ColorId", colorId);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        color = new Color
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
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
            return color;
        }
    }
}