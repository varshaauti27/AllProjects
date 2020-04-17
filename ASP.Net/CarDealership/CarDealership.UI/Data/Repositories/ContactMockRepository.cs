using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class ContactMockRepository : IContactRepository
    {
        private static readonly List<Contact> _allContact = new List<Contact>()
        {
            new Contact{ Name="Varsha Auti", Email="varsha@gmail.com" , Message = "Hiiiii" , Vin ="" },
        };

        public void AddContactInquiry(Contact contact)
        {
            _allContact.Add(contact);
        }
    }
}