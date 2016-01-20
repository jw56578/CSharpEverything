using Data.Entities;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Test
{
    public class PersonRepository : IRepository<Person>
    {

        public PersonRepository()
        {

        }

        public void AddField(Field field)
        {
        }

        public void AddRelation(Relation relation)
        {
        }

        public void Fill(List<Person> collection)
        {
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
        }

        public Person Get(int id)
        {
            return new Person();
        }
        public void Save(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
