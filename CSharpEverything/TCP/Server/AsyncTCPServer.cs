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
        string host;
        int port;
        ITCPClientHandler _clientHandler;
        public AsyncTCPServer(ITCPClientHandler handler)
        {
            host = Config.IPAddress;
            port = Config.Port;
            _clientHandler = handler;
        }
        public AsyncTCPServer(ITCPClientHandler handler,string host,int port)
        {
            this.host = host;
            this.port = port;
            _clientHandler = handler;
        }
        public  void StartServer()
        {
            System.Net.IPAddress localIPAddress = System.Net.IPAddress.Parse(host);
            IPEndPoint ipLocal = new IPEndPoint(localIPAddress, port);
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
