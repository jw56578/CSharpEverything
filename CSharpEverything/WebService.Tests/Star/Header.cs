using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace WebService.Tests
{
        [XmlRoot(ElementName = "manifest", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public class Manifest
        {
            [XmlAttribute(AttributeName = "contentID")]
            public string ContentID { get; set; }
            [XmlAttribute(AttributeName = "element")]
            public string Element { get; set; }
            [XmlAttribute(AttributeName = "namespaceURI")]
            public string NamespaceURI { get; set; }
            [XmlAttribute(AttributeName = "version")]
            public string Version { get; set; }
        }

        [XmlRoot(ElementName = "payloadManifest", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
        public class PayloadManifest
        {
            [XmlElement(ElementName = "manifest", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
            public Manifest Manifest { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
        }

        [XmlRoot(ElementName = "Timestamp", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public class Timestamp
        {
            [XmlElement(ElementName = "Created", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
            public string Created { get; set; }
            [XmlElement(ElementName = "Expires", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
            public string Expires { get; set; }
            [XmlAttribute(AttributeName = "Id", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
            public string Id { get; set; }
        }

        [XmlRoot(ElementName = "Password", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public class Password
        {
            [XmlAttribute(AttributeName = "Type")]
            public string Type { get; set; }
            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "UsernameToken", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public class UsernameToken
        {
            [XmlElement(ElementName = "Username", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
            public string Username { get; set; }
            [XmlElement(ElementName = "Password", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
            public Password Password { get; set; }
            [XmlAttribute(AttributeName = "Id", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
            public string Id { get; set; }
        }

        [XmlRoot(ElementName = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public class Security
        {
            [XmlElement(ElementName = "Timestamp", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
            public Timestamp Timestamp { get; set; }
            [XmlElement(ElementName = "UsernameToken", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
            public UsernameToken UsernameToken { get; set; }
            [XmlAttribute(AttributeName = "mustUnderstand", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public string MustUnderstand { get; set; }
            [XmlAttribute(AttributeName = "mustunderstand", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public string Mustunderstand { get; set; }
        }

        [XmlRoot(ElementName = "GMAuthorization", Namespace = "http://www.gm.com/Service/Authorization")]
        public class GMAuthorization
        {
            [XmlElement(ElementName = "TradingPartnerID", Namespace = "http://www.gm.com/Service/Authorization")]
            public string TradingPartnerID { get; set; }
            [XmlElement(ElementName = "BAC", Namespace = "http://www.gm.com/Service/Authorization")]
            public string BAC { get; set; }
            [XmlAttribute(AttributeName = "xmlns")]
            public string Xmlns { get; set; }
    }


 



        [XmlRoot(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Header
        {
            [XmlElement(ElementName = "payloadManifest", Namespace = "http://www.starstandards.org/webservices/2005/10/transport")]
            public PayloadManifest PayloadManifest { get; set; }
            [XmlElement(ElementName = "Security", Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
            public Security Security { get; set; }
            [XmlElement(ElementName = "Action", Namespace = "http://www.w3.org/2005/08/addressing")]
            public string Action { get; set; }
            [XmlAttribute(AttributeName = "soap", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Soap { get; set; }
            [XmlAttribute(AttributeName = "starws", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Starws { get; set; }
            [XmlAttribute(AttributeName = "wsa", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Wsa { get; set; }
            [XmlAttribute(AttributeName = "wsse", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Wsse { get; set; }
            [XmlAttribute(AttributeName = "wsu", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Wsu { get; set; }
        }

    

}
