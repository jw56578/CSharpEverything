using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static partial class RepositoryMapper
    {
        public static Func<string, object> GetMap = GetMapFunction;


        /// <summary>
        /// the consumer has to know that it should cast the returned object to something of the repository nature
        /// this thing cannot return a Repository type because it is generic and this thing can't be generic
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetMapFunction(string key)
        {
            object repo = null;
            if (Maps.TryGetValue(key, out repo))
            {
                return repo;
            }
            else
            {
                return new DefaultRepository(key);
            }

        }
        public static object GetTestMapFunction(string key)
        {
            object repo = null;
            if (TestMaps.TryGetValue(key, out repo))
            {
                return repo;
            }
            else
            {
                return new DefaultRepository(key);
            }

        }
    }
}