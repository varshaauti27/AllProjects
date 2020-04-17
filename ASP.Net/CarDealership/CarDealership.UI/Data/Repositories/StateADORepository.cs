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
    public class StateADORepository : IStateRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public StateADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public List<State> GetAllStates()
        {
            List<State> _allState = new List<State>();
            try
            {
                sqlCommand = new SqlCommand("sp_GetAllStates", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        State state = new State
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Code = reader["Code"].ToString()
                        };

                        _allState.Add(state);
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
            return _allState;
        }

        public State GetState(int stateId)
        {
            State state = null;
            try
            {
                sqlCommand = new SqlCommand("sp_GetStateById", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                sqlCommand.Parameters.AddWithValue("@StateId", stateId);

                sqlConnection.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        state = new State
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Code = reader["Code"].ToString()
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
            return state;
        }
    }
}