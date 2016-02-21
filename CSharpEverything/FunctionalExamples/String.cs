using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    public static partial class Functions
    {
        //Split is a method group, if you define the variable type then you can assign it, else since there are many method overloads
        //it wouldn't know which one you are referring to
        //Func<char[], String[]> proxySplit = "".Split;

        //this won't work as the Split method is an instance method so there has to be a this and you can't do call, apply bind in C#
        //it has to already know what instance of string you are referring to
        //so we need to create our own split
        //the order of the parameters matters, when you curry something it will start with the first argument
        //so whatever you want to curry, the thing you are going to hard code into the function, needs to be first




        //typed version
        //this does not work with composition because the thing that goes into the function has to be an object and it can't be derived from object
        //because generics don't work that way
        //static Func<char[], string, string[]> CustomSplit = (c, input) => {
        //    return input.Split(c);
        //};

        ////now what?
        ////okay the compiler can infer from the signature of the func which curry function to use
        //static Func<char[], Func<string, string[]>> CurriedSplit = Curry(CustomSplit);

        ////curry to hard code the thing to split on, a dash in this case
        //public static Func<string, string[]> SplitOnDash = CurriedSplit("-".ToCharArray());


        //Untyped version
        static Func<char[], object, string[]> CustomSplit = (c, input) => {
            return input.ToString().Split(c);
        };
        static Func<char[], Func<object, string[]>> CurriedSplit = Curry(CustomSplit);

        public static Func<object, string[]> SplitOnDash = CurriedSplit("-".ToCharArray());


    }
}
