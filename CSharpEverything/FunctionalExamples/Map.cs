using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    public static partial class Functions
    {

        static Func<Func<object, object>, object, object> _Map = (c, input) => {
            var list = input as IEnumerable<object>;
            if(list == null)
                return c(input);
            List<object> mapped = new List<object>();
            foreach (var thing in list)
            {
                mapped.Add(c(thing));
            }
            return mapped;
        };
        public static Func<Func<object, object>, Func<object, object>> Map = Curry(_Map);

    }

}