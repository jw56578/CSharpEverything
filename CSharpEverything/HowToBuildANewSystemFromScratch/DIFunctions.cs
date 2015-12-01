using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HowToBuildANewSystemFromScratch.Types.Functions;
using System.Diagnostics;

namespace HowToBuildANewSystemFromScratch
{
    [TestClass]
    public class DIFunctions
    {
        public DIFunctions()
        {
            ProcessThirdPartyInfo.BMWInventory += () => {

                Debug.WriteLine("why does this get hit");
            };
            ProcessThirdPartyInfo.BMWInventory += () => {
                Debug.WriteLine("why does this not get hit");
            };
        }
        [TestMethod]
        public void CanDoDIOnFunctions()
        {
            ProcessThirdPartyInfo.BMWInventory();
        }
    }
}
