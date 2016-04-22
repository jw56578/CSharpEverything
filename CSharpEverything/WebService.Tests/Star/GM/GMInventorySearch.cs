using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star.GM
{
    public class GMInventorySearch
    {
        GMStarImplementation implementer;
        public GMInventorySearch(GMStarImplementation implementer)
        {
            this.implementer = implementer;
        }
        public ExtGetVehicleInventory GetSearch(SearchInventoryCriteria criteria)
        {
            if (criteria.Zipcode.HasValue)
                return GetZicodeSearch(criteria);
            if (criteria.Company.HasValue)
                return GetCompanySearch(criteria);
            if (criteria.City.HasValue)
                return GetCitySearch(criteria);
            if (criteria.State.HasValue)
                return GetStateSearch(criteria);
            return null;
        }
        ExtGetVehicleInventory GetStateSearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var region = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByRegion = new SearchByRegion();
            region.RegionCode = new List<string>();
            region.RegionCode.Add(criteria.State.Value.RegionCode);
            return inv;
        }
        ExtGetVehicleInventory GetCompanySearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var vendor = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchBySingleVendor = new SearchBySingleVendor();
            vendor.VendorId = criteria.Company.Value.Id;
            return inv;
        }
        ExtGetVehicleInventory GetZicodeSearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var pc = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByPostalCode = new SearchByPostalCode();
            pc.Proximity = criteria.Zipcode.Value.Proximity.ToString();
            pc.PostalCode = criteria.Zipcode.Value.PostalCode;
            return inv;
        }
        ExtGetVehicleInventory GetCitySearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var sbc = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity = new SearchByCity();
            sbc.RegionCode = criteria.City.Value.RegionCode;
            sbc.Proximity = criteria.City.Value.Proximity.ToString();
            sbc.City = criteria.City.Value.Name;
            return inv;
        }
        ExtGetVehicleInventory Create(SearchInventoryCriteria criteria)
        {
            ExtGetVehicleInventory inv = new ExtGetVehicleInventory();
            inv.ExtApplicationArea = new ExtApplicationArea();
            inv.ExtApplicationArea.CreationDateAndTime = DateTime.UtcNow.ToString("o");

            CreateCredentials(inv,criteria);
            CreateVehicleSpec(inv, criteria);
            CreateOutputSpec(inv, criteria);
            return inv;
        }
        void CreateVehicleSpec(ExtGetVehicleInventory inv, SearchInventoryCriteria criteria)
        {
            var vs = inv.ExtGetVehicleInventoryDataArea.ExtGet.VehicleSpecification = new VehicleSpecification();
            vs.MakeCode = "001";
            vs.MerchandisingModelDesignator = "12P43";
            vs.SellingSourceCode = "13";
            vs.Year = "2015";

        }
        void CreateOutputSpec(ExtGetVehicleInventory inv, SearchInventoryCriteria criteria)
        {
            //minimal required outputspecifications
            var o = inv.ExtGetVehicleInventoryDataArea.ExtGet.OutputSpecification = new OutputSpecification();
            o.IncludeModelInfo = "true";
            o.IncludePricing = "true";
            o.IncludeOptions = "true";
            o.IncludeStatus = "true";
            o.IncludeVendorAssigned = "true";
            o.IncludeVendorDetail = "true";
            o.OptionDescriptionType = "DEFAULT";

        }
        void CreateCredentials(ExtGetVehicleInventory inv, SearchInventoryCriteria criteria)
        {
            var d = inv.ExtApplicationArea.Destination = new Destination();
            d.DestinationNameCode = implementer.DestinationNameCode;
            d.DestinationSoftwareCode = implementer.DestinationSoftwareCode;
            var e = inv.ExtApplicationArea.ExtSender = new ExtSender();
            e.CreatorNameCode = implementer.CreatorNameCode;
            e.SenderNameCode = implementer.SenderNameCode;
            e.DealerNumberID = implementer.DealerNumberID;
            e.ExtDealerCountryCode = implementer.ExtDealerCountryCode;
            e.TaskID = implementer.TaskID;
            e.ComponentID = implementer.ComponentID;
            e.ExtLanguageCode = implementer.ExtLanguageCode;

            inv.ExtGetVehicleInventoryDataArea = new ExtGetVehicleInventoryDataArea();
            var g = inv.ExtGetVehicleInventoryDataArea.ExtGet = new ExtGet();
            g.SearchCriteria = new SearchCriteria();

            //var f = g.FilterCriteria = new FilterCriteria();
            //f.EarliestEventCode = "3000";
            //10/20/30/40/50
            g.ExtMaxItems = criteria.MaxItems.ToString();
            g.Expression = " ";

        }
    }
}
