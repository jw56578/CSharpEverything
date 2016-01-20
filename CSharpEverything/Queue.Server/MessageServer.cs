using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue.Server
{
    public class MessageServer
    {
        TCP.AsyncTCPServer tcpServer;
        public MessageServer(string host)
        {
            tcpServer = new TCP.AsyncTCPServer(new MessageHandler());


        }
        public void Start()
        {
            tcpServer.StartServer();
        }
    }
}
