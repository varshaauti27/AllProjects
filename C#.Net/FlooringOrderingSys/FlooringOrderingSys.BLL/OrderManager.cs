using FlooringOrderingSys.Models;
using FlooringOrderingSys.Models.Interfaces;
using FlooringOrderingSys.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlooringOrderingSys.BLL
{
    public class OrderManager
    {
        private IOrderRepository _repository;

        public OrderManager(IOrderRepository repository)
        {
            _repository = repository;
        }

        public LoadOrdersResponse LoadOrders(DateTime orderDate)
        {
            LoadOrdersResponse response = new LoadOrdersResponse();

            response.Orders = _repository.LoadOrders(orderDate);
            response.OrderDate = orderDate;
            if (response.Orders == null)
            {
                response.Success = false;

                response.Message = $"No Order Found with Order Date({orderDate.ToShortDateString()}), Unable to get order information !!!";
                return response;
            }
            response.Success = true;
            return response;
        }

        public AddOrderResponse AddOrder(DateTime orderDate, Order order)
        {
            AddOrderResponse response = new AddOrderResponse();

            response.Success = ValidateOrderDate(orderDate);
            if (!response.Success)
            {
                response.Message = "Invalid Order Date !!";
                return response;
            }

            response.Success = ValidateCustName(order.CustomerName);
            if (!response.Success)
            {
                response.Message = "Invalid Customer Name !!";
                return response;
            }

            response.Success = ValidateState(order.State);
            if (!response.Success)
            {
                response.Message = "Invalid State !!";
                return response;
            }

            response.Success = ValidateProductType(order.ProductType);
            if (!response.Success)
            {
                response.Message = "Invalid Product Type !!";
                return response;
            }

            response.Success = ValidateArea(order.Area);
            if (!response.Success)
            {
                response.Message = "Invalid Area !!";
                return response;
            }

            response.OrderId = _repository.AddOrder(orderDate, order);

            if (response.OrderId == -1)
            {
                response.Message = $"Unable to Add Order with OrderDate {orderDate.ToShortDateString()} !!!!";
                response.Success = false;
                return response;
            }

            response.Success = true;
            response.Message = $"Order Added Successfully with OrderDate {orderDate.ToShortDateString()} and OrderNumber {response.OrderId} !!!!";

            return response;
        }

        private bool ValidateArea(decimal area)
        {
            if (area < 100)
                return false;
            return true;
        }

        private bool ValidateProductType(string productType)
        {
            ProductManager productManager = ProductManagerFactory.Create();
            LoadProductsResponse productResponse = productManager.LoadProducts();

            if (!productResponse.Success)
                return false;

            if (productResponse.Products.Where(p=>p.ProductType==productType).Count()<=0)
            {
                return false;
            }
            return true;
        }

        private bool ValidateState(string state)
        {
            TaxManager taxManager = TaxManagerFactory.Create();
            LoadTaxesResponse taxesResponse = taxManager.LoadTaxes();

            if (!taxesResponse.Success)
                return false;

            if ((String.IsNullOrEmpty(state)) || (!(taxesResponse.Taxes.Exists(i => i.StateAbbreviation.Equals(state)))))
            {
                return false;
            }
            return true;
        }

        private bool ValidateCustName(string customerName)
        {
            if (!String.IsNullOrEmpty(customerName) && Regex.IsMatch(customerName, "([A-Z]*,|.|[a-z]*,|.|[0-9])*$"))
            {
                return true;
            }
            return false;
        }

        public OrderResponse GetOrder(DateTime orderDate, int orderNumber)
        {
            OrderResponse response = new OrderResponse();

            response.Order = _repository.GetOrder(orderDate, orderNumber);

            if (response.Order == null)
            {
                response.Success = false;
                response.Message = "No Order found !!!";
                return response;
            }

            response.Success = true;
            return response;
        }

        public Response RemoveOrder(DateTime orderDate,int orderNumber)
        {
            Response response = new Response();

            response.Success = _repository.RemoveOrder(orderDate,orderNumber);

            if (response.Success)
            {
                response.Message = $"Order {orderNumber} removed Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to remove Order {orderNumber} !!!!";
            }

            return response;
        }

        public Response EditOrder(DateTime orderDate, Order oldOrder, Order newOrder)
        {
            Response response = new Response();

            if (String.IsNullOrEmpty(newOrder.CustomerName))
                newOrder.CustomerName = oldOrder.CustomerName;

            if (String.IsNullOrEmpty(newOrder.State))
                newOrder.State = oldOrder.State;

            if(String.IsNullOrEmpty(newOrder.ProductType))
                newOrder.ProductType  = oldOrder.ProductType;
        
            response.Success = ValidateCustName(newOrder.CustomerName);
            if (!response.Success)
            {
                response.Message = "Invalid Customer Name !!";
                return response;
            }

            response.Success = ValidateState(newOrder.State);
            if (!response.Success)
            {
                response.Message = "Invalid State !!";
                return response;
            }

            response.Success = ValidateProductType(newOrder.ProductType);
            if (!response.Success)
            {
                response.Message = "Invalid Product Type !!";
                return response;
            }

            response.Success = ValidateArea(newOrder.Area);
            if (!response.Success)
            {
                response.Message = "Invalid Area !!";
                return response;
            }

            response.Success = _repository.EditOrder(orderDate, newOrder);

            if (response.Success)
            {
                response.Message = $"Order {newOrder.OrderNumber} edited Successfully !!!!";
            }
            else
            {
                response.Message = $"Unable to edit Order{newOrder.OrderNumber} !!!!";
            }
            return response;
        }

        private bool ValidateOrderDate(DateTime orderDate)
        {
            try
            {
                if (!(DateTime.Compare(orderDate, DateTime.Now) > 0))
                    return false;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}