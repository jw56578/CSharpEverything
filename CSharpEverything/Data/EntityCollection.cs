using Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public interface IEntityCollection< in A>   where A :BaseEntity
    {
        void Add(A item);
    }

    public class EntityCollection<A> : IEntityCollection<A> where A : BaseEntity
    {
        public void Add(A item)
        {
            throw new NotImplementedException();
        }
    }
    public class PersonCollection : IEntityCollection<Person>
    {
        public void Add(Person item)
        {
            throw new NotImplementedException();
        }
    }

}
