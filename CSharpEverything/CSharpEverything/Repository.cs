using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEverything
{
    [TestClass]
    class Repository
    {
        //why the hell doesn't this work, this is the whole point of contravariance
        // IBaseContraVarianceThing<object> baseVariableWithDerivedValue = new ImplementedContraVarianceThing<string>();

        //why the freaking hell does this work but the above doesn't work
        IEnumerable<object> baseVariableWithDerivedValue = new List<string>();

        //why the hell does this not work
        // ICollection<object> test2 = new List<string>();


        [TestMethod]
        public void TestRepository()
        {
            var repo = new ThingThatHandlesDynamicGenericRepository();
            //you can't send a derived type into a method that wants a base type
            //repo.CanITakeADerivedTypeFromBaseArgument(baseVariableWithDerivedValue);

            //covariance is when you put a derived type into the base type which is what we want except
            //that you then cannot have any methods using the Generic type as a parameter
            //var child = new DerivedThing();
            //IBaseInterfaceThing<IEnumerable<object>> parent = child;

            //repo.CanITakeADerivedTypeFromBaseArgument<string>(child);
            //repo.CanITakeADerivedTypeFromBaseArgument<string>(parent);



            /*
                a thing needs to take a generic base collection to be filled OR must return a strongly typed collection
                the generic type is what is used to determine what will be used to fill collection
                
            
            */
        }

    }
    /// <summary>
    /// this thing has to be generic on the class so that the compiler will create a new closed type for each so 
    /// such that there will be a unique static constructor per closed type in order to initialize stuff
    /// </summary>
    //public class ThingToDecideWhatFillsCollection<T> where T : Type1
    //{
    //    //this is what is screwing everything up, you can't cast things to this
    //    IBaseInterfaceThing<IEnumerable<T>> repo;
    //    //you can't return enumerable of type T when you are returning enumerable of object
    //    public ThingToDecideWhatFillsCollection()
    //    {
            
    //        repo = new DerivedThing(); // this is the issue that cannot be fixed, 
    //    }
    //    public IEnumerable<T> Fill( )
    //    {
    //        return repo.ICanOnlyReturnThings();
    //    }
    
    //}
    //public interface IBaseInterfaceThing<out T> where T : Type1
    //{
    //    T ICanOnlyReturnThings();
    //}
    //public class DerivedThing : IBaseInterfaceThing<IEnumerable<Type2>>
    //{
    //    IEnumerable<Type2> IBaseInterfaceThing<IEnumerable<Type2>>.ICanOnlyReturnThings()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class Type1
    { }
    public class Type2 : Type1
    { }
    public class Type3 : Type1
    {
    }
    public class ThingThatHandlesDynamicGenericRepository
    {
        public void CanITakeADerivedTypeFromBaseArgument(IBaseContraVarianceThing<object> thing)
        {
            thing.ICanOnlyTakeTArguments("sldkfj");
        }
        //public void CanITakeADerivedTypeFromBaseArgument<T>(IBaseInterfaceThing<object> thing)
        //{
        //    thing.ICanOnlyReturnThings();
        //}
    }
}

/*
What the hell is LLbGen doing.
Creates a EntityCollection

*/