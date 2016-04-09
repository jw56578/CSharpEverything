using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Security;
using System.Net;
using WebService.Tests.com.gm.pp.gmb2c;
using System.IO;
using System.Xml;
using System.Text;
using static WebService.Tests.Functions;

namespace WebService.Tests
{
    [TestClass]
    public class WebServiceTests
    {
        public WebServiceTests()
        {
            SetProxyForFiddler();
            SetupFiddlerForSSL();
        }
        [TestMethod]
        public void CanCallWebServiceThatDoesNotHaveProxySecurityHeader()
        {
            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
            Functions.SetCredentials(locatorService);
            var payload = GetProxyPayload();
            locatorService.process(ref payload);
        }
        [TestMethod]
        public void CanCallWebServiceWithSerializedPayload()
        {
            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
            Functions.SetCredentials(locatorService);
            var payload = GetVehicleInventorySearchPayload();
            locatorService.process(ref payload);
        }
        [TestMethod]
        public void CanDeserializeWebServiceResponse()
        {
            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
            Functions.SetCredentials(locatorService);
            var payload = GetVehicleInventorySearchPayload();
            locatorService.process(ref payload);
            var response = payload.content[0].Any.InnerXml;

        }
        [TestMethod]
        public void CanDeserializeResponse()
        {
            var searchresult = Deserialize<ExtShowVehicleInventory>(SampleXML.InventorySearchResponse);
        }
        [TestMethod]
        public void CanSerializeAManuallyGeneratedProxyClass()
        {
            var result = Serialize<ExtGetVehicleInventory>(GetSearch());

            Assert.IsFalse(string.IsNullOrEmpty(result));
        }
        ExtGetVehicleInventory GetSearch()
        { 
            ExtGetVehicleInventory inv = new ExtGetVehicleInventory();
            inv.ExtGetVehicleInventoryDataArea = new ExtGetVehicleInventoryDataArea();
            inv.ExtGetVehicleInventoryDataArea.ExtGet = new ExtGet();
            inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria = new SearchCriteria();
            inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity = new SearchByCity();
            inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity.RegionCode = "MI";
            inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity.Proximity = "100";
            inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity.Proximity = "Detroit";

            return inv;
        }
        [TestMethod]
        public void CanLoadXmlIntoXmlElement()
        {
            var s = GetSearch();
            var result = Serialize<ExtGetVehicleInventory>(s);
            var p = new Payload();
            p.content = new Content[1];
            p.content[0] = new Content();
            p.content[0].Any = GetVehicleInventorySearch(result);

        }

        XmlElement GetVehicleInventorySearch(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.DocumentElement;
        }
        Payload GetVehicleInventorySearchPayload()
        {
            var s = GetSearch();
            var result = Serialize<ExtGetVehicleInventory>(s);
            var p = new Payload();
            p.content = new Content[1];
            p.content[0] = new Content();
            p.content[0].Any = GetVehicleInventorySearch(result);
            return p;
        }
    }
}
