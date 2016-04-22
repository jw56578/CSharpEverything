using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star
{
    public partial class StarRequest
    {
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
    }
}
