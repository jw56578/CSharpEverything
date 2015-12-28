using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// how do static constructors work with generics
    /// change the name of this if it ever works
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayDataService<T> where T : BaseEntity, new()
    {
        static IRepo<T> repo;
        static ArrayDataService()
        {
            var myType = typeof(T);
            var mytypeName = myType.Name;
            repo = RepoMappings.mappings[0] as IRepo<T>;
        }

        public void Get(IEntityCollection<BaseEntity> collection)
        {
            //does the typeof itself make is slow or is it accessing the dictionary
            repo.Get(collection);
            //i believe this cast is causing performance issues
            //nothing can be done about this as the repo itself returns IEnumerable of object, not the specific type
            //how can we get rid of any casting
            //why does this need to be cast as stuff is an IEnuberable of what T is contrained to
            //return stuff as  IEnumerable<T>;

            //covariance is not working for anything 

        }
    }
}
