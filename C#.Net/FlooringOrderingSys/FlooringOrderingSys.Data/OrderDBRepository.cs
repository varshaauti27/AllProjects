using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Data
{
    public class OrderDBRepository : IOrderRepository
    {
        public string connectionString = "DATA SOURCE=VARSHAAUTI4B26;INITIAL CATALOG=FlooringOrderSys;INTEGRATED SECURITY=True";
        SqlConnection conn;

        public OrderDBRepository()
        {
            conn = new SqlConnection();
            conn.ConnectionString = connectionString;
        }
        public int AddOrder(DateTime orderDate, Order order)
        {
            int orderNo = -1;
            try
            {
                SqlCommand insertCommand = new SqlCommand("INSERT INTO [Order] VALUES (@custName,@state,@productType,@area,@orderDate);", conn);
                insertCommand.Parameters.Add(new SqlParameter("custName", order.CustomerName));
                insertCommand.Parameters.Add(new SqlParameter("state", order.State));
                insertCommand.Parameters.Add(new SqlParameter("productType", order.ProductType));
                insertCommand.Parameters.Add(new SqlParameter("area", order.Area));
                insertCommand.Parameters.Add(new SqlParameter("orderDate", orderDate));

                conn.Open();
                insertCommand.ExecuteNonQuery();
                insertCommand.Dispose();
                conn.Close();

                SqlCommand command = new SqlCommand("SELECT MAX(orderNo) FROM[Order]; ", conn);
                conn.Open();
                orderNo = Convert.ToInt32(command.ExecuteScalar());
                command.Dispose();
                conn.Close();
            }
            catch
            {
                return orderNo;
            }
            finally
            {
                conn.Close();
            }
            return orderNo;
        }

        public bool EditOrder(DateTime orderDate, Order newOrder)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("UPDATE [ORDER] SET CustName = @Name, State = @State, ProductType = @Type, Area = @Area WHERE OrderNo=@orderNumber;", conn);
                sqlCommand.Parameters.Add(new SqlParameter("Name", newOrder.CustomerName));
                sqlCommand.Parameters.AddWithValue("State", newOrder.State);
                sqlCommand.Parameters.AddWithValue("Type", newOrder.ProductType);
                sqlCommand.Parameters.AddWithValue("Area", newOrder.Area);
                sqlCommand.Parameters.AddWithValue("orderNumber", newOrder.OrderNumber);

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

        public Order GetOrder(DateTime orderDate, int orderNumber)
        {
            Order _order = null;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Order]" +
                                                       "Left outer Join Product On Product.Type = [Order].ProductType " +
                                                       "Left Outer Join[State] On[State].StateAbbreviation = [Order].State " +
                                                       "WHERE OrderNo = @orderNumber AND OrderDate = @orderDate;", conn);
                sqlCommand.Parameters.AddWithValue("orderNumber", orderNumber);
                sqlCommand.Parameters.AddWithValue("orderDate", orderDate);

                conn.Open();
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        _order = GererateOrder.Create(reader["CustName"].ToString(),
                                                      reader["State"].ToString(),
                                                      reader["ProductType"].ToString(),
                                                      Convert.ToDecimal(reader["Area"]),
                                                      Convert.ToDecimal(reader["CostPerSquareFoot"]),
                                                      Convert.ToDecimal(reader["LaborCostPerSquareFoot"]),
                                                      Convert.ToDecimal(reader["TaxRate"]));
                    }
                }
                sqlCommand.Dispose();
                conn.Close();
            }
            catch
            {
                conn.Close();
                return null;
            }
            return _order;
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            List<Order> orders = new List<Order>();
            try
            {
                SqlCommand command = new SqlCommand("SELECT * FROM [Order] " +
                                                    "Left outer Join Product On Product.Type = [Order].ProductType " +
                                                    "Left Outer Join[State] On[State].StateAbbreviation = [Order].State " +
                                                    "WHERE OrderDate = @dt", conn);
                command.Parameters.Add(new SqlParameter("dt", orderDate));



                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // while there is another record present
                    while (reader.Read())
                    {
                        Order _order = GererateOrder.Create(reader["CustName"].ToString(),
                                                      reader["State"].ToString(),
                                                      reader["ProductType"].ToString(),
                                                      Convert.ToDecimal(reader["Area"]),
                                                      Convert.ToDecimal(reader["CostPerSquareFoot"]),
                                                      Convert.ToDecimal(reader["LaborCostPerSquareFoot"]),
                                                      Convert.ToDecimal(reader["TaxRate"]));
                        orders.Add(_order);
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
            return orders;
        }

        public bool RemoveOrder(DateTime orderDate, int orderNumber)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Order] WHERE OrderDate = @dt And OrderNo = @orderNumber", conn);
                command.Parameters.Add(new SqlParameter("dt", orderDate));
                command.Parameters.AddWithValue("orderNumber", orderNumber);

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