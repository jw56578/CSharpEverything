using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public class AsyncTCPServer
    {
        private  TcpListener _listener;

        ITCPClientHandler _clientHandler;
        public AsyncTCPServer(ITCPClientHandler handler)
        {
            _clientHandler = handler;
        }
        public  void StartServer()
        {
            System.Net.IPAddress localIPAddress = System.Net.IPAddress.Parse(Config.IPAddress);
            IPEndPoint ipLocal = new IPEndPoint(localIPAddress, Config.Port);
            _listener = new TcpListener(ipLocal);
            _listener.Start();
            WaitForClientConnect();
        }
        private  void WaitForClientConnect()
        {
            object obj = new object();
            _listener.BeginAcceptTcpClient(new System.AsyncCallback(OnClientConnect), obj);
        }
        private  void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                TcpClient clientSocket = _listener.EndAcceptTcpClient(asyn);
                _clientHandler.OnClientConnected(clientSocket);
                HandleClientRequest clientReq = new HandleClientRequest(clientSocket,_clientHandler);
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
