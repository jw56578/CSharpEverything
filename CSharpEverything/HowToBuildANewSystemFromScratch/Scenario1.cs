using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;

namespace HowToBuildANewSystemFromScratch
{
    [TestClass]
    public class Scenario1
    {
        //this is the thing that is responsible for newing up everything so it must just exist globablly available
        public static IUnityContainer container = new UnityContainer();
        static Scenario1()
        {
            //this is the most appropriate place to register the types

             container.RegisterType<IDefinitionOfWhatAThingCanDo, ThingThatDoesSpecificThing>();

        }

        [TestMethod]
        public void Run()
        {
            //this will never change, this starting point will always want to do this thing
            ThingsThatCanBeDone.DoTheSpecificThing(new Arguments() { Value1="test"});
        }
    }

    public static class ThingsThatCanBeDone
    {
        public static void DoTheSpecificThing(Arguments args)
        {
            //once we are at this point, there is no possiblity for DI of anything that this class uses
            //so we need to use a concrete class that will never need to be tested or changed
            //this thing will have to be responsible for using the IOC directly
            var thingThatwillDoWhatIWant = Scenario1.container.Resolve<IDefinitionOfWhatAThingCanDo>();
            thingThatwillDoWhatIWant.DoSomethingSpecific();

        }
    }
    /// <summary>
    /// structs should be used as method arguments 
    /// </summary>
    public struct Arguments
    {
        public string Value1 { get; set; }
    }
    public interface IDefinitionOfWhatAThingCanDo
    {
        void DoSomethingSpecific();
    }
    public class ThingThatDoesSpecificThing:IDefinitionOfWhatAThingCanDo
    {
        public void DoSomethingSpecific()
        {

        }

    }
}
