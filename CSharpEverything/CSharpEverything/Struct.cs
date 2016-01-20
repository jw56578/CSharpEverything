using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpEverything
{
    [TestClass]
    public class Struct
    {
        [TestMethod]
        public void TestStruct()
        {
            //the constuctor is never called
            TestStruct test;
            //the constructo is called
            test = new CSharpEverything.TestStruct(1);
        }
    }

    public struct TestStruct
    {
        int id;
        bool success;
        public TestStruct(int x)
        {
            id = 0;
            success = false;
        }
    }

}
