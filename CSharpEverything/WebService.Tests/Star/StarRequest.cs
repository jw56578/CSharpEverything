using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Tests.ProxyClasses;

namespace WebService.Tests.Star
{
    public partial class StarRequest
    {
        IStarImplementation implementer;
        string template = SampleXML.EnvelopeTemplate;
        public StarRequest(IStarImplementation implementer)
        {
            this.implementer = implementer;
        }

        IEnumerable<object> Search()
        {
            var header = implementer.GetHeaderXML();
            var content = implementer.GetContentXml();
            var envelope = string.Format(template, header, content);
            var response = Functions.HttpPOST(implementer.GetUrl(), envelope);
            var results = implementer.HandleSearchInventoryResponse(response);
            return results;

        }


    }
}
