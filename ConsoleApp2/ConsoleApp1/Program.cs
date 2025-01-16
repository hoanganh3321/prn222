using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
     class Program
    {
        static void ConnectServer(string host, int port)
        {
            UdpClient client = new UdpClient();
            IPAddress address = IPAddress.Parse(host);
            IPEndPoint remoteEndPoint = new IPEndPoint(address, port);
            string message;
            int count = 0;
            bool done = false;
            Console.Title = "UDP client";
            try
            {
                Console.WriteLine(new string('*', 40));
                client.Connect(remoteEndPoint);
                while (!done)
                {
                    message = $"message {++count:D2}";
                    byte[] sendByte = Encoding.ASCII.GetBytes(message);
                    client.Send(sendByte, sendByte.Length);
                    Console.WriteLine($"sent:{message}");
                    Thread.Sleep(2000);
                    if (count == 10)
                    {
                        done = true;
                        Console.WriteLine("done");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
                static void Main(string[] args)
                {
                    string host = "127.0.0.1";
                    int port = 11000;
                    ConnectServer(host, port);
                    Console.Read();
                }
    }
    
}
