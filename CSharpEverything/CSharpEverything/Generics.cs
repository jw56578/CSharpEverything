using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace CSharpEverything
{
    [TestClass]
    public class Generics
    {
        [TestMethod]
        public void TestGenereics()
        {
            //this works because T is described as out for coVariance. you can put a
            //more derived type into a less derived variable string is child of object
            IEnumerable<IBaseThing<object>> test1 = new List<ImplementedThing<string>>();
            IBaseThing < object > testCoVarianceConcrete = new ImplementedThing<string>();
            testCoVarianceConcrete.ICanOnlyReturnT();

            //show that the static constructor is called once per closed type
            var test2 = new ImplementedThing<string>();
            var test3 = new ImplementedThing<int>();

            //this will not work because its a contravariance thing
            // IEnumerable<IBaseContraVarianceThing<object>> test4 = new List<ImplementedContraVarianceThing<string>>();

            //this is what contravariance allows, but what good is this?
            //this is what we want in order to send a collection into a method to be populated generically
            IEnumerable<IBaseContraVarianceThing<string>> test4 = new List<ImplementedContraVarianceThing<object>>();
            IBaseContraVarianceThing<string> test5 = new ImplementedContraVarianceThing<object>();
            test5.ICanOnlyTakeTArguments("sldkfj");
            List<ImplementedContraVarianceThing<string>> canYouCoVariantAList = new List<ImplementedContraVarianceThing<string>>();



            //how does this work
            //1) the variable type has to be of the derived type in order to use it when its populated
            IBaseContraVarianceThing<string> baseVariableWithDerivedValue = new ImplementedContraVarianceThing<string>();
            //2) so the method has to take the base type in order to be generic, but it won't allow the cast, so this will not work
            //won't compile
            //3) the fact that this won't compile basically means that what i'm trying to do is impossible 
            //CanITakeADerivedTypeFromBaseArgument(baseVariableWithDerivedValue);
            //CanITakeADerivedTypeFromBaseArgument<string>(canYouCoVariantAList);





            //what is the point of contra variance if this doesn't work:
            //IBaseContraVarianceThing<string> test4 = new List<ImplementedContraVarianceThing<string>>();

            //this stuff has nothing to do with method signature, you can't send a derived type into a method taking a base type


        }
        void CanITakeADerivedTypeFromBaseArgument(IBaseContraVarianceThing<object> thing)
        {
            thing.ICanOnlyTakeTArguments("sldkfj");
        }
    }
    
    //https://msdn.microsoft.com/en-us/library/dd997386.aspx
    public interface IBaseThing<out T>
    {
        //you cannot use a covariance specified T as any argument in any method, only return values
        // void Add(out T item);
        T ICanOnlyReturnT();
    }
    public class ImplementedThing<T> : IBaseThing<T>
    {
        //http://stackoverflow.com/questions/2936580/c-sharp-generic-static-constructor
        static ImplementedThing()
        {
            //this will be run for each closed type that is implmented of the open type, NOT once per open type
        }
        public T ICanOnlyReturnT()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// i don't get what the point of this is yet
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseContraVarianceThing<in T>
    {
        //you cannot use a contravariant thing as the return type so this will not compile
        //T ICannotReturnT();
        void ICanOnlyTakeTArguments(T item);
    }
    public class ImplementedContraVarianceThing<T> : IBaseContraVarianceThing<T>
    {
        public void ICanOnlyTakeTArguments(T item)
        {
            throw new NotImplementedException();
        }
    }

    public class Base<T>
    {

    }
    public class Parent
    {

    }
    public class Child : Parent
    {


    }

}
