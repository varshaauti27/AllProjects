using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class CustomerMockRepository :ICustomerRepository
    {
        private static readonly List<Customer> _allCustomer = new List<Customer>()
        {
            new Customer{ Id = 1 , Name = "Customer1" , Phone="123456789", Email ="customer@gmail.com" ,
                          Address = new Address{ Street1 = "street 1",Street2 = "street 2", City ="city" , 
                                                State = new State{ Id = 1 , Name = "Alaska", Code="AK"} , Zipcode = 55044 }
                        }
        };

        public int AddCustomer(Customer customer)
        {
            customer.Id = _allCustomer.Max(c => c.Id) + 1;
            _allCustomer.Add(customer);

            return customer.Id;
        }
    }
}