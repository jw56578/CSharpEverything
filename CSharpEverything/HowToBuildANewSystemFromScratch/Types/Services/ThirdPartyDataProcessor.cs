using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToBuildANewSystemFromScratch.Types.Services
{
    /// <summary>
    /// the concept is that you are processing information received from a third party
    /// "processing" could be anything
    /// 1) take xml and change it to csv and save to disk
    /// 2) take xml and parse and save to a database table
    /// 3) take json and send it somewhere else
    /// how do you abstract this
    /// who is responsbile for deciding which processing gets done based on something
    /// 
    /// </summary>

    public interface IThirdPartyDataProcessor
    { 
    
    }
    /// <summary>
    /// the only point of having a type use instance methods is so that the this keyword is available which allows it to access instance fields
    /// it also is used in order to have the constructor define what this type needs in order to operate
    /// but why can't these things just be in the method if they don't need to be persisted over multiple method calls
    /// instance methods would also be used to make chained calls? can you chain a static type? NO, unless you made a singleton
    /// 
    /// so there would just be this static type with a method for every type of import that could be done, why not?
    /// does this need to be an interface so that you can DI these methods for testing? Why not? its a thing that does stuff not IS A
    /// </summary>
    public static class ThirdPartyDataProcessor
    {

        public static void ProcessBMWInventory()
        {
            
        }
    }

  
}
