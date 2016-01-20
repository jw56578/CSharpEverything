using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using HowToBuildANewSystemFromScratch.Types.Interfaces;
using HowToBuildANewSystemFromScratch.Types.Services;
using HowToBuildANewSystemFromScratch.Types.Commands;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IImportDmsInformation, BMWInventoryImport>(
                //new InjectionConstructor("connectionstring goes here")
                );
            container.RegisterType<ICommand, ImportDmsInformation>(
                //new InjectionConstructor("connectionstring goes here")
                );
            HowToBuildANewSystemFromScratch.Types.Static.CurrentUnityContainer = container;



            Web.WebService1 ws = new Web.WebService1();
            ws.HelloWorld();
        }

        [TestMethod]
        public void TestStruct()
        {
        }
    }

    public struct TestStruct
    {
        public TestStruct(int x)
        {

        }
    }
}