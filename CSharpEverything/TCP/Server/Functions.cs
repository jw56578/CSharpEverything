using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP
{
    public static  class Functions
    {
        public static void WriteToClient(System.Net.Sockets.TcpClient client, string data)
        {
            NetworkStream networkStream = client.GetStream();
            Byte[] sendBytes = Encoding.ASCII.GetBytes(data);
            networkStream.Write(sendBytes, 0, sendBytes.Length);
            networkStream.Flush();
        }
    }
}
