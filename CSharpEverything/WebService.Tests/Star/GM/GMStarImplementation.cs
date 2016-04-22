using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Tests.ProxyClasses;

namespace WebService.Tests.Star.GM
{
    public class GMStarImplementation : IStarImplementation
    {
        string bac;
        Criteria criteria;
        Func<string> getContentxml = null;
        Func<string> getHeader = null;

        public GMStarImplementation(string bac)
        {
            this.bac = bac;
 
        }
        string GetVehicleSearch()
        {
            var inv = GMVehicleSearch.GetSearch(criteria.SearchVehicleCriteria);
            return Functions.Serialize<ExtGetVehicleSpecifications>(inv);
        }
        string GetInventorySearch()
        {
            var inv = GMInventorySearch.GetSearch(criteria.SearchCriteria);
            return Functions.Serialize<ExtGetVehicleInventory>(inv);
        }
        public string GetContentXml()
        {
            return getContentxml();
        }
        string GetInventorySearchHeader()
        {
            var gmHeader = new GMHeader();
            Functions.CreateHeader(gmHeader);
            var ga = gmHeader.GMAuthorization = new GMAuthorization();
            ga.TradingPartnerID = "EL";
            ga.BAC = this.bac;
            var result = Functions.Serialize<GMHeader>(gmHeader);

            return result;
        }
        string GetVehicleSearchHeader()
        {
            var gmHeader = new GMHeader();
            Functions.CreateHeader(gmHeader,"VehicleSelector","ExtGetVehicleSpecifications");
            var ga = gmHeader.GMAuthorization = new GMAuthorization();
            ga.TradingPartnerID = "EL";
            ga.BAC = this.bac;
            var result = Functions.Serialize<GMHeader>(gmHeader);

            return result;
        }
        public string GetHeaderXML()
        {
            return getHeader();
        }

        public string GetUrl()
        {
            return "https://gmb2c.pp.gm.com/VehicleLocatorService/services/ProcessMessage";
        }

        public IEnumerable<object> HandleSearchInventoryResponse(string responseXml)
        {
            var searchresult = Functions.Deserialize<Envelope>(responseXml);
            var result = searchresult.Body.ProcessMessageResponse.Payload.Content.
                ExtShowVehicleInventory.ExtShowVehicleInventoryDataArea.ExtVehicleInventory.
                ExtVehicleInventoryInvoice.ExtVehicleInventoryVehicleLineItem;
            foreach (var inv in result)
            {
                yield return inv;
            }
        }

        public void SetCriteria(Criteria criteria)
        {
            this.criteria = criteria;
            if (criteria.SearchCriteria != null)
            {
                getContentxml = GetInventorySearch;
                getHeader = GetInventorySearchHeader;
            }

            if (criteria.SearchVehicleCriteria != null)
            {
                getHeader = GetVehicleSearchHeader;
                getContentxml = GetVehicleSearch;
            }
        }

        public IEnumerable<object> HandleResponse(string responseXml)
        {
            throw new NotImplementedException();
        }
    }
}
