﻿using Data.Entities;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Parse
{
    /// <summary>
    /// this is an example of a thing that would need to be auto generated by a t4 template
    /// okay so what happens here, does this thing need to be hard coded to use the specific data store code like ado.net
    /// or does this thing use another thing that will dynamically determine that
    /// 
    /// ** this thing has to be responsible for doing the back end specific thing
    /// so the Type specific repository would have to be generated per thing Parse, sql server
    /// </summary>
    public class PersonRepository : IRepository<Person>
    {
        IQueryBuilder<Person> qb = null;
        Data.Parse.Parse p = null;

        public PersonRepository()
        {
            qb = new QueryBuilder<Person>(new Entity<Person>() { Name = "Person" });
            p = new Data.Parse.Parse();
        }

        public void AddField(Field field)
        {
            qb.AddField(field);
        }

        public void AddRelation(Relation relation)
        {
            qb.AddRelation(relation);
        }

        public void Fill(List<Person> collection)
        {
            //what the heck is responsible for taking information from wherever (ADO.net) and putting it into the type
            //if we are using Parse, what references the parse object
            var peopleTask = p.Find("Person");
            peopleTask.Wait();
            foreach (var p in peopleTask.Result) {
                collection.Add(new Person() {
                    FirstName = p.Get<string>("firstName"),
                    LastName = p.Get<string>("lastName")
                });
            }
            ///sooo.... use some object from the Parse assembly
            /// it needs Field and Relation stuff i guess
            /// 
        }
        public Person Get(int id)
        {
            return new Person();
        }
        public void Save(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
