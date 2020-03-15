using FlooringOrderingSys.BLL;
using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Responses;
using FlooringOrderingSys.UI.Workflows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSys.Test
{
    [TestFixture]
    class FlooringOrderingTest
    {
        [Test]
        public void CanLoadProducts()
        {
            ProductManager productManager = ProductManagerFactory.Create();
            LoadProductsResponse response = productManager.LoadProducts();

            Assert.IsTrue(response.Success);
            Assert.AreEqual(4, response.Products.Count);
        }

        [Test]
        public void CanLoadTaxes()
        {
            TaxManager taxManager = TaxManagerFactory.Create();
            LoadTaxesResponse response = taxManager.LoadTaxes();

            Assert.IsTrue(response.Success);
            Assert.AreEqual("OH", response.Taxes[0].StateAbbreviation);
            Assert.AreEqual("PA", response.Taxes[1].StateAbbreviation);
            Assert.AreEqual(4, response.Taxes.Count);
        }

        [TestCase("1/1/2021", true)]
        [TestCase("1/1/2019", false)]
        public void LoadAllOrders(DateTime orderDate, bool expected)
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            LoadOrdersResponse response = orderManager.LoadOrders(orderDate);

            Assert.AreEqual(expected, response.Success);

            if (response.Success)
            {
                Assert.AreEqual(4, response.Orders.Count);
                Assert.AreEqual("Wise", response.Orders[0].CustomerName);
                Assert.AreEqual("Bryan", response.Orders[1].CustomerName);
            }
        }

        [TestCase("1/1/2021", 1, true)]
        [TestCase("1/1/2021", 2, true)]
        [TestCase("2/1/2019", 2, false)]
        [TestCase("1/1/2021", 5, false)]
        public void GetOrder(DateTime orderDate, int orderNumber, bool expected)
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            OrderResponse orderResponse = orderManager.GetOrder(orderDate, orderNumber);

            Assert.AreEqual(expected, orderResponse.Success);
        }

        [TestCase("1/1/2021", "Varsha", "OH", "Wood", 230.0, true)]
        [TestCase("1/1/2021", "Varsha", "OH", "Wood", 80.0, false)]
        [TestCase("1/1/2021", "Tom", "MI", "Wood1", 230.0, false)]
        [TestCase("1/1/2021", "", "XX", "Wood", 230.0, false)]
        [TestCase("1/1/2021", "Tom", "PA", "Wood1", 230.0, false)]
        [TestCase("1/1/2020", "Tom", "MI", "Wood", 230.0, false)]
        public void AddOrder(DateTime orderDate, string custName, string state, string productType, decimal area, bool expected)
        {
            try
            {
                OrderManager orderManager = OrderManagerFactory.Create();

                TaxManager taxManager = TaxManagerFactory.Create();
                LoadTaxesResponse taxResponse = taxManager.LoadTaxes();

                ProductManager productManager = ProductManagerFactory.Create();
                LoadProductsResponse productResponse = productManager.LoadProducts();

                AddOrderResponse addOrderResponse = orderManager.AddOrder(orderDate, GererateOrder.Create(custName, state, productType, area, taxResponse, productResponse));

                Assert.AreEqual(expected, addOrderResponse.Success);
                if (addOrderResponse.Success)
                {
                    LoadOrdersResponse orderResponse1 = orderManager.LoadOrders(orderDate);
                    Assert.AreEqual(5, orderResponse1.Orders.Count);
                }
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        /*
             OrderNumber = 2, CustomerName = "Bryan", State = "IN", TaxRate = 6.00M, ProductType = "Tile",
             Area = 100.00M , CostPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M, MaterialCost = 350.00M,
             LaborCost = 415.00M, Tax = 45.90M, Total = 810.90M
         */

        //Valid Entry..
        [TestCase("1/1/2021", 2, "Varsha", "IN", "Tile", 100.00, true)]
        //Invalid Entry..
        [TestCase("1/1/2021", 2, "", "", "", 100.00, true)]
        [TestCase("1/1/2021", 2, "", "MI", "Wood", 100.00, true)]
        [TestCase("1/1/2021", 2, "Varsha", "", "Wood", 100.00, true)]
        //No OrderFound..
        [TestCase("1/1/2021", 5, "Varsha", "PA", "", 100.00, false)]
        //Invalid Date..
        [TestCase("1/1/2020", 2, "Varsha", "IN", "Tile", 99.00, false)]
        [TestCase("1/1/2021", 2, "", "AI", "Wood", 100.00, false)]
        [TestCase("1/1/2021", 2, "", "MI", "Wood1", 100.00, false)]
        public void EditOrder(DateTime orderDate, int orderNumber, string custName, string state, string productType, decimal area, bool expected)
        {

            OrderManager orderManager = OrderManagerFactory.Create();
            OrderResponse orderResponse = orderManager.GetOrder(orderDate, orderNumber);
            Response response = new Response();
            if (orderResponse.Success)
            {

                TaxManager taxManager = TaxManagerFactory.Create();
                LoadTaxesResponse taxResponse = taxManager.LoadTaxes();

                ProductManager productManager = ProductManagerFactory.Create();
                LoadProductsResponse productResponse = productManager.LoadProducts();

                Order oldOrder = orderResponse.Order;
                Order newOrder = GererateOrder.Create(custName, state, productType, area, taxResponse, productResponse);
                newOrder.OrderNumber = oldOrder.OrderNumber;

                response = orderManager.EditOrder(orderDate, oldOrder, newOrder);                
            }

            Assert.AreEqual(expected, response.Success);
            if (response.Success)
            {
                if (custName != "")
                {
                    LoadOrdersResponse orderResponse1 = orderManager.LoadOrders(orderDate);
                    Assert.AreEqual(custName, orderResponse1.Orders.Where(i=>i.OrderNumber == orderNumber).FirstOrDefault().CustomerName);
                }
            }
        }

        [TestCase("1/1/2021", 2, true)]
        [TestCase("1/1/2021", 5, false)]
        [TestCase("2/1/2019", 2, false)]
        [TestCase("2/1/2019", 5, false)]
        public void RemoveOrder(DateTime orderDate, int orderNumber, bool expected)
        {
            OrderManager orderManager = OrderManagerFactory.Create();
            Response response = orderManager.RemoveOrder(orderDate, orderNumber);

            Assert.AreEqual(expected, response.Success);

            if (response.Success)
            {
                LoadOrdersResponse orderResponse = orderManager.LoadOrders(orderDate);
                Assert.AreEqual(3, orderResponse.Orders.Count);
            }
        }
    }
}
 