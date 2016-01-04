using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP
{
    public class TCPClientHandler
    {
        static List<System.Net.Sockets.TcpClient> connectedClients = new List<System.Net.Sockets.TcpClient>();
        static int counter = 0;
        public void Process(System.Net.Sockets.TcpClient client)
        {
            connectedClients.Add(client);

            //testing, see if you can write to client after a few seconds
            StartAsyncTimedWork( client);

        }
        private async Task delayedWork(System.Net.Sockets.TcpClient client)
        {
            await Task.Delay(2000);
            HandleClientRequest.WriteToClient(client, client.GetHashCode().ToString());
          
        }

        //This could be a button click event handler or the like */
        private void StartAsyncTimedWork(System.Net.Sockets.TcpClient client)
        {
            Task ignoredAwaitableResult = this.delayedWork(client);
        }
    }
}
