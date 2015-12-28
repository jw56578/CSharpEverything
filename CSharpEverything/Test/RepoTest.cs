using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class RepoTest
    {
        int tries = 1000000;
        [TestMethod]
        public void TestGenericRepoVsConcreteRepo()
        {
            while (true)
            {
                ExecuteConcreteRepo();
                ExecuteArrayGenericRepo();
               // ExecutePersonSpecificRepo();
            }

       



        }
        void ExecuteConcreteRepo()
        {
            var p = new PersonRepo();
            var people = new List<Person>();
            for (int i = 0; i < tries; i++)
            {
                //p.Get(people);
                foreach (var thing in people) 
                {

                }

            }
        }
        //void ExecutePersonSpecificRepo()
        //{
        //    var p = new PersonSpecificDataService<Person>();
        //    IEnumerable<BaseEntity> people;
        //    var peoples = new List<Person>();
        //    people = peoples;
        //    var personCollection = new PersonCollection();
        //    for (int i = 0; i < tries; i++)
        //    {
        //        p.Get(personCollection);
        //        foreach (var thing in people)
        //        {

        //        }

        //    }
        //}
        void ExecuteArrayGenericRepo()
        {
            var p = new ArrayDataService<Person>();
            IEntityCollection<BaseEntity, BaseEntity> personCollection = null;// = new EntityCollection<Person,Person>();
            for (int i = 0; i < tries; i++)
            {
                p.Get(personCollection);
                foreach (var thing in personCollection)
                {

                }
            }
        }
    }
}
