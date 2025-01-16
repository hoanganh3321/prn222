using System.Data;
using System.Net.Sockets;

namespace ConsoleApp1
{
    class Program
    {
        static void connectedServer(string server, int port)
        {
            int bytes;
            string message, responsedData;
            try
            {
                TcpClient tcpClient = new TcpClient(server, port);
                Console.Title = "client application";
                NetworkStream stream = null;
                while (true)
                {
                    Console.WriteLine("input message <press enter to exit> : ");
                    message = Console.ReadLine();
                    if (message == string.Empty)
                    {
                        break;
                    }
                    Byte[] data = System.Text.Encoding.ASCII.GetBytes($"{message}");
                    stream = tcpClient.GetStream();
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine("sent:{0}", message);
                    data = new Byte[256];
                    bytes = stream.Read(data, 0, data.Length);
                    responsedData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("recevied:{0}", responsedData);

                }
                tcpClient.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("exception:{0}", e.Message);
            }

        }
        static void Main(string[] args)
        {
            string server = "127.0.0.1";
            int port = 13000;
            connectedServer(server, port);
        }

    }

}
