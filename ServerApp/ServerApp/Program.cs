
using System.Net;
using System.Net.Sockets;

namespace ServerApp
{
     class Program
    {
        static void ProcessMessage(object parm)
        {
            string data;
            int count;
            try
            {
                TcpClient client = parm as TcpClient;
                byte[] bytes = new Byte[256];
                NetworkStream stream = client.GetStream();
                while ((count = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, count);
                    Console.WriteLine($"Received:{data} at {DateTime.Now:t}");
                    data = $"{data.ToUpper()}";
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine($"Sent:{data}");
                }
                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}", ex.Message);
                Console.WriteLine("waiting message....");
            }
        }

        static void ExecuteServer(string host, int port)
        {
            int count = 0;
            TcpListener server = null;
            try
            {
                Console.Title = "server application";
                IPAddress localAddress = IPAddress.Parse(host);
                server = new TcpListener(localAddress, port);
                server.Start();
                Console.WriteLine(new string('*',40));
                Console.WriteLine("waiting for connection........");
                while(true)
                {
                    TcpClient client =server.AcceptTcpClient();
                    Console.WriteLine($"number of client connected:{++count}");
                    Console.WriteLine(new string('*',40));
                    Thread thread=new Thread(new ParameterizedThreadStart(ProcessMessage));
                    thread.Start(client);
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("exception:{0}",ex.Message);

            }
            finally
            {
                server.Stop();
                Console.WriteLine("server stopped. press any key to exit");
            }
            Console.Read();
        }

        static void Main()
        {
            string host = "127.0.0.1";
            int port = 13000;
            ExecuteServer(host, port);
        }


    }
}
