using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebService.Tests.Star;
using WebService.Tests.Star.GM;

namespace WebService.Tests
{
    public static partial class Functions
    {
        public static string BAC = "999970";
        public static IStarImplementation CurrentImplementer;
        public static StarRequest CurrentStarRequest;

        static Functions()
        {
            CurrentImplementer= new GMStarImplementation(BAC);
            CurrentStarRequest = new StarRequest(CurrentImplementer);
        }
    }
}
