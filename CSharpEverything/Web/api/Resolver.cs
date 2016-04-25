using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.api
{
    public class Resolver
    {
        public object Resolve(string controller, string action, string id)
        {
            object result = null;
            if (String.Equals(controller, "gmvehicleselector", StringComparison.OrdinalIgnoreCase))
            {
                if (String.Equals(action, "year", StringComparison.OrdinalIgnoreCase))
                {
                    result = new GMVehicleSelector().GetYears();
                }
                if (String.Equals(action, "make", StringComparison.OrdinalIgnoreCase))
                {
                    result = new GMVehicleSelector().GetMakes(id);
                }
                if (String.Equals(action, "model", StringComparison.OrdinalIgnoreCase))
                {
                    result = new GMVehicleSelector().GetYears();
                }
            }
            return result;
        }
    }
}