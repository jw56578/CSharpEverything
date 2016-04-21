using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static WebService.Tests.Functions;
using WebService.Tests.ProxyClasses;

namespace WebService.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void CanSerializeWithNamespace()
        {

        }

        [TestMethod]
        public void CanSerializeHeader()
        {

        }

        [TestMethod]
        public void CanDeserializeResponse()
        {
            var searchresult = Deserialize<Envelope>(SampleXML.InventorySearchResponse);
        }

    }
}
