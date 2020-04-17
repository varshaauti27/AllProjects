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
    public class HomeController : Controller
    {
        readonly IVehicleRepository _repository;
        readonly ISpecialsRepository _specialsRepository;
        public HomeController()
        {
            _repository = VehicleManager.Create();
            _specialsRepository = SpecialsManager.Create();
        }
    
        public ActionResult Index()
        {
            return View("Index", _repository.GetFeatureVehicle());
            //return View(_repository.GetFeatureVehicle());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(string id)
        {
            Contact contact = new Contact
            {
                Message = id
            };
            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            //TO Do Save contact data into database ...
            if (ModelState.IsValid)
            {
                IContactRepository _contactRepository = ContactManager.Create();
                _contactRepository.AddContactInquiry(contact);

                return RedirectToAction("Index");
            }
            else
            {
                // send them back to the entry form
                ViewBag.Vin = contact.Message;
                return View("Contact", contact);
            }
        }

        public ActionResult Specials()
        {
            SpecialsViewModel specialsVM = new SpecialsViewModel { Specials = _specialsRepository.GetAllSpecials() };

            return View("Specials", specialsVM);
        }

        [HttpPost]
        public ActionResult Specials(SpecialsViewModel specialsVM)
        {
            if (string.IsNullOrWhiteSpace(specialsVM.Title))
            {
                ModelState.AddModelError("Title", "Please enter title");
            }

            if (string.IsNullOrWhiteSpace(specialsVM.Description))
            {
                ModelState.AddModelError("Description", "Please enter description");
            }

            if (!ModelState.IsValid)
            {
                //specialsVM.Specials = _specialsRepository.GetAllSpecials();               
                return View("Specials",specialsVM);
            }
            _specialsRepository.AddSpecial(new Specials { Name = specialsVM.Title, Description = specialsVM.Description });
            return RedirectToAction("Specials");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSpecials(int id)
        {
            _specialsRepository.DeleteSpecial(id);

            return RedirectToAction("Specials");
        }
    }
}