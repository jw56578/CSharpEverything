using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;


namespace CSharpEverything
{
    [TestClass]
    public class SystemProcess
    {
        [TestMethod]
        public void CanRun()
        {

            Process[] localAll = Process.GetProcesses();
            var path = localAll[0].MainModule.FileName;
            Process p = Process.Start(path);

            while (!p.HasExited)
            {

            }

            Console.WriteLine(p.ExitCode);
            Console.ReadKey(true);

        
        }
    }
}
