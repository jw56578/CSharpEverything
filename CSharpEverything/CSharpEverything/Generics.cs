using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace CSharpEverything
{
    [TestClass]
    public class Generics
    {
        [TestMethod]
        public void TestGenereics()
        {
            //this works because T is described as out.
            IEnumerable<IBaseThing<object>> test1 = new List<IBaseThing<string>>();

            //show that the static constructor is called once per closed type
            var test2 = new ImplementedThing<string>();
            var test3 = new ImplementedThing<int>();
        }
    }
    //https://msdn.microsoft.com/en-us/library/dd997386.aspx
    public interface IBaseThing<out T>
    {
        //you cannot use a covariance specified T as any argument in any method, only return values
        // void Add(out T item);
        T ICanOnlyReturnT();
    }
    public class ImplementedThing<T> : IBaseThing<T>
    {
        static ImplementedThing()
        {
            //this will be run for each closed type that is implmented of the open type, NOT once per open type
        }
        public T ICanOnlyReturnT()
        {
            throw new NotImplementedException();
        }
    }

    public class Base<T>
    {

    }
    public class Parent
    {

    }
    public class Child : Parent
    {


    }

}
