using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Field : Predicate
    {
        public Field(Field p)
        {
        }
        public Field()
        { }
        public static Field operator |(Field x, Field y)
        {
            return new Field();
        }
        public static Field operator ==(Field x, object y)
        {
            return new Field();
        }
        public static Field operator !=(Field x, object y)
        {
            return new Field();
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
