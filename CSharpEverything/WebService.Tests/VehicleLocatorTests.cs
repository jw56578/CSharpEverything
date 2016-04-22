using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Tests.Star.GM;
using System.Linq;
using static WebService.Tests.Functions;

namespace WebService.Tests
{
    [TestClass]
    public class VehicleLocatorTests
    {
        [TestMethod]
        public void CanSearchInventoryByZipcode()
        {
            var results = CurrentStarRequest.SearchInventoryByZipcode("30062", 200);
            var count = results.Count();
            Assert.IsTrue(count > 0,"There were no results from 30062");
            results = CurrentStarRequest.SearchInventoryByZipcode("78745", 500);
            Assert.IsTrue(count != results.Count(),"The results were not different for another zip code and proximity");
        }
    }
}
