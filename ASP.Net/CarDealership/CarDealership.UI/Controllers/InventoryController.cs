using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    public class InventoryController : Controller
    {
        readonly IVehicleRepository _repository;

        public InventoryController()
        {
            _repository = VehicleManager.Create();
        }
        // GET: Inventory
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult New()
        {
            ViewBag.Title = "New Vehicle";
            ViewBag.IsNewVehicle = "true";
            ViewBag.Page = "Inventory";
            return View("Search");
        }

        public ActionResult Used()
        {
            ViewBag.Title = "Used Vehicle";
            ViewBag.IsNewVehicle = "false";
            ViewBag.Page = "Inventory";
            return View("Search");
        }

        public ActionResult Details(string id)
        {
            ViewBag.Title = "Vehicle Detail";
            Vehicle vehicle = _repository.GetVehicleByVin(id);
            return View("Details",vehicle);
        }

        [HttpPost]
        public JsonResult SearchVehicles(SearchRequest searchRequest)
        {
            return Json(_repository.SearchVehicles(searchRequest), JsonRequestBehavior.AllowGet);
        }
    }
}