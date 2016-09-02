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
    public  static partial class Functions
    {
        public static string HttpPOST(string url, string data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/xml; charset=utf-8"; // or whatever - application/json, etc, etc
            request.Method = "POST";
            using (StreamWriter requestWriter = new StreamWriter(request.GetRequestStream()))
            {
                requestWriter.Write(data);
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
        public static string Serialize<T>(object obj)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("vls", "urn:com.gm:vls");
            ns.Add("star", "http://www.starstandard.org/STAR/5");
            ns.Add("oagis", "http://www.openapplications.org/oagis/9");
            ns.Add("soap", "http://schemas.xmlsoap.org/soap/envelope/");
            ns.Add("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
            ns.Add("starws", "http://www.starstandards.org/webservices/2005/10/transport");
            ns.Add("wsa", "http://www.w3.org/2005/08/addressing");
            ns.Add("wsu", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd");


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
             

            //client.SecurityValue = new Security();
            //client.SecurityValue.MustUnderstand = true;
            //client.SecurityValue.UsernameToken = new SecurityUsernameToken();
            //client.SecurityValue.UsernameToken.Password = "Password123";
            //client.SecurityValue.UsernameToken.Username = "mgifedl001";


            //client.GMAuthorization = new GMAuthorization();
            //client.GMAuthorization.BAC = "115275";
            //client.GMAuthorization.TradingPartnerID = "EL";

            //client.SecurityValue.Timestamp = new Timestamp();
            //client.SecurityValue.Timestamp.Created = DateTime.UtcNow.ToString("o");
            //client.SecurityValue.Timestamp.Expires = DateTime.UtcNow.AddMinutes(1).ToString("o");

            //client.Action = new Action();

            //var pm = client.payloadManifest = new PayloadManifest();
            //pm.manifest = new Manifest[1];
            //pm.manifest[0] = new Manifest();
            //pm.manifest[0].element = "ExtGetVehicleInventory";
            //pm.manifest[0].contentID = "Content0";
            //pm.manifest[0].version="1.0";
            //pm.manifest[0].namespaceURI = "http://www.gm.com/vls";



        }
     
    }
}
