using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebService.Tests.Star.GM
{
    [XmlRoot(ElementName = "Header", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class GMHeader:Header
    {
        [XmlElement(ElementName = "GMAuthorization", Namespace = "http://www.gm.com/Service/Authorization")]
        public GMAuthorization GMAuthorization { get; set; }
    }
}
