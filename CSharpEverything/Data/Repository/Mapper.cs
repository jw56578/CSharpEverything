using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    //how would this work with DI? we might need to use different versions of a repository (parse vs MS SQL server)
    public static class RepositoryMapper
    {
        static readonly string nameSpace = "Data.Entities";
        static Dictionary<string, object> Maps = new Dictionary<string, object>() {
            { nameSpace + ".Person", new PersonRepository() }
        };

        public static object GetMap(string key)
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

    }
}
