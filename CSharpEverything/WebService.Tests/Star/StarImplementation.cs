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
        IEnumerable<object> HandleResponse(string responseXml);

        string DestinationNameCode { get;  }
        string DestinationSoftwareCode { get;  }
        string CreatorNameCode { get;  }
        string SenderNameCode { get;  }
        string DealerNumberID { get;  }
        string ExtDealerCountryCode { get;  }
        string TaskID { get;  }
        string ComponentID { get;  }
        string ExtLanguageCode { get;  }

    }
    public interface IStarVehicleSearchImplementation: IStarImplementation
    {
        IEnumerable<object> HandleSearchVehicleResponse(string responseXml);
    }

    public class StarImplementation
    {

    }
}
