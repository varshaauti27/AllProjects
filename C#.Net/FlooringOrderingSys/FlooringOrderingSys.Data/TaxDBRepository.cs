using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class TaxDBRepository : ITaxRepository
    {
        string connectionString = "Data Source=VARSHAAUTI4B26;Initial Catalog=FlooringOrderSys;Integrated Security=True";
        SqlConnection conn;
        public TaxDBRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }
        public bool AddTax(Tax tax)
        {
            try
            {
                SqlDataAdapter adapter;
                DataSet ds = new DataSet();

                string query = $"INSERT INTO [State] VALUES('{tax.StateAbbreviation}','{tax.StateName}',{tax.TaxRate})";
                conn.Open();
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds);
                adapter.Dispose();
                conn.Close();
            }
            catch
            {
                conn.Close();
                return false;
            }
            return true;
        }

        public bool EditTax(Tax newTax)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UPDATE [State] SET StateName = @StateName, TaxRate = @TaxRate WHERE StateAbbreviation = @StateAbbreviation;", conn);

                sqlCommand.Parameters.AddWithValue("StateName", newTax.StateName);
                sqlCommand.Parameters.AddWithValue("TaxRate", newTax.TaxRate);
                sqlCommand.Parameters.AddWithValue("StateAbbreviation", newTax.StateAbbreviation);

                conn.Open();
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                conn.Close();
            }
            catch
            {
                conn.Close();
                return false;
            }
            return true;
        }

        public Tax GetTax(string stateAbbreviation)
        {
            Tax _tax = null;
            try
            {
                string query = $"SELECT * FROM [State] WHERE StateAbbreviation = '{stateAbbreviation}'";

                SqlDataAdapter adapter;
                DataSet ds = new DataSet();

                conn.Open();
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds);

                _tax = new Tax()
                {
                    StateAbbreviation = ds.Tables[0].Rows[0]["StateAbbreviation"].ToString(),
                    StateName = ds.Tables[0].Rows[0]["StateName"].ToString(),
                    TaxRate = decimal.Parse(ds.Tables[0].Rows[0]["TaxRate"].ToString())
                };
                conn.Close();
            }
            catch
            {
                conn.Close();
                return null;
            }
            return _tax;
        }

        public List<Tax> LoadTaxes()
        {
            List<Tax> taxes = new List<Tax>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM State", conn);

                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        taxes.Add(new Tax()
                        {
                            StateAbbreviation = reader["StateAbbreviation"].ToString(),
                            StateName = reader["StateName"].ToString(),
                            TaxRate = Convert.ToDecimal(reader["TaxRate"])
                        });
                    }
                }
                command.Dispose();
                conn.Close();
            }
            catch
            {
                conn.Close();
                return null;
            }
            return taxes;
        }

        public bool RemoveTax(string stateAbbreviation)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM [State] WHERE StateAbbreviation = @StateAbbreviation", conn);
                command.Parameters.AddWithValue("StateAbbreviation", stateAbbreviation);

                conn.Open();
                command.ExecuteScalar();
                command.Dispose();
                conn.Close();
            }
            catch
            {
                conn.Close();
                return false;
            }
            return true;
        }
    }
}
