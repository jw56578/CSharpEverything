using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;

namespace Data.Repository.Parse
{
    public class ParseRepository<T> : IRepository<T>
    {
        public void AddField(Field field)
        {
            throw new NotImplementedException();
        }

        public void AddRelation(Relation relation)
        {
            throw new NotImplementedException();
        }

        public void Fill(List<T> collection)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
