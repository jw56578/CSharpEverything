using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Compile.Types
{
    [DataContract]
    public class OpCode
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public object Operand { get; set; }
       
    }
    [DataContract]
    public class MethodReference
    {
        [DataMember]
        public string FullName { get; set; }

    }

    [DataContract]
    public class ParameterDefinition
    {
        [DataMember]
        public string FullName { get; set; }

    }
}
