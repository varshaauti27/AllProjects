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
    public class ProductDBRepository : IProductRepository
    {
        string connectionString = "DATA SOURCE=VARSHAAUTI4B26;INITIAL CATALOG=FlooringOrderSys;INTEGRATED SECURITY=True";
        SqlConnection conn;

        public ProductDBRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }
        public bool AddProduct(Product product)
        {
            try
            {
                SqlDataAdapter adapter;
                DataSet ds = new DataSet();

                string query = $"INSERT INTO Product VALUES('{product.ProductType}',{product.CostPerSquareFoot},{product.LaborCostPerSquareFoot})";
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

        public bool EditProduct(Product newProduct)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UPDATE Product SET CostPerSquareFoot = @CostPerSquareFoot, LaborCostPerSquareFoot = @LaborCostPerSquareFoot WHERE Type = @productType;", conn);

                sqlCommand.Parameters.AddWithValue("CostPerSquareFoot", newProduct.CostPerSquareFoot);
                sqlCommand.Parameters.AddWithValue("LaborCostPerSquareFoot", newProduct.LaborCostPerSquareFoot);
                sqlCommand.Parameters.AddWithValue("ProductType", newProduct.ProductType);

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

        public Product GetProduct(string productType)
        {
            Product _product = null;
            try
            {
                string query = $"SELECT * FROM Product WHERE Type = '{productType}'";

                SqlDataAdapter adapter;
                DataSet ds = new DataSet();

                conn.Open();
                adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds);
               
                _product = new Product() { ProductType = ds.Tables[0].Rows[0]["Type"].ToString(),
                                           CostPerSquareFoot = decimal.Parse(ds.Tables[0].Rows[0]["CostPerSquareFoot"].ToString()),
                                           LaborCostPerSquareFoot = decimal.Parse(ds.Tables[0].Rows[0]["LaborCostPerSquareFoot"].ToString())  };
                conn.Close();
            }
            catch
            {
                conn.Close();
                return null;
            }
            return _product;
        }

        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Product", conn);

                conn.Open();
               
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductType = reader["Type"].ToString(),
                            CostPerSquareFoot = Convert.ToDecimal(reader["CostPerSquareFoot"]),
                            LaborCostPerSquareFoot = Convert.ToDecimal(reader["LaborCostPerSquareFoot"])
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
            return products;
        }

        public bool RemoveProduct(string productType)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM Product WHERE Type = @productType", conn);
                command.Parameters.AddWithValue("productType", productType);

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
