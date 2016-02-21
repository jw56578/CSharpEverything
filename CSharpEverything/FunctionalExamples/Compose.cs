using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    public static partial class Functions
    {
        /// <summary>
        /// how can this be done in C# without limiting to object type only, Generics?
        /// maybe you can only compose 2 things at a time and then have to compose compositions
        /// </summary>
        /// <param name="a"></param>
        public static Func<object, object> Compose( params Func<object,object>[] a)
        {
            return (input) => {
                var l = a.Length -1;
                object result = a[l](input);
                l--;
                while (l >= 0)
                {
                    result = a[l](result);
                    l--;
                }

                return result;
            }; 
        }
        /// <summary>
        /// generic doesn't help that much because you are still restricted to the input and output being the same, wait i guess that 
        /// is just how it would always work even in dynamic languages
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Func<T, T> Compose<T>(params Func<T, T>[] a)
        {
            return (input) => {
                var l = a.Length - 1;
                T result = a[l](input);
                l--;
                while (l >= 0)
                {
                    result = a[l](result);
                    l--;
                }
                return result;
            };
        }
    }
}

