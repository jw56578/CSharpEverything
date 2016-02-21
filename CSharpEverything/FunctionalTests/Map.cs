using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static FunctionalExamples.Functions;
using System.Collections.Generic;

namespace FunctionalTests
{
    [TestClass]
    public class Map
    {
        [TestMethod]
        public void CanCurryMap()
        {
            //i want to send in a function Func<object,object> into map and it will just be hard coded to that function for all applied things
            //create a list of the objects ToStringed

            //since we are using this here, we know that we are dealing with strings
            var ToString = Map((o) =>
            {
                return o.ToString();
            });
            //when we get an Ienumerable of object we know because of ToString that the objects are really strings
            var result = ToString(new List<object>() { 1, 2, 3, 4, 5 }) as IEnumerable<object>;

            //so we can just cast the objects back to string if we care
            int i = 1;
            foreach (string thing in result)
            {
                Assert.AreEqual(thing, i.ToString());
                i++;
            }

        }
        [TestMethod]
        public void CanComposeMap()
        {
            //lets change whatever to a string
            var ToString = Map((o) =>
            {
                return o.ToString();
            });
            //then lets capitalize it
            var ToUpper = Map((o) =>
            {
                return o.ToString().ToUpper();
            });

            var SplitThenToStringThenUpper = Compose(ToUpper, ToString,SplitOnDash);

            var result = SplitThenToStringThenUpper("does-this-work");
        }
    }
}
