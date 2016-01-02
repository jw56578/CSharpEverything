using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using Data;
using ORM;
using Data.Entities;

namespace Test
{
    [TestClass]
    public class ORM
    {
        [TestMethod]
        public void TestMethod1()
        {
            /*
            what should be responsible for defining the structure of the where criteria
            what should be responsible for defining the relations include, what part of the object graphs should be there
            what should be responsible for getting things in the first place
            
            */
            List<Person> people = new List<Person>();

            new DataService<Person>()
                .Include(Person.Relations.Addresses & Person.Relations.Emails)
                .Where(Person.Fields.Id == 1 | Person.Fields.FirstName == "jon")
                .Fill(people); //<Person>;
            Assert.IsTrue(people.Count > 0);
           // ds.Where = PersonFields.Id == 1 | PersonFields.FirstName == "jon";
        }
    }


}
