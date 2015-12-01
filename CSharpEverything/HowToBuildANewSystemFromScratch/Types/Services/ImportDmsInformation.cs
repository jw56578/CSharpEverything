using HowToBuildANewSystemFromScratch.Types.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToBuildANewSystemFromScratch.Types.Services
{
    /// <summary>
    /// how would DI work if this thing needed to be different per use of it
    /// this won't work because this thing requires input and commands can't take input
    /// you cannot dependency inject a variable thing which might be an xml node or string
    /// </summary>
    public class ImportDmsInformation:IImportDmsInformation
    {
        public ImportDmsInformation()
        { 
        
        }
        public virtual void Execute()
        {
            
        }
    }
    public class BMWInventoryImport:ImportDmsInformation
    {
        public BMWInventoryImport(string xml)
        { 
        
        }
        public override void Execute()
        {
            base.Execute();
        }
    }
}
