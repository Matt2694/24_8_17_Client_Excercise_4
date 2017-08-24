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
    class Program
    {
        private static TcpClient client = null;
        private static StreamReader reader = null;
        private static StreamWriter writer = null;
        private EchoServerFacade remoteFacade = null;
        private bool isRunning = true;

        static void Main(string[] args)
        {
            Program client = new Program();
            client.Run();
        }

        private void Run()
        {
            remoteFacade = new EchoServerFacade();
            string output = "";
            while (isRunning)
            {
                string input = Console.ReadLine();
                string[] strArr = input.Split(' ');
                switch (strArr[0])
                {
                    case "Echo":
                    case "echo":
                        output = remoteFacade.Echo(strArr[1]);
                        break;
                    case "EchoUpper":
                    case "echoupper":
                        output = remoteFacade.EchoUpper(strArr[1]);
                        break;
                    case "Exit":
                    case "exit":
                        isRunning = false;
                        remoteFacade.Dispose();
                        break;
                    default:
                        isRunning = false;
                        remoteFacade.Dispose();
                        break;
                }
                Console.WriteLine(output);
            }

            //using Sockets

            //try
            //{
            //    Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //    s.Connect(new IPEndPoint(IPAddress.Loopback, 5000));
            //    while (true)
            //    {
            //        string command = Console.ReadLine();
            //        byte[] msg = Encoding.ASCII.GetBytes(command);
            //        s.Send(msg);
            //        byte[] retMsg = new byte[1024];
            //        s.Receive(retMsg);
            //        string str = Encoding.ASCII.GetString(retMsg);
            //        int i = str.IndexOf('\0');
            //        str = str.Substring(0, i);
            //        Console.WriteLine(str);

            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.ReadKey();
            //}

            //using Tcp

            //client = new TcpClient("localhost", 5000);
            //reader = new StreamReader(client.GetStream());
            //writer = new StreamWriter(client.GetStream());
            //writer.AutoFlush = true;

            //try
            //{
            //    string data = Console.ReadLine();
            //    writer.WriteLine(data);
            //    while (data != null && data != "")
            //    {
            //        data = reader.ReadLine();
            //        Console.WriteLine(data);

            //        data = Console.ReadLine();
            //        writer.WriteLine(data);
            //    }
            //    client.Close();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
        }
    }
}
