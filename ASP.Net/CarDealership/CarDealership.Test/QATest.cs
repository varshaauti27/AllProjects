using CarDealership.UI.Controllers;
using CarDealership.UI.Data.Repositories;
using CarDealership.UI.Models;
using CarDealership.UI.Models.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealership.Test
{
    [TestFixture]
    public class QATest
    {
        readonly HomeController _homeController = new HomeController();

        //[TestCase("Title","Description")]
        //[TestCase("", "Description")]
        //[TestCase("Title", "")]
        [Test]
        public void CanAdminAddSpecials()
        {
            ISpecialsRepository _specialsRepository = new SpecialsMockRepository();

            //To Do : GetCount then check...
            SpecialsViewModel special = new SpecialsViewModel
            {
                Title = "title",
                Description = "Description"
            };

            RedirectToRouteResult result = _homeController.Specials(special) as RedirectToRouteResult;
  
            Assert.AreEqual(4, _specialsRepository.GetAllSpecials().Count());
        }
    }
}
