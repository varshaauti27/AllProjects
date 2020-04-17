using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Data.Repositories
{
    public class PurchaseTypeMockRepository : IPurchaseTypeRepository
    {
        private static readonly List<PurchaseType> _allPurchases = new List<PurchaseType>
        {
            new PurchaseType{ Id = 1, Type = "Bank finance"},
            new PurchaseType{ Id = 2, Type = "Cash"},
            new PurchaseType{ Id = 3, Type = "Dealer finance"}
        };

        public List<PurchaseType> GetAllPurchaseTypes()
        {
            return _allPurchases;
        }

        public PurchaseType GetPurchaseType(int id)
        {
            return _allPurchases.FirstOrDefault(c => c.Id == id );
        }
    }
}