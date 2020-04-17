using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin,Sales")]
    public class SalesController : Controller
    {
        readonly IStateRepository _stateRepository = StateManager.Create();
        readonly IPurchaseTypeRepository _purchaseTypeRepository = PurchaseTypeManager.Create();
        readonly IVehicleRepository _vehicleRepository = VehicleManager.Create();
        readonly ISalesRepository _salesRepository = SalesManager.Create();
        readonly ICustomerRepository _customerRepository = CustomerManager.Create();

        // GET: Sales
        public ActionResult Index()
        {
            ViewBag.Page = "Sales";
            ViewBag.Title = "Sales";
            return View("Index");
        }

        public ActionResult Purchase(string id)
        {
            ViewBag.Page = "Sales";
            ViewBag.Title = "Sales";

            PurchaseViewModel purchaseVM = new PurchaseViewModel();
            Vehicle vehicle = _vehicleRepository.GetVehicleByVin(id);
            purchaseVM.Vehicle = vehicle;
            purchaseVM.SetStateItems(_stateRepository.GetAllStates());
            purchaseVM.SetPurchaseTypeItems(_purchaseTypeRepository.GetAllPurchaseTypes());

            return View("Purchase",purchaseVM);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel purchaseVM)
        {
            if (!string.IsNullOrWhiteSpace(purchaseVM.Customer.Address.Zipcode.ToString()) && purchaseVM.Customer.Address.Zipcode.ToString().Length!=5)
            {
                ModelState.AddModelError("Customer.Zipcode", $"Zip code must be a 5 digit number.");
            }
            if (purchaseVM.Sales.PurchasePrice.HasValue)
            {
                decimal maxPricePercentage = (decimal)0.95;

                if (purchaseVM.Sales.PurchasePrice.Value < (purchaseVM.Vehicle.SalesPrice.Value * maxPricePercentage))
                {
                    ModelState.AddModelError("Sales.PurchasePrice", $"The purchase price cannot be less than 95% of the sales price.");
                }
                else if (purchaseVM.Sales.PurchasePrice.Value > purchaseVM.Vehicle.MSRP.Value)
                {
                    ModelState.AddModelError("Sales.PurchasePrice", $"The purchase price cannot exceed the MSRP.");
                }
            }

            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                purchaseVM.Customer.Address.State = _stateRepository.GetState(purchaseVM.Customer.Address.State.Id);

                int custId = _customerRepository.AddCustomer(purchaseVM.Customer);

                purchaseVM.Sales.CustomerId = custId;
                purchaseVM.Sales.PurchaseDate = DateTime.Now;
                purchaseVM.Sales.PurchaseType = _purchaseTypeRepository.GetPurchaseType(purchaseVM.Sales.PurchaseTypeId).Type;
                purchaseVM.Sales.UserId = userId;
                purchaseVM.Sales.Vin = purchaseVM.Vehicle.Vin;

                _salesRepository.PurchaseVehicle(purchaseVM.Sales);
           
                _vehicleRepository.SetVehicleIsSold(purchaseVM.Vehicle.Vin);

                return RedirectToAction("Index", "Sales");
            }
            else
            {
                purchaseVM.SetStateItems(_stateRepository.GetAllStates());
                purchaseVM.SetPurchaseTypeItems(_purchaseTypeRepository.GetAllPurchaseTypes());

                return View(purchaseVM);
            }
        }
    }
}