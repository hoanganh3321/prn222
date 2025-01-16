namespace Client
{
    using System;
    using System.Net.Sockets;
    using System.Text;

    class ClientApp
    {
        static void Main()
        {

            string serverIp = "127.0.0.1"; // Localhost
            int port = 8080;

            try
            {
                TcpClient client = new TcpClient(serverIp, port);
                Console.WriteLine($"Connected to server at {serverIp}:{port}");


                NetworkStream stream = client.GetStream();


                Console.Write("Enter a message to send to the server: ");
                string message = Console.ReadLine();
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                stream.Write(messageBytes, 0, messageBytes.Length);
                Console.WriteLine($"Sent to server: {message}");


                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received from server: {response}");


                client.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

}