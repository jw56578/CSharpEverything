using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TCP;
using System.Threading.Tasks;
using System.Threading;

namespace Test
{
    [TestClass]
    public class TCP
    {
        [TestMethod]
        public void TestTCP()
        {
            AsyncTCPServer.StartServer();

            Action<string> dataRecivedAsync = (data) => {
                Console.WriteLine("client Async" + data);
            };
   
            for (int i = 0; i < 10; i++)
            {
                var asyncClient = new AsynchronousClient(dataRecivedAsync);
                asyncClient.StartClient();
            }
            Func< int> action = () =>
            {
                Thread.Sleep(60000);
                return 9;
            };
            Task<int> t = Task<int>.Factory.StartNew(action);
            t.Wait();
        }
    }
}
