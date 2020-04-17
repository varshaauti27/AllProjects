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
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            IVehicleRepository _vehicleRepository = VehicleManager.Create();
         
            return View(_vehicleRepository.GetInventoryReports());
        }
       

        public ActionResult Sales()
        {
            SalesReportViewModel _salesReportVM = new SalesReportViewModel();
            var context = new ApplicationDbContext();
            _salesReportVM.SetUserItems(context.Users);

            return View(_salesReportVM);
        }

        [HttpGet]
        public JsonResult GetSalesReport(string userId, DateTime? fromDate, DateTime? toDate)
        {
            ISalesRepository _salesRepository = SalesManager.Create();
            var salesReport = _salesRepository.GetSalesReport(userId, fromDate, toDate);
            return Json(salesReport, JsonRequestBehavior.AllowGet);
        }
    }
}