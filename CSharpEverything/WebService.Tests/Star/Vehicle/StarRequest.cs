using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star
{
    public partial class StarRequest
    {
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
