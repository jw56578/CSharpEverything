using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionalExamples;
using static FunctionalExamples.Functions;

namespace FunctionalTests
{
    [TestClass]
    public class Compose
    {
        /// <summary>
        /// so how would you compose existing delegates like string split such that you only provide the thing to split on and 
        /// not what you actually want to split
        /// http://stackoverflow.com/questions/8719929/function-composition
        /// </summary>
        [TestMethod]
        public void ComposeExistingMethodsUsingObject()
        {

            Func<object, object> composed = Compose(SplitOnDash);
            //this is getting all messed because of strong typing
            string[] splitWords = composed("hello-there-how-are-you-i-hope-this-works") as string[];
            Assert.AreEqual(splitWords.Length, 9);
            Assert.AreEqual(splitWords[0], "hello");
        }
        [TestMethod]
        public void ComposeTwoMethods()
        {
            Func<object, object> ChangeEachArrayEntryToHello = (x) => {
                var objAsArray = x as string[];
                for (int i = 0; i < objAsArray.Length; i++) {
                    objAsArray[i] = "hello";
                }
                return objAsArray;
            };
            Func<object, object> composed = Compose(ChangeEachArrayEntryToHello,SplitOnDash);
            //this is getting all messed because of strong typing
            string[] splitWords = composed("hello-there-how-are-you-i-hope-this-works") as string[];
            Assert.AreEqual(splitWords.Length, 9);
            Assert.AreEqual(splitWords[0], "hello");
            Assert.AreEqual(splitWords[1], "hello");
            Assert.AreEqual(splitWords[2], "hello");
            Assert.AreEqual(splitWords[3], "hello");
            Assert.AreEqual(splitWords[4], "hello");
        }
        /// <summary>
        /// this won't work because it one method requires diffferent types for the input and output
        /// SplitOnDash takes a string input to split and outputs an array, well you can't have 2 different types
        /// </summary>
        //[TestMethod]
        //public void ComposeTwoMethodsGenerically()
        //{
        //    Func<string[], string[]> ChangeEachArrayEntryToHello = (x) => {
        //        var objAsArray = x ;
        //        for (int i = 0; i < objAsArray.Length; i++)
        //        {
        //            objAsArray[i] = "hello";
        //        }
        //        return objAsArray;
        //    };
        //    Func<char[], string, string[]> CustomSplit = (c, input) =>
        //    {
        //        return input.Split(c);
        //    };

        //    Func<char[], Func<string, string[]>> CurriedSplit = Curry(CustomSplit);
        //    Func<string, string[]> SplitOnDash = CurriedSplit("-".ToCharArray());

        //Func<object, object> composed = Compose<string[]>(ChangeEachArrayEntryToHello, SplitOnDash);
        //    //this is getting all messed because of strong typing
        //    string[] splitWords = composed("hello-there-how-are-you-i-hope-this-works") as string[];
        //    Assert.AreEqual(splitWords.Length, 9);
        //    Assert.AreEqual(splitWords[0], "hello");
        //    Assert.AreEqual(splitWords[1], "hello");
        //    Assert.AreEqual(splitWords[2], "hello");
        //    Assert.AreEqual(splitWords[3], "hello");
        //    Assert.AreEqual(splitWords[4], "hello");
        //}
        [TestMethod]
        public void CurryStringSplit()
        { 
            string[] splitWords = SplitOnDash("hello-there-how-are-you-i-hope-this-works");
            Assert.AreEqual(splitWords.Length, 9);
            Assert.AreEqual(splitWords[0], "hello");
        }
        [TestMethod]
        public void CurryTwoThings()
        {
            Func<int,int, int> addTwoThings = (a, b) => a + b ;
            var curriedaddTwoThings = Curry(addTwoThings);
            var addOne = curriedaddTwoThings(1);
            var result = addOne(4);
            Assert.AreEqual(result, 5);
        }

       


    }
}
