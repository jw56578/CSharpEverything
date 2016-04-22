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
        public IEnumerable<object> SearchInventoryByZipcode(string zip, int proximity)
        {
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
            return Search();
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
        public void SearchInventory()
        {
            SearchCompanyInventory("EL_115275");
        }
        public IEnumerable<object> SearchCompanyInventory(string id)
        {
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
            return Search();
        }

        public IEnumerable<object> GetYears()
        {
            implementer.SetCriteria(new Criteria()
            {
                SearchVehicleCriteria = new SearchVehicleCriteria()
                {

                }
            });
            return Search();
        }

    }
}
