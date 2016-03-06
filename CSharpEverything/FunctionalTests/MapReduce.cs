using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortableFCSLib;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalTests
{
    public class Group<TKey, TValue> : Tuple<TKey, List<TValue>>
    {
        public Group(TKey key) : base(key, new List<TValue>())
        {
        }

        public TKey Key
        {
            get
            {
                return base.Item1;
            }
        }

        public List<TValue> Values
        {
            get
            {
                return base.Item2;
            }
        }
    }
    [TestClass]
    public class MapReduceTests
    {
        public static void Main()
        {
            // Do it manually

            // Step 1: Map      
            var pairs = Functional.Collect(
              text => Functional.Map(
                word => Tuple.Create(word, 1),
                text.Split(new[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)),
              new[] { hamlet });

            // Step 1a, intermediate: Group
            var groups = Group<string,Tuple<string,int>>(pair => pair.Item1, pairs);


            // Step 2: Reduce each group
            var results = Functional.Map(
              g => Tuple.Create(g.Key,
                Functional.FoldL((r, v) => r + v.Item2, 0, g.Values)),
              groups);

            foreach (var t in results.OrderBy(t => t.Item1))
                Console.WriteLine("{0}: {1}", t.Item1, t.Item2);
            Console.WriteLine("{0} results", results.Count());

            // Use an abstract function
            var newResults =
              MapReduce(
                text => Functional.Map(
                  word => Tuple.Create(word, 1),
                  text.Split(new[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)),
                (r, v) => r + v.Item2, 0,
                new[] { hamlet });
            Console.WriteLine("---------------------------------------------");

            foreach (var t in newResults.OrderBy(t => t.Item1))
                Console.WriteLine("{0}: {1}", t.Item1, t.Item2);
            Console.WriteLine("{0} results", newResults.Count());

        }

        static IEnumerable<Tuple<TKey, TReduceResult>> MapReduce<TKey, TValue, TReduceInput, TReduceResult>(
          PortableFCSLib.Converter<TValue, IEnumerable<Tuple<TKey, TReduceInput>>> mapStep,
          Func<TReduceResult, Tuple<TKey, TReduceInput>, TReduceResult> reduceStep,
          TReduceResult reduceStartVal,
          IEnumerable<TValue> list)
        {
            var pairs = Functional.Collect<TValue, Tuple<TKey, TReduceInput>>(mapStep, list);
            var groups = Group(pair => pair.Item1, pairs);
            return Functional.Map(
              g => Tuple.Create(g.Key,
                Functional.FoldL(reduceStep, reduceStartVal, g.Values)), groups);
        }

        static IEnumerable<Group<TKey, TValue>> Group<TKey, TValue>(
         PortableFCSLib.Converter<TValue, TKey> extractor, IEnumerable<TValue> list)
        {
            // This implementation of Group is based on a Group data type
            // that has a mutable list of Values.

            var dict = new Dictionary<TKey, Group<TKey, TValue>>();
            foreach (TValue val in list)
            {
                var key = extractor(val);
                if (!dict.ContainsKey(key))
                    dict[key] = new Group<TKey, TValue>(key);
                dict[key].Values.Add(val);
            }
            return dict.Values;
        }

        const string hamlet = @"Though yet of Hamlet our dear brother's death
The memory be green, and that it us befitted
To bear our hearts in grief and our whole kingdom
To be contracted in one brow of woe,
Yet so far hath discretion fought with nature
That we with wisest sorrow think on him,
Together with remembrance of ourselves.
Therefore our sometime sister, now our queen,
The imperial jointress to this warlike state,
Have we, as 'twere with a defeated joy,--
With an auspicious and a dropping eye,
With mirth in funeral and with dirge in marriage,
In equal scale weighing delight and dole,--
Taken to wife: nor have we herein barr'd
Your better wisdoms, which have freely gone
With this affair along. For all, our thanks.
Now follows, that you know, young Fortinbras,
Holding a weak supposal of our worth,
Or thinking by our late dear brother's death
Our state to be disjoint and out of frame,
Colleagued with the dream of his advantage,
He hath not fail'd to pester us with message,
Importing the surrender of those lands
Lost by his father, with all bonds of law,
To our most valiant brother. So much for him.
Now for ourself and for this time of meeting:
Thus much the business is: we have here writ
To Norway, uncle of young Fortinbras,--
Who, impotent and bed-rid, scarcely hears
Of this his nephew's purpose,--to suppress
His further gait herein; in that the levies,
The lists and full proportions, are all made
Out of his subject: and we here dispatch
You, good Cornelius, and you, Voltimand,
For bearers of this greeting to old Norway;
Giving to you no further personal power
To business with the king, more than the scope
Of these delated articles allow.
Farewell, and let your haste commend your duty.";

    

        [TestMethod]
        public void CanMapReduce2()
        {
            Main();
        }
        [TestMethod]
        public void CanMapReduce()
        {
         
            //built in delegate that just takes something in and returns it, not sure why this is necessary over func, action
            //the only reason to use delegates is to explicitly describe what the delegate is suppose to do
            //take in a string and just create a tuple with the value of 1
            //each word just has a value of 1 because we are counting so you just add 1 each time you see the word
            PortableFCSLib.Converter<string, Tuple<string,int>> createTuple = (word) => {
                return Tuple.Create(word, 1);
            };
            //this is the normal map function, take a collection of things, in this case a list of strings
            //call a function on each item and save the return value in a collection
            //return the collection 
            PortableFCSLib.Converter<string, IEnumerable<Tuple<string, int>>> getTuples = (text) => {
                return Functional.Map(createTuple,
                        text.Split(new[] { " ", Environment.NewLine },
                        StringSplitOptions.RemoveEmptyEntries));
            };
            //Collect assumes that it gets a collection of collections and just flattens them out by returning one colleciton of all subcollections
            var pairs = Functional.Collect(
                getTuples,
                new[] { hamlet });


            //now we have a collection of unique words as they key and the value is a collection of 1's representing each instance the word appears
            var groups = Group(pair => pair.Item1, pairs);

            //we don't want a collection of 1's we want tha count of the 1's which is just adding them all up
            //map through the groups, use the foldL function which is the same as reduce, so it will just loop and add everything up
            var results = Functional.Map(
             g => Tuple.Create(g.Key,
               Functional.FoldL((r, v) => r + v.Item2, 0, g.Values)),
             groups);



        }

    }
}
