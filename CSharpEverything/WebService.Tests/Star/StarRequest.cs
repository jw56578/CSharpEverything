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
        string header;
        string url;
        IStarImplementation implementer;
        public StarRequest(IStarImplementation implementer)
        {
            url = implementer.GetUrl();
            this.implementer = implementer;
        }
        public void SearchInventoryByZipcode(string zip, int proximity)
        {
            var template = SampleXML.EnvelopeTemplate;
            implementer.SetCriteria(new Criteria()
            {
                SearchCriteria = new SearchInventoryCriteria()
                {
                    Zipcode = new Zipcode()
                    {
                        PostalCode = zip,
                        Proximity = proximity
                    }
                }
            });
            header = implementer.GetHeaderXML();
            var content = implementer.GetContentXml();
            template = string.Format(template, header, content);
           
            var response = Functions.HttpPOST(url, template);
            var resuls = implementer.HandleSearchInventoryResponse(response);
          

        }
        public void SearchInventory()
        {
            SearchCompanyInventory("EL_115275");
        }
        public void SearchCompanyInventory(string id)
        {
            var template = SampleXML.EnvelopeTemplate;
            implementer.SetCriteria(new Criteria()
            {
                SearchCriteria = new SearchInventoryCriteria()
                {
                    Company = new Company()
                    {
                        Id = id
                    }
                }
            });
            header = implementer.GetHeaderXML();
            var content = implementer.GetContentXml();
            template = string.Format(template, header, content);

            var response = Functions.HttpPOST(url, template);
            var resuls = implementer.HandleSearchInventoryResponse(response);
        }

        public void GetYears()
        {
            var template = SampleXML.EnvelopeTemplate;
            implementer.SetCriteria(new Criteria()
            {
                SearchVehicleCriteria = new SearchVehicleCriteria()
                {

                }
            });
            header = implementer.GetHeaderXML();
            var content = implementer.GetContentXml();
            template = string.Format(template, header, content);

            var response = Functions.HttpPOST(url, template);
            var resuls = implementer.HandleSearchInventoryResponse(response);
        }

    }
}
