using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TCP
{
    public class TCPClientHandler:ITCPClientHandler
    {
        static List<System.Net.Sockets.TcpClient> connectedClients = new List<System.Net.Sockets.TcpClient>();

        public void OnClientConnected(TcpClient client)
        {
            connectedClients.Add(client);
            //testing, see if you can write to client after a few seconds
            StartAsyncTimedWork(client);
        }

        public void OnClientRead(TcpClient client,string data)
        {

            //do the job with the data here
            //send the data back to client.
            Functions.WriteToClient(client, "Processed " + data);
        }

        private async Task delayedWork(System.Net.Sockets.TcpClient client)
        {
            await Task.Delay(2000);
            Functions.WriteToClient(client, client.GetHashCode().ToString());
          
        }

        //This could be a button click event handler or the like */
        private void StartAsyncTimedWork(System.Net.Sockets.TcpClient client)
        {
            Task ignoredAwaitableResult = this.delayedWork(client);
        }
    }
}
