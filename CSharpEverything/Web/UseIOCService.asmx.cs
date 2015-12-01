using HowToBuildANewSystemFromScratch.Types.Commands;
using HowToBuildANewSystemFromScratch.Types.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Web
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class WebService1 : System.Web.Services.WebService
    {
        public WebService1()
        {
            InjectDependencies();
        }
        /*
         how is dependency injection appropriate here
         * I don't need something that does something in general, i Need somthing that does somethign very specific
         * take a bunch of mappings 
         * take an xml node
         * convert all that junk into a string of CSV
         * write that to file
         * how could this be abstracted
         * you would have to have a class that defines the overall concept of doing this
         * what is the best way to organize the code that is responsible for doing all those things
         *In this case this seems to be a business specific process, not technology specific
         *so it might need a type called ThirdPartyImporter
         *how does doing this help anything
         */
        [Dependency]
        public IImportDmsInformation Importer
        {
            get;
            set;
        }
        [Dependency]
        public ICommand Command
        {
            get;
            set;
        }
        //this is pointless as it means the service has to be aware that BMWImporter is the resolved type so it might as well just expliclity instaniate this itself instead of going through the IOC
        protected virtual void InjectDependencies()
        {
            IUnityContainer container = HowToBuildANewSystemFromScratch.Types.Static.CurrentUnityContainer;
            if (container == null)
                throw new InvalidOperationException("Container on Global Application Class is Null. Cannot perform BuildUp.");
           this.Importer = container.Resolve<IImportDmsInformation>(new ParameterOverride("xml","") );
           this.Command = container.Resolve<ICommand>();// new ParameterOverride();
           //container.BuildUp(this);
        }

        [WebMethod]
        public string HelloWorld()
        {
            Importer.Execute();
            return "Hello World";
        }
    }
}
