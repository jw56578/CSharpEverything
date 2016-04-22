using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Tests.Star.GM;
using System.Linq;
using static WebService.Tests.Functions;

namespace WebService.Tests
{
    [TestClass]
    public class VehicleSelectorTests
    {

        [TestMethod]
        public void CanGetAllYears()
        {
            var results = CurrentStarRequest.GetYears();
            var count = results.Count();
        }
        [TestMethod]
        public void CanGetMakesByYear()
        {
            var results = CurrentStarRequest.GetYears();
            var count = results.Count();
        }
    }
}
