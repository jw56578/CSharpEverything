﻿using Data.Repository;
using Data.Repository.Parse;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataService<T>
    {
        void Fill(List<T> collection);
        void Save(T entity);
    }
    //every closed instance of this type will have its own static fields in order to store information that should be cached per app domain
    //this is where reflection type things should be saved so you don't have to reflect again
    public class DataService<T>:IDataService<T> where T : new()
    {
        static string EntityName = typeof(T).Name;
        //shit, this thing will have to be aware of a specific mapper implmentation
        //need to have a mapper factory
        //for now just let this thing be aware that we are using Parse
        static IRepository<T> f = RepositoryMapper.GetMap(typeof(T).FullName) as IRepository<T>;
       
        //need to have some instance field that maintain a reference to something from ORM to handle Relations and Predicate
        //no then what is the point of the repository

        public T Get(int id)
        {
            return f.Get(id);
        }
        public void Fill(List<T> collection)
        {
            f.Fill(collection);
        }
        public IEnumerable<T> Get()
        {
            var list = new List<T>();
            this.Fill(list);
            return list;
        }
        public void Save(T entity)
        {
            f.Save(entity);
        }
        public DataService<T> Where(Field where)
        {
            //what the hell happens here
            f.AddField(where);
            return this;
        }
        public DataService<T> Include(Relation where)
        {
            f.AddRelation(where);
            return this;
        }
    }

    public struct DataServiceArgs
    {
        public int? Id { get; set; }
    }
}
