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
    public class CustomerADORepository : ICustomerRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public CustomerADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public int AddCustomer(Customer customer)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_AddCustomer", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Name", customer.Name);
                sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);
                sqlCommand.Parameters.AddWithValue("@Email", customer.Email);
                sqlCommand.Parameters.AddWithValue("@Street1", customer.Address.Street1);
                sqlCommand.Parameters.AddWithValue("@Street2", customer.Address.Street2);
                sqlCommand.Parameters.AddWithValue("@City", customer.Address.City);
                sqlCommand.Parameters.AddWithValue("@StateId", customer.Address.State.Id);
                sqlCommand.Parameters.AddWithValue("@Zipcode", customer.Address.Zipcode);

                var returnCustId = sqlCommand.Parameters.Add("@cust_id", SqlDbType.Int);
                returnCustId.Direction = ParameterDirection.ReturnValue;

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                sqlConnection.Close();
                customer.Id = Convert.ToInt32(returnCustId.Value);

                return customer.Id;
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
            return -1;
        }
    }
}