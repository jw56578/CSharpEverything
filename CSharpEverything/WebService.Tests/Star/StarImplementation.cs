using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService.Tests.Star
{
    public interface IStarImplementation
    {
        string GetHeaderXML();
        string GetUrl();
        string GetContentXml();
        void SetCriteria(Criteria criteria);
        IEnumerable<object> HandleSearchInventoryResponse(string responseXml);
    }
    public interface IStarVehicleSearchImplementation: IStarImplementation
    {
        IEnumerable<object> HandleSearchVehicleResponse(string responseXml);
    }

    public class StarImplementation
    {

    }
}
