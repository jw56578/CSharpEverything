using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public class TCPClient:IDisposable
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
        Action<string> OnDataRecieved;

        public TCPClient(Action<string> onDataRecieved)
        {
            OnDataRecieved = onDataRecieved;
        }
        public void ConnectToServer()
        {
            clientSocket.Connect(Config.IPAddress, 8888);
        }
        public void SendData(string dataTosend)
        {
            if (string.IsNullOrEmpty(dataTosend))
                return;
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(dataTosend);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }
        /// <summary>
        /// this needs to be changed to Async else the consumer needs to be responsible for running seperate clients on seperate threads
        /// 
        /// </summary>
        public void ReceiveData()
        {
            StringBuilder message = new StringBuilder();
            NetworkStream serverStream = clientSocket.GetStream();
            serverStream.ReadTimeout = 100;
            //the loop should continue until no dataavailable to read and message string is filled.
            //if data is not available and message is empty then the loop should continue, until
            //data is available and message is filled.
            while (true)
            {
                if (serverStream.DataAvailable)
                {
                    int read = serverStream.ReadByte();
                    if (read > 0)
                        message.Append((char)read);
                    else
                        break;
                }
                else if (message.ToString().Length > 0)
                {
                    OnDataRecieved(message.ToString());
                    message.Clear();
                }
            }
            
        }

        public void Dispose()
        {
           
        }
        public void CloseConnection()
        {
            clientSocket.Close();
        }
    }
}
