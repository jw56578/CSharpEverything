using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;

namespace Test
{
    [TestClass]
    public class GenericRepository
    {
        [TestMethod]
        public void Works()
        {
            /*
            1) there needs to be a method that will take a base class in order for things to be generic
            2) that method then needs to send that thing to a specific implmentation that will be a derived type into it
               -- a Collection of BaseEntities sent to the Person repository which adds PersonEntities
            */
            //you can only use contravarience on intefaces so this can never be cast to a class type on the left sid
            IEntityCollection<BaseEntity> p = new PersonCollection() as IEntityCollection<BaseEntity>;
            //arraydataservice needs a generic parameter so that it can dynamically know which repo to use based on type name
            var ds = new ArrayDataService<Person>();
            ds.Get(p);

        }

     
    }
}
