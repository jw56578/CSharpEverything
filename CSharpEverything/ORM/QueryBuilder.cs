using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// I guess this thing will somehow take a collection of relations and field clauses to make whatever query is needed?
    /// each query builder would be back end specific? Parse sql server, etc
    /// how is this thing aware of the entity its dealing with
    /// how the hell is this thing suppose to return an actual entity - Generics?
    /// </summary>
    public interface IQueryBuilder<T>
    {

    }
    /// <summary>
    /// this is the thing that is back end specific
    /// there would need to be one of these per data store , sql server, mongo db, whatever
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryBuilder<T> :IQueryBuilder<T>
    {
        public QueryBuilder(Entity<T> entity)
        {

        }
        public void AddRelation(Relation relation)
        {

        }
        public void AddField(Field field)
        {

        }
        public T Get()
        {
            throw new Exception("no implmemented");
        }


    }
    /// <summary>
    /// something needs to describe the thing we are trying to get in a neutral manner?
    /// </summary>
    public class Entity<T>
    {
        public string Name;
        public T Object;

    }
}
