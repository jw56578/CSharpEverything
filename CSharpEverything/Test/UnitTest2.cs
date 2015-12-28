using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Data;

namespace Test
{
    [TestClass]
    public class GenericsTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //https://msdn.microsoft.com/en-us/library/dd469487.aspx
            //nope - cannot use out on classes only interfaces
            //Base<Parent> test1 = new Base<Child>();

            //why the hell does this work
           // IEnumerable<Parent> test = new List<Child>();

            //IBaseThing<Parent> test1 = new ImplementedThing<Child>();

            ///IEntityCollection<Person,Person> test3  = new 
            //IEntityCollection<BaseEntity, BaseEntity> personCollection = null;// = new EntityCollection<Person,Person>();
            //IBaseThing<object> test4 = new ImplementedThing<string>();
        }
    }


}
