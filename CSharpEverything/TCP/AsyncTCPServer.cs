using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    class AsyncTCPServer
    {
        private static TcpListener _listener;
        static TCPClientHandler clientHandler = new TCPClientHandler();
        public static void StartServer()
        {
            System.Net.IPAddress localIPAddress = System.Net.IPAddress.Parse(Config.IPAddress);
            IPEndPoint ipLocal = new IPEndPoint(localIPAddress, 8888);
            _listener = new TcpListener(ipLocal);
            _listener.Start();
            WaitForClientConnect();
        }
        private static void WaitForClientConnect()
        {
            object obj = new object();
            _listener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnect), obj);
        }
        private static void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpClient clientSocket = default(TcpClient);
                clientSocket = _listener.EndAcceptTcpClient(asyn);
                clientHandler.Process(clientSocket);
                HandleClientRequest clientReq = new HandleClientRequest(clientSocket);
                clientReq.StartClient();
            }
            catch (Exception se)
            {
                throw;
            }

            WaitForClientConnect();
        }
    }
}
