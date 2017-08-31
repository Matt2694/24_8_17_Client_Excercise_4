using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _24_8_17_Client_Excercise_4
{
    class EchoServerFacade
    {
        private NetworkStream netStream;
        private TcpClient client;
        private int port;
        private StreamReader reader;
        private StreamWriter writer;
        private string serverName;
        private Socket serverSocket;
        private IPAddress ip = IPAddress.Loopback;

        public EchoServerFacade()
        {
            //Sockets

            port = 5000;
            serverName = "Echo Server";
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Connect(new IPEndPoint(ip, port));

            //Tcp

            //port = 5000;
            //serverName = "Echo Server";
            //client = new TcpClient("localhost", port);
            //netStream = client.GetStream();
            //reader = new StreamReader(netStream);
            //writer = new StreamWriter(netStream);
            //writer.AutoFlush = true;
        }

        private void Close()
        {
            serverSocket.Close();
        }

        public void Dispose()
        {
            serverSocket.Dispose();
        }

        public string Echo(string[] words)
        {
            //Sockets

            try
            {
                SendToServer(words[0] + " " + words[1]);
                string str = ReceiveFromServer();
                int i = str.IndexOf('\0');
                str = str.Substring(0, i);
                return str;
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //Tcp

            //try
            //{
            //    writer.WriteLine(words[0] + " " + words[1]);
            //    string str = reader.ReadLine();
            //    return str;
            //}
            //catch (Exception e)
            //{
            //    return e.Message;
            //}
        }

        public string EchoUpper(string[] words)
        {
            //Sockets

            try
            {
                SendToServer(words[0] + " " + words[1]);
                string str = ReceiveFromServer();
                int i = str.IndexOf('\0');
                str = str.Substring(0, i);
                return str;
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //Tcp

            //try
            //{
            //    writer.WriteLine(words[0] + " " + words[1]);
            //    string str = reader.ReadLine();
            //    return str;
            //}
            //catch (Exception e)
            //{
            //    return e.Message;
            //}
        }

        private void Open()
        {
            throw new NotImplementedException();
        }

        private string ReceiveFromServer()
        {
            byte[] retMsg = new byte[1024];
            serverSocket.Receive(retMsg);
            string str = Encoding.ASCII.GetString(retMsg);
            return str;
        }

        private void SendToServer(string word)
        {
            byte[] msg = Encoding.ASCII.GetBytes(word);
            serverSocket.Send(msg);
        }
    }
}
