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
            StartAsyncTimedWork();

        }
        private async Task delayedWork()
        {
            await Task.Delay(3000);
            HandleClientRequest.WriteToClient(connectedClients[counter], "did this work 3 seconds later?");
            counter++;
        }

        //This could be a button click event handler or the like */
        private void StartAsyncTimedWork()
        {
            Task ignoredAwaitableResult = this.delayedWork();
        }
    }
}
