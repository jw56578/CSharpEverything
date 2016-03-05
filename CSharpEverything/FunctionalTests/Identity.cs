using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FunctionalExamples.Functions;

namespace FunctionalTests
{
    [TestClass]
    public class Identity
    {
        [TestMethod]
        public void CanMapIdentity()
        {
            var i= Identity("hello").Map((o) => o.ToString().ToUpper());
        }
        [TestMethod]
        public void CanMapFunction()
        {
            var curryToUpper = Map((o) => o.ToString().ToUpper());
            var result = curryToUpper(Identity("firehose"));
        }
        [TestMethod]
        public void NullThrowsException()
        {
            var composed = Compose(
                (o) => { return o.ToString(); },
                (o) => { return null; }
                );
            composed(1);
        }
        [TestMethod]
        public void MaybeProtectsAgainstNull()
        {
            var mapped = Map((o) => { return o.ToString(); });
            var composed = Compose(
                mapped,
                Maybe,
                (o) => { return o; }
                );
            var result = composed(1);
        }
    }
}
