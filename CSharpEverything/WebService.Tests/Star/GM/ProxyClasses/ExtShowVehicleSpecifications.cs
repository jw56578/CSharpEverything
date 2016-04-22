using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebService.Tests
{

        [XmlRoot(ElementName = "Sender", Namespace = "http://www.starstandard.org/STAR/5")]
        public class Sender
        {
            [XmlElement(ElementName = "ComponentID", Namespace = "http://www.starstandard.org/STAR/5")]
            public string ComponentID { get; set; }
            [XmlElement(ElementName = "TaskID", Namespace = "http://www.starstandard.org/STAR/5")]
            public string TaskID { get; set; }
            [XmlElement(ElementName = "CreatorNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
            public string CreatorNameCode { get; set; }
            [XmlElement(ElementName = "SenderNameCode", Namespace = "http://www.starstandard.org/STAR/5")]
            public string SenderNameCode { get; set; }
        }


        [XmlRoot(ElementName = "DocumentIdentification", Namespace = "http://www.starstandard.org/STAR/5")]
        public class DocumentIdentification
        {
            [XmlElement(ElementName = "DocumentID", Namespace = "http://www.starstandard.org/STAR/5")]
            public string DocumentID { get; set; }
        }

        [XmlRoot(ElementName = "DocumentIdentificationGroup", Namespace = "http://www.starstandard.org/STAR/5")]
        public class DocumentIdentificationGroup
        {
            [XmlElement(ElementName = "DocumentIdentification", Namespace = "http://www.starstandard.org/STAR/5")]
            public DocumentIdentification DocumentIdentification { get; set; }
        }

        [XmlRoot(ElementName = "VehicleSpecificationsHeader", Namespace = "http://www.starstandard.org/STAR/5")]
        public class VehicleSpecificationsHeader
        {
            [XmlElement(ElementName = "DocumentIdentificationGroup", Namespace = "http://www.starstandard.org/STAR/5")]
            public DocumentIdentificationGroup DocumentIdentificationGroup { get; set; }
        }

        [XmlRoot(ElementName = "ModelYear", Namespace = "urn:com.gm:vls")]
        public class ModelYear
        {
            [XmlElement(ElementName = "MakeList", Namespace = "urn:com.gm:vls")]
            public string MakeList { get; set; }
            [XmlElement(ElementName = "Year", Namespace = "urn:com.gm:vls")]
            public string Year { get; set; }
        }

        [XmlRoot(ElementName = "ExtVehicleSpecifications", Namespace = "urn:com.gm:vls")]
        public class ExtVehicleSpecifications
        {
            [XmlElement(ElementName = "VehicleSpecificationsHeader", Namespace = "http://www.starstandard.org/STAR/5")]
            public VehicleSpecificationsHeader VehicleSpecificationsHeader { get; set; }
            [XmlElement(ElementName = "ModelYear", Namespace = "urn:com.gm:vls")]
            public List<ModelYear> ModelYear { get; set; }
        }

        [XmlRoot(ElementName = "ExtShowVehicleSpecificationsDataArea", Namespace = "urn:com.gm:vls")]
        public class ExtShowVehicleSpecificationsDataArea
        {
            [XmlElement(ElementName = "ExtShow", Namespace = "urn:com.gm:vls")]
            public string ExtShow { get; set; }
            [XmlElement(ElementName = "ExtVehicleSpecifications", Namespace = "urn:com.gm:vls")]
            public ExtVehicleSpecifications ExtVehicleSpecifications { get; set; }
        }

        [XmlRoot(ElementName = "ExtShowVehicleSpecifications", Namespace = "urn:com.gm:vls")]
        public class ExtShowVehicleSpecifications
        {
            [XmlElement(ElementName = "ExtApplicationArea", Namespace = "urn:com.gm:vls")]
            public ExtApplicationArea ExtApplicationArea { get; set; }
            [XmlElement(ElementName = "ExtShowVehicleSpecificationsDataArea", Namespace = "urn:com.gm:vls")]
            public ExtShowVehicleSpecificationsDataArea ExtShowVehicleSpecificationsDataArea { get; set; }
            [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
            public string SchemaLocation { get; set; }
            [XmlAttribute(AttributeName = "oagis", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Oagis { get; set; }
            [XmlAttribute(AttributeName = "star", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Star { get; set; }
            [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Xsi { get; set; }
            [XmlAttribute(AttributeName = "vls", Namespace = "http://www.w3.org/2000/xmlns/")]
            public string Vls { get; set; }
        }

}
