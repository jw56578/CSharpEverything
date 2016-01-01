using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Models;

namespace View
{
    /// <summary>
    /// There is one service that is responsible for getting entities which are the things directly mapped to the domain models
    /// but then for UI purposes there might be view models, This class is responsible for getting those
    /// what should be the name of the individual types that are responsible for getting the specific view models WhateverModelService?
    /// this class must be generic in order to be able to determine which type of model getter it should use and cash that
    /// 
    /// these classes cannot be generated because they are very specific to the UI
    /// </summary>
    public class ModelService <T> where T : BaseModel,new()
    {
        static string EntityName = typeof(T).Name;
        //static IRepository<T> f = RepositoryMapper.GetMap(typeof(T).FullName) as IRepository<T>;

        public ModelService()
        {

        }
        public T Get(ModelServiceArgs args)
        {
           
            return new T();
        }
    }
    /// <summary>
    /// how could this value type possible have all the information needed to get every view model in the system
    /// it would soon just have many properties to account for every piece of information needed to get all view models?
    /// maybe it wouldn't be that many? or you just inherit from each other which means a struct can't be used
    /// </summary>
    public struct ModelServiceArgs
    {
        public int? Id { get; set; }

    }
}
