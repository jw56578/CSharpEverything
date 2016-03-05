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
            _assemblyDefinition = AssemblyDefinition.ReadAssembly("TypesToBeDecompiled.dll");

        }
        [TestMethod]
        public void CanExtractTypeFromAssembly()
        {
            CanReadAssembly();
            var typeName = "CanYouDecompileMe";
            _type = _assemblyDefinition.MainModule.Types
               .Single(t => t.Name == typeName);
        }
        [TestMethod]
        public void CanExtracMethodFromType()
        {
            CanExtractTypeFromAssembly();
            var methodName = "CanYouSerializeThisMethod";
            _method = _type.Methods
              .Single(m => m.Name == methodName);
        }
        [TestMethod]
        public void CanSerializeILInstructions()
        {
            CanExtracMethodFromType();
            List<OpCode> codes = new List<OpCode>();
            foreach (var il in _method.Body.Instructions)
            {
                object operand = null;
                var operandAsString = il.Operand as string;
                var operandAsInstruction = il.Operand as Mono.Cecil.Cil.Instruction;
                var operandAsMethodReference = il.Operand as Mono.Cecil.MethodReference;
                var operandAsParameterDef = il.Operand as Mono.Cecil.ParameterDefinition;


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

                else if (operandAsString != null)
                {
                    operand = operandAsString;
                }
                else if (il.Operand is int)
                {
                    operand = il.Operand;
                }
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
