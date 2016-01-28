using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{
    /// <summary>
    /// there just has to be a base entity class to be used as the starting point for all domain entities
    /// this is just what you do if you are using DDD approach
    /// the whole thing about an entity is that it has a unique id
    /// so by definition there needs to be an Id property
    /// so you might as well have a abstract class that enforces this
    /// </summary>
    public abstract class Entity
    {
        //every entity needs a unique id, why would there not be one? duh
        //and if you are going to have an id why would it not be a long
        //this would account for a normal use of how many objects would be in a system
        public long Id { get;  set; }

        /// <summary>
        /// not sure yet why its important to override this for DDD use
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            //something that has an id of zero is not valid, therefore it can't equal anything
            if (Id == 0 || other.Id == 0)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);

        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
