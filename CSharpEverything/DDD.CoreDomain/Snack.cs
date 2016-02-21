using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{
    public class Snack : Aggregate
    {
        //these static fields are a technique to represent reference data, data in the DB that doesn't change often
        //and is only changed by an admin type person
        //it is not inserted by user
        //the id is the id of the database record
        //this is similiar to useing Enum where the number is what is in database

        //None is like the null object pattern, there is no Id of zero 
        public static readonly Snack None = new Snack(0, "None");
        public static readonly Snack Chocolate = new Snack(1, "Chocolate");
        public static readonly Snack Soda = new Snack(2, "Soda");
        public static readonly Snack Gum = new Snack(3, "Gum");

        public virtual string Name { get; }

        protected Snack()
        {
        }

        private Snack(long id, string name)
            : this()
        {
            Id = id;
            Name = name;
        }
    }
}
