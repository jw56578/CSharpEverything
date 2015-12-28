using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    
    public class Person : BaseEntity
    {
        //public override int TypeId
        //{
        //    get; set; //the coder cannot be responsible for putting the value in there else they would have to know the last id made in the system
        //}
       

        //public override IRepo repo()
        //{
        //    //this should only happen once so the cast is okay i guess?
        //    return new PersonRepo();
        //}

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    //public class PersonSpecificDataService<T> where T : BaseEntity, new()
    //{
    //    static IRepo repo;
    //    static PersonSpecificDataService()
    //    {

    //        repo = new PersonRepo();
    //    }
    //    public void Get(List<BaseEntity> collection)
    //    {
    //        collection.Add(new Person());

    //    }
    //}
}
