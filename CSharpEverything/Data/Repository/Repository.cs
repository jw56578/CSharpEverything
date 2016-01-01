using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   
    public interface IRepository<T>
    {
        void Fill(List<T> collection);
        T Get(int id);
        void Save(T entity);
    }
    //what if you needed to add a method to the interface after it was already created
    //create new interface inheriting from base one and all new Types can use that one
    public interface IRepositoryWithDelete<T>:IRepository<T>
    {
        void Delete(T entity);
    }

}
