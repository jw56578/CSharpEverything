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
    /// this appears to be too slow, it is N2.5 times slower than just filling the collection directly
    /// if I remove the static variable and just instantiate an new repository each time it is as fast
    /// why is accessing a static thing so slow?
    /// i put the static field back in and just assign it directly to the personfiller and its almost just as fast WTF
    /// holy crap, using a static constructor was making it so slow
    /// http://blogs.msdn.com/b/brada/archive/2004/04/17/115300.aspx
    /// </summary>
    [TestClass]
    public class SimpleGenericRepository
    {
        int repeats = 5000000;

        [TestMethod]
        public void TestSimpleGenericRepository()
        {
            while (true)
            {
                Concrete();
                Generic();
            }

        }

        void Concrete()
        {
            for (int i = 0; i < repeats; i++)
            {
                List<Person> coll = new List<Person>();
                PersonFiller f = new PersonFiller();
                f.Fill(coll);
            }
        }
        void Generic()
        {
            for (int i = 0; i < repeats; i++)
            {
                var personFiller = new DataService<Person>();
                List<Person> coll = new List<Person>();
                personFiller.Fill(coll);
            }
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
        static IRepository<T> f = RepositoryMapper.GetMap(typeof(T).FullName) as IRepository<T>;

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
