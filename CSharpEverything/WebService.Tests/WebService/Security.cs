//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WebService.Tests
//{
//    //  <GMAuthorization xmlns = "http://www.gm.com/Service/Authorization" >
//    //   < TradingPartnerID > String </ TradingPartnerID >
//    //   < BAC > String </ BAC >
//    //</ GMAuthorization >
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.starstandards.org/webservices/2009/transport")]
//    public partial class Manifest
//    {

//        private string contentIDField;

//        private string namespaceURIField;

//        private string elementField;

//        private string relatedIDField;

//        private string versionField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "IDREF")]
//        public string contentID
//        {
//            get
//            {
//                return this.contentIDField;
//            }
//            set
//            {
//                this.contentIDField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "anyURI")]
//        public string namespaceURI
//        {
//            get
//            {
//                return this.namespaceURIField;
//            }
//            set
//            {
//                this.namespaceURIField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string element
//        {
//            get
//            {
//                return this.elementField;
//            }
//            set
//            {
//                this.elementField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string relatedID
//        {
//            get
//            {
//                return this.relatedIDField;
//            }
//            set
//            {
//                this.relatedIDField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string version
//        {
//            get
//            {
//                return this.versionField;
//            }
//            set
//            {
//                this.versionField = value;
//            }
//        }
//    }
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.starstandards.org/webservices/2009/transport")]
//    [System.Xml.Serialization.XmlRootAttribute("payloadManifest", Namespace = "http://www.starstandards.org/webservices/2009/transport", IsNullable = false)]
//    public partial class PayloadManifest : System.Web.Services.Protocols.SoapHeader
//    {

//        private Manifest[] manifestField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("manifest")]
//        public Manifest[] manifest
//        {
//            get
//            {
//                return this.manifestField;
//            }
//            set
//            {
//                this.manifestField = value;
//            }
//        }
//    }

//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.w3.org/2005/08/addressing")]
//    public partial class Action : System.Web.Services.Protocols.SoapHeader
//    {
//        public override string ToString()
//        {
//            return "ldkfj";
//        }
//    }


//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.gm.com/Service/Authorization")]
//    public partial class GMAuthorization : System.Web.Services.Protocols.SoapHeader
//    {
//        public string TradingPartnerID { get; set; }
//        public string BAC { get; set; }
//    }


//    /// <remarks/>
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd" +
//        "")]
//    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd" +
//        "", IsNullable = false)]
//    public partial class Security : System.Web.Services.Protocols.SoapHeader
//    {

//        private SecurityUsernameToken usernameTokenField;

//        private System.Xml.XmlAttribute[] anyAttrField;

//        /// <remarks/>
//        public SecurityUsernameToken UsernameToken
//        {
//            get
//            {
//                return this.usernameTokenField;
//            }
//            set
//            {
//                this.usernameTokenField = value;
//            }
//        }
//        public Timestamp Timestamp
//        { get; set; }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
//        public System.Xml.XmlAttribute[] AnyAttr
//        {
//            get
//            {
//                return this.anyAttrField;
//            }
//            set
//            {
//                this.anyAttrField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd" +
//        "")]
//    public partial class SecurityUsernameToken
//    {

//        private string usernameField;

//        private string passwordField;

//        /// <remarks/>
//        public string Username
//        {
//            get
//            {
//                return this.usernameField;
//            }
//            set
//            {
//                this.usernameField = value;
//            }
//        }

//        /// <remarks/>
//        public string Password
//        {
//            get
//            {
//                return this.passwordField;
//            }
//            set
//            {
//                this.passwordField = value;
//            }
//        }
//        public string TradingPartnerID { get; set; }
//        public string BAC { get; set; }

//    }
//    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
//    [System.SerializableAttribute()]
//    [System.Diagnostics.DebuggerStepThroughAttribute()]
//    [System.ComponentModel.DesignerCategoryAttribute("code")]
//    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd" +
//      "")]
//    public partial class Timestamp : System.Web.Services.Protocols.SoapHeader
//    {

//        private string createdField;

//        private string expiresField;

//        /// <remarks/>
//        public string Created
//        {
//            get
//            {
//                return this.createdField;
//            }
//            set
//            {
//                this.createdField = value;
//            }
//        }

//        /// <remarks/>
//        public string Expires
//        {
//            get
//            {
//                return this.expiresField;
//            }
//            set
//            {
//                this.expiresField = value;
//            }
//        }
//    }
//}
