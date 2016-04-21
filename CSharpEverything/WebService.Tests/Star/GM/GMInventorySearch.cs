using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star.GM
{
    public static class GMInventorySearch
    {
        public static ExtGetVehicleInventory GetSearch(SearchInventoryCriteria criteria)
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
        static ExtGetVehicleInventory GetStateSearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var region = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByRegion = new SearchByRegion();
            region.RegionCode = new List<string>();
            region.RegionCode.Add(criteria.State.Value.RegionCode);
            return inv;
        }
        static ExtGetVehicleInventory GetCompanySearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var vendor = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchBySingleVendor = new SearchBySingleVendor();
            vendor.VendorId = criteria.Company.Value.Id;
            return inv;
        }
        static ExtGetVehicleInventory GetZicodeSearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var pc = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByPostalCode = new SearchByPostalCode();
            pc.Proximity = criteria.Zipcode.Value.Proximity.ToString();
            pc.PostalCode = criteria.Zipcode.Value.PostalCode;
            return inv;
        }
        static ExtGetVehicleInventory GetCitySearch(SearchInventoryCriteria criteria)
        {
            var inv = Create(criteria);
            var sbc = inv.ExtGetVehicleInventoryDataArea.ExtGet.SearchCriteria.SearchByCity = new SearchByCity();
            sbc.RegionCode = criteria.City.Value.RegionCode;
            sbc.Proximity = criteria.City.Value.Proximity.ToString();
            sbc.City = criteria.City.Value.Name;
            return inv;
        }
        static ExtGetVehicleInventory Create(SearchInventoryCriteria criteria)
        {
            ExtGetVehicleInventory inv = new ExtGetVehicleInventory();
            inv.ExtApplicationArea = new ExtApplicationArea();
            inv.ExtApplicationArea.CreationDateAndTime = DateTime.UtcNow.ToString("o");

            CreateHardCoded(inv);
            CreateVehicleSpec(inv);
            CreateOutputSpec(inv);
            return inv;
        }
        static void CreateVehicleSpec(ExtGetVehicleInventory inv)
        {
            var vs = inv.ExtGetVehicleInventoryDataArea.ExtGet.VehicleSpecification = new VehicleSpecification();
            vs.MakeCode = "001";
            vs.MerchandisingModelDesignator = "12P43";
            vs.SellingSourceCode = "13";
            vs.Year = "2015";

        }
        static void CreateOutputSpec(ExtGetVehicleInventory inv)
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
        static void CreateHardCoded(ExtGetVehicleInventory inv)
        {
            var d = inv.ExtApplicationArea.Destination = new Destination();
            d.DestinationNameCode = "VLS";
            d.DestinationSoftwareCode = "VLS Locate Service";
            var e = inv.ExtApplicationArea.ExtSender = new ExtSender();
            e.CreatorNameCode = "ELEAD";
            e.SenderNameCode = "EL";
            e.DealerNumberID = "113730"; // /is this eleads or what? 
            e.ExtDealerCountryCode = "US";
            e.TaskID = "Locate Vehicle";
            e.ComponentID = "Locate Module";
            e.ExtLanguageCode = "en-US";


            inv.ExtGetVehicleInventoryDataArea = new ExtGetVehicleInventoryDataArea();
            var g = inv.ExtGetVehicleInventoryDataArea.ExtGet = new ExtGet();
            g.SearchCriteria = new SearchCriteria();



            var f = g.FilterCriteria = new FilterCriteria();
            f.EarliestEventCode = "3000";
            //10/20/30/40/50
            g.ExtMaxItems = "20";
            g.Expression = " ";



        }
    }
}
