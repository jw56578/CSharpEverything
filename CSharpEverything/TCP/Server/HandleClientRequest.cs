using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public class HandleClientRequest
    {
        TcpClient _clientSocket;
        NetworkStream _networkStream = null;
        ITCPClientHandler handler;
        public HandleClientRequest(TcpClient clientConnected,ITCPClientHandler handler)
        {
            this.handler = handler;
            this._clientSocket = clientConnected;
        }
        public void StartClient()
        {
            _networkStream = _clientSocket.GetStream();
            WaitForRequest();
        }

        public void WaitForRequest()
        {
            byte[] buffer = new byte[_clientSocket.ReceiveBufferSize];

            _networkStream.BeginRead(buffer, 0, buffer.Length, ReadCallback, buffer);
        }

        private void ReadCallback(IAsyncResult result)
        {
            NetworkStream networkStream = _clientSocket.GetStream();
            try
            {
                int read = networkStream.EndRead(result);
                if (read == 0)
                {
                    _networkStream.Close();
                    _clientSocket.Close();
                    return;
                }

                byte[] buffer = result.AsyncState as byte[];
                string data = Encoding.Default.GetString(buffer, 0, read);
                handler.OnClientRead(_clientSocket, data);

            }
            catch (Exception ex)
            {
                throw;
            }

            this.WaitForRequest();
        }

    }
}
