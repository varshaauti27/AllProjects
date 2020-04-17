using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Models
{
    public class PurchaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public Customer Customer { get; set; }
        //public PurchaseType PurchaseType { get; set; }
        public Sales Sales { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<SelectListItem> PurchaseTypeItems { get; set; }

        public PurchaseViewModel()
        {
            Vehicle = new Vehicle();
            Customer = new Customer();
            //PurchaseType = new PurchaseType();
            Sales = new Sales();
            StateItems = new List<SelectListItem>();
            PurchaseTypeItems = new List<SelectListItem>();
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.Id.ToString(),
                    Text = state.Name
                });
            }
        }

        public void SetPurchaseTypeItems(IEnumerable<PurchaseType> purchaseType)
        {
            foreach (var purchase in purchaseType)
            {
                PurchaseTypeItems.Add(new SelectListItem()
                {
                    Value = purchase.Id.ToString(),
                    Text = purchase.Type
                });
            }
        }
    }
}