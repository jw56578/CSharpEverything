using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using WebService.Tests.com.gm.pp.gmb2c;


namespace WebService.Tests
{
    public static class Functions
    {
        public static string HttpPOST(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/xml; charset=utf-8"; // or whatever - application/json, etc, etc
            request.Method = "POST";
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());

            try
            {
                requestWriter.Write(data);
            }
            catch
            {
                throw;
            }
            finally
            {
                requestWriter.Close();
                requestWriter = null;
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                return sr.ReadToEnd();
            }
        }
        public static void SetProxyForFiddler(int port = 8888)
        {
            System.Net.WebRequest.DefaultWebProxy = new WebProxy("127.0.0.1",port);
        }
        public static void SetupFiddlerForSSL()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
                      delegate
                      {
                          return true;
                      });
        }
        public static Payload GetProxyPayload()
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Payload));
            object result;
            using (TextReader reader = new StringReader(SampleXML.SerializedPayloadTemplate))
            {
                result = serializer.Deserialize(reader);
            }
            return result as Payload;
        }
        public static string Serialize<T>(object obj)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("vls", "urn:com.gm:vls");
            ns.Add("star", "http://www.starstandard.org/STAR/5");
            ns.Add("oagis", " http://www.openapplications.org/oagis/9");



       

            using (TextWriter writer = new StringWriter(sb))
            {
                using (XmlWriter xmlwriter = XmlWriter.Create(writer, settings))
                {
                    serializer.Serialize(xmlwriter, obj,ns);
                }
                    
            }
            return sb.ToString();
        }
        public static T Deserialize<T>(string xml) where T:class
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            object result;
            using (TextReader reader = new StringReader(xml))
            {
                result = serializer.Deserialize(reader);
            }
            return result as T;
        }
        public static void SetCredentials(com.gm.pp.gmb2c.vehicleLocatorService_Service client)
        {

            // [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityValue")]
            //this is the trick, this attribute has to be put on the method that is called, in this case "process"

            //client.Url = "https://gmb2c.gm.com/VehicleLocatorService/services/ProcessMessage";

            //doesn't work
            //client.Credentials = new NetworkCredential("xxxxx", "xxxxxx");

            //nope
            //System.Net.CredentialCache myCredentials = new System.Net.CredentialCache();
            //NetworkCredential netCred = new NetworkCredential("UserName", "Password");
            //myCredentials.Add(new Uri(client.Url), "Basic", netCred);
            //client.Credentials = myCredentials;

            //nope
            //SoapAuthHeader authHeader = new SoapAuthHeader();
            //authHeader.Username = "username";
            //authHeader.Password = "password";
            //client.AuthHeader = authHeader;
             

            client.SecurityValue = new Security();
            client.SecurityValue.MustUnderstand = true;
            client.SecurityValue.UsernameToken = new SecurityUsernameToken();
            client.SecurityValue.UsernameToken.Password = "Password123";
            client.SecurityValue.UsernameToken.Username = "mgifedl001";


            client.GMAuthorization = new GMAuthorization();
            client.GMAuthorization.BAC = "115275";
            client.GMAuthorization.TradingPartnerID = "EL";

            client.SecurityValue.Timestamp = new Timestamp();
            client.SecurityValue.Timestamp.Created = DateTime.UtcNow.ToString("o");
            client.SecurityValue.Timestamp.Expires = DateTime.UtcNow.AddMinutes(1).ToString("o");

            client.Action = new Action();

            var pm = client.payloadManifest = new PayloadManifest();
            pm.manifest = new Manifest[1];
            pm.manifest[0] = new Manifest();
            pm.manifest[0].element = "ExtGetVehicleInventory";
            pm.manifest[0].contentID = "Content0";
            pm.manifest[0].version="1.0";
            pm.manifest[0].namespaceURI = "http://www.gm.com/vls";



        }
        public static ExtGetVehicleInventory CreateMinimalMessage()
        {
            ExtGetVehicleInventory inv = new ExtGetVehicleInventory();
            inv.ExtApplicationArea = new ExtApplicationArea();
            inv.ExtApplicationArea.CreationDateAndTime = DateTime.UtcNow.ToString("o");

            var d = inv.ExtApplicationArea.Destination = new Destination();
            d.DestinationNameCode = "VLS";
            d.DestinationSoftwareCode = "VLS Locate Service";
            var e = inv.ExtApplicationArea.ExtSender = new ExtSender();
            e.CreatorNameCode = "ADP";
            e.SenderNameCode = "AD";
            e.DealerNumberID = "119086";
            e.ExtDealerCountryCode = "US";
            e.TaskID = "Locate Vehicle";
            e.ComponentID = "Locate Module";
            e.ExtLanguageCode = "en-US";
            inv.ExtGetVehicleInventoryDataArea = new ExtGetVehicleInventoryDataArea();
            var g = inv.ExtGetVehicleInventoryDataArea.ExtGet = new ExtGet();
            g.SearchCriteria = new SearchCriteria();

            var vs = g.VehicleSpecification = new VehicleSpecification();
            vs.MakeCode = "001";
            vs.MerchandisingModelDesignator = "12P43";
            vs.SellingSourceCode = "13";
            vs.Year = "2015";

            var f = g.FilterCriteria = new FilterCriteria();
            f.EarliestEventCode = "3000";

            var sbc = g.SearchCriteria.SearchByCity = new SearchByCity();
            sbc.RegionCode = "MI";
            sbc.Proximity = "100";
            sbc.City = "Detroit";

            //var pc = g.SearchCriteria.SearchByPostalCode = new SearchByPostalCode();
            //pc.Proximity = "200";
            //pc.PostalCode = "30062";
   
            g.ExtMaxItems = "20";
            g.Expression = " ";

            var o = g.OutputSpecification = new OutputSpecification();
            o.IncludeModelInfo = "true";
            o.IncludePricing = "true";
            o.IncludeOptions = "true";
            o.IncludeStatus = "true";
            o.IncludeVendorAssigned = "true";
            o.IncludeVendorDetail = "true";
            o.OptionDescriptionType = "DEFAULT";
            return inv;



        }
    }
}
