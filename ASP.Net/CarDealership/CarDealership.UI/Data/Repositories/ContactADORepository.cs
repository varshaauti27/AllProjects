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
    public class ContactADORepository : IContactRepository
    {
        readonly SqlConnection sqlConnection = null;
        private SqlCommand sqlCommand = null;

        public ContactADORepository()
        {
            sqlConnection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString
            };
        }
        public void AddContactInquiry(Contact contact)
        {
            try
            {
                sqlCommand = new SqlCommand("sp_InsertContactInformation", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCommand.Parameters.AddWithValue("@Name", contact.Name);
                sqlCommand.Parameters.AddWithValue("@Email", contact.Email);
                sqlCommand.Parameters.AddWithValue("@Phone", contact.Phone);
                sqlCommand.Parameters.AddWithValue("@Vin", contact.Vin);
                sqlCommand.Parameters.AddWithValue("@Message",contact.Message);

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
    }
}