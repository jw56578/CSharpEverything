using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static WebService.Tests.Functions;
using WebService.Tests.Star.GM;

namespace WebService.Tests
{
    [TestClass]
    public class HttpPostTests
    {
       /// <summary>
       /// need to have the soap envelope literal text
       /// 
       /// </summary>
        [TestMethod]
        public void CanPostRawDataToEndPoint()
        {
            var result = Functions.HttpPOST("https://gmb2c.pp.gm.com/VehicleLocatorService/services/ProcessMessage?wsdl", SampleXML.WorkingSOAPEnvelopeXMLMinimum);
        }
        [TestMethod]
        public void CanPostRawDataFromTemplateToEndPoint()
        {
            var template = SampleXML.EnvelopeTemplate;
            template = string.Format(template, SampleXML.Header, SampleXML.ExtGetVehicleInventoryMinimum);
            Functions.HttpPOST("https://gmb2c.pp.gm.com/VehicleLocatorService/services/ProcessMessage?wsdl", template);
        }
        [TestMethod]
        public void CanPostRawDataFromTemplateAndSerializedObjetToEndPoint()
        {

        }
    }
}
