﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    /// <summary>
    /// this libary is the basis for creating tcp clients, this can be used for any other tool that need to connect computers for a purpose
    /// a queue system, distributed systems, message bus
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<string> hashCodes = new List<string>();

            var server = new AsyncTCPServer(new TCPClientHandler());
            server.StartServer();
           
            Action<string> dataRecived1 = (data) => {
                Console.WriteLine("client 1" + data);
            };
            Action<string> dataRecived2 = (data) => {
                Console.WriteLine("client 2" + data);
            };
            Action<string> dataRecivedAsync = (data) => {
                //if (data == "Processed This is a test<EOF>")
                //{
                //    Console.WriteLine(data);
                //    return;
                //}
                //if (hashCodes.Contains(data))
                //{
                //    //throw new Exception("TCP client duplication");
                //}
                //hashCodes.Add(data);
                Console.WriteLine(data);
            };
            //var t = Task.Run(() => {
            //    TCPClient client = null;
            //    //the clients are not async so i have to know that i must run each one in a seperate thread else the first one will block the rest of them
            //    using (client = new TCPClient(dataRecived1))
            //    {
            //        client.ConnectToServer();
            //        client.SendData("hello");
            //        client.ReceiveData();

            //    }
            //});
            //var t2 = Task.Run(() => {
            //    TCPClient client2 = new TCPClient(dataRecived2);
            //    //can you have 2 tcp clients on the same computer?
            //    //since recieve data is blocking, you won't be able to send anything else after a call to RecieveData, you would have to stop it somehow
            //    client2.ConnectToServer();
            //    client2.SendData("hello2");
            //    client2.ReceiveData();
            //});
            List<AsynchronousClient> clients = new List<AsynchronousClient>();

            for (int i = 0; i < 10; i++)
            {
                var asyncClient = new AsynchronousClient(dataRecivedAsync);
                clients.Add(asyncClient);
                asyncClient.StartClient();
                asyncClient.Send("Client" + i.ToString());
            }
            string input;
            while ((input = Console.ReadLine()) != null) {
                foreach (var c in clients)
                {
                    c.Send(input);
                }
            }
           
        }
    }
}
