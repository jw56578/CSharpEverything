using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using WebService.Tests.com.gm.pp.gmb2c;

namespace WebService.Tests
{
    public static class Functions
    {
        public static void SetProxyForFiddler()
        {
            System.Net.WebRequest.DefaultWebProxy = new WebProxy("127.0.0.1", 8888);
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
            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, obj);
            }
            return sb.ToString();
        }
        public static void SetCredentials(com.gm.pp.gmb2c.vehicleLocatorService_Service client)
        {

            // [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityValue")]
            //this is the trick, this attribute has to be put on the method that is called, in this case "process"



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
            client.SecurityValue.UsernameToken = new SecurityUsernameToken();
            client.SecurityValue.UsernameToken.Password = "La5WAGDCtpDkj4eh";
            client.SecurityValue.UsernameToken.Username = "bmw";
        }
    }
}
