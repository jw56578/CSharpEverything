using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.api
{
    public class GMVehicleSelector
    {
        public string[] GetYears()
        {
            return new string[] {
                "2000",
                "2001",
                "2002",
                "2003",
                "2004",
            };

        }
        public string[] GetMakes(string year)
        {
            if(year == "2002")
                return new string[] {
                    "VW",
                    "Chevy",
                    "Cadillac",
                    "Ferrari",
                    "Scion",
                };
            if (year == "2001")
                return new string[] {
                    "Toyota",
                    "Hyundai",
                    "Kia",
                    "Mazda",
                    "Buick",
                };
            return new string[] {
                    "GM",
                    "Honda",
                    "BMW",
                    "Ford",
                    "Buick",
                };
        }
    }
}