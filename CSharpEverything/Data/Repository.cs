using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /*
trying to create a generic data retrieval type that get just get whatever of type T
this is not possible because you cannot specifiy a specific type to be returned in whatever class
gets the specific type

     * considerations
     * this is using typeof as the key to the dictionary of concrete repositories
     * this is casting the result of the concrete type t T
     * what are performance implications
     * using the generic approach is 2x as slow
        1st fix-----
        change the datastore for the repo  types from typeof(whatever) as the key to just an array of 0 - 1000
        a code generator like t4 could map types to numbers , Person = 1, Vehicle =2 etc
        duh this doesn't help anything as you can't map type T to whatever number
       improvment is incosistent sometimes generic is faster, sometimes concrete is faster

*/
/*
    building it this way seem silly as when you use generics the compiler makes the closed type but then you still are having to 
    use an array or some other logic to decie whic repositry to use
    so its as if there is a GetPerson method but then that method has to decide which thing to use which it should already know at compile
    time since it is specficially GetPerson.
    so it would be a decision to sacrifice performance in order to not have a concrete repository class for each type

*/
    public abstract class BaseEntity
    {
        public abstract Int32 TypeId{ get; set; }
        public abstract IRepo GetRepo();
    }
 
    /// <summary>
    /// what if this thing runs through all types in a certain namespace
    /// you have to assign a number to a certain type of repository and then somehow map that to the type being returned by the type itself
    /// give the type a TypeId?  which then just maps to the Repository ID?
    /// this would require code generation 
    /// </summary>
    public static class RepoMappings
    {
        public static IRepo[] mappings;
        static RepoMappings()
        {
            mappings = new IRepo[10];
            mappings[0] = new PersonRepo();
            /*
            find all baseclass entities
            assign the ids incrementally
            then get the repository from it itself
            then assign the same id

            */
        }
    }
    /// <summary>
    /// how do static constructors work with generics
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayDataService<T> where T : BaseEntity,new()
    {
        static IRepo repo;
        static ArrayDataService()
        {
            var myType = typeof(T);
            var mytypeName = myType.Name;
            repo = RepoMappings.mappings[0];
        }

        public void Get(IEntityCollection<BaseEntity,BaseEntity> collection)
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
    public class PersonSpecificDataService<T> where T : BaseEntity, new()
    {
        static IRepo repo;
        static PersonSpecificDataService()
        {

            repo = new PersonRepo();
        }
        public void Get(List<BaseEntity> collection)
        {
            collection.Add(new Person());

        }
    }
    public interface IRepo
    {
       void Get(IEntityCollection<BaseEntity,BaseEntity> collection);
    }
    public class PersonRepo :IRepo
    {
        //why can't this return value
        public void Get(IEntityCollection<BaseEntity,BaseEntity> collection)
        {
            var p = new Person();
           
           
        }
    }



}
/*
there is no way to make a generic repository because you would have to implement a generic type of some type of base class Object or Custom
but then the generic repository would have to cast the return value into the specific closed type desired
this casting is not acceptable

    there is some weird thing with generics as you can't just return a derived type collection of the generic T
    type even though its contstrained to a base t ype

*/

/*
LLbGen populates things by providing the ICollection To the method that is retrieving the data
you have to create a custom class? because you cannot to covariance on List<T>


    the compiler will not allow to convert any derived generic to any base generic
*/