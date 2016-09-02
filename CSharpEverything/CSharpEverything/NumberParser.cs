using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpEverything
{
    [TestClass]
    public class NumberParser
    {
        //http://cc.davelozinski.com/c-sharp/fastest-way-to-convert-a-string-to-an-int
        [TestMethod]
        public void CanParseSimpleInteger()
        {
            var s = "39492";
            int total = 0;
            int y = 0;
            for (int i = 0; i < s.Length; i++)
            {
                //not sure what the point of this is
                var whatisthis = (s[i] - '0');
                ///multiply the previous number by 10 and then add the next digit
                y = y * 10 + whatisthis;
            }
              
            total += y;
        }
    }
}
