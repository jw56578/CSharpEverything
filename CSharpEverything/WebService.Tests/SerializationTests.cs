using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static WebService.Tests.Functions;

namespace WebService.Tests
{
    [TestClass]
    public class SerializationTests
    {
        [TestMethod]
        public void CanSerializeWithNamespace()
        {
            var result = Serialize<ExtGetVehicleInventory>(CreateMinimalMessage());

            Assert.IsFalse(string.IsNullOrEmpty(result));
            Assert.IsTrue(result.Contains("vls:"),"vls namespace was not added");
            Assert.IsTrue(result.Contains("star:"), "star namespace was not added");
        }
    }
}
