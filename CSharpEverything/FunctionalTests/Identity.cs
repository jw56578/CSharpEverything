using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FunctionalExamples.Functions;

namespace FunctionalTests
{
    [TestClass]
    public class Identity
    {
        [TestMethod]
        public void CanMap()
        {
            var i= Identity("hello").Map((o) => o.ToString().ToUpper());
        }
    }
}
