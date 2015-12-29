using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public static class RepositoryMapper
    {
        static Dictionary<string, object> Maps = new Dictionary<string, object>();
        static RepositoryMapper()
        {
            Maps.Add("Data.Person", new PersonRepository());
        }
        public static object GetMap(string key)
        {
            return Maps[key];
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
}
