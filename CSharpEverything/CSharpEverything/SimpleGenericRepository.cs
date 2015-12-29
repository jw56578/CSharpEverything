using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace CSharpEverything
{
    /// <summary>
    /// this is the simplist version of what i'm trying to accomplish with a dynamic generic repository thing
    /// using the trick of static constructors to cache the mapping of repositories to types
    /// you can't have an interace definition and then implmment with a derived type as the method parameter
    /// </summary>
    [TestClass]
    public class SimpleGenericRepository
    {
        [TestMethod]
        public void TestSimpleGenericRepository()
        {
            var personFiller = new DataService<Person>();
            List<Person> coll = new List<Person>();
            PersonFiller f = new PersonFiller();
            f.Fill(coll);
            personFiller.Fill(coll);
        }
    }
    public static class RepositoryMapper
    {
        static Dictionary<string, object> Maps = new Dictionary<string, object>();
        static RepositoryMapper()
        {
            Maps.Add("CSharpEverything.Person", new PersonFiller());
        }
        public static object GetMap(string key)
        {
            return Maps[key];
        }

    }
    public class DataService<T> 
    {
        static IRepository<T> f;
        static DataService()
        {
            f = RepositoryMapper.GetMap(typeof(T).FullName) as IRepository<T>;
        }
        public void Fill(List<T> collection)
        {
            if (f == null)
                throw new Exception("there is no Repository for this type");
            f.Fill(collection); 
        }
        public List<T> Get()
        {
            var list = new List<T>();
            this.Fill(list);
            return list;

        }
    }
    public interface IRepository<T>
    {
        void Fill(List<T> collection);
    }
    public class Filler : IRepository<object>
    {
        public void Fill(List<object> colleciton)
        {
           
        }
    }
    public class PersonFiller : IRepository<Person>
    {
        public void Fill(List<Person> collection)
        {
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
            collection.Add(new Person());
        }
    }
    public class EntityBase
    {

    }
    public class Person : EntityBase
    {

    }
}
