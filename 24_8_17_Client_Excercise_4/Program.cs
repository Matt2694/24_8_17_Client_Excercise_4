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
                        break;
                    default:
                        isRunning = false;
                        break;
                }
                Console.WriteLine(output);
            }
        }
    }
}
