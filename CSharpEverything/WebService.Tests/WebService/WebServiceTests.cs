//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Net.Security;
//using System.Net;
//using WebService.Tests.com.gm.pp.gmb2c;
//using System.IO;
//using System.Xml;
//using System.Text;
//using static WebService.Tests.Functions;
//using WebService.Tests.ProxyClasses;

//namespace WebService.Tests
//{
//    [TestClass]
//    public class WebServiceTests
//    {
//        public WebServiceTests()
//        {
//            SetProxyForFiddler(3597);
//            SetupFiddlerForSSL();
//        }

        


//        [TestMethod]
//        public void CanCallWebServiceThatDoesNotHaveProxySecurityHeader()
//        {
//            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
//            Functions.SetCredentials(locatorService);
//            var payload = GetProxyPayload();
//            locatorService.process(ref payload);
//        }
//        [TestMethod]
//        public void CanCallWebServiceWithSerializedPayload()
//        {
//            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
//            Functions.SetCredentials(locatorService);
//            var payload = GetVehicleInventorySearchPayload();
//            locatorService.process(ref payload);
//        }
//        [TestMethod]
//        public void CanDeserializeWebServiceResponse()
//        {
//            com.gm.pp.gmb2c.vehicleLocatorService_Service locatorService = new com.gm.pp.gmb2c.vehicleLocatorService_Service();
//            Functions.SetCredentials(locatorService);
//            var payload = GetVehicleInventorySearchPayload();
//            locatorService.process(ref payload);
//            var response = payload.content[0].Any.InnerXml;

//        }

//        [TestMethod]
//        public void CanSerializeAManuallyGeneratedProxyClass()
//        {
//            var result = Serialize<ExtGetVehicleInventory>(GetSearch());

//            Assert.IsFalse(string.IsNullOrEmpty(result));
//        }
//        ExtGetVehicleInventory GetSearch()
//        { 
//            ExtGetVehicleInventory inv = new ExtGetVehicleInventory();
//            inv.ExtApplicationArea = new ExtApplicationArea();
//            inv.ExtApplicationArea.CreationDateAndTime = "2011-12-17T09: 30:47Z";

//            var d = inv.ExtApplicationArea.Destination = new Destination();                       
//            d.DestinationNameCode = "VLS";
//            d.DestinationSoftwareCode = "VLS Locate Service";
//            var e = inv.ExtApplicationArea.ExtSender = new ExtSender();
//            e.CreatorNameCode = "2008-11-05T13:15:30.00Z";
//            e.SenderNameCode = "QI";
//            e.DealerNumberID = "115097";
//            e.ExtDealerCountryCode = "US";
//            e.TaskID = "Locate Vehicle";
//            e.ComponentID = "Locate Module";
//            e.ExtLanguageCode = "en-US";
//            inv.ExtGetVehicleInventoryDataArea = new ExtGetVehicleInventoryDataArea();
//            var g = inv.ExtGetVehicleInventoryDataArea.ExtGet = new ExtGet();
//            g.SearchCriteria = new SearchCriteria();
//            g.SearchCriteria.SearchByCity = new SearchByCity();
//            g.SearchCriteria.SearchByCity.RegionCode = "MI";
//            g.SearchCriteria.SearchByCity.Proximity = "100";
//            g.SearchCriteria.SearchByCity.Proximity = "Detroit";

//            return inv;
//        }
//        [TestMethod]
//        public void CanLoadXmlIntoXmlElement()
//        {
//            var s = GetSearch();
//            var result = Serialize<ExtGetVehicleInventory>(s);
//            var p = new Payload();
//            p.content = new Content[1];
//            p.content[0] = new Content();
//            p.content[0].Any = GetVehicleInventorySearch(result);

//        }

//        XmlElement GetVehicleInventorySearch(string xml)
//        {
//            XmlDocument doc = new XmlDocument();
//            doc.LoadXml(xml);
//            return doc.DocumentElement;
//        }
//        Payload GetVehicleInventorySearchPayload()
//        {
//            var s = GetSearch();
//            var result = Serialize<ExtGetVehicleInventory>(s);
//            var p = new Payload();
//            p.content = new Content[1];
//            p.content[0] = new Content();
//            p.content[0].Any = GetVehicleInventorySearch(result);
//            return p;
//        }
//    }
//}
