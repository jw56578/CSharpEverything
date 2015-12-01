using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToBuildANewSystemFromScratch.Types.Functions
{
    public static class ProcessThirdPartyInfo
    {
        static ProcessThirdPartyInfo()
        {
            BMWInventory = _BMWInventory;
        }
        public static Action BMWInventory { get; set; }

        static void _BMWInventory()
        { 
        
        }
    }
}
