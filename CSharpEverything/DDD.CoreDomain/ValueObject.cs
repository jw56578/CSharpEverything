using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{
    /// <summary>
    /// this is not the same as the .Net value type struct
    /// structs cannot do everything that DDD value types need to do like inheritence
    /// so its a DDD value type represented by a class
    /// using inheritence with abstract class insures that the child class implement some function
    /// that is needed to be implemented for the value type
    /// </summary>
    public abstract class ValueObject<T>
        where T :ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObject = obj as T;
            if (ReferenceEquals(valueObject, null))
                return false;
            return EqualsCore(valueObject);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ///value types can't have a generic equality method like the entity types
        //because the equality is very specific, not just Ids
        //you have to know exactly what in the child type makes things equal
        //so you can insure that it does this with abstract methods

        protected abstract bool EqualsCore(T other);
        protected abstract int GetHashCodeCore();


    }
}
