using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public interface ITCPClientHandler
    {
        void OnClientConnected(System.Net.Sockets.TcpClient client);
        void OnClientRead(System.Net.Sockets.TcpClient client,string data);
    }
}
