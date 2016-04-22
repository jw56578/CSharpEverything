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
        public IEnumerable<object> GetMakes(string year)
        {
            implementer.SetCriteria(new Criteria()
            {
                SearchVehicleCriteria = new SearchVehicleCriteria()
                {
                    Year = year
                }
            });
            return Search();
        }
        public IEnumerable<object> GetModels(string year,string make)
        {
            implementer.SetCriteria(new Criteria()
            {
                SearchVehicleCriteria = new SearchVehicleCriteria()
                {
                    Year = year,
                    Make= make
                }
            });
            return Search();
        }
        public IEnumerable<object> GetOptions(string year, string make,string model)
        {
            implementer.SetCriteria(new Criteria()
            {
                SearchVehicleCriteria = new SearchVehicleCriteria()
                {
                    Year = year,
                    Make = make,
                    ModelCode = model
                }
            });
            return Search();
        }
    }
}
