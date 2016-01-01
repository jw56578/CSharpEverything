using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpEverything
{
    /// <summary>
    /// its interesting how you can manipulate operator overloads to create things the represent comparison expressions
    /// the trick is to know how to create a tree of the expresion
    /// </summary>
    [TestClass]
    public class OperatorOverload
    {
        [TestMethod]
        public void TestOperatorOverload()
        {
            var test1 = new Predicate();
            var test2 = new Predicate();

            var whatever = new Predicate(test1 == 1 | test2);
        }
    }


    public class Predicate
    {
        public Predicate(Predicate p)
        {
        }
        public Predicate()
        { }
        public static Predicate operator |(Predicate x, Predicate y)
        {
            return new Predicate();
        }
        public static Predicate operator ==(Predicate x, object y)
        {
            return new Predicate();
        }
        public static Predicate operator !=(Predicate x, object y)
        {
            return new Predicate();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
