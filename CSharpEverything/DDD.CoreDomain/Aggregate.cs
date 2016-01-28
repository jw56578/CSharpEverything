using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.CoreDomain
{
    /// <summary>
    /// Any domain has many entities but they usually have to work together
    /// Aggregates are an abstraction cohesive notion of a scenario in which certain entityes work together
    /// an aggregate should maintain transactional integrity, everything in it should save or nothing should save
    /// in DDD an entity can only belong to one Aggregate
    /// how do you decide what goes into an Aggregate - ask, does it make sense that an entity would exist without another entity?
    /// would a slot object exist without a snack machine object? - probably not, would a snack exists on its own? -yes, so it could be its own aggregate
    /// there is no perfect formula for defining aggregates so you just have to trial and error
    /// simplicity VS performance
    /// should have 1-3 entities per aggregate
    /// you can have as many value type objects in an aggregate as you want
    /// 
    /// multiple entities under a single absraction
    /// conceptual whole
    /// root entity
    /// single oepration unit for the applicaiton layer
    /// consistency boundaries
    /// 
    /// no consuming code should ever reference an entity that isn't an aggregate
    /// </summary>
    public abstract class Aggregate:Entity
    {
    }

    /// <summary>
    /// only one root entity should be visiable from the aggregate boundry
    /// all other entities should be hidden
   
    /// </summary>
    public class VendingMachine : Aggregate
    {
        //root entity
        public partial class BetterSnackMachine
        {

        }
        private partial class Snack
        {

        }
        /// the aggregate should be responsible for enforcing state validation
        public int MaximumSnackMachineWeight;

    }
}
