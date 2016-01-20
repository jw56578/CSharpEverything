using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Server
{
    class MessageHandler : TCP.ITCPClientHandler
    {
        public void OnClientConnected(TcpClient client)
        {
            throw new NotImplementedException();
        }

        public void OnClientRead(TcpClient client, string data)
        {
            throw new NotImplementedException();
        }
    }
}
