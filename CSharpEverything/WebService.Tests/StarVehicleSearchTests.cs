using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebService.Tests.Star.GM;

namespace WebService.Tests
{
    [TestClass]
    public class StarVehicleSearchTests
    {
        [TestMethod]
        public void CanSearchYears()
        {
            var gm = new GMStarImplementation("999970");
            var sr = new Star.StarRequest(gm);
            sr.GetYears();

        }


        [TestMethod]
        public void CanPostGetAllYears()
        {
            var template = SampleXML.EnvelopeTemplate;
            template = string.Format(template, SampleXML.Header, SampleXML.GetAllYears);
            Functions.HttpPOST("https://gmb2c.pp.gm.com/VehicleLocatorService/services/ProcessMessage?wsdl", template);
        }

        [TestMethod]
        public void CanPostGetAllMakes()
        {
            Functions.HttpPOST("https://gmb2c.pp.gm.com/VehicleLocatorService/services/ProcessMessage", SampleXML.GetAllMakesEntireEnvelopeXML);
        }
    }
}
