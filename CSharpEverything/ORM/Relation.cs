using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Relation
    {
        public Relation(Relation p)
        {
        }
        public Relation()
        { }
        public static Relation operator |(Relation x, Relation y)
        {
            return new Relation();
        }
        public static Relation operator &(Relation x, Relation y)
        {
            return new Relation();
        }
        public static Relation operator ==(Relation x, object y)
        {
            return new Relation();
        }
        public static Relation operator !=(Relation x, object y)
        {
            return new Relation();
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
