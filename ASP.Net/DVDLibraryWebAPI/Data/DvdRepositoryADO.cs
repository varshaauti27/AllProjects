using DVDLibraryWebAPI.Models;
using DVDLibraryWebAPI.Models.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDLibraryWebAPI.Data
{
    public class DvdRepositoryADO : IDvdRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;
        public DvdRepositoryADO()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibraryCatalog"].ConnectionString
            };
        }
        public void Add(DVD dvd)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddDvd", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                //sqlCommand.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                sqlCommand.Parameters.AddWithValue("@Title", dvd.Title);
                sqlCommand.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                sqlCommand.Parameters.AddWithValue("@Director", dvd.Director);
                sqlCommand.Parameters.AddWithValue("@Rating", dvd.Rating);
                sqlCommand.Parameters.AddWithValue("@Notes", dvd.Notes);

                var returnDvdId = sqlCommand.Parameters.Add("@DvdId", SqlDbType.Int);
                returnDvdId.Direction = ParameterDirection.ReturnValue;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                sqlConnection.Close();
                dvd.DvdId = Convert.ToInt32(returnDvdId.Value);
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

        public void Delete(int id)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_DeleteDvd", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@DvdId", id);

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

        public void Edit(DVD dvd)
        {
            try 
            {
                sqlCommand = new SqlCommand("sp_EditDvd", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@DvdId", dvd.DvdId);
                sqlCommand.Parameters.AddWithValue("@Title", dvd.Title);
                sqlCommand.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                sqlCommand.Parameters.AddWithValue("@Director", dvd.Director);
                sqlCommand.Parameters.AddWithValue("@Rating", dvd.Rating);
                sqlCommand.Parameters.AddWithValue("@Notes", dvd.Notes);

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

        public List<DVD> GetAllDvds()
        {
            List<DVD> _allDvds = new List<DVD>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllDvds", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        DVD dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
                        };
                        _allDvds.Add(dvd);
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
            return _allDvds;
        }

        public DVD GetDvd(int id)
        {
            DVD dvd = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetDvdByID", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@DvdId",id);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
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
            return dvd;
        }

        public List<DVD> GetDvdByDirectorName(string directorName)
        {
            List<DVD> _allDvds = new List<DVD>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetDvdByDirector", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Director",directorName);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        DVD dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
                        };
                        _allDvds.Add(dvd);
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
            return _allDvds;
        }

        public List<DVD> GetDvdByRating(string rating)
        {
            List<DVD> _allDvds = new List<DVD>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetDvdByRating", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Rating", rating);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        DVD dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
                        };
                        _allDvds.Add(dvd);
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
            return _allDvds;
        }

        public List<DVD> GetDvdByTitle(string title)
        {
            List<DVD> _allDvds = new List<DVD>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetDvdByTitle", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@Title", title);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        DVD dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
                        };
                        _allDvds.Add(dvd);
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
            return _allDvds;
        }

        public List<DVD> GetDvdByYear(int releaseYear)
        {
            List<DVD> _allDvds = new List<DVD>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetDvdByYear", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@ReleaseYear", releaseYear);
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        DVD dvd = new DVD
                        {
                            DvdId = Convert.ToInt32(reader["DvdId"]),
                            Title = reader["Title"].ToString(),
                            ReleaseYear = Convert.ToInt32(reader["ReleaseYear"]),
                            Director = reader["Director"].ToString(),
                            Rating = reader["Rating"].ToString(),
                            Notes = reader["Notes"].ToString()
                        };
                        _allDvds.Add(dvd);
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
            return _allDvds;
        }
    }
}