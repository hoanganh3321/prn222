using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     class executeServer
    {
        public static ParameterizedThreadStart ProcessMessage { get; private set; }

        static void ExecuteServer(string host,int port)
        {
            int count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "server application";
                IPAddress localAddr = IPAddress.Parse(host);
                server = new TcpListener(localAddr, port);
                server.Start();
                Console.WriteLine(new string('*', 40));
                Console.WriteLine("waitting for connection");
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine($"number of client connected:{++count}");
                    Console.WriteLine(new string('*', 40));
                    Thread thread = new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start();
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                server.Stop();
                Console.WriteLine("server stoped.press any key to exit");
            }
            Console.Read();
        }
    }
}
