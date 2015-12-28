using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PersonCollection : EntityCollection<Person,Person>
    {

    }
    public class Person : BaseEntity
    {
        public override int TypeId
        {
            get; set; //the coder cannot be responsible for putting the value in there else they would have to know the last id made in the system
        }
        public override IRepo GetRepo()
        {
            return new PersonRepo(); //not sure if this is okay to have a POCO return its own repository
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
