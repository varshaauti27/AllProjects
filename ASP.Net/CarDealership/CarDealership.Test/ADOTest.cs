using CarDealership.UI.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Test
{
    [TestFixture]
    public class ADOTest
    {
        [Test]
        public void CanGetAllColors()
        {
            var repo = new ColorADORepository();
            var colors = repo.GetAllColors();

            Assert.AreEqual(6,colors.Count);
            Assert.AreEqual("Black", colors[0].Name);
        }
    }
}
