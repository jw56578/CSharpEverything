using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.Cecil;
using System.Linq;
using Compile.Types;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Compile
{
    [TestClass]
    public class MonoCecilTests
    {
        private AssemblyDefinition _assemblyDefinition;
        TypeDefinition _type;
        MethodDefinition _method;

        public MonoCecilTests()
        {
            var types = new Compile.TypesToBeDecompiled.CanYouDecompileMe();
        }
        [TestMethod]
        public void CanReadAssembly()
        {
            //read in the dll so the mono cecil thing can do whatever it does to decompile  it and extract the information
            _assemblyDefinition = AssemblyDefinition.ReadAssembly("TypesToBeDecompiled.dll");

        }
        [TestMethod]
        public void CanExtractTypeFromAssembly()
        {
            CanReadAssembly();
            var typeName = "CanYouDecompileMe";
            //remember there is a thing called a module that is a sub struture under an assembly where types and such exist
            //so get a specific type that we want
            _type = _assemblyDefinition.MainModule.Types
               .Single(t => t.Name == typeName);
        }
        [TestMethod]
        public void CanExtracMethodFromType()
        {
            CanExtractTypeFromAssembly();
            // get a specific method we want on the type that we got
            var methodName = "CanYouSerializeThisMethod";
            _method = _type.Methods
              .Single(m => m.Name == methodName);
        }
        [TestMethod]
        public void CanSerializeILInstructions()
        {
            CanExtracMethodFromType();
            List<OpCode> codes = new List<OpCode>();
            //mono cecil does all the work of getting out the IL codes from the raw binary data 
            //reading bit by bit 
            foreach (var il in _method.Body.Instructions)
            {
                object operand = null;
                var operandAsString = il.Operand as string;
                var operandAsInstruction = il.Operand as Mono.Cecil.Cil.Instruction;
                var operandAsMethodReference = il.Operand as Mono.Cecil.MethodReference;
                var operandAsParameterDef = il.Operand as Mono.Cecil.ParameterDefinition;

                // stand alone commmand that doesn't need a paramters
                if (il.Operand == null)
                {
                    operand = null;
                }
                else if (operandAsInstruction != null)
                {
                    operand = new OpCode()
                    {
                        Name = operandAsInstruction.OpCode.Name,
                        Operand = operandAsInstruction.Operand
                    };
                }
                //load a string
                else if (operandAsString != null)
                {
                    operand = operandAsString;
                }
                //load a constant number
                else if (il.Operand is int)
                {
                    operand = il.Operand;
                }
                //something like a call virtual, for a  method on a type
                else if (operandAsMethodReference != null)
                {
                    operand = new Compile.Types.MethodReference() {FullName = operandAsMethodReference.FullName };
                }
                else if (operandAsParameterDef != null)
                {
                    //operand = new Compile.Types.ParameterDefinition() { FullName = operandAsParameterDef.Method.;
                }
                else
                {
                    int xxx = 3;

                }

                var newCode = new OpCode() {
                    Name = il.OpCode.Name,
                    Operand = operand
                };
                codes.Add(newCode);
            }
            //dammit i hate serialization. this isn't working but just do whatever is needed to serialize this information 
            SerializeObject(codes.GetType(), codes);
        }
        public static void SerializeObject(Type t,object obj)
        {
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(t);
            ser.WriteObject(stream1, obj);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            var json = (sr.ReadToEnd());
        }

    }
}
