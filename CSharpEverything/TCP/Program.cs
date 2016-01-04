using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncTCPServer.StartServer();
           
            Action<string> dataRecived1 = (data) => {
                Console.WriteLine("client 1" + data);
            };
            Action<string> dataRecived2 = (data) => {
                Console.WriteLine("client 2" + data);
            };
            var t = Task.Run(() => {
                TCPClient client = null;
                //the clients are not async so i have to know that i must run each one in a seperate thread else the first one will block the rest of them
                using (client = new TCPClient(dataRecived1))
                {
                    client.ConnectToServer();
                    client.SendData("hello");
                    client.ReceiveData();

                }
            });
            TCPClient client2 = new TCPClient(dataRecived2);
            //can you have 2 tcp clients on the same computer?
            
            client2.ConnectToServer();
            client2.SendData("hello2");
            client2.ReceiveData();
            
            
            Console.ReadLine();
        }
    }
}
