using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HowToBuildANewSystemFromScratch
{
    [TestClass]
    public class MockWebServiceTests
    {
        /// <summary>
        /// This represents a method that would be called by a web service method call
        /// Thinking about the responsiblities of this thing
        /// 1) authenticate
        /// 2) use another type to do the work of the system
        /// Can you use IOC on web service class so that you can decide what object it uses to do this work?
        /// </summary>
        [TestMethod]
        public void ConvertXmlToCSVAndSaveToFile()
        {
           
        }
       
    }
}
