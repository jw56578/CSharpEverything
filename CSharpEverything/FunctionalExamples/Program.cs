using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FunctionalExamples.Functions;

namespace FunctionalExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int, int> addFourThings = (a, b, c, d) => a + b + c + d;

            //Func<T1, Func<T2, Func<T3, Func<T4, T5>>>>
            var curriedAddFourThings = Curry(addFourThings);
            //Func<T2, Func<T3, Func<T4, T5>>>
            var temp = curriedAddFourThings(1);
            // Func<T3, Func<T4, T5>>
            var temp2 = temp(2);
            // Func<T4, T5>
            Func<int,int> temp3 = temp2(3);

            int result = temp3(4);

            result = curriedAddFourThings(1)(2)(3)(4);  // result = 10

            var addOne = curriedAddFourThings(1);
        
            var addOneAndTwo = addOne(2);
            var addOneAndTwoAndThree = addOneAndTwo(3);

            int result2 = addOneAndTwoAndThree(4); // result2 = 10
        }

    }
}
