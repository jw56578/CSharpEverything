using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CSharpEverything
{
    [TestClass]
    public class GenericDelegates
    {
        [TestMethod]
        public void TestGenericDelegates()
        {
            Action<Type1> action1 = (t) => {
               
            };
            Action<Type2> action2 = (t) =>
            {

            };
            Action<Type3> action3 = (t) =>
            {

            };
            action1 = (Action<Type1>)action2;
            action1(new Type1());
            action2 = action1;
            action1(new Type1());
            action1(new Type2());
            action3 = action1;
            action1(new Type1());
           
           
        }
    }
}
