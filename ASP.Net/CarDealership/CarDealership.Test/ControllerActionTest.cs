using CarDealership.UI.Controllers;
using CarDealership.UI.Models;
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
    public class ControllerActionTest
    {
        readonly HomeController _homeController = new HomeController();
        readonly InventoryController _inventoryController = new InventoryController();
        readonly SalesController _salesController = new SalesController();
        [Test]
        public void HomeIndexActionReturnsIndexView()
        {
            string expected = "Index";
            var result = _homeController.Index() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
            Assert.IsNotNull(result);
        }

        [Test]
        public void SpecialsActionReturnsSpecialsView()
        {
            string expected = "Specials";
            var result = _homeController.Specials() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        //[Test]
        //public void DeleteSpecialsActionReturnsSpecialsView()
        //{
        //    var result = _homeController.DeleteSpecials(1) as RedirectToRouteResult;

        //    Assert.That(result.RouteValues["action"], Is.EqualTo("Specials"));
        //}

        [Test]
        public void InventoryIndexActionReturnsIndexView()
        {
            string expected = "Index";
            var result = _inventoryController.Index() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void NewActionReturnsSearchView()
        {
            string expected = "Search";
            var result = _inventoryController.New() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void UsedActionReturnsSearchView()
        {
            string expected = "Search";
            var result = _inventoryController.Used() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void DetailsActionReturnsDetailsView()
        {
            string expected = "Details";
            var result = _inventoryController.Details("1ABCDEFG") as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void SalesIndexActionReturnsIndexView()
        {
            string expected = "Index";
            var result = _salesController.Index() as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }

        [Test]
        public void PurchaseActionReturnsPurchaseView()
        {
            string expected = "Purchase";
            var result = _salesController.Purchase("1ABCDEFG") as ViewResult;

            Assert.AreEqual(expected, result.ViewName);
        }
    }
}
