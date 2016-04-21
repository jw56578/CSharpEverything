using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star.GM
{
    public static class GMVehicleSearch
    {
        public static ExtGetVehicleSpecifications GetSearch(SearchVehicleCriteria criteria)
        {
            if (string.IsNullOrEmpty(criteria.Year))
                return GetYearSearch(criteria);
            return null;
        }
        static ExtGetVehicleSpecifications GetYearSearch(SearchVehicleCriteria criteria)
        {
            var inv = Create(criteria);
            var year = inv.ExtGetVehicleSpecificationsDataArea.ExtGet.VehicleSelectorCriteria = new VehicleSelectorCriteria();
            year.MethodName = "GetAllYears";
            year.Year = new Year();
            year.Year.FromYear = "1980";
            year.Year.ToYear = "9999";
            return inv;
        }


        static ExtGetVehicleSpecifications Create(SearchVehicleCriteria criteria)
        {
            ExtGetVehicleSpecifications inv = new ExtGetVehicleSpecifications();
            inv.ExtApplicationArea = new ExtApplicationArea();
            inv.ExtApplicationArea.CreationDateAndTime = DateTime.UtcNow.ToString("o");

            CreateHardCoded(inv);
            return inv;
        }
        static void CreateHardCoded(ExtGetVehicleSpecifications inv)
        {
            var d = inv.ExtApplicationArea.Destination = new Destination();
            d.DestinationNameCode = "VLS";
            d.DestinationSoftwareCode = "VLS Vehicle Selector Service";
            var e = inv.ExtApplicationArea.ExtSender = new ExtSender();
            e.CreatorNameCode = "ELEAD";
            e.SenderNameCode = "EL";
            e.DealerNumberID = "113730"; // /is this eleads or what? 
            e.ExtDealerCountryCode = "US";
            e.TaskID = "Vehicle Selector";
            e.ComponentID = "Vehicle Selector Module";
            e.ExtLanguageCode = "en-US";
            inv.ExtGetVehicleSpecificationsDataArea = new ExtGetVehicleSpecificationsDataArea();
            var g = inv.ExtGetVehicleSpecificationsDataArea.ExtGet = new ExtGet();
            g.Expression = " ";

        }
    }
}
