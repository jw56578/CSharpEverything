using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Protocols;

namespace WebService.Tests
{
    public class SoapAuthHeader : SoapHeader
    {
        public string Username;
        public string Password;
    }

}
namespace WebService.Tests.com.gm.pp.gmb2c
{
    public partial class vehicleLocatorService_Service
    {
        public Security SecurityValue
        {
            get;
            set;
        }
        public GMAuthorization GMAuthorization
        { get; set; }
   
        public Action Action
        { get; set; }
        public PayloadManifest payloadManifest { get; set; }
        //this attribute is what needs to be added to the method after generattion
        //just add it here and delete from the generated file so that if its regenerated a compile time error will happen and it will be known to delete it
        //DELETE THE METHOD IN THE GENERATED CLASS
        [System.Web.Services.Protocols.SoapHeaderAttribute("SecurityValue")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("GMAuthorization")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("Action")]
        [System.Web.Services.Protocols.SoapHeaderAttribute("payloadManifest")]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("", RequestElementName = "ProcessMessage", RequestNamespace = "http://www.starstandards.org/webservices/2005/10/transport", ResponseElementName = "ProcessMessageResponse", ResponseNamespace = "http://www.starstandards.org/webservices/2005/10/transport", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void process(ref Payload payload)
        {
            object[] results = this.Invoke("process", new object[] {
                        payload});
            payload = ((Payload)(results[0]));
        }


    }

}