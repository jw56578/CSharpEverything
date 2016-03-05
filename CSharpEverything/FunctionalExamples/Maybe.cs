using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalExamples
{
    public class Maybe:Identity
    {

        public Maybe(object val):base(val)
        {
        }

        public override Identity Map(Func<object, object> f)
        {
            return this.val != null? new Maybe(f(this.val)) : new Maybe(null);
        }
    }
    public static partial class Functions
    {
        public static Maybe Maybe(object val)
        {
            return new Maybe(val);
        }
    }
}
