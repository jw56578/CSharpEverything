using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataService<T>
    {
        void File(List<T> collection);
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
}
