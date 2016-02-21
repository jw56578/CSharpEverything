using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    public  static partial class Functions
    {
        public static Func<T1,T2> Curry<T1, T2>(Func<T1, T2> function)
        {
            return a => function(a);
        }

        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(Func<T1, T2, T3> function)
        {
            return a => b => function(a, b);
        }

        public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(Func<T1, T2, T3, T4> function)
        {
            return a => b => c => function(a, b, c);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> function)
        {
            //lambda short hand kinda confusing
            //the compiler knows what type a, b,c and d should be because of the return type in the method signature
            //a = T1, b = T2, c = T3, d = T4, the return falue of function(a,b,c,d) = T5
            //return function a
            //calling a returns function b
            //calling b returns function c
            //calling c returns function d
            //calling d calls the original function
            return a => b => c => d => function(a, b, c, d);
        }
    }
}
