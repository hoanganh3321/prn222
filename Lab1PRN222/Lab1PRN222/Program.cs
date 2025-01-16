namespace server
{

    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;

    class ServerApp
    {
        static void Main()
        {
           
            string serverIp = "127.0.0.1"; // Localhost
            int port = 8080;

          
            TcpListener listener = new TcpListener(IPAddress.Parse(serverIp), port);

            try
            {
                listener.Start();
                Console.WriteLine($"Server started. Listening on {serverIp}:{port}...");

                while (true)
                {
                  
                    TcpClient client = listener.AcceptTcpClient();
                    Console.WriteLine("Client connected.");

                    
                    NetworkStream stream = client.GetStream();

                  
                    byte[] buffer = new byte[1024];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string receivedData = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received from client: {receivedData}");

                  
                    string responseData = receivedData.ToUpper();

                   
                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseData);
                    stream.Write(responseBytes, 0, responseBytes.Length);
                    Console.WriteLine($"Sent to client: {responseData}");

                    client.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }
    }
}
