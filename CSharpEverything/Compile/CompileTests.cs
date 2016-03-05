using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Text;
using System.IO;

namespace Compile
{
    [TestClass]
    public class CompileTests
    {

        [TestMethod]
        public void CanCompileAStringOfCode()
        {
            //need to look up the documentation on this
            int compilerVersion = 4;
            //why would you not want to optimize?
            bool optimize = false;
            //different IL has to be made in order to debug
            bool useDebug = false;

            //this is the build in c# compiler provided by microsoft
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string> { { "CompilerVersion", "v" + new Version(compilerVersion, 0) } });
           
            //all we need is a string containing valid C# code
            string code = GetCodeString();

            //different settings for compiling
            CompilerParameters options = new CompilerParameters();
            options.CompilerOptions = "/unsafe /o" + (optimize ? "+" : "-") + (useDebug ? " /debug" : "");
            if (compilerVersion >= 4)
                options.ReferencedAssemblies.Add("System.Core.dll");
            CompilerResults results = provider.CompileAssemblyFromSource(options, code);

            ProcessCompileErrors(results);

            //how is this generated?
            //probably have to specify it in the parameters somehow
            string pathToAssemblyl = results.PathToAssembly;

            var assemblyFileStream =  CreateFileStreamFromAssembly(results.PathToAssembly);



        }
        void ProcessStreamIntoImage(Stream stream)
        {
            string fileName = Path.GetFullPath((stream as FileStream).Name);

            if (stream.Length < 128)
                throw new BadImageFormatException();


        }

        void ReadModuleFromFileStream(Stream stream)
        {

        }
        FileStream CreateFileStreamFromAssembly(string pathToAssembly)
        {
            //we know the assembly exists so we just need to open it, not create or write
            FileMode fm = FileMode.Open;
            //we are only reading, no writing, the assembly is already made duh
            FileAccess fa = FileAccess.Read;
            //
            FileShare share = FileShare.Read;

            return new FileStream(pathToAssembly, fm, fa, share);
        }
        /// <summary>
        /// Get a string of C# code however you see fit. File, hard coded, from database  ... etc
        /// </summary>
        /// <returns></returns>
        string GetCodeString()
        {
            return CSharpCode.Loops;
        }
        void ProcessCompileErrors(CompilerResults results)
        {
            if (results.Errors.Count > 0)
            {
                StringBuilder b = new StringBuilder("Compiler error:");
                foreach (var error in results.Errors)
                {
                    b.AppendLine(error.ToString());
                }
                throw new Exception(b.ToString());
            }
        }
    }
}
