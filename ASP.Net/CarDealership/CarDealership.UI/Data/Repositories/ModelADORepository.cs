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
    public class ModelADORepository : IModelRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public ModelADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public void AddModel(Model model)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddModel", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@MakeId",model.MakeId);
                sqlCommand.Parameters.AddWithValue("@Name", model.Name);
                sqlCommand.Parameters.AddWithValue("@UserId", model.UserId);
                sqlCommand.Parameters.AddWithValue("@DateAdded", model.DateAdded);

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

        public List<Model> GetAllModels()
        {
            List<Model> _allModel = new List<Model>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllModels", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Model make = new Model
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["ModelName"].ToString(),
                            MakeId = Convert.ToInt32(reader["MakeId"]),
                            MakeName = reader["MakeName"].ToString(),
                            DateAdded = DateTime.Parse(reader["DateAdded"].ToString()),
                            UserId = reader["UserId"].ToString(),
                            UserName = reader["UserName"].ToString()
                        };

                        _allModel.Add(make);
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
            return _allModel;
        }

        public Model GetModel(int modelId)
        {
            Model model = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetModelById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ModelId", modelId);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        model = new Model
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["ModelName"].ToString(),
                            MakeId = Convert.ToInt32(reader["MakeId"]),
                            MakeName = reader["MakeName"].ToString(),
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
            return model;
        }

        public List<Model> GetModelsByMakeId(int makeId)
        {
            List<Model> _allModel = new List<Model>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetModelByMakeId", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@MakeId", makeId);
                sqlConnection.Open();

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Model model = new Model
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["ModelName"].ToString(),
                            MakeId = Convert.ToInt32(reader["MakeId"]),
                            MakeName = reader["MakeName"].ToString(),
                            DateAdded = DateTime.Parse(reader["DateAdded"].ToString()),
                            UserId = reader["UserId"].ToString(),
                            UserName = reader["UserName"].ToString()
                        };

                        _allModel.Add(model);
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
            return _allModel;
        }
    }
}