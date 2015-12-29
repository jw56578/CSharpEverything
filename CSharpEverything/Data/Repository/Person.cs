using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class PersonRepository : IRepository<Person>
    {
        public void Fill(List<Person> collection)
        {
            collection.Add(new Person() { FirstName="Mike",LastName="Smith"});
            collection.Add(new Person() { FirstName = "Mike", LastName = "Smith" });
            collection.Add(new Person() { FirstName = "Mike", LastName = "Smith" });
            collection.Add(new Person() { FirstName = "Mike", LastName = "Smith" });
            collection.Add(new Person() { FirstName = "Mike", LastName = "Smith" });
            collection.Add(new Person() { FirstName = "Mike", LastName = "Smith" });
        }
    }
}
