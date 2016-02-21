using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    //also known as Container
    public class Identity
    {
        object val;
        public Identity(object val)
        {
            this.val = val;
        }

        public Identity Map(Func<object, object> f)
        {
            return new Identity(f(this.val));
        }
    }
    public static partial class Functions
    {
        public static Identity Identity(object val)
        {
            return new Identity(val);
        }
    }
}
