﻿using Data.Repository;
using Data.Repository.Parse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

    //how would this work with DI? we might need to use different versions of a repository (parse vs MS SQL server)
    /// <summary>
    /// this thing would have to be dynamically generated by t4 template per back end implementation 
    /// if using Parse then generatre a Parse specific mapper that maps Parse repositories to the entity type
    /// 
    /// </summary>
    public static partial class RepositoryMapper
    {
        static readonly string nameSpace = "Data.Entities";
        static Dictionary<string, object> Maps = new Dictionary<string, object>() {
            { nameSpace + ".Person", new PersonRepository() }
        };

        static Dictionary<string, object> TestMaps = new Dictionary<string, object>() {
            { nameSpace + ".Person", new Data.Repository.Test.PersonRepository() }
        };

    }
}
